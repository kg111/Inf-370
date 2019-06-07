﻿using System;
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
    public class DriverController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: Driver
        public ActionResult Index()
        {
            var drivers = db.Drivers.Include(d => d.DriverType).Include(d => d.Employee).Include(d => d.LicenseType);
            return View(drivers.ToList());
        }

        // GET: Driver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            ViewBag.DriverTypeID = new SelectList(db.DriverTypes, "DriverTypeID", "DriverTypeDescription");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.LicenseTypeID = new SelectList(db.LicenseTypes, "LicenseTypeID", "LicenseTypeDescription");
            return View();
        }

        // POST: Driver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverID,LicenseNumber,LicenseExpiryDate,OutsourceName,OutsourceNumber,OutsourseIdentityNumber,LicenseTypeID,DriverTypeID,EmployeeID")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Drivers.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverTypeID = new SelectList(db.DriverTypes, "DriverTypeID", "DriverTypeDescription", driver.DriverTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", driver.EmployeeID);
            ViewBag.LicenseTypeID = new SelectList(db.LicenseTypes, "LicenseTypeID", "LicenseTypeDescription", driver.LicenseTypeID);
            return View(driver);
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverTypeID = new SelectList(db.DriverTypes, "DriverTypeID", "DriverTypeDescription", driver.DriverTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", driver.EmployeeID);
            ViewBag.LicenseTypeID = new SelectList(db.LicenseTypes, "LicenseTypeID", "LicenseTypeDescription", driver.LicenseTypeID);
            return View(driver);
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverID,LicenseNumber,LicenseExpiryDate,OutsourceName,OutsourceNumber,OutsourseIdentityNumber,LicenseTypeID,DriverTypeID,EmployeeID")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverTypeID = new SelectList(db.DriverTypes, "DriverTypeID", "DriverTypeDescription", driver.DriverTypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", driver.EmployeeID);
            ViewBag.LicenseTypeID = new SelectList(db.LicenseTypes, "LicenseTypeID", "LicenseTypeDescription", driver.LicenseTypeID);
            return View(driver);
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = db.Drivers.Find(id);
            db.Drivers.Remove(driver);
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
