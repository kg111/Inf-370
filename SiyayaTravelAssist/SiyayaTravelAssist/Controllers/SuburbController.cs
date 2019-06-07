using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiyayaTravelAssist.Models;

namespace SiyayaTravelAssist.Controllers
{
    public class SuburbController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: Suburb
        public ActionResult Index()
        {
            return View(db.Suburbs.ToList());
        }

        // GET: Suburb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return HttpNotFound();
            }
            return View(suburb);
        }

        // GET: Suburb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suburb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuburbID,SuburbDescription")] Suburb suburb)
        {
            if (ModelState.IsValid)
            {
                db.Suburbs.Add(suburb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suburb);
        }

        // GET: Suburb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return HttpNotFound();
            }
            return View(suburb);
        }

        // POST: Suburb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuburbID,SuburbDescription")] Suburb suburb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suburb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suburb);
        }

        // GET: Suburb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return HttpNotFound();
            }
            return View(suburb);
        }

        // POST: Suburb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suburb suburb = db.Suburbs.Find(id);
            db.Suburbs.Remove(suburb);
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
