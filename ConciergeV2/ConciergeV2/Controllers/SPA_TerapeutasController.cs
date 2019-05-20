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
    public class SPA_TerapeutasController : Controller
    {
        private ConciergeEntities db = new ConciergeEntities();

        // GET: SPA_Terapeutas
        public ActionResult Index()
        {
            return View(db.SPA_Terapeutas.ToList());
        }

        // GET: SPA_Terapeutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Terapeutas sPA_Terapeutas = db.SPA_Terapeutas.Find(id);
            if (sPA_Terapeutas == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Terapeutas);
        }

        // GET: SPA_Terapeutas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPA_Terapeutas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodTerap,NomTerap")] SPA_Terapeutas sPA_Terapeutas)
        {
            if (ModelState.IsValid)
            {
                db.SPA_Terapeutas.Add(sPA_Terapeutas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sPA_Terapeutas);
        }

        // GET: SPA_Terapeutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Terapeutas sPA_Terapeutas = db.SPA_Terapeutas.Find(id);
            if (sPA_Terapeutas == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Terapeutas);
        }

        // POST: SPA_Terapeutas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodTerap,NomTerap")] SPA_Terapeutas sPA_Terapeutas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPA_Terapeutas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPA_Terapeutas);
        }

        // GET: SPA_Terapeutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Terapeutas sPA_Terapeutas = db.SPA_Terapeutas.Find(id);
            if (sPA_Terapeutas == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Terapeutas);
        }

        // POST: SPA_Terapeutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPA_Terapeutas sPA_Terapeutas = db.SPA_Terapeutas.Find(id);
            db.SPA_Terapeutas.Remove(sPA_Terapeutas);
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
