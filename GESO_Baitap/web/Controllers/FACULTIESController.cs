using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class FACULTIESController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();

        // GET: FACULTIES
        public ActionResult Index()
        {
            return View(db.FACULTIES.ToList());
        }

        // GET: FACULTIES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULTIES fACULTIES = db.FACULTIES.Find(id);
            if (fACULTIES == null)
            {
                return HttpNotFound();
            }
            return View(fACULTIES);
        }

        // GET: FACULTIES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FACULTIES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,SCHOOL_FK")] FACULTIES fACULTIES)
        {
            if (ModelState.IsValid)
            {
                db.FACULTIES.Add(fACULTIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fACULTIES);
        }

        // GET: FACULTIES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULTIES fACULTIES = db.FACULTIES.Find(id);
            if (fACULTIES == null)
            {
                return HttpNotFound();
            }
            return View(fACULTIES);
        }

        // POST: FACULTIES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,SCHOOL_FK")] FACULTIES fACULTIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACULTIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fACULTIES);
        }

        // GET: FACULTIES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULTIES fACULTIES = db.FACULTIES.Find(id);
            if (fACULTIES == null)
            {
                return HttpNotFound();
            }
            return View(fACULTIES);
        }

        // POST: FACULTIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACULTIES fACULTIES = db.FACULTIES.Find(id);
            db.FACULTIES.Remove(fACULTIES);
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
