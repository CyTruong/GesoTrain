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
    public class STUDENT_EXPERIENCEController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();

        // GET: STUDENT_EXPERIENCE
        public ActionResult Index()
        {
            return View(db.STUDENT_EXPERIENCE.ToList());
        }

        // GET: STUDENT_EXPERIENCE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_EXPERIENCE sTUDENT_EXPERIENCE = db.STUDENT_EXPERIENCE.Find(id);
            if (sTUDENT_EXPERIENCE == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_EXPERIENCE);
        }

        // GET: STUDENT_EXPERIENCE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STUDENT_EXPERIENCE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,STUDENT_FK,COMPANY_NAME,TITLE,FROM_MONTH,TO_MONTH,FROM_YEAR,TO_YEAR,DESCRIPTION_JOB,SALARY")] STUDENT_EXPERIENCE sTUDENT_EXPERIENCE)
        {
            if (ModelState.IsValid)
            {
                db.STUDENT_EXPERIENCE.Add(sTUDENT_EXPERIENCE);
                db.SaveChanges();
                 return RedirectToAction("Index");
            }

            return View(sTUDENT_EXPERIENCE);
        }

        // GET: STUDENT_EXPERIENCE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_EXPERIENCE sTUDENT_EXPERIENCE = db.STUDENT_EXPERIENCE.Find(id);
            if (sTUDENT_EXPERIENCE == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_EXPERIENCE);
        }

        // POST: STUDENT_EXPERIENCE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,STUDENT_FK,COMPANY_NAME,TITLE,FROM_MONTH,TO_MONTH,FROM_YEAR,TO_YEAR,DESCRIPTION_JOB,SALARY")] STUDENT_EXPERIENCE sTUDENT_EXPERIENCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT_EXPERIENCE).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Userpage");
            }
            return Redirect("/Home/Userpage");
        }

        // GET: STUDENT_EXPERIENCE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_EXPERIENCE sTUDENT_EXPERIENCE = db.STUDENT_EXPERIENCE.Find(id);
            if (sTUDENT_EXPERIENCE == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_EXPERIENCE);
        }

        // POST: STUDENT_EXPERIENCE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENT_EXPERIENCE sTUDENT_EXPERIENCE = db.STUDENT_EXPERIENCE.Find(id);
            db.STUDENT_EXPERIENCE.Remove(sTUDENT_EXPERIENCE);
            db.SaveChanges();
            return Redirect("/Home/Userpage");
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
