using ConciergeV2.Controllers;
using ConciergeV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConciergeV2.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private User oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (User)HttpContext.Current.Session["UserID"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is HomeController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Home/Login");
                    }
                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }

        }
    }
}