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
    public class TOUR_OperadoresController : Controller
    {
        private ConciergeEntities1 db = new ConciergeEntities1();

        // GET: TOUR_Operadores
        public ActionResult Index()
        {
            var tOUR_Operadores = db.TOUR_Operadores.Include(t => t.TOUR_Catalogo_Tour);
            return View(tOUR_Operadores.ToList());
        }

        // GET: TOUR_Operadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Operadores tOUR_Operadores = db.TOUR_Operadores.Find(id);
            if (tOUR_Operadores == null)
            {
                return HttpNotFound();
            }
            return View(tOUR_Operadores);
        }

        // GET: TOUR_Operadores/Create
        public ActionResult Create()
        {
            ViewBag.CodCom = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour");
            return View();
        }

        // POST: TOUR_Operadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCom,NomCom,TelCom,EmaCom,Contacto1,Telcon1,EmaCon1,Contacto2,Telcon2,Emacon2")] TOUR_Operadores tOUR_Operadores)
        {
            if (ModelState.IsValid)
            {
                db.TOUR_Operadores.Add(tOUR_Operadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCom = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour", tOUR_Operadores.CodCom);
            return View(tOUR_Operadores);
        }

        // GET: TOUR_Operadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Operadores tOUR_Operadores = db.TOUR_Operadores.Find(id);
            if (tOUR_Operadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCom = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour", tOUR_Operadores.CodCom);
            return View(tOUR_Operadores);
        }

        // POST: TOUR_Operadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCom,NomCom,TelCom,EmaCom,Contacto1,Telcon1,EmaCon1,Contacto2,Telcon2,Emacon2")] TOUR_Operadores tOUR_Operadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR_Operadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCom = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour", tOUR_Operadores.CodCom);
            return View(tOUR_Operadores);
        }

        // GET: TOUR_Operadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Operadores tOUR_Operadores = db.TOUR_Operadores.Find(id);
            if (tOUR_Operadores == null)
            {
                return HttpNotFound();
            }
            return View(tOUR_Operadores);
        }

        // POST: TOUR_Operadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOUR_Operadores tOUR_Operadores = db.TOUR_Operadores.Find(id);
            db.TOUR_Operadores.Remove(tOUR_Operadores);
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
