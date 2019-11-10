using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class OrderController : Controller
    {
        IOrderService Service = null;
        public OrderController()
        {
            Service = new OrderService();
        }
        // GET: Order
        public ActionResult Index()
        {
            var orders = new List<OrderVm>();
            foreach (Order ordo in Service.GetMany())
            {
                orders.Add(new OrderVm()

                {
                    OrderDate = DateTime.Now,
                    ProductId = ordo.ProductId, 
                    ProductQuantity = ordo.ProductQuantity,
                    UserId = 1,
                    ProductName = ordo.Product.Name,
                    Price = ordo.Product.Price
                });
            }


            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id, int idu)
        {
            Order b = Service.getbyids(id,idu);
            OrderVm bvm = new OrderVm()
            {
                //CodeBungalow =b.CodeBungalow,
                OrderDate = b.OrderDate,
                ProductName = b.Product.Name,
                ProductQuantity = b.ProductQuantity,
                Price = b.Product.Price
            };
            return View(bvm);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderVm ovm, int id)
        {

            Order Orderdomain = new Order()
            {

                OrderDate = DateTime.Now,
                ProductId = id,
                UserId = 1,
                ProductQuantity = ovm.ProductQuantity

            };

            Service.Add(Orderdomain);
            Service.Commit();
            //Service.Dispose();
            return RedirectToAction("Index");

            //Order or = new Order()
            //{
            //    OrderDate = DateTime.Now,
            //    ProductId = idProduct,
            //    UserId = 1,
            //    ProductQuantity = ovm.ProductQuantity
            //};

            //Service.Add(or);
            //Service.Commit();

        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id, int idu)
        {

            Order p = Service.getbyids(id, idu);
            OrderVm p1 = new OrderVm()
            {
                ProductId = p.ProductId,
                UserId = p.UserId



            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }
        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, int idu, OrderVm ovm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Order p = Service.getbyids(id,idu);
                    p.ProductQuantity = ovm.ProductQuantity;


                    if (p == null)
                        return HttpNotFound();

                    Service.Update(p);
                    Service.Commit();
                   Service.Dispose();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(ovm);

            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id, int idu)
        {
            //if (id == null)

            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //Order p = Service.getbyids(id, idu);
            //OrderVm p1 = new OrderVm()
            //{
            //      OrderDate = p.OrderDate,
            //      ProductQuantity = p.ProductQuantity, 
            //      ProductId = p.ProductId,
            //      UserId = p.UserId

            //    // type=p.type

            //};
            //if (p == null)
            //    return HttpNotFound();
            //return View(p1);
            Service.Delete(x => x.ProductId==id && x.UserId == idu);
            Service.Commit();
           return RedirectToAction("Index");

        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int idu, OrderVm ovm)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Order p = Service.getbyids(id, idu);
                    
                    if (p == null)
                        return HttpNotFound();
                    Service.Delete(p);
                    Service.Commit();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(ovm);

            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetOrders()
        {
            var orders = new List<OrderVm>();
            foreach (Order ordo in Service.GetMany())
            {
                orders.Add(new OrderVm()

                {
                    OrderDate = DateTime.Now,
                    ProductId = ordo.ProductId,
                    ProductQuantity = ordo.ProductQuantity,
                    UserId = 1,
                    ProductName = ordo.Product.Name,
                    Price = ordo.Product.Price
                });
            }
            return View(orders);
        }

        public ActionResult ExportPDF()
        {
            return new ActionAsPdf("GetOrders")
            {
                FileName = Server.MapPath("~Content/Invoice.pdf")
            };
        }
    }
}
