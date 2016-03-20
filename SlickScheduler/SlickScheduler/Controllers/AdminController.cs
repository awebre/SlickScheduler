using SlickScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlickScheduler.Controllers
{
    public class AdminController : Controller
    {
        private DataModelContext db = new DataModelContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Users = db.Users.ToList();
            return View();
        }
    }
}