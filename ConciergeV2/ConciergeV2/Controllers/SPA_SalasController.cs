using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConciergeV2.Models;

namespace ConciergeV2.Controllers
{
    public class SPA_SalasController : Controller
    {
        private ConciergeEntities db = new ConciergeEntities();

        // GET: SPA_Salas
        public ActionResult Index()
        {
            return View(db.SPA_Salas.ToList());
        }

        // GET: SPA_Salas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Salas sPA_Salas = db.SPA_Salas.Find(id);
            if (sPA_Salas == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Salas);
        }

        // GET: SPA_Salas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPA_Salas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodSala,DesSala,CarSala")] SPA_Salas sPA_Salas)
        {
            if (ModelState.IsValid)
            {
                db.SPA_Salas.Add(sPA_Salas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sPA_Salas);
        }

        // GET: SPA_Salas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Salas sPA_Salas = db.SPA_Salas.Find(id);
            if (sPA_Salas == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Salas);
        }

        // POST: SPA_Salas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodSala,DesSala,CarSala")] SPA_Salas sPA_Salas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPA_Salas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPA_Salas);
        }

        // GET: SPA_Salas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Salas sPA_Salas = db.SPA_Salas.Find(id);
            if (sPA_Salas == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Salas);
        }

        // POST: SPA_Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SPA_Salas sPA_Salas = db.SPA_Salas.Find(id);
            db.SPA_Salas.Remove(sPA_Salas);
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
