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
    public class VehicleMaintenanceController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: VehicleMaintenance
        public ActionResult Index()
        {
            var vehicleMaintenances = db.VehicleMaintenances.Include(v => v.ServiceProvider).Include(v => v.Vehicle);
            return View(vehicleMaintenances.ToList());
        }

        // GET: VehicleMaintenance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMaintenance vehicleMaintenance = db.VehicleMaintenances.Find(id);
            if (vehicleMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMaintenance);
        }

        // GET: VehicleMaintenance/Create
        public ActionResult Create()
        {
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleLicenseNumber");
            return View();
        }

        // POST: VehicleMaintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleMaintenanceID,KmToMaintenance,MaintenanceStatus,MaintenanceDate,VehicleID,ServiceProviderID")] VehicleMaintenance vehicleMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.VehicleMaintenances.Add(vehicleMaintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName", vehicleMaintenance.ServiceProviderID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleLicenseNumber", vehicleMaintenance.VehicleID);
            return View(vehicleMaintenance);
        }

        // GET: VehicleMaintenance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMaintenance vehicleMaintenance = db.VehicleMaintenances.Find(id);
            if (vehicleMaintenance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName", vehicleMaintenance.ServiceProviderID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleLicenseNumber", vehicleMaintenance.VehicleID);
            return View(vehicleMaintenance);
        }

        // POST: VehicleMaintenance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleMaintenanceID,KmToMaintenance,MaintenanceStatus,MaintenanceDate,VehicleID,ServiceProviderID")] VehicleMaintenance vehicleMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleMaintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName", vehicleMaintenance.ServiceProviderID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleLicenseNumber", vehicleMaintenance.VehicleID);
            return View(vehicleMaintenance);
        }

        // GET: VehicleMaintenance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMaintenance vehicleMaintenance = db.VehicleMaintenances.Find(id);
            if (vehicleMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMaintenance);
        }

        // POST: VehicleMaintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleMaintenance vehicleMaintenance = db.VehicleMaintenances.Find(id);
            db.VehicleMaintenances.Remove(vehicleMaintenance);
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
