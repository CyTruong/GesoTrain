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
    public class STUDENT_SKILLController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();

        // GET: STUDENT_SKILL
        public ActionResult Index()
        {
            return View(db.STUDENT_SKILL.ToList());
        }

        // GET: STUDENT_SKILL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_SKILL sTUDENT_SKILL = db.STUDENT_SKILL.Find(id);
            if (sTUDENT_SKILL == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_SKILL);
        }

        // GET: STUDENT_SKILL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STUDENT_SKILL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,STUDENT_FK,SKILL_FK")] STUDENT_SKILL sTUDENT_SKILL)
        {
            if (ModelState.IsValid)
            {
                db.STUDENT_SKILL.Add(sTUDENT_SKILL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTUDENT_SKILL);
        }

        // GET: STUDENT_SKILL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_SKILL sTUDENT_SKILL = db.STUDENT_SKILL.Find(id);
            if (sTUDENT_SKILL == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_SKILL);
        }

        // POST: STUDENT_SKILL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,STUDENT_FK,SKILL_FK")] STUDENT_SKILL sTUDENT_SKILL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT_SKILL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTUDENT_SKILL);
        }

        // GET: STUDENT_SKILL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_SKILL sTUDENT_SKILL = db.STUDENT_SKILL.Find(id);
            if (sTUDENT_SKILL == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_SKILL);
        }

        // POST: STUDENT_SKILL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENT_SKILL sTUDENT_SKILL = db.STUDENT_SKILL.Find(id);
            db.STUDENT_SKILL.Remove(sTUDENT_SKILL);
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
