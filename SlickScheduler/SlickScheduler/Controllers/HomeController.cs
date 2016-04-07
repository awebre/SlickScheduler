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

        public ActionResult Scheduler(string email)
        {
            if (Request.IsAuthenticated)
            {
                var user = new User();
                var currentUser = db.Users.ToList().Single(u => u.Email == HttpContext.User.Identity.Name);
                if (email == null)
                {
                    user = currentUser;
                } else
                {
                    user = db.Users.ToList().Single(u => u.Email == email);
                }
                
                //creates blank lists of courses
                List<Course> Math = new List<Course>();
                List<Course> English = new List<Course>();
                List<Course> Science = new List<Course>();
                List<Course> Elective = new List<Course>();
                List<Course> CMPS = new List<Course>();

                //creates blank lists of grades
                List<Grade> MathGrades = new List<Grade>();
                List<Grade> EnglishGrades = new List<Grade>();
                List<Grade> ScienceGrades = new List<Grade>();
                List<Grade> ElectiveGrades = new List<Grade>();
                List<Grade> CMPSGrades = new List<Grade>();
                if (user != null && user.Student != null)
                {
                    //creates a list of semesters based on student profile
                    var semesters = user.Student.Plan.Semesters;
                    var courses = new List<Course>();
                    //for earch semester in the list
                    foreach(var s in semesters)
                    {
                        foreach(var c in s.Courses)
                        {
                            var grade = user.Student.Grades.SingleOrDefault(g => g.Course == c);
                            if(grade == null)
                            {
                                grade = new Grade()
                                {
                                    Course = c,
                                    LetterGrade = LetterGrade.N,
                                    Student = user.Student
                                };
                                user.Student.Grades.Add(grade);
                                db.SaveChanges();
                            }
                            courses.Add(c);

                            switch (c.Subject)
                            {
                                case "MATH":
                                    Math.Add(c);
                                    MathGrades.Add(grade);
                                    break;
                                case "ENGL":
                                    English.Add(c);
                                    EnglishGrades.Add(grade);
                                    break;
                                case "PLAB":
                                    Science.Add(c);
                                    ScienceGrades.Add(grade);
                                    break;
                                case "PHYS":
                                    Science.Add(c);
                                    ScienceGrades.Add(grade);
                                    break;
                                case "CHEM":
                                    Science.Add(c);
                                    ScienceGrades.Add(grade);
                                    break;
                                case "CLAB":
                                    Science.Add(c);
                                    ScienceGrades.Add(grade);
                                    break;
                                case "GBIO":
                                    Science.Add(c);
                                    ScienceGrades.Add(grade);
                                    break;
                                case "BIOL":
                                    Science.Add(c);
                                    ScienceGrades.Add(grade);
                                    break;
                                case "CMPS":
                                    CMPS.Add(c);
                                    CMPSGrades.Add(grade);
                                    break;
                                default:
                                    Elective.Add(c);
                                    ElectiveGrades.Add(grade);
                                    break;
                            }
                        }
                       
                    }
                    //Send all this info to the view
                    ViewBag.AllCourses = courses;
                    ViewBag.Math = Math;
                    ViewBag.English = English;
                    ViewBag.Science = Science;
                    ViewBag.CMPS = CMPS;
                    ViewBag.Electives = Elective;
                    ViewBag.User = user;
                    ViewBag.MathG = MathGrades;
                    ViewBag.ScienceG = ScienceGrades;
                    ViewBag.EnglishG = ElectiveGrades;
                    ViewBag.CMPSG = CMPSGrades;
                    ViewBag.ElectiveG = ElectiveGrades;
                }

                return View();
            }

            return Redirect(Url.Action("Error401", "Error"));
        }
    }
}