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
    public class HeroinasController : Controller
    {
        private HeroinasEntities db = new HeroinasEntities();

        // GET: Heroinas
        public ActionResult Index()
        {
            var heroinas = db.Heroinas.Include(h => h.CreadoX).Include(h => h.Origenes);
            return View(heroinas.ToList());
        }

        // GET: Heroinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroinas heroinas = db.Heroinas.Find(id);
            if (heroinas == null)
            {
                return HttpNotFound();
            }
            return View(heroinas);
        }

        // GET: Heroinas/Create
        public ActionResult Create()
        {
            ViewBag.ID_CreadoX = new SelectList(db.CreadoX, "ID", "CreadoX1");
            ViewBag.ID_Origen = new SelectList(db.Origenes, "ID", "Origen");
            return View();
        }

        // POST: Heroinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Alias,ID_CreadoX,ID_Origen")] Heroinas heroinas)
        {
            if (ModelState.IsValid)
            {
                db.Heroinas.Add(heroinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CreadoX = new SelectList(db.CreadoX, "ID", "CreadoX1", heroinas.ID_CreadoX);
            ViewBag.ID_Origen = new SelectList(db.Origenes, "ID", "Origen", heroinas.ID_Origen);
            return View(heroinas);
        }

        // GET: Heroinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroinas heroinas = db.Heroinas.Find(id);
            if (heroinas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CreadoX = new SelectList(db.CreadoX, "ID", "CreadoX1", heroinas.ID_CreadoX);
            ViewBag.ID_Origen = new SelectList(db.Origenes, "ID", "Origen", heroinas.ID_Origen);
            return View(heroinas);
        }

        // POST: Heroinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Alias,ID_CreadoX,ID_Origen")] Heroinas heroinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heroinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CreadoX = new SelectList(db.CreadoX, "ID", "CreadoX1", heroinas.ID_CreadoX);
            ViewBag.ID_Origen = new SelectList(db.Origenes, "ID", "Origen", heroinas.ID_Origen);
            return View(heroinas);
        }

        // GET: Heroinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroinas heroinas = db.Heroinas.Find(id);
            if (heroinas == null)
            {
                return HttpNotFound();
            }
            return View(heroinas);
        }

        // POST: Heroinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heroinas heroinas = db.Heroinas.Find(id);
            db.Heroinas.Remove(heroinas);
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
