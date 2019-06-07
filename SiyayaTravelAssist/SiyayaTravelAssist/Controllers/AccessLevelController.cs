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
    public class AccessLevelController : Controller
    {
        private SiyayaTravelAssistEntities db = new SiyayaTravelAssistEntities();

        // GET: AccessLevel
        public ActionResult Index()
        {
            return View(db.AccessLevels.ToList());
        }

        // GET: AccessLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessLevel accessLevel = db.AccessLevels.Find(id);
            if (accessLevel == null)
            {
                return HttpNotFound();
            }
            return View(accessLevel);
        }

        // GET: AccessLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessLevelID,AccessLevelDescription")] AccessLevel accessLevel)
        {
            if (ModelState.IsValid)
            {
                db.AccessLevels.Add(accessLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessLevel);
        }

        // GET: AccessLevel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessLevel accessLevel = db.AccessLevels.Find(id);
            if (accessLevel == null)
            {
                return HttpNotFound();
            }
            return View(accessLevel);
        }

        // POST: AccessLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessLevelID,AccessLevelDescription")] AccessLevel accessLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessLevel);
        }

        // GET: AccessLevel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessLevel accessLevel = db.AccessLevels.Find(id);
            if (accessLevel == null)
            {
                return HttpNotFound();
            }
            return View(accessLevel);
        }

        // POST: AccessLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessLevel accessLevel = db.AccessLevels.Find(id);
            db.AccessLevels.Remove(accessLevel);
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
