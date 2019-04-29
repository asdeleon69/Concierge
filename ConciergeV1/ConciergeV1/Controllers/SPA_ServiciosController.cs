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
    public class SPA_ServiciosController : Controller
    {
        private ConciergeEntities db = new ConciergeEntities();

        // GET: SPA_Servicios
        public ActionResult Index()
        {
            return View(db.SPA_Servicios.ToList());
        }

        // GET: SPA_Servicios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Servicios sPA_Servicios = db.SPA_Servicios.Find(id);
            if (sPA_Servicios == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Servicios);
        }

        // GET: SPA_Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPA_Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodSer,NomSer,DesSer,DurSer,PreSer")] SPA_Servicios sPA_Servicios)
        {
            if (ModelState.IsValid)
            {
                    db.SPA_Servicios.Add(sPA_Servicios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }

            return View(sPA_Servicios);
        }

        // GET: SPA_Servicios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Servicios sPA_Servicios = db.SPA_Servicios.Find(id);
            if (sPA_Servicios == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Servicios);
        }

        // POST: SPA_Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodSer,NomSer,DesSer,DurSer,PreSer")] SPA_Servicios sPA_Servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPA_Servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPA_Servicios);
        }

        // GET: SPA_Servicios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Servicios sPA_Servicios = db.SPA_Servicios.Find(id);
            if (sPA_Servicios == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Servicios);
        }

        // POST: SPA_Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SPA_Servicios sPA_Servicios = db.SPA_Servicios.Find(id);
            db.SPA_Servicios.Remove(sPA_Servicios);
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
