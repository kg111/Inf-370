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
    public class VehicleColorController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: VehicleColor
        public ActionResult Index()
        {
            return View(db.VehicleColors.ToList());
        }

        // GET: VehicleColor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleColor vehicleColor = db.VehicleColors.Find(id);
            if (vehicleColor == null)
            {
                return HttpNotFound();
            }
            return View(vehicleColor);
        }

        // GET: VehicleColor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleColor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleColorID,VehicleColorDescription")] VehicleColor vehicleColor)
        {
            if (ModelState.IsValid)
            {
                db.VehicleColors.Add(vehicleColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleColor);
        }

        // GET: VehicleColor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleColor vehicleColor = db.VehicleColors.Find(id);
            if (vehicleColor == null)
            {
                return HttpNotFound();
            }
            return View(vehicleColor);
        }

        // POST: VehicleColor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleColorID,VehicleColorDescription")] VehicleColor vehicleColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleColor);
        }

        // GET: VehicleColor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleColor vehicleColor = db.VehicleColors.Find(id);
            if (vehicleColor == null)
            {
                return HttpNotFound();
            }
            return View(vehicleColor);
        }

        // POST: VehicleColor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleColor vehicleColor = db.VehicleColors.Find(id);
            db.VehicleColors.Remove(vehicleColor);
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
