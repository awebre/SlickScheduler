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
            var currentUser = db.Users.ToList().Single(u => u.Email == HttpContext.User.Identity.Name);
            List<Course> Math = new List<Course>();
            List<Course> English = new List<Course>();
            List<Course> Science = new List<Course>();
            List<Course> History = new List<Course>();
            List<Course> Elective = new List<Course>();
            List<Course> CMPS = new List<Course>();
            var semesters = currentUser.Student.Plan.Semesters;
            var courses = new List<Course>();
            if (currentUser != null && currentUser.Student != null)
            {
                foreach (var s in semesters)
                {
                    foreach (var c in s.Courses)
                    {
                        courses.Add(c);
                        switch (c.Subject)
                        {
                            case "MATH":
                                Math.Add(c);
                                break;
                            case "ENGL":
                                English.Add(c);
                                break;
                            case "SCI":
                                Science.Add(c);
                                break;
                            case "HIST":
                                History.Add(c);
                                break;
                            case "CMPS":
                                CMPS.Add(c);
                                break;
                            default:
                                Elective.Add(c);
                                break;
                        }
                    }
                }
                ViewBag.AllCourses = courses;
                ViewBag.Math = Math;
                ViewBag.English = English;
                ViewBag.Science = Science;
                ViewBag.History = History;
                ViewBag.CMPS = CMPS;
                ViewBag.Electives = Elective;
                ViewBag.CurrentUser = currentUser;
            }

            return View();
        }
    }
}