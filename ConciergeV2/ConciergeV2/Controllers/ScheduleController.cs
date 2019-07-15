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
    [Authorize]
    public class ScheduleController : Controller
    {
        private Models.ConciergeEntities1 db = new Models.ConciergeEntities1();
        
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            try
            {
                var Reg = (from r in db.SPA_Detalle_Reserva
                           select new
                           {
                               r.CodReserva,
                               des = "Servicio de " + r.SPA_Servicios.DesSer + ", atendido por " + r.SPA_Terapeutas.NomTerap + " en sala " + r.SPA_Salas.CarSala,
                               r.FecHoraRes,
                               r.NomHues,
                               r.Notas,
                               r.Numreg
                           }).ToList()
                           .Select(x => new
                           {
                               x.CodReserva,
                               x.des,
                               x.FecHoraRes,
                               x.NomHues,
                               x.Notas,
                               x.Numreg
                           }).AsEnumerable();
                return new JsonResult { Data = Reg, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = "Error ", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}