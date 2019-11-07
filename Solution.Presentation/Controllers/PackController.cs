using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class PackController : Controller
    {

            IPackService service = null;

            public PackController()
            {
                service = new PackService();
            }

            // GET: Pack
            public ActionResult Index()
            {
                var packs = new List<PackVM>();


                foreach (Pack item in service.GetMany())
                {
                    packs.Add(new PackVM()
                    {
                        TypePack = item.TypePack,
                        PackName = item.PackName,
                        Description = item.Description,
                        Quantity = item.Quantity,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        PackId = item.PackId,
                    });
                }

                return View(packs);
            }

            // GET: Pack/Details/5
            public ActionResult Details(int id)
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Pack p = service.GetById(id);
                PackVM p1 = new PackVM()
                {
                    TypePack = p.TypePack,
                    PackName = p.PackName,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    PackId = p.PackId,


                };
                if (p == null)
                    return HttpNotFound();

                return View(p1);
            }

            // GET: Pack/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Pack/Create
            [HttpPost]
            public ActionResult Create(PackVM ovm)
            {
                Pack p = new Pack()
                {
                    TypePack = ovm.TypePack,
                    PackName = ovm.PackName,
                    Description = ovm.Description,
                    Quantity = ovm.Quantity,
                    StartDate = ovm.StartDate,
                    EndDate = ovm.EndDate,
                };
                service.Add(p);
                service.Commit();
                //service.Dispose();
                return RedirectToAction("Index");
            }

            // GET: Pack/Edit/5
            public ActionResult Edit(int id)
            {
                if (id == null)

                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Pack p = service.GetById(id);
                PackVM p1 = new PackVM()
                {
                    Description = p.Description,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    PackName = p.PackName,
                    TypePack = p.TypePack,
                    Quantity = p.Quantity

                };
                if (p == null)
                    return HttpNotFound();
                return View(p1);
            }

            // POST: Pack/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, PackVM ovm)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (id == null)
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        Pack p = service.GetById(id);

                        p.Description = ovm.Description;
                        p.EndDate = ovm.EndDate;
                        p.StartDate = ovm.StartDate;
                        p.PackName = ovm.PackName;
                        p.TypePack = ovm.TypePack;
                        p.Quantity = ovm.Quantity;

                    //ss
                        if (p == null)
                            return HttpNotFound();

                        service.Update(p);
                        service.Commit();
                        // Service.Dispose();

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


            // GET: Pack/Delete/5
            public ActionResult Delete(int id)
            {
                if (id == null)

                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Pack p = service.GetById(id);
                PackVM p1 = new PackVM()
                {
                    Description = p.Description,
                    EndDate = p.EndDate,
                    StartDate = p.StartDate,
                    PackName = p.PackName,
                    TypePack = p.TypePack,
                    Quantity = p.Quantity

                };
                if (p == null)
                    return HttpNotFound();
                return View(p1);
            }

            // POST: Pack/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, PackVM aftervm)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (id == null)

                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        Pack p = service.GetById(id);
                        PackVM p1 = new PackVM()
                        {
                            Description = p.Description,
                            EndDate = p.EndDate,
                            StartDate = p.StartDate,
                            PackName = p.PackName,
                            TypePack = p.TypePack,
                            Quantity = p.Quantity

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
        }
    }