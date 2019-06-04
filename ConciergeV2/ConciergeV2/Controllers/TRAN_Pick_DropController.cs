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
    public class TRAN_Pick_DropController : Controller
    {
        private ConciergeEntities1 db = new ConciergeEntities1();

        // GET: TRAN_Pick_Drop
        public ActionResult Index()
        {
            return View(db.TRAN_Pick_Drop.ToList());
        }

        // GET: TRAN_Pick_Drop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Pick_Drop tRAN_Pick_Drop = db.TRAN_Pick_Drop.Find(id);
            if (tRAN_Pick_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Pick_Drop);
        }

        // GET: TRAN_Pick_Drop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRAN_Pick_Drop/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPick,DesPick")] TRAN_Pick_Drop tRAN_Pick_Drop)
        {
            if (ModelState.IsValid)
            {
                db.TRAN_Pick_Drop.Add(tRAN_Pick_Drop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRAN_Pick_Drop);
        }

        // GET: TRAN_Pick_Drop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Pick_Drop tRAN_Pick_Drop = db.TRAN_Pick_Drop.Find(id);
            if (tRAN_Pick_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Pick_Drop);
        }

        // POST: TRAN_Pick_Drop/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPick,DesPick")] TRAN_Pick_Drop tRAN_Pick_Drop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRAN_Pick_Drop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRAN_Pick_Drop);
        }

        // GET: TRAN_Pick_Drop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAN_Pick_Drop tRAN_Pick_Drop = db.TRAN_Pick_Drop.Find(id);
            if (tRAN_Pick_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tRAN_Pick_Drop);
        }

        // POST: TRAN_Pick_Drop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRAN_Pick_Drop tRAN_Pick_Drop = db.TRAN_Pick_Drop.Find(id);
            db.TRAN_Pick_Drop.Remove(tRAN_Pick_Drop);
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
