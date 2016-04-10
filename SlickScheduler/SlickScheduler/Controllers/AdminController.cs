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
        [AuthorizeUser(AccessLevel = "Admin")]
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
        [AuthorizeUser(AccessLevel = "Admin")]
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

        [AuthorizeUser(AccessLevel = "Admin")]
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

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult AddAdmin(string email, bool add)
        {
            //gets the user you wish to add to admin status
            var user = db.Users.ToList().Single(u => u.Email == email);
            //checks if the current user has confirmed the add
            if(add == false)
            {
                //returns the view if not confirmed
                return View(user);
            }
            else
            {
                //adds user if confirmed
                user.Admin = new Admin
                {
                    AdminId = user.UserId,
                    User = user
                };
                db.SaveChanges();
                //returns back to the admin index
                return RedirectToAction("Index", "Admin");
            }
        }

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult DeleteAdmin(string email, bool delete)
        {
            //gets current user
            var user = db.Users.ToList().Single(u => u.Email == email);
            //checks if deletion has been confirmed
            if (delete)
            {
                //removes admin if confirmed
                db.Admins.Remove(user.Admin);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                //returns deleteAdmin view if not confirmed
                return View(user);
            }
        }

        [AuthorizeUser(AccessLevel = "Admin")]
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
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = "Admin")]
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
        [AuthorizeUser(AccessLevel ="Admin")]
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
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult AddCourseToPlan(int courseID)
        {
            var course = db.Courses.ToList().Single(c => c.CourseId == courseID);
            var plans = db.Plans.ToList();
            ViewBag.Course = course;
            List<SelectListItem> semesterNums = new List<SelectListItem>();
            for(int i = 1; i < 9; i++)
            {
                semesterNums.Add(new SelectListItem
                {
                    Text = "Semester" + i,
                    Value = i.ToString()
                });
            }
            List<SelectListItem> selectPlan = new List<SelectListItem>();
            foreach (var p in plans)
            {
                selectPlan.Add(new SelectListItem
                {
                    Text = p.Name,
                    Value = p.PlanId.ToString()
                }
                    );
            }
            ViewData["SelectPlan"] = selectPlan;
            ViewData["ListSemNum"] = semesterNums;
            return View();
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult AddCourseToPlan(int courseID, string selectPlanId, string semesterNum)
        {
            int semNum = Int32.Parse(semesterNum);
            int planID = Int32.Parse(selectPlanId);
            var plan = db.Plans.ToList().Single(p => p.PlanId == planID);
            var course = db.Courses.ToList().Single(c => c.CourseId == courseID);
            var allSemesters = plan.Semesters.ToList();
            var semester = allSemesters.Single(s => s.SemesterNum == semNum );
            semester.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("ManageCourses", "Admin");
            
        }
        
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult ManagePlans(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MajorSort = String.IsNullOrEmpty(sortOrder) ? "Major_Desc" : "";
            ViewBag.ConcSort = sortOrder == "Conc" ? "Conc_Desc" : "Conc";
            ViewBag.CatSort = sortOrder == "Cat" ? "Cat_Desc" : "Cat";

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            var plans = from p in db.Plans
                          select p;
            if (!String.IsNullOrEmpty(search))
            {
                plans = plans.Where(p => p.Name.Contains(search));
            }

            switch (sortOrder)
            {
                case "Major_Desc":
                    plans = plans.OrderByDescending(p => p.Name);
                    break;
                case "Conc":
                    plans = plans.OrderBy(p => p.Concentration);
                    break;
                case "Conc_Desc":
                    plans = plans.OrderByDescending(p => p.Concentration);
                    break;
                case "Cat":
                    plans = plans.OrderBy(p => p.CatalogYear);
                    break;
                case "Cat_Desc":
                    plans = plans.OrderByDescending(p => p.CatalogYear);
                    break;
                default:
                    plans = plans.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);

            return View(plans.ToPagedList(pageNumber, pageSize));
        }

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult EditPlan(int planId)
        {
            var plan = db.Plans.Single(p => p.PlanId == planId);
            return View(plan);
        }

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult EditPlanInfo(int planId)
        {
            var plan = db.Plans.Single(p => p.PlanId == planId);
            return View(plan);
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult EditPlanInfo(Plan plan)
        {
            var dbPlan = db.Plans.Single(p => p.PlanId == plan.PlanId);
            dbPlan.Major = plan.Major;
            dbPlan.Concentration = plan.Concentration;
            dbPlan.CatalogYear = plan.CatalogYear;
            dbPlan.Name = plan.Name;
            db.SaveChanges();

            return RedirectToAction("ManagePlans");
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