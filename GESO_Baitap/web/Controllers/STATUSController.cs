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
    public class STATUSController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();

        // GET: STATUS
        public ActionResult Index()
        {
            return View(db.STATUS.ToList());
        }

        // GET: STATUS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATUS sTATUS = db.STATUS.Find(id);
            if (sTATUS == null)
            {
                return HttpNotFound();
            }
            return View(sTATUS);
        }

        // GET: STATUS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STATUS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME")] STATUS sTATUS)
        {
            if (ModelState.IsValid)
            {
                db.STATUS.Add(sTATUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTATUS);
        }

        // GET: STATUS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATUS sTATUS = db.STATUS.Find(id);
            if (sTATUS == null)
            {
                return HttpNotFound();
            }
            return View(sTATUS);
        }

        // POST: STATUS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME")] STATUS sTATUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTATUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTATUS);
        }

        // GET: STATUS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATUS sTATUS = db.STATUS.Find(id);
            if (sTATUS == null)
            {
                return HttpNotFound();
            }
            return View(sTATUS);
        }

        // POST: STATUS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STATUS sTATUS = db.STATUS.Find(id);
            db.STATUS.Remove(sTATUS);
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
