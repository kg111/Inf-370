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
    public class LicenseTypeController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: LicenseType
        public ActionResult Index()
        {
            return View(db.LicenseTypes.ToList());
        }

        // GET: LicenseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseType licenseType = db.LicenseTypes.Find(id);
            if (licenseType == null)
            {
                return HttpNotFound();
            }
            return View(licenseType);
        }

        // GET: LicenseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LicenseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LicenseTypeID,LicenseTypeDescription")] LicenseType licenseType)
        {
            if (ModelState.IsValid)
            {
                db.LicenseTypes.Add(licenseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(licenseType);
        }

        // GET: LicenseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseType licenseType = db.LicenseTypes.Find(id);
            if (licenseType == null)
            {
                return HttpNotFound();
            }
            return View(licenseType);
        }

        // POST: LicenseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LicenseTypeID,LicenseTypeDescription")] LicenseType licenseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(licenseType);
        }

        // GET: LicenseType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseType licenseType = db.LicenseTypes.Find(id);
            if (licenseType == null)
            {
                return HttpNotFound();
            }
            return View(licenseType);
        }

        // POST: LicenseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicenseType licenseType = db.LicenseTypes.Find(id);
            db.LicenseTypes.Remove(licenseType);
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
