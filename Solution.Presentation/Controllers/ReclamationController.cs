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
    public class ReclamationController : Controller
    {
        IreclamationService service = null;

        public ReclamationController()
        {
            service = new reclamationService();
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
                    contenu = item.contenu,
                    type = item.type,
                    etat = item.etat


    });
            }

            return View(reclamations);
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(ReclamationVm rvm)
        {
            reclamation reclamationdomain = new reclamation()
            {
                Idrec = rvm.Idrec,
               titre = rvm.titre,
                date = rvm.date,
                objet = rvm.objet,
                contenu = rvm.contenu,
                type = rvm.type,
                etat = rvm.etat


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
                type=p.type

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
                        type = p.type


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
