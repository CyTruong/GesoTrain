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
    public class SCHOOLsController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();

        // GET: SCHOOLs
        public ActionResult Index()
        {
            return View(db.SCHOOL.ToList());
        }

        // GET: SCHOOLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHOOL sCHOOL = db.SCHOOL.Find(id);
            if (sCHOOL == null)
            {
                return HttpNotFound();
            }
            return View(sCHOOL);
        }

        // GET: SCHOOLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SCHOOLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,ADDRESS,STATUS_FK,CREATE_USER,CREATE_DATE,ALTER_USER,ALTER_DATE,CODE,HOUR_ABSENT,DAY_ABSENT,TYPEOFTRAINING_FK")] SCHOOL sCHOOL)
        {
            if (ModelState.IsValid)
            {
                db.SCHOOL.Add(sCHOOL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sCHOOL);
        }

        // GET: SCHOOLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHOOL sCHOOL = db.SCHOOL.Find(id);
            if (sCHOOL == null)
            {
                return HttpNotFound();
            }
            return View(sCHOOL);
        }

        // POST: SCHOOLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,ADDRESS,STATUS_FK,CREATE_USER,CREATE_DATE,ALTER_USER,ALTER_DATE,CODE,HOUR_ABSENT,DAY_ABSENT,TYPEOFTRAINING_FK")] SCHOOL sCHOOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCHOOL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCHOOL);
        }

        // GET: SCHOOLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCHOOL sCHOOL = db.SCHOOL.Find(id);
            if (sCHOOL == null)
            {
                return HttpNotFound();
            }
            return View(sCHOOL);
        }

        // POST: SCHOOLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCHOOL sCHOOL = db.SCHOOL.Find(id);
            db.SCHOOL.Remove(sCHOOL);
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
