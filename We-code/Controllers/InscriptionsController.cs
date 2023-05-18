using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using We_code.Models;

namespace We_code.Controllers
{
    public class InscriptionsController : Controller
    {
        private data1Entities1 db = new data1Entities1();

        // GET: Inscriptions
        public ActionResult Index()
        {
            var inscriptions = db.Inscriptions.Include(i => i.Employe).Include(i => i.Formation).Include(i => i.Participer);
            return View(inscriptions.ToList());
        }

        // GET: Inscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // GET: Inscriptions/Create
        public ActionResult Create()
        {
            ViewBag.EmployeID = new SelectList(db.Employes, "EmployeID", "LastName");
            ViewBag.FormationID = new SelectList(db.Formations, "FormationID", "NomFormation");
            ViewBag.InscriptionID = new SelectList(db.Participers, "InscriptionID", "Mention");
            return View();
        }

        // POST: Inscriptions/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscriptionID,FormationID,EmployeID,DateInscription")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                db.Inscriptions.Add(inscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeID = new SelectList(db.Employes, "EmployeID", "LastName", inscription.EmployeID);
            ViewBag.FormationID = new SelectList(db.Formations, "FormationID", "NomFormation", inscription.FormationID);
            ViewBag.InscriptionID = new SelectList(db.Participers, "InscriptionID", "Mention", inscription.InscriptionID);
            return View(inscription);
        }

        // GET: Inscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeID = new SelectList(db.Employes, "EmployeID", "LastName", inscription.EmployeID);
            ViewBag.FormationID = new SelectList(db.Formations, "FormationID", "NomFormation", inscription.FormationID);
            ViewBag.InscriptionID = new SelectList(db.Participers, "InscriptionID", "Mention", inscription.InscriptionID);
            return View(inscription);
        }

        // POST: Inscriptions/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscriptionID,FormationID,EmployeID,DateInscription")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeID = new SelectList(db.Employes, "EmployeID", "LastName", inscription.EmployeID);
            ViewBag.FormationID = new SelectList(db.Formations, "FormationID", "NomFormation", inscription.FormationID);
            ViewBag.InscriptionID = new SelectList(db.Participers, "InscriptionID", "Mention", inscription.InscriptionID);
            return View(inscription);
        }

        // GET: Inscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscription inscription = db.Inscriptions.Find(id);
            db.Inscriptions.Remove(inscription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
