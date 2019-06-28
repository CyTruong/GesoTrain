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
    public class STUDENTsController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();

        // GET: STUDENTs
        public ActionResult Index()
        {
            return View(db.STUDENT.ToList());
        }

        // GET: STUDENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENT.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            SCHOOL sCHOOL = db.SCHOOL.Find(sTUDENT.SCHOOL_FK);
            STATUS sTATUS = db.STATUS.Find(sTUDENT.STATUS_FK);
            FACULTIES fACULTIES = db.FACULTIES.Find(sTUDENT.FACULTIES_FK);
            String tentruong = "";
            String trangthai = "";
            String tennganh = "";
            if (sCHOOL !=null)
            {
                tentruong = sCHOOL.NAME;
            }
            if (sTATUS != null)
            {
                trangthai = sTATUS.NAME;
            }
            if (fACULTIES != null)
            {
                tennganh = fACULTIES.NAME;
            }
            ViewBag.tentruong = tentruong;
            ViewBag.trangthai = trangthai;
            ViewBag.tennganh = tennganh;
            return View(sTUDENT);
        }

        // GET: STUDENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STUDENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,EMAIL,PHONE,CLASS_CODE,SCHOOL_FK,STATUS_FK,CREATE_USER,CREATE_DATE,ALTER_USER,ALTER_DATE,CODE,FACULTIES_FK,AVATAR")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                db.STUDENT.Add(sTUDENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTUDENT);
        }

        // GET: STUDENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENT.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT);
        }

        // POST: STUDENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,EMAIL,PHONE,CLASS_CODE,SCHOOL_FK,STATUS_FK,CREATE_USER,CREATE_DATE,ALTER_USER,ALTER_DATE,CODE,FACULTIES_FK,AVATAR,GENDER,TRAINING_YEAR_FROM,TRAINING_YEAR_TO,LEVEL")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Home/Userpage");
            }
            return Redirect("/Home/Userpage");
        }

        // GET: STUDENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENT.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT);
        }

        // POST: STUDENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENT sTUDENT = db.STUDENT.Find(id);
            db.STUDENT.Remove(sTUDENT);
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
