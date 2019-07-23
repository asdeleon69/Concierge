using ConciergeV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ConciergeV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(String message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private ConciergeEntities1 db = new ConciergeEntities1();
        public ActionResult Login()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (objUser.Usuario != null && objUser.Password != null)
            {
                {
                    var obj = db.Users.Where(a => a.Usuario.Equals(objUser.Usuario) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null && obj.Activo == true)
                    {
                        FormsAuthentication.SetAuthCookie(obj.Nombre, false);
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Nombre.ToString();
                        Session["Nivel"] = obj.Nivel.ToString();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Index("Usuario o password incorrectos / No se encuentran los datos.");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult SingOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

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