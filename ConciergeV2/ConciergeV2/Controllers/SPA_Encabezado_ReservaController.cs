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
    public class SPA_Encabezado_ReservaController : Controller
    {
        private ConciergeEntities db = new ConciergeEntities();

        // GET: SPA_Encabezado_Reserva
        public ActionResult Index()
        {
            var sPA_Encabezado_Reserva = db.SPA_Encabezado_Reserva.Include(s => s.SPA_Detalle_Reserva);
            return View(sPA_Encabezado_Reserva.ToList());
        }

        // GET: SPA_Encabezado_Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Encabezado_Reserva sPA_Encabezado_Reserva = db.SPA_Encabezado_Reserva.Find(id);
            if (sPA_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Encabezado_Reserva);
        }

        // GET: SPA_Encabezado_Reserva/Create
        public ActionResult Create()
        {
            ViewBag.CodReserva = new SelectList(db.SPA_Detalle_Reserva, "CodReserva", "CodSer");
            return View();
        }

        // POST: SPA_Encabezado_Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodReserva,ReservaOpera,NomHuesped,NumRoom,Checkin,Checkout,FecReg,UsrReg,Alergias,Observaciones,NotasCliente,Email")] SPA_Encabezado_Reserva sPA_Encabezado_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.SPA_Encabezado_Reserva.Add(sPA_Encabezado_Reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodReserva = new SelectList(db.SPA_Detalle_Reserva, "CodReserva", "CodSer", sPA_Encabezado_Reserva.CodReserva);
            return View(sPA_Encabezado_Reserva);
        }

        // GET: SPA_Encabezado_Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Encabezado_Reserva sPA_Encabezado_Reserva = db.SPA_Encabezado_Reserva.Find(id);
            if (sPA_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodReserva = new SelectList(db.SPA_Detalle_Reserva, "CodReserva", "CodSer", sPA_Encabezado_Reserva.CodReserva);
            return View(sPA_Encabezado_Reserva);
        }

        // POST: SPA_Encabezado_Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodReserva,ReservaOpera,NomHuesped,NumRoom,Checkin,Checkout,FecReg,UsrReg,Alergias,Observaciones,NotasCliente,Email")] SPA_Encabezado_Reserva sPA_Encabezado_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPA_Encabezado_Reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodReserva = new SelectList(db.SPA_Detalle_Reserva, "CodReserva", "CodSer", sPA_Encabezado_Reserva.CodReserva);
            return View(sPA_Encabezado_Reserva);
        }

        // GET: SPA_Encabezado_Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Encabezado_Reserva sPA_Encabezado_Reserva = db.SPA_Encabezado_Reserva.Find(id);
            if (sPA_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Encabezado_Reserva);
        }

        // POST: SPA_Encabezado_Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPA_Encabezado_Reserva sPA_Encabezado_Reserva = db.SPA_Encabezado_Reserva.Find(id);
            db.SPA_Encabezado_Reserva.Remove(sPA_Encabezado_Reserva);
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
