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
    public class UsersController : Controller
    {
        private ConciergeEntities1 db = new ConciergeEntities1();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user, String PasswordConfirm)
        {
            if (db.Users.Any(a => a.Usuario == user.Usuario))
            {
                ModelState.AddModelError("Usuario", "Este usuario ya existe.");
            }
            if (user.Password != PasswordConfirm)
            {
                ModelState.AddModelError("ConfirmPassword", "El password no coincide.");
            }
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(user).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(user);

            if (user != null)
            {
                
                ConciergeEntities1 db_Aux = new ConciergeEntities1();
                var Upd = db_Aux.Users.Find(user.Id);
                if (Upd != null)
                {
                    //Actulizando datos
                    Upd.Nombre = user.Nombre;
                    Upd.Nivel = user.Nivel;
                    Upd.Activo = user.Activo;
                    db_Aux.Entry(Upd).CurrentValues.SetValues(Upd);
                    db_Aux.SaveChanges();
                }
                return RedirectToAction("Index");
                
            }
            return View(user);

        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        // GET: Users/Edit/5
        public ActionResult EditPassword(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword(User user, String PasswordConfirm)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(user).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            if (user != null)
            {
            if (user.Password == PasswordConfirm)
            {
                ConciergeEntities1 db_Aux = new ConciergeEntities1();
                var Upd = db_Aux.Users.Find(user.Id);
                if (Upd != null)
                {
                    //Actulizando datos
                    Upd.Password = user.Password;
                    db_Aux.Entry(Upd).CurrentValues.SetValues(Upd);
                    db_Aux.SaveChanges();
                }
                return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("ConfirmPassword", "El password no coincide.");
                }
            }
            return View(user);
        }
    }
}
