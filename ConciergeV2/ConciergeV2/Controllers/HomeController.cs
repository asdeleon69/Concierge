using ConciergeV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (ModelState.IsValid)
            {
                {
                    var obj = db.Users.Where(a => a.Usuario.Equals(objUser.Usuario) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        FormsAuthentication.SetAuthCookie(obj.Nombre, false);
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Nombre.ToString();
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
    }
}