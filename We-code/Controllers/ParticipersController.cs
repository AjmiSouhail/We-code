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
    public class ParticipersController : Controller
    {
        private data1Entities1 db = new data1Entities1();

        // GET: Participers
        public ActionResult Index()
        {
            var participers = db.Participers.Include(p => p.Inscription);
            return View(participers.ToList());
        }

        // GET: Participers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participer participer = db.Participers.Find(id);
            if (participer == null)
            {
                return HttpNotFound();
            }
            return View(participer);
        }

        // GET: Participers/Create
        public ActionResult Create()
        {
            ViewBag.InscriptionID = new SelectList(db.Inscriptions, "InscriptionID", "InscriptionID");
            return View();
        }

        // POST: Participers/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscriptionID,Mention,Resultat")] Participer participer)
        {
            if (ModelState.IsValid)
            {
                db.Participers.Add(participer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InscriptionID = new SelectList(db.Inscriptions, "InscriptionID", "InscriptionID", participer.InscriptionID);
            return View(participer);
        }

        // GET: Participers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participer participer = db.Participers.Find(id);
            if (participer == null)
            {
                return HttpNotFound();
            }
            ViewBag.InscriptionID = new SelectList(db.Inscriptions, "InscriptionID", "InscriptionID", participer.InscriptionID);
            return View(participer);
        }

        // POST: Participers/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscriptionID,Mention,Resultat")] Participer participer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InscriptionID = new SelectList(db.Inscriptions, "InscriptionID", "InscriptionID", participer.InscriptionID);
            return View(participer);
        }

        // GET: Participers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participer participer = db.Participers.Find(id);
            if (participer == null)
            {
                return HttpNotFound();
            }
            return View(participer);
        }

        // POST: Participers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participer participer = db.Participers.Find(id);
            db.Participers.Remove(participer);
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
