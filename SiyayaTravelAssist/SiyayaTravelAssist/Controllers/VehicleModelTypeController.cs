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
    public class VehicleModelTypeController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: VehicleModelType
        public ActionResult Index()
        {
            return View(db.VehicleModelTypes.ToList());
        }

        // GET: VehicleModelType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelType vehicleModelType = db.VehicleModelTypes.Find(id);
            if (vehicleModelType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModelType);
        }

        // GET: VehicleModelType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleModelType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleModelTypeID,VehicleModelTypeDescription")] VehicleModelType vehicleModelType)
        {
            if (ModelState.IsValid)
            {
                db.VehicleModelTypes.Add(vehicleModelType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleModelType);
        }

        // GET: VehicleModelType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelType vehicleModelType = db.VehicleModelTypes.Find(id);
            if (vehicleModelType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModelType);
        }

        // POST: VehicleModelType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleModelTypeID,VehicleModelTypeDescription")] VehicleModelType vehicleModelType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleModelType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleModelType);
        }

        // GET: VehicleModelType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelType vehicleModelType = db.VehicleModelTypes.Find(id);
            if (vehicleModelType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModelType);
        }

        // POST: VehicleModelType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleModelType vehicleModelType = db.VehicleModelTypes.Find(id);
            db.VehicleModelTypes.Remove(vehicleModelType);
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
