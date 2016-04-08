using SlickScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlickScheduler.Controllers
{
    public class ErrorController : Controller
    {
        private DataModelContext db = new DataModelContext();
        //Generic Error
        public ActionResult Oops()
        {
            return View();
        }

        //401 Error
        public ActionResult Error401()
        {
            
            if (Request.IsAuthenticated)
            {
                var user = db.Users.Single(u => u.Email == HttpContext.User.Identity.Name);
                return View(user);
            } else
            {
                return View();
            }
        }

        //404 Error
        public ActionResult Error404()
        {
            return View();
        }
    }
}