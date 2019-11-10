using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class ReclamationController : Controller
    {
        IreclamationService service = null;
        IProductService serviceProd = null;

        public ReclamationController()
        {
            service = new reclamationService();
            serviceProd = new ProductService();
        }
        // GET: Reclamation
        public ActionResult Index(string SearchString, string date)
        {
            var reclamations = new List<ReclamationVm>();


            foreach (reclamation item in service.GetReclamationsearch(SearchString, date))
            {
                reclamations.Add(new ReclamationVm()
                {
                    Idrec = item.Idrec,
                    titre = item.titre,
                    date = item.date,
                    objet = item.objet,
                    ImageURL = item.ImageURL,
                    contenu = item.contenu,
                   // type = item.type,
                    etat = item.etat,
                    


                });
            }

            return View(reclamations);
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            reclamation p = service.GetById(id);
            ReclamationVm p1 = new ReclamationVm()
            {
                titre = p.titre,
                date = p.date,              
                objet = p.objet,
                contenu = p.contenu,
                etat = p.etat,
                

                
            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            //viewback faiblement Typer
            var Products = serviceProd.GetMany();
            ViewBag.myproduct = new SelectList(Products, "ProductId", "Title");
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(ReclamationVm rvm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.
                    Combine(Server.MapPath("~/Content/Upload/"),
                    fileName);
                file.SaveAs(path);
            }
            reclamation reclamationdomain = new reclamation()
            {
               
               titre = rvm.titre,
                date = rvm.date,
                objet = rvm.objet,
                contenu = rvm.contenu,
                type = (Domain.Entities.typevm)rvm.type,
                ImageURL = fileName,
                etat = rvm.etat,
                ProductId = rvm.ProductId

            };
            service.Add(reclamationdomain);
            service.Commit();

           


            return RedirectToAction("Index");
        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            reclamation p = service.GetById(id);
            ReclamationVm p1 = new ReclamationVm()
            {
                titre = p.titre,
                date = p.date,
                objet = p.objet,
                contenu = p.contenu,
                

            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }


        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReclamationVm ovm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    reclamation p = service.GetById(id);

                    p.titre = ovm.titre;
                    p.date = ovm.date;
                    p.objet = ovm.objet;
                    p.contenu = ovm.contenu;


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

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            reclamation p = service.GetById(id);
            ReclamationVm p1 = new ReclamationVm()
            {
                Idrec = p.Idrec,
                titre = p.titre,
                contenu = p.contenu,
                objet = p.objet,
                date = p.date,
                etat= p.etat,
               // type=p.type

            };
            if (p == null)
                return HttpNotFound();
            return View(p1);
        }

        // POST: Reclamation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ReclamationVm recv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    reclamation p = service.GetById(id);
                    ReclamationVm p1 = new ReclamationVm()
                    {
                        Idrec = p.Idrec,
                         titre = p.titre,
                        contenu = p.contenu,
                        objet = p.objet,
                        date = p.date,
                        etat = p.etat,
                       // type = p.type


                    };
                    if (p == null)
                        return HttpNotFound();
                    service.Delete(p);
                    service.Commit();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(recv);

            }
            catch
            {
                return View();
            }
        }
    }
}
