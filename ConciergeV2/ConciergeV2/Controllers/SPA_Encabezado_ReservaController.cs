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
        private ConciergeEntities1 db = new ConciergeEntities1();

        // GET: SPA_Encabezado_Reserva
        public ActionResult Index()
        {
            return View(db.SPA_Encabezado_Reserva.ToList());
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
            db.SPA_Detalle_Reserva.RemoveRange(db.SPA_Detalle_Reserva.Where(a => a.CodReserva == id));
            db.SaveChanges();
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

        //Listar servicios
        public JsonResult GetServicios()
        {
            var Servicios = (from r in db.SPA_Servicios
                       select new
                       {
                           r.CodSer,
                           r.DesSer
                       }).ToList();

            return new JsonResult { Data = Servicios, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Listar terapeutas
        public JsonResult GetTerapeutas()
        {
            var Terapeutas = (from r in db.SPA_Terapeutas
                       select new
                       {
                           r.CodTerap,
                           r.NomTerap
                       }).ToList();

            return new JsonResult { Data = Terapeutas, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Listar Salas
        public JsonResult GetSalas()
        {
            var Salas = (from r in db.SPA_Salas
                       select new
                       {
                           r.CodSala,
                           r.DesSala
                       }).ToList();

            return new JsonResult { Data = Salas, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Obtener Precio Servicio
        public ActionResult GetPrecioServicio(String Servicios)
        {
            try
            {
                return Json(db.SPA_Servicios.Where(c => c.CodSer == Servicios)
                                    .Select(a => new
                                    {
                                        a.PreSer
                                    }).SingleOrDefault(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { PreSer = 0 });
            }
        }

        [HttpPost]
        public JsonResult GuardarReserva(SPA_Encabezado_Reserva Det)
        {
            bool status = true;
            if (ModelState.IsValid)
            {
                try
                {
                    //Guardando
                    Det.UsrReg = "admin";//Session["Usr"].ToString();

                    db.SPA_Encabezado_Reserva.Add(Det);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            //Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            //    ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }
                //catch (Exception)
                //{
                //    status = false;
                //}
            }
            return new JsonResult { Data = new { status = status } }; 
        }
    }
}
