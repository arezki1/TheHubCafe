using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheHubCafe.Models;

namespace TheHubCafe.Controllers
{
    public class SaladsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Salads
        public ActionResult Index()
        {
            return View(db.Salads.ToList());
        }

        // GET: Salads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salad salad = db.Salads.Find(id);
            if (salad == null)
            {
                return HttpNotFound();
            }
            return View(salad);
        }

        // GET: Salads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Size,ingredients,OrderDate")] Salad salad)
        {
            if (ModelState.IsValid)
            {
                db.Salads.Add(salad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salad);
        }

        // GET: Salads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salad salad = db.Salads.Find(id);
            if (salad == null)
            {
                return HttpNotFound();
            }
            return View(salad);
        }

        // POST: Salads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Size,ingredients,OrderDate")] Salad salad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salad);
        }

        // GET: Salads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salad salad = db.Salads.Find(id);
            if (salad == null)
            {
                return HttpNotFound();
            }
            return View(salad);
        }

        // POST: Salads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salad salad = db.Salads.Find(id);
            db.Salads.Remove(salad);
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
