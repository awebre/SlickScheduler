using PagedList;
using SlickScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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

        [HttpGet]
        public ActionResult AddAdvisor(string email, bool add)
        {
            //selects user with the email submitted from the view
            var user = db.Users.ToList().Single(u => u.Email == email);
            if (add == false)
            {
                //if add is false we go to the add Advisor page
                return View(user);
            }
            else
            {
                //otherwise create a new advisor and connect it to the user
                user.Advisor = new Advisor
                {
                    AdvisorID = user.UserId,
                    User = user
                };
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult DeleteAdvisor(string email, bool delete)
        {
            var user = db.Users.ToList().Single(u => u.Email == email);
            if(delete == false)
            {
                return View(user);
            }
            else
            {
                db.Advisors.Remove(user.Advisor);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult AddAdmin(string email, bool add)
        {
            var user = db.Users.ToList().Single(u => u.Email == email);
            if(add == false)
            {
                return View(user);
            }
            else
            {
                user.Admin = new Admin
                {
                    AdminId = user.UserId,
                    User = user
                };
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult ManageCourses(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.SubjSort = sortOrder == "Subj" ? "Subj_Desc" : "Subj";

            if(search != null)
            {
                page = 1;
            } else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            var courses = from c in db.Courses
                          select c;
            if (!String.IsNullOrEmpty(search))
            {
                courses = courses.Where(c => c.Name.Contains(search) || c.Subject.Contains(search));
            }

            switch (sortOrder)
            {
                case "Name_Desc":
                    courses = courses.OrderByDescending(u => u.Name);
                    break;
                case "Subj":
                    courses = courses.OrderBy(u => u.Subject);
                    break;
                case "Subj_Desc":
                    courses = courses.OrderByDescending(u => u.Subject);
                    break;
                default:
                    courses = courses.OrderBy(u => u.Name);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            
            return View(courses.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!CourseExists(course.Name))
                    {
                        var newCourse = db.Courses.Create();
                        newCourse.Name = course.Name;
                        newCourse.Subject = course.Subject;
                        newCourse.Number = course.Number;
                        newCourse.CreditHours = course.CreditHours;
                        db.Courses.Add(newCourse);
                        db.SaveChanges();
                        return RedirectToAction("ManageCourses", "Admin", new { search = course.Name });
                    } 
                    else
                    {
                        ModelState.AddModelError("", "That courses already exists");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Your Model State was Invalid");
                    return View();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public ActionResult RemoveCourse(int courseID, bool remove)
        {
            var course = db.Courses.ToList().Single(c => c.CourseId == courseID);
            if (remove)
            {
                if(course != null)
                {
                    db.Courses.Remove(course);
                    db.SaveChanges();
                }
                return RedirectToAction("ManageCourses", "Admin", new { search = course.Name });
            }
            else
            {
                return View(course);
            }
        }

        [HttpGet]
        public ActionResult AddCourseToPlan(int courseID)
        {
            var course = db.Courses.ToList().Single(c => c.CourseId == courseID);
            var plans = db.Plans.ToList();
            ViewBag.Course = course;
            return View(plans);
        }
        [HttpPost]
        public ActionResult AddCourseToPlan(int courseID, Plan plan, int semesterNum)
        {
            var course = db.Courses.ToList().Single(c => c.CourseId == courseID);
            var semester = plan.Semesters.ToList().Single(s => s.SemesterNum == semesterNum);
            semester.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("ManageCourses", "Admin");
            
        }

        private bool CourseExists(string courseName)
        {
            bool exists = false;
            var allCourses = db.Courses.ToList();
            //finds the first course in the list that has the course name
            var course = allCourses.FirstOrDefault(c => c.Name == courseName);
            if(course != null)
            {
                exists = true;
            }
            return exists;
        }
    }
}