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
    public class BookingController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: Booking
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.BookingType).Include(b => b.Quote);
            return View(bookings.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.BookingTypeID = new SelectList(db.BookingTypes, "BookingTypeID", "BookingTypeDescription");
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,DateCreated,BookingStatus,BookingReference,BookingOrder,numberOfPassengers,PaymentStatus,AdditionalInformation,QuoteID,BookingTypeID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingTypeID = new SelectList(db.BookingTypes, "BookingTypeID", "BookingTypeDescription", booking.BookingTypeID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", booking.QuoteID);
            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingTypeID = new SelectList(db.BookingTypes, "BookingTypeID", "BookingTypeDescription", booking.BookingTypeID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", booking.QuoteID);
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,DateCreated,BookingStatus,BookingReference,BookingOrder,numberOfPassengers,PaymentStatus,AdditionalInformation,QuoteID,BookingTypeID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingTypeID = new SelectList(db.BookingTypes, "BookingTypeID", "BookingTypeDescription", booking.BookingTypeID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", booking.QuoteID);
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
