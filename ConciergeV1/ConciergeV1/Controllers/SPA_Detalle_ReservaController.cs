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
    public class SPA_Detalle_ReservaController : Controller
    {
        public JsonResult GetEvents()
        {
            {
                var sPA_Detalle_Reserva = db.SPA_Detalle_Reserva.Include(s => s.SPA_Encabezado_Reserva).Include(s => s.SPA_Salas).Include(s => s.SPA_Servicios).Include(s => s.SPA_Terapeutas);
                return new JsonResult { Data = sPA_Detalle_Reserva, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(SPA_Detalle_Reserva e)
        {
            var status = false;
            using (ConciergeEntities dc = new ConciergeEntities())
            {
                if (e.CodReserva > 0)
                {
                    //Update the event
                    var v = dc.SPA_Detalle_Reserva.Where(a => a.CodReserva == e.CodReserva).FirstOrDefault();
                    if (v != null)
                    {
                        v.NomHues = e.NomHues;
                        v.FecHoraRes = e.FecHoraRes;
                        v.Notas = e.Notas;
                    }
                }
                else
                {
                    dc.SPA_Detalle_Reserva.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (ConciergeEntities dc = new ConciergeEntities())
            {
                var v = dc.SPA_Detalle_Reserva.Where(a => a.CodReserva == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.SPA_Detalle_Reserva.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
        /// <summary>
       
        /// </summary>

        private ConciergeEntities db = new ConciergeEntities();

        // GET: SPA_Detalle_Reserva
        public ActionResult Index()
        {
            var sPA_Detalle_Reserva = db.SPA_Detalle_Reserva.Include(s => s.SPA_Encabezado_Reserva).Include(s => s.SPA_Salas).Include(s => s.SPA_Servicios).Include(s => s.SPA_Terapeutas);
            return View(sPA_Detalle_Reserva.ToList());
        }

        // GET: SPA_Detalle_Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Detalle_Reserva sPA_Detalle_Reserva = db.SPA_Detalle_Reserva.Find(id);
            if (sPA_Detalle_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Detalle_Reserva);
        }

        // GET: SPA_Detalle_Reserva/Create
        public ActionResult Create()
        {
            ViewBag.CodReserva = new SelectList(db.SPA_Encabezado_Reserva, "CodReserva", "ReservaOpera");
            ViewBag.CodSala = new SelectList(db.SPA_Salas, "CodSala", "DesSala");
            ViewBag.CodSer = new SelectList(db.SPA_Servicios, "CodSer", "NomSer");
            ViewBag.CodTerap = new SelectList(db.SPA_Terapeutas, "CodTerap", "NomTerap");
            return View();
        }

        // POST: SPA_Detalle_Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodReserva,Numreg,FecHoraRes,CodSer,CodSala,CodTerap,Notas,NomHues")] SPA_Detalle_Reserva sPA_Detalle_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.SPA_Detalle_Reserva.Add(sPA_Detalle_Reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodReserva = new SelectList(db.SPA_Encabezado_Reserva, "CodReserva", "ReservaOpera", sPA_Detalle_Reserva.CodReserva);
            ViewBag.CodSala = new SelectList(db.SPA_Salas, "CodSala", "DesSala", sPA_Detalle_Reserva.CodSala);
            ViewBag.CodSer = new SelectList(db.SPA_Servicios, "CodSer", "NomSer", sPA_Detalle_Reserva.CodSer);
            ViewBag.CodTerap = new SelectList(db.SPA_Terapeutas, "CodTerap", "NomTerap", sPA_Detalle_Reserva.CodTerap);
            return View(sPA_Detalle_Reserva);
        }

        // GET: SPA_Detalle_Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Detalle_Reserva sPA_Detalle_Reserva = db.SPA_Detalle_Reserva.Find(id);
            if (sPA_Detalle_Reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodReserva = new SelectList(db.SPA_Encabezado_Reserva, "CodReserva", "ReservaOpera", sPA_Detalle_Reserva.CodReserva);
            ViewBag.CodSala = new SelectList(db.SPA_Salas, "CodSala", "DesSala", sPA_Detalle_Reserva.CodSala);
            ViewBag.CodSer = new SelectList(db.SPA_Servicios, "CodSer", "NomSer", sPA_Detalle_Reserva.CodSer);
            ViewBag.CodTerap = new SelectList(db.SPA_Terapeutas, "CodTerap", "NomTerap", sPA_Detalle_Reserva.CodTerap);
            return View(sPA_Detalle_Reserva);
        }

        // POST: SPA_Detalle_Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodReserva,Numreg,FecHoraRes,CodSer,CodSala,CodTerap,Notas,NomHues")] SPA_Detalle_Reserva sPA_Detalle_Reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPA_Detalle_Reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodReserva = new SelectList(db.SPA_Encabezado_Reserva, "CodReserva", "ReservaOpera", sPA_Detalle_Reserva.CodReserva);
            ViewBag.CodSala = new SelectList(db.SPA_Salas, "CodSala", "DesSala", sPA_Detalle_Reserva.CodSala);
            ViewBag.CodSer = new SelectList(db.SPA_Servicios, "CodSer", "NomSer", sPA_Detalle_Reserva.CodSer);
            ViewBag.CodTerap = new SelectList(db.SPA_Terapeutas, "CodTerap", "NomTerap", sPA_Detalle_Reserva.CodTerap);
            return View(sPA_Detalle_Reserva);
        }

        // GET: SPA_Detalle_Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPA_Detalle_Reserva sPA_Detalle_Reserva = db.SPA_Detalle_Reserva.Find(id);
            if (sPA_Detalle_Reserva == null)
            {
                return HttpNotFound();
            }
            return View(sPA_Detalle_Reserva);
        }

        // POST: SPA_Detalle_Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPA_Detalle_Reserva sPA_Detalle_Reserva = db.SPA_Detalle_Reserva.Find(id);
            db.SPA_Detalle_Reserva.Remove(sPA_Detalle_Reserva);
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
