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
    public class AuditTrailController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: AuditTrail
        public ActionResult Index()
        {
            return View(db.AuditTrails.ToList());
        }

        // GET: AuditTrail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditTrail auditTrail = db.AuditTrails.Find(id);
            if (auditTrail == null)
            {
                return HttpNotFound();
            }
            return View(auditTrail);
        }

        // GET: AuditTrail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuditTrail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuditTrailID,AuditTrailDate,AuditTrailTime")] AuditTrail auditTrail)
        {
            if (ModelState.IsValid)
            {
                db.AuditTrails.Add(auditTrail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auditTrail);
        }

        // GET: AuditTrail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditTrail auditTrail = db.AuditTrails.Find(id);
            if (auditTrail == null)
            {
                return HttpNotFound();
            }
            return View(auditTrail);
        }

        // POST: AuditTrail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuditTrailID,AuditTrailDate,AuditTrailTime")] AuditTrail auditTrail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditTrail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auditTrail);
        }

        // GET: AuditTrail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditTrail auditTrail = db.AuditTrails.Find(id);
            if (auditTrail == null)
            {
                return HttpNotFound();
            }
            return View(auditTrail);
        }

        // POST: AuditTrail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuditTrail auditTrail = db.AuditTrails.Find(id);
            db.AuditTrails.Remove(auditTrail);
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
