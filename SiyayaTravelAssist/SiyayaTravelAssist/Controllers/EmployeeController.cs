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
    public class EmployeeController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.AccessLevel).Include(e => e.AuditTrail).Include(e => e.Country).Include(e => e.EmployeeType).Include(e => e.Nationality).Include(e => e.Province).Include(e => e.Suburb).Include(e => e.Title).Include(e => e.City).Include(e => e.Gender1);
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.AccessLevelID = new SelectList(db.AccessLevels, "AccessLevelID", "AccessLevelDescription");
            ViewBag.AuditTrailID = new SelectList(db.AuditTrails, "AuditTrailID", "AuditTrailID");
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescription");
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeDescription");
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "NationalityDescription");
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescription");
            ViewBag.SuburbID = new SelectList(db.Suburbs, "SuburbID", "SuburbDescription");
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescription");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityDescription");
            ViewBag.Gender = new SelectList(db.Genders, "GenderID", "GenderDescription");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,LastName,EmailAddress,Telephone,DateOfBirth,Password,IsEmailVerified,EmployeeTypeID,CountryID,TitleID,ProvinceID,SuburbID,AuditTrailID,AccessLevelID,NationalityID,CityID,Gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessLevelID = new SelectList(db.AccessLevels, "AccessLevelID", "AccessLevelDescription", employee.AccessLevelID);
            ViewBag.AuditTrailID = new SelectList(db.AuditTrails, "AuditTrailID", "AuditTrailID", employee.AuditTrailID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescription", employee.CountryID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeDescription", employee.EmployeeTypeID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "NationalityDescription", employee.NationalityID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescription", employee.ProvinceID);
            ViewBag.SuburbID = new SelectList(db.Suburbs, "SuburbID", "SuburbDescription", employee.SuburbID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescription", employee.TitleID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityDescription", employee.CityID);
            ViewBag.Gender = new SelectList(db.Genders, "GenderID", "GenderDescription", employee.Gender);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessLevelID = new SelectList(db.AccessLevels, "AccessLevelID", "AccessLevelDescription", employee.AccessLevelID);
            ViewBag.AuditTrailID = new SelectList(db.AuditTrails, "AuditTrailID", "AuditTrailID", employee.AuditTrailID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescription", employee.CountryID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeDescription", employee.EmployeeTypeID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "NationalityDescription", employee.NationalityID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescription", employee.ProvinceID);
            ViewBag.SuburbID = new SelectList(db.Suburbs, "SuburbID", "SuburbDescription", employee.SuburbID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescription", employee.TitleID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityDescription", employee.CityID);
            ViewBag.Gender = new SelectList(db.Genders, "GenderID", "GenderDescription", employee.Gender);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,LastName,EmailAddress,Telephone,DateOfBirth,Password,IsEmailVerified,EmployeeTypeID,CountryID,TitleID,ProvinceID,SuburbID,AuditTrailID,AccessLevelID,NationalityID,CityID,Gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessLevelID = new SelectList(db.AccessLevels, "AccessLevelID", "AccessLevelDescription", employee.AccessLevelID);
            ViewBag.AuditTrailID = new SelectList(db.AuditTrails, "AuditTrailID", "AuditTrailID", employee.AuditTrailID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescription", employee.CountryID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeDescription", employee.EmployeeTypeID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "NationalityDescription", employee.NationalityID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescription", employee.ProvinceID);
            ViewBag.SuburbID = new SelectList(db.Suburbs, "SuburbID", "SuburbDescription", employee.SuburbID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescription", employee.TitleID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityDescription", employee.CityID);
            ViewBag.Gender = new SelectList(db.Genders, "GenderID", "GenderDescription", employee.Gender);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
