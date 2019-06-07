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
    public class TripController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: Trip
        public ActionResult Index()
        {
            var trips = db.Trips.Include(t => t.Location).Include(t => t.Location1).Include(t => t.Passenger).Include(t => t.Quote);
            return View(trips.ToList());
        }

        // GET: Trip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trip/Create
        public ActionResult Create()
        {
            ViewBag.DropOffLocation = new SelectList(db.Locations, "LocationID", "LocationDescription");
            ViewBag.PickupLocation = new SelectList(db.Locations, "LocationID", "LocationDescription");
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerDescription");
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID");
            return View();
        }

        // POST: Trip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TripID,PickupTime,DropOffTime,TripDate,PassengerID,PickupLocation,DropOffLocation,Distance,QuoteID")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DropOffLocation = new SelectList(db.Locations, "LocationID", "LocationDescription", trip.DropOffLocation);
            ViewBag.PickupLocation = new SelectList(db.Locations, "LocationID", "LocationDescription", trip.PickupLocation);
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerDescription", trip.PassengerID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", trip.QuoteID);
            return View(trip);
        }

        // GET: Trip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.DropOffLocation = new SelectList(db.Locations, "LocationID", "LocationDescription", trip.DropOffLocation);
            ViewBag.PickupLocation = new SelectList(db.Locations, "LocationID", "LocationDescription", trip.PickupLocation);
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerDescription", trip.PassengerID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", trip.QuoteID);
            return View(trip);
        }

        // POST: Trip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TripID,PickupTime,DropOffTime,TripDate,PassengerID,PickupLocation,DropOffLocation,Distance,QuoteID")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DropOffLocation = new SelectList(db.Locations, "LocationID", "LocationDescription", trip.DropOffLocation);
            ViewBag.PickupLocation = new SelectList(db.Locations, "LocationID", "LocationDescription", trip.PickupLocation);
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "PassengerDescription", trip.PassengerID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", trip.QuoteID);
            return View(trip);
        }

        // GET: Trip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = db.Trips.Find(id);
            db.Trips.Remove(trip);
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
