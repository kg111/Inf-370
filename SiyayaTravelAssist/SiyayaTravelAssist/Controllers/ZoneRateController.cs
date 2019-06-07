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
    public class ZoneRateController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: ZoneRate
        public ActionResult Index()
        {
            return View(db.ZoneRates.ToList());
        }

        // GET: ZoneRate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneRate zoneRate = db.ZoneRates.Find(id);
            if (zoneRate == null)
            {
                return HttpNotFound();
            }
            return View(zoneRate);
        }

        // GET: ZoneRate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZoneRate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZoneRateID,ZoneRateDescription")] ZoneRate zoneRate)
        {
            if (ModelState.IsValid)
            {
                db.ZoneRates.Add(zoneRate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zoneRate);
        }

        // GET: ZoneRate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneRate zoneRate = db.ZoneRates.Find(id);
            if (zoneRate == null)
            {
                return HttpNotFound();
            }
            return View(zoneRate);
        }

        // POST: ZoneRate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZoneRateID,ZoneRateDescription")] ZoneRate zoneRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zoneRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zoneRate);
        }

        // GET: ZoneRate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoneRate zoneRate = db.ZoneRates.Find(id);
            if (zoneRate == null)
            {
                return HttpNotFound();
            }
            return View(zoneRate);
        }

        // POST: ZoneRate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZoneRate zoneRate = db.ZoneRates.Find(id);
            db.ZoneRates.Remove(zoneRate);
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
