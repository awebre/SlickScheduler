using SlickScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlickScheduler.Controllers
{
    public class HomeController : Controller
    {
        private DataModelContext db = new DataModelContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Thanks for showing interest in our team!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Scheduler()
        {

            return View();
        }
       
    }
}