using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlickScheduler.Controllers
{
    public class ErrorController : Controller
    {
        //Generic Error
        public ActionResult Oops()
        {
            return View();
        }

        //401 Error
        public ActionResult Error401()
        {
            return View();
        }

        //404 Error
        public ActionResult Error404()
        {
            return View();
        }
    }
}