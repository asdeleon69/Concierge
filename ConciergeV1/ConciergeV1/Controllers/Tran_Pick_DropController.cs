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
    public class Tran_Pick_DropController : Controller
    {
        private ConciergeEntities db = new ConciergeEntities();

        // GET: Tran_Pick_Drop
        public ActionResult Index()
        {
            return View(db.Tran_Pick_Drop.ToList());
        }

        // GET: Tran_Pick_Drop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tran_Pick_Drop tran_Pick_Drop = db.Tran_Pick_Drop.Find(id);
            if (tran_Pick_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tran_Pick_Drop);
        }

        // GET: Tran_Pick_Drop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tran_Pick_Drop/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPick,DesPick")] Tran_Pick_Drop tran_Pick_Drop)
        {
            if (ModelState.IsValid)
            {
                db.Tran_Pick_Drop.Add(tran_Pick_Drop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tran_Pick_Drop);
        }

        // GET: Tran_Pick_Drop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tran_Pick_Drop tran_Pick_Drop = db.Tran_Pick_Drop.Find(id);
            if (tran_Pick_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tran_Pick_Drop);
        }

        // POST: Tran_Pick_Drop/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPick,DesPick")] Tran_Pick_Drop tran_Pick_Drop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tran_Pick_Drop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tran_Pick_Drop);
        }

        // GET: Tran_Pick_Drop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tran_Pick_Drop tran_Pick_Drop = db.Tran_Pick_Drop.Find(id);
            if (tran_Pick_Drop == null)
            {
                return HttpNotFound();
            }
            return View(tran_Pick_Drop);
        }

        // POST: Tran_Pick_Drop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tran_Pick_Drop tran_Pick_Drop = db.Tran_Pick_Drop.Find(id);
            db.Tran_Pick_Drop.Remove(tran_Pick_Drop);
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
