﻿using System;
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
    public class TOUR_Encabezado_ReservaController : Controller
    {
        private ConciergeEntities db = new ConciergeEntities();

        // GET: TOUR_Encabezado_Reserva
        public ActionResult Index()
        {
            var tOUR_Encabezado_Reserva = db.TOUR_Encabezado_Reserva.Include(t => t.TOUR_Catalogo_Tour).Include(t => t.TOUR_Operadores);
            return View(tOUR_Encabezado_Reserva.ToList());
        }

        // GET: TOUR_Encabezado_Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Encabezado_Reserva tOUR_Encabezado_Reserva = db.TOUR_Encabezado_Reserva.Find(id);
            if (tOUR_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(tOUR_Encabezado_Reserva);
        }

        // GET: TOUR_Encabezado_Reserva/Create
        public ActionResult Create()
        {
            ViewBag.CodTour = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour");
            ViewBag.CodCom = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom");
            return View();
        }

        // POST: TOUR_Encabezado_Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodReserva,ReservaOpera,NomHuesped,NumRoom,Checkin,Checkout,FecReg,UsrReg,Alergias,Observaciones,NotasCliente,Email,CodCom,CodTour,PaxAdul,PaxAdulM,PaxNino,Total,Fecha,Hora,ReturnTime")] TOUR_Encabezado_Reserva tOUR_Encabezado_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.TOUR_Encabezado_Reserva.Add(tOUR_Encabezado_Reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodTour = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour", tOUR_Encabezado_Reserva.CodTour);
            ViewBag.CodCom = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom", tOUR_Encabezado_Reserva.CodCom);
            return View(tOUR_Encabezado_Reserva);
        }

        // GET: TOUR_Encabezado_Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Encabezado_Reserva tOUR_Encabezado_Reserva = db.TOUR_Encabezado_Reserva.Find(id);
            if (tOUR_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodTour = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour", tOUR_Encabezado_Reserva.CodTour);
            ViewBag.CodCom = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom", tOUR_Encabezado_Reserva.CodCom);
            return View(tOUR_Encabezado_Reserva);
        }

        // POST: TOUR_Encabezado_Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodReserva,ReservaOpera,NomHuesped,NumRoom,Checkin,Checkout,FecReg,UsrReg,Alergias,Observaciones,NotasCliente,Email,CodCom,CodTour,PaxAdul,PaxAdulM,PaxNino,Total,Fecha,Hora,ReturnTime")] TOUR_Encabezado_Reserva tOUR_Encabezado_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR_Encabezado_Reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodTour = new SelectList(db.TOUR_Catalogo_Tour, "CodTour", "NomTour", tOUR_Encabezado_Reserva.CodTour);
            ViewBag.CodCom = new SelectList(db.TOUR_Operadores, "CodCom", "NomCom", tOUR_Encabezado_Reserva.CodCom);
            return View(tOUR_Encabezado_Reserva);
        }

        // GET: TOUR_Encabezado_Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR_Encabezado_Reserva tOUR_Encabezado_Reserva = db.TOUR_Encabezado_Reserva.Find(id);
            if (tOUR_Encabezado_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(tOUR_Encabezado_Reserva);
        }

        // POST: TOUR_Encabezado_Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOUR_Encabezado_Reserva tOUR_Encabezado_Reserva = db.TOUR_Encabezado_Reserva.Find(id);
            db.TOUR_Encabezado_Reserva.Remove(tOUR_Encabezado_Reserva);
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
