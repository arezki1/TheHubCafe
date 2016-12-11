using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheHubCafe.Models;
using TheHubCafe.Models;

namespace TheHubCafe.Controllers
{
    public class PastasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pastas
        public ActionResult Index()
        {
            return View(db.Pastas.ToList());
        }

        // GET: Pastas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasta pasta = db.Pastas.Find(id);
            if (pasta == null)
            {
                return HttpNotFound();
            }
            return View(pasta);
        }

        // GET: Pastas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pastas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Size,ingredients,OrderDate")] Pasta pasta)
        {
            if (ModelState.IsValid)
            {
                db.Pastas.Add(pasta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pasta);
        }

        // GET: Pastas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasta pasta = db.Pastas.Find(id);
            if (pasta == null)
            {
                return HttpNotFound();
            }
            return View(pasta);
        }

        // POST: Pastas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Size,ingredients,OrderDate")] Pasta pasta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pasta);
        }

        // GET: Pastas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasta pasta = db.Pastas.Find(id);
            if (pasta == null)
            {
                return HttpNotFound();
            }
            return View(pasta);
        }

        // POST: Pastas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pasta pasta = db.Pastas.Find(id);
            db.Pastas.Remove(pasta);
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
