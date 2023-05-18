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
    public class EmployesController : Controller
    {
        private data1Entities1 db = new data1Entities1();

        // GET: Employes
        public ActionResult Index()
        {
            return View(db.Employes.ToList());
        }

        // GET: Employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: Employes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeID,LastName,FirstName,DateBirth")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Employes.Add(employe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employe);
        }

        // GET: Employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeID,LastName,FirstName,DateBirth")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        // GET: Employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employe employe = db.Employes.Find(id);
            db.Employes.Remove(employe);
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
