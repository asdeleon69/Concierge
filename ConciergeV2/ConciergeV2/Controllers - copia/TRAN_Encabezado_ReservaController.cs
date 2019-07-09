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
    public class TRAN_Encabezado_ReservaController : Controller
    {
        private ConciergeEntities1 db = new ConciergeEntities1();

        // GET: TRAN_Encabezado_Reserva
        public ActionResult Index()
        {
            var tRAN_Encabezado_Reserva = db.TRAN_Encabezado_Reserva.Include(t => t.TRAN_Pick_Drop).Include(t => t.TRAN_Pick_Drop1).Include(t => t.TRAN_Tipo_Transporte);
            return View(tRAN_Encabezado_Reserva.ToList());
        }

        // GET: TRAN_Encabezado_Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Encabezado_Reserva tRAN_Encabezado_Reserva = db.TRAN_Encabezado_Reserva.Find(id);
            if (tRAN_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Encabezado_Reserva);
        }

        // GET: TRAN_Encabezado_Reserva/Create
        public ActionResult Create()
        {
            ViewBag.Pickup = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick");
            ViewBag.Dropoff = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick");
            ViewBag.TipoTran = new SelectList(db.TRAN_Tipo_Transporte, "Codtip", "Destip");
            return View();
        }

        // POST: TRAN_Encabezado_Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodReserva,ReservaOpera,NomHuesped,NumRoom,Checkin,Checkout,FecReg,UsrReg,Alergias,Observaciones,NotasCliente,Email,TipoTran,Pickup,Dropoff,Pax,Precio,Fecha,Hora,Aerolinea,NoVuelo")] TRAN_Encabezado_Reserva tRAN_Encabezado_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.TRAN_Encabezado_Reserva.Add(tRAN_Encabezado_Reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pickup = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick", tRAN_Encabezado_Reserva.Pickup);
            ViewBag.Dropoff = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick", tRAN_Encabezado_Reserva.Dropoff);
            ViewBag.TipoTran = new SelectList(db.TRAN_Tipo_Transporte, "Codtip", "Destip", tRAN_Encabezado_Reserva.TipoTran);
            return View(tRAN_Encabezado_Reserva);
        }

        // GET: TRAN_Encabezado_Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Encabezado_Reserva tRAN_Encabezado_Reserva = db.TRAN_Encabezado_Reserva.Find(id);
            if (tRAN_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pickup = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick", tRAN_Encabezado_Reserva.Pickup);
            ViewBag.Dropoff = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick", tRAN_Encabezado_Reserva.Dropoff);
            ViewBag.TipoTran = new SelectList(db.TRAN_Tipo_Transporte, "Codtip", "Destip", tRAN_Encabezado_Reserva.TipoTran);
            return View(tRAN_Encabezado_Reserva);
        }

        // POST: TRAN_Encabezado_Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodReserva,ReservaOpera,NomHuesped,NumRoom,Checkin,Checkout,FecReg,UsrReg,Alergias,Observaciones,NotasCliente,Email,TipoTran,Pickup,Dropoff,Pax,Precio,Fecha,Hora,Aerolinea,NoVuelo")] TRAN_Encabezado_Reserva tRAN_Encabezado_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRAN_Encabezado_Reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pickup = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick", tRAN_Encabezado_Reserva.Pickup);
            ViewBag.Dropoff = new SelectList(db.TRAN_Pick_Drop, "CodPick", "DesPick", tRAN_Encabezado_Reserva.Dropoff);
            ViewBag.TipoTran = new SelectList(db.TRAN_Tipo_Transporte, "Codtip", "Destip", tRAN_Encabezado_Reserva.TipoTran);
            return View(tRAN_Encabezado_Reserva);
        }

        // GET: TRAN_Encabezado_Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Encabezado_Reserva tRAN_Encabezado_Reserva = db.TRAN_Encabezado_Reserva.Find(id);
            if (tRAN_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Encabezado_Reserva);
        }

        // POST: TRAN_Encabezado_Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRAN_Encabezado_Reserva tRAN_Encabezado_Reserva = db.TRAN_Encabezado_Reserva.Find(id);
            db.TRAN_Encabezado_Reserva.Remove(tRAN_Encabezado_Reserva);
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
