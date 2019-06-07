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
    public class VehicleGroupController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: VehicleGroup
        public ActionResult Index()
        {
            return View(db.VehicleGroups.ToList());
        }

        // GET: VehicleGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGroup vehicleGroup = db.VehicleGroups.Find(id);
            if (vehicleGroup == null)
            {
                return HttpNotFound();
            }
            return View(vehicleGroup);
        }

        // GET: VehicleGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleGroupID,VehicleGroupDescription")] VehicleGroup vehicleGroup)
        {
            if (ModelState.IsValid)
            {
                db.VehicleGroups.Add(vehicleGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleGroup);
        }

        // GET: VehicleGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGroup vehicleGroup = db.VehicleGroups.Find(id);
            if (vehicleGroup == null)
            {
                return HttpNotFound();
            }
            return View(vehicleGroup);
        }

        // POST: VehicleGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleGroupID,VehicleGroupDescription")] VehicleGroup vehicleGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleGroup);
        }

        // GET: VehicleGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGroup vehicleGroup = db.VehicleGroups.Find(id);
            if (vehicleGroup == null)
            {
                return HttpNotFound();
            }
            return View(vehicleGroup);
        }

        // POST: VehicleGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleGroup vehicleGroup = db.VehicleGroups.Find(id);
            db.VehicleGroups.Remove(vehicleGroup);
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
