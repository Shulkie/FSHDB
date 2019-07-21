using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FSHDB.Models;

namespace FSHDB.Controllers
{
    public class CreadoXesController : Controller
    {
        private HeroinasEntities db = new HeroinasEntities();

        // GET: CreadoXes
        public ActionResult Index()
        {
            return View(db.CreadoX.ToList());
        }

        // GET: CreadoXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreadoX creadoX = db.CreadoX.Find(id);
            if (creadoX == null)
            {
                return HttpNotFound();
            }
            return View(creadoX);
        }

        // GET: CreadoXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreadoXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreadoX1")] CreadoX creadoX)
        {
            if (ModelState.IsValid)
            {
                db.CreadoX.Add(creadoX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creadoX);
        }

        // GET: CreadoXes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreadoX creadoX = db.CreadoX.Find(id);
            if (creadoX == null)
            {
                return HttpNotFound();
            }
            return View(creadoX);
        }

        // POST: CreadoXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreadoX1")] CreadoX creadoX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creadoX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creadoX);
        }

        // GET: CreadoXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreadoX creadoX = db.CreadoX.Find(id);
            if (creadoX == null)
            {
                return HttpNotFound();
            }
            return View(creadoX);
        }

        // POST: CreadoXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreadoX creadoX = db.CreadoX.Find(id);
            db.CreadoX.Remove(creadoX);
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
