using Microsoft.Owin.Security.Twitter.Messages;
using PagedList;
using PagedList.Mvc;
using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{



    public  class OfferController : Controller
    {

        IOfferService service = null;
        public OfferController()
        {
            service = new OfferService();
        }

     

        public ActionResult Index_shop(string SearchString, string date, int? i)
        {
            var offers = new List<OfferVm>();


            foreach (Offer item in service.GetOfferssearch(SearchString, date))
            {
                offers.Add(new OfferVm()
                {
                    Id = item.OfferId,
                    OfferName = item.OfferName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Description = item.Description,
                    ImgUrl = item.ImgUrl,
                    ProductId = item.ProductId,
                    Price = item.Price,

                });
            }


            return View(offers.ToPagedList(i ?? 1, 9));
        }


        // GET: Offer
        public ActionResult Index(string SearchString,string date,int? i)
        {


           
            var offers = new List<OfferVm>();


            foreach (Offer item in service.GetOfferssearch(SearchString,date))
            {
                offers.Add(new OfferVm()
                {
                    Id = item.OfferId,
                    OfferName = item.OfferName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Description = item.Description,
                    ImgUrl = item.ImgUrl,
                    ProductId = item.ProductId,
                    Price = item.Price,

                });
            }
            

            return View(offers.ToPagedList(i?? 1,9));
        }                                                                                                                                                                   

        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
        
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Offer p = service.GetById(id);
            OfferVm p1 = new OfferVm()
            {
                Description = p.Description,
                OfferName = p.OfferName,
                Price = p.Price,

                EndDate = p.EndDate,
                StartDate = p.StartDate,
                ImgUrl = p.ImgUrl,


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);


        }

        // GET: Offer/Create
        public ActionResult Create()
        {


            OfferService ps = new OfferService();
            var Producers = ps.GetTtireId();
            ViewBag.myproducts =
            new SelectList(Producers, "ProductId", "Title");



         

            return View();

        }

        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(OfferVm ovm, HttpPostedFileBase file)
        {


            if (
              file == null ||
              file.ContentLength == 0)
            {
                return RedirectToAction("Create");
            }


            Offer offerdomain = new Offer()
            {
                StartDate = ovm.StartDate,
                OfferName = ovm.OfferName,
                Price = ovm.Price,
                EndDate = ovm.EndDate,
                ProductId = ovm.ProductId,
                Description = ovm.Description,
                ImgUrl = file.FileName,

            };
                service.Add(offerdomain);
                service.Commit();


                var path = "";
                //ajout d'image sous dossier
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    path = Path.
                       Combine(Server.MapPath("~/Content/Uploads/"),
                       fileName);
                    file.SaveAs(path);
                }
                var path2 = path;
                return RedirectToAction("Index");

        


        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Offer p = service.GetById(id);
            OfferVm p1 = new OfferVm()
            {
                Description = p.Description,
                OfferName = p.OfferName,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                ImgUrl = p.ImgUrl,
                ProductId= p.ProductId,
                Price = p.Price,

            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }


        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OfferVm ovm, HttpPostedFileBase file)
        {

            var allowedExtensions = new string[] { ".jpeg", ".png", ".jpg" };
            string extension = Path.GetExtension(file.FileName);

            try
            {
                
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


                    //ajout d'image sous dossier
                    var fileName = "";
                    if (file.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        var path = Path.
                           Combine(Server.MapPath("~/Content/Uploads/"),
                           fileName);
                        file.SaveAs(path);
                    }
                    Offer p = service.GetById(id);

                    p.Description = ovm.Description;
                    p.EndDate = ovm.EndDate;
                    p.OfferName = ovm.OfferName;
                    p.StartDate = ovm.StartDate;
                    p.ImgUrl = file.FileName;
                    p.Price = ovm.Price;

                    

                    if (p == null)
                        return HttpNotFound();
                    if (allowedExtensions.Contains(extension))
                    {


                        service.Update(p);
                        service.Commit();
                        // Service.Dispose();

                        return RedirectToAction("Index");
                    }else
                    {
                        return RedirectToAction("Edit");


                    }

                
                // TODO: Add delete logic here
                return View(ovm);

            }
            catch
            {
                return View();
            }
        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Offer p = service.GetById(id);
            OfferVm p1 = new OfferVm()
            {
                Description = p.Description,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                ImgUrl = p.ImgUrl,
                OfferName = p.OfferName,
                Price = p.Price,


            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }

        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OfferVm aftervm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Offer p = service.GetById(id);
                    OfferVm p1 = new OfferVm()
                    {
                        Description = p.Description,
                        EndDate = p.EndDate,
                        StartDate = p.StartDate,
                        ImgUrl = p.ImgUrl,
                        OfferName = p.OfferName,
                        Price = p.Price,


                    };
                    if (p == null)
                        return HttpNotFound();
                    service.Delete(p);
                    service.Commit();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(aftervm);

            }
            catch
            {
                return View();
            }
        }

        // : jsonClassList/5
        public JsonResult jsonClassList(string name)
        {
            var classes = service.Getofferbyname(name);
            return Json(classes , JsonRequestBehavior.AllowGet);
        }


    }
}
