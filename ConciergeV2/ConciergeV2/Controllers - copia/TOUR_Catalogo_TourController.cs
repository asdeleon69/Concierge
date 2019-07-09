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
    public class TOUR_Catalogo_TourController : Controller
    {
        private ConciergeEntities1 db = new ConciergeEntities1();

        // GET: TOUR_Catalogo_Tour
        public ActionResult Index()
        {
            var tOUR_Catalogo_Tour = db.TOUR_Catalogo_Tour.Include(t => t.TOUR_Operadores);
            return View(tOUR_Catalogo_Tour.ToList());
        }

        // GET: TOUR_Catalogo_Tour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Catalogo_Tour tOUR_Catalogo_Tour = db.TOUR_Catalogo_Tour.Find(id);
            if (tOUR_Catalogo_Tour == null)
            {
                return HttpNotFound();
            }
            return View(tOUR_Catalogo_Tour);
        }

        // GET: TOUR_Catalogo_Tour/Create
        public ActionResult Create()
        {
            ViewBag.ComTour = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom");
            return View();
        }

        // POST: TOUR_Catalogo_Tour/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodTour,NomTour,DesTour,DurTour,PreTourAdulto,PreTourAdultoM,PreTourNino,NotasTour,ComTour")] TOUR_Catalogo_Tour tOUR_Catalogo_Tour)
        {
            if (ModelState.IsValid)
            {
                db.TOUR_Catalogo_Tour.Add(tOUR_Catalogo_Tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComTour = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom", tOUR_Catalogo_Tour.ComTour);
            return View(tOUR_Catalogo_Tour);
        }

        // GET: TOUR_Catalogo_Tour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Catalogo_Tour tOUR_Catalogo_Tour = db.TOUR_Catalogo_Tour.Find(id);
            if (tOUR_Catalogo_Tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComTour = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom", tOUR_Catalogo_Tour.ComTour);
            return View(tOUR_Catalogo_Tour);
        }

        // POST: TOUR_Catalogo_Tour/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodTour,NomTour,DesTour,DurTour,PreTourAdulto,PreTourAdultoM,PreTourNino,NotasTour,ComTour")] TOUR_Catalogo_Tour tOUR_Catalogo_Tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR_Catalogo_Tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComTour = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom", tOUR_Catalogo_Tour.ComTour);
            return View(tOUR_Catalogo_Tour);
        }

        // GET: TOUR_Catalogo_Tour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Catalogo_Tour tOUR_Catalogo_Tour = db.TOUR_Catalogo_Tour.Find(id);
            if (tOUR_Catalogo_Tour == null)
            {
                return HttpNotFound();
            }
            return View(tOUR_Catalogo_Tour);
        }

        // POST: TOUR_Catalogo_Tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOUR_Catalogo_Tour tOUR_Catalogo_Tour = db.TOUR_Catalogo_Tour.Find(id);
            db.TOUR_Catalogo_Tour.Remove(tOUR_Catalogo_Tour);
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
