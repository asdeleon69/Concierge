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
    public class TRAN_Tipo_TransporteController : Controller
    {
        private ConciergeEntities1 db = new ConciergeEntities1();

        // GET: TRAN_Tipo_Transporte
        public ActionResult Index()
        {
            return View(db.TRAN_Tipo_Transporte.ToList());
        }

        // GET: TRAN_Tipo_Transporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Tipo_Transporte tRAN_Tipo_Transporte = db.TRAN_Tipo_Transporte.Find(id);
            if (tRAN_Tipo_Transporte == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Tipo_Transporte);
        }

        // GET: TRAN_Tipo_Transporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRAN_Tipo_Transporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codtip,Destip")] TRAN_Tipo_Transporte tRAN_Tipo_Transporte)
        {
            if (ModelState.IsValid)
            {
                db.TRAN_Tipo_Transporte.Add(tRAN_Tipo_Transporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRAN_Tipo_Transporte);
        }

        // GET: TRAN_Tipo_Transporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Tipo_Transporte tRAN_Tipo_Transporte = db.TRAN_Tipo_Transporte.Find(id);
            if (tRAN_Tipo_Transporte == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Tipo_Transporte);
        }

        // POST: TRAN_Tipo_Transporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codtip,Destip")] TRAN_Tipo_Transporte tRAN_Tipo_Transporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRAN_Tipo_Transporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRAN_Tipo_Transporte);
        }

        // GET: TRAN_Tipo_Transporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Tipo_Transporte tRAN_Tipo_Transporte = db.TRAN_Tipo_Transporte.Find(id);
            if (tRAN_Tipo_Transporte == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Tipo_Transporte);
        }

        // POST: TRAN_Tipo_Transporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRAN_Tipo_Transporte tRAN_Tipo_Transporte = db.TRAN_Tipo_Transporte.Find(id);
            db.TRAN_Tipo_Transporte.Remove(tRAN_Tipo_Transporte);
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
