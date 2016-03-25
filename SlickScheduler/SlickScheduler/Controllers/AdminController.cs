using PagedList;
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
        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string search, int? page)
        {
            //holds the current sort order for use across multiple pages
            ViewBag.CurrentSort = sortOrder;
            //Determines which sort to link to for name and Wnumber
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.WNumSort = sortOrder == "WNum" ? "WNum_Desc" : "WNum";
            //Determins if this is the first page and handles filters
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            //saves current filter for use in view
            ViewBag.CurrentFilter = search;

            //sets up a list of users
            var users = from u in db.Users
                        select u;
            //gets whatever users match the current search
            if (!String.IsNullOrEmpty(search))
            {
                users = users.Where(s => s.FirstName.Contains(search) || s.LastName.Contains(search) || s.WNumber.Contains(search));
            }

            //sorts the data
            switch (sortOrder)
            {
                case "Name_Desc":
                    users = users.OrderByDescending(u => u.FirstName);
                    break;
                case "WNum":
                    users = users.OrderBy(u => u.WNumber);
                    break;
                case "WNum_Desc":
                    users = users.OrderByDescending(u => u.WNumber);
                    break;
                default:
                    users = users.OrderBy(u => u.FirstName);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Scheduler(User user)
        {
            if (Request.IsAuthenticated)
            {
                //creates blank lists of courses
                List<Course> Math = new List<Course>();
                List<Course> English = new List<Course>();
                List<Course> Science = new List<Course>();
                List<Course> Elective = new List<Course>();
                List<Course> CMPS = new List<Course>();
                if (user != null && user.Student != null)
                {
                    //creates a list of semesters based on student profile
                    var semesters = user.Student.Plan.Semesters;
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
                                case "PLAB":
                                    Science.Add(c);
                                    break;
                                case "PHYS":
                                    Science.Add(c);
                                    break;
                                case "CHEM":
                                    Science.Add(c);
                                    break;
                                case "CLAB":
                                    Science.Add(c);
                                    break;
                                case "GBIO":
                                    Science.Add(c);
                                    break;
                                case "BIOL":
                                    Science.Add(c);
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
                    ViewBag.CMPS = CMPS;
                    ViewBag.Electives = Elective;
                    ViewBag.User = user;
                }

                return View();
            }

            return Redirect(Url.Action("Error401", "Error"));
        }
        
    }
}