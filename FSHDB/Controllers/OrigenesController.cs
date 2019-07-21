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
    public class OrigenesController : Controller
    {
        private HeroinasEntities db = new HeroinasEntities();

        // GET: Origenes
        public ActionResult Index()
        {
            return View(db.Origenes.ToList());
        }

        // GET: Origenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Origenes origenes = db.Origenes.Find(id);
            if (origenes == null)
            {
                return HttpNotFound();
            }
            return View(origenes);
        }

        // GET: Origenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Origenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Origen")] Origenes origenes)
        {
            if (ModelState.IsValid)
            {
                db.Origenes.Add(origenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(origenes);
        }

        // GET: Origenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Origenes origenes = db.Origenes.Find(id);
            if (origenes == null)
            {
                return HttpNotFound();
            }
            return View(origenes);
        }

        // POST: Origenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Origen")] Origenes origenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(origenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(origenes);
        }

        // GET: Origenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Origenes origenes = db.Origenes.Find(id);
            if (origenes == null)
            {
                return HttpNotFound();
            }
            return View(origenes);
        }

        // POST: Origenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Origenes origenes = db.Origenes.Find(id);
            db.Origenes.Remove(origenes);
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
