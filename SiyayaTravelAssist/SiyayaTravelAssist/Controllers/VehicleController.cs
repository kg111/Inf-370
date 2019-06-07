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
    public class VehicleController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: Vehicle
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.OutsourceVehicleGroupCompany).Include(v => v.VehicleBrandType).Include(v => v.VehicleColor).Include(v => v.VehicleGroup).Include(v => v.VehicleType);
            return View(vehicles.ToList());
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.OutsourceVehicleGroupCompaniesID = new SelectList(db.OutsourceVehicleGroupCompanies, "OutsourceVehicleGroupCompaniesID", "OutsourceVehicleGroupCompaniesDescription");
            ViewBag.VehicleBrandTypeID = new SelectList(db.VehicleBrandTypes, "VehicleBrandTypeID", "VehicleBrandTypeDescription");
            ViewBag.VehicleColorID = new SelectList(db.VehicleColors, "VehicleColorID", "VehicleColorDescription");
            ViewBag.VehicleGroupID = new SelectList(db.VehicleGroups, "VehicleGroupID", "VehicleGroupDescription");
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", "VehicleTypeDescription");
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleID,VehicleLicenseNumber,VehicleBrandTypeID,VehicleColorID,VehicleGroupID,VehicleTypeID,OutsourceVehicleGroupCompaniesID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OutsourceVehicleGroupCompaniesID = new SelectList(db.OutsourceVehicleGroupCompanies, "OutsourceVehicleGroupCompaniesID", "OutsourceVehicleGroupCompaniesDescription", vehicle.OutsourceVehicleGroupCompaniesID);
            ViewBag.VehicleBrandTypeID = new SelectList(db.VehicleBrandTypes, "VehicleBrandTypeID", "VehicleBrandTypeDescription", vehicle.VehicleBrandTypeID);
            ViewBag.VehicleColorID = new SelectList(db.VehicleColors, "VehicleColorID", "VehicleColorDescription", vehicle.VehicleColorID);
            ViewBag.VehicleGroupID = new SelectList(db.VehicleGroups, "VehicleGroupID", "VehicleGroupDescription", vehicle.VehicleGroupID);
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", "VehicleTypeDescription", vehicle.VehicleTypeID);
            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.OutsourceVehicleGroupCompaniesID = new SelectList(db.OutsourceVehicleGroupCompanies, "OutsourceVehicleGroupCompaniesID", "OutsourceVehicleGroupCompaniesDescription", vehicle.OutsourceVehicleGroupCompaniesID);
            ViewBag.VehicleBrandTypeID = new SelectList(db.VehicleBrandTypes, "VehicleBrandTypeID", "VehicleBrandTypeDescription", vehicle.VehicleBrandTypeID);
            ViewBag.VehicleColorID = new SelectList(db.VehicleColors, "VehicleColorID", "VehicleColorDescription", vehicle.VehicleColorID);
            ViewBag.VehicleGroupID = new SelectList(db.VehicleGroups, "VehicleGroupID", "VehicleGroupDescription", vehicle.VehicleGroupID);
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", "VehicleTypeDescription", vehicle.VehicleTypeID);
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleID,VehicleLicenseNumber,VehicleBrandTypeID,VehicleColorID,VehicleGroupID,VehicleTypeID,OutsourceVehicleGroupCompaniesID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OutsourceVehicleGroupCompaniesID = new SelectList(db.OutsourceVehicleGroupCompanies, "OutsourceVehicleGroupCompaniesID", "OutsourceVehicleGroupCompaniesDescription", vehicle.OutsourceVehicleGroupCompaniesID);
            ViewBag.VehicleBrandTypeID = new SelectList(db.VehicleBrandTypes, "VehicleBrandTypeID", "VehicleBrandTypeDescription", vehicle.VehicleBrandTypeID);
            ViewBag.VehicleColorID = new SelectList(db.VehicleColors, "VehicleColorID", "VehicleColorDescription", vehicle.VehicleColorID);
            ViewBag.VehicleGroupID = new SelectList(db.VehicleGroups, "VehicleGroupID", "VehicleGroupDescription", vehicle.VehicleGroupID);
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", "VehicleTypeDescription", vehicle.VehicleTypeID);
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
