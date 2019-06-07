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
    public class VehicleBrandTypeController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: VehicleBrandType
        public ActionResult Index()
        {
            var vehicleBrandTypes = db.VehicleBrandTypes.Include(v => v.VehicleModelType);
            return View(vehicleBrandTypes.ToList());
        }

        // GET: VehicleBrandType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBrandType vehicleBrandType = db.VehicleBrandTypes.Find(id);
            if (vehicleBrandType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBrandType);
        }

        // GET: VehicleBrandType/Create
        public ActionResult Create()
        {
            ViewBag.VehicleModelTypeID = new SelectList(db.VehicleModelTypes, "VehicleModelTypeID", "VehicleModelTypeDescription");
            return View();
        }

        // POST: VehicleBrandType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleBrandTypeID,VehicleBrandTypeDescription,VehicleModelTypeID")] VehicleBrandType vehicleBrandType)
        {
            if (ModelState.IsValid)
            {
                db.VehicleBrandTypes.Add(vehicleBrandType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleModelTypeID = new SelectList(db.VehicleModelTypes, "VehicleModelTypeID", "VehicleModelTypeDescription", vehicleBrandType.VehicleModelTypeID);
            return View(vehicleBrandType);
        }

        // GET: VehicleBrandType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBrandType vehicleBrandType = db.VehicleBrandTypes.Find(id);
            if (vehicleBrandType == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleModelTypeID = new SelectList(db.VehicleModelTypes, "VehicleModelTypeID", "VehicleModelTypeDescription", vehicleBrandType.VehicleModelTypeID);
            return View(vehicleBrandType);
        }

        // POST: VehicleBrandType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleBrandTypeID,VehicleBrandTypeDescription,VehicleModelTypeID")] VehicleBrandType vehicleBrandType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleBrandType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleModelTypeID = new SelectList(db.VehicleModelTypes, "VehicleModelTypeID", "VehicleModelTypeDescription", vehicleBrandType.VehicleModelTypeID);
            return View(vehicleBrandType);
        }

        // GET: VehicleBrandType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBrandType vehicleBrandType = db.VehicleBrandTypes.Find(id);
            if (vehicleBrandType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBrandType);
        }

        // POST: VehicleBrandType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleBrandType vehicleBrandType = db.VehicleBrandTypes.Find(id);
            db.VehicleBrandTypes.Remove(vehicleBrandType);
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
