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
            if (Request.IsAuthenticated)
            {
                //gets the current user
                var currentUser = db.Users.ToList().Single(u => u.Email == HttpContext.User.Identity.Name);
                //creates blank lists of courses
                List<Course> Math = new List<Course>();
                List<Course> English = new List<Course>();
                List<Course> Science = new List<Course>();
                List<Course> History = new List<Course>();
                List<Course> Elective = new List<Course>();
                List<Course> CMPS = new List<Course>();
                if (currentUser != null && currentUser.Student != null)
                {
                    //creates a list of semesters based on student profile
                    var semesters = currentUser.Student.Plan.Semesters;
                    var courses = new List<Course>();
                    //for earch semester in the list
                    foreach (var s in semesters)
                    {
                        //and each course in that semester
                        foreach (var c in s.Courses)
                        {
                            //add that course to the total courses
                            courses.Add(c);
                            //add that course to a particular subject
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
                    //Send all this info to the view
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

            return Redirect(Url.Action("Error401", "Error"));
        }
    }
}