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
    public class CV_STUDENTController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();

        // GET: CV_STUDENT
        public ActionResult Index()
        {
            return View(db.CV_STUDENT.ToList());
        }

        // GET: CV_STUDENT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV_STUDENT cV_STUDENT = db.CV_STUDENT.Find(id);
            if (cV_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(cV_STUDENT);
        }

        // GET: CV_STUDENT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CV_STUDENT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,STUDENT_FK,HOBBY,SPECIAL_SKILLS_TALENTS")] CV_STUDENT cV_STUDENT)
        {
            if (ModelState.IsValid)
            {
                db.CV_STUDENT.Add(cV_STUDENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cV_STUDENT);
        }

        // GET: CV_STUDENT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV_STUDENT cV_STUDENT = db.CV_STUDENT.Find(id);
            if (cV_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(cV_STUDENT);
        }

        // POST: CV_STUDENT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,STUDENT_FK,HOBBY,SPECIAL_SKILLS_TALENTS")] CV_STUDENT cV_STUDENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cV_STUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cV_STUDENT);
        }

        // GET: CV_STUDENT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV_STUDENT cV_STUDENT = db.CV_STUDENT.Find(id);
            if (cV_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(cV_STUDENT);
        }

        // POST: CV_STUDENT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CV_STUDENT cV_STUDENT = db.CV_STUDENT.Find(id);
            db.CV_STUDENT.Remove(cV_STUDENT);
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
