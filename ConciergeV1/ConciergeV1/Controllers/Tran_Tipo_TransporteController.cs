using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConciergeV1.Models;

namespace ConciergeV1.Controllers
{
    public class Tran_Tipo_TransporteController : Controller
    {
        private ConciergeEntities db = new ConciergeEntities();

        // GET: Tran_Tipo_Transporte
        public ActionResult Index()
        {
            return View(db.Tran_Tipo_Transporte.ToList());
        }

        // GET: Tran_Tipo_Transporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tran_Tipo_Transporte tran_Tipo_Transporte = db.Tran_Tipo_Transporte.Find(id);
            if (tran_Tipo_Transporte == null)
            {
                return HttpNotFound();
            }
            return View(tran_Tipo_Transporte);
        }

        // GET: Tran_Tipo_Transporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tran_Tipo_Transporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codtip,Destip")] Tran_Tipo_Transporte tran_Tipo_Transporte)
        {
            if (ModelState.IsValid)
            {
                db.Tran_Tipo_Transporte.Add(tran_Tipo_Transporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tran_Tipo_Transporte);
        }

        // GET: Tran_Tipo_Transporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tran_Tipo_Transporte tran_Tipo_Transporte = db.Tran_Tipo_Transporte.Find(id);
            if (tran_Tipo_Transporte == null)
            {
                return HttpNotFound();
            }
            return View(tran_Tipo_Transporte);
        }

        // POST: Tran_Tipo_Transporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codtip,Destip")] Tran_Tipo_Transporte tran_Tipo_Transporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tran_Tipo_Transporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tran_Tipo_Transporte);
        }

        // GET: Tran_Tipo_Transporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tran_Tipo_Transporte tran_Tipo_Transporte = db.Tran_Tipo_Transporte.Find(id);
            if (tran_Tipo_Transporte == null)
            {
                return HttpNotFound();
            }
            return View(tran_Tipo_Transporte);
        }

        // POST: Tran_Tipo_Transporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tran_Tipo_Transporte tran_Tipo_Transporte = db.Tran_Tipo_Transporte.Find(id);
            db.Tran_Tipo_Transporte.Remove(tran_Tipo_Transporte);
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
