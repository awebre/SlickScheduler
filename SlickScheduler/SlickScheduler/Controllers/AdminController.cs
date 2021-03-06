﻿using PagedList;
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
        [Authorize]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Index(string sortOrder, string currentFilter, string search, int? page)
        {
            var currentUser = db.Users.Single(u => u.Email == HttpContext.User.Identity.Name);
            //holds the current sort order for use across multiple pages
            ViewBag.CurrentSort = sortOrder;
            //Determines which sort to link to for name and Wnumber
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.WNumSort = sortOrder == "WNum" ? "WNum_Desc" : "WNum";
            //Determine glyphicon
            string sortIconName = "glyphicon-sort";
            string sortIconWNum = sortIconName;
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
            var users = db.Users.Where(u => u.EmailConfirmed == true);
            users = users.Where(s => s.Email != currentUser.Email);
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
                    sortIconName = "glyphicon-sort-by-alphabet-alt";
                    break;
                case "WNum":
                    users = users.OrderBy(u => u.WNumber);
                    sortIconWNum = "glyphicon-sort-by-order";
                    break;
                case "WNum_Desc":
                    users = users.OrderByDescending(u => u.WNumber);
                    sortIconWNum = "glyphicon-sort-by-order-alt";
                    break;
                default:
                    users = users.OrderBy(u => u.FirstName);
                    sortIconName = "glyphicon-sort-by-alphabet";
                    break;
            }
            ViewBag.SortIconN = sortIconName;
            ViewBag.SortIconW = sortIconWNum;
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult AddAdvisor(string email)
        {
            //selects user with the email submitted from the view
            var user = db.Users.ToList().Single(u => u.Email == email);
            user.Advisor = new Advisor
            {
                AdvisorID = user.UserId,
                User = user
            };
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult DeleteAdvisor(string email)
        {
            var user = db.Users.ToList().Single(u => u.Email == email);
            db.Advisors.Remove(user.Advisor);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult AddAdmin(string email)
        {
            //gets the user you wish to add to admin status
            var user = db.Users.ToList().Single(u => u.Email == email);
            //checks if the current user has confirmed the add
                
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

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult DeleteAdmin(string email)
        {
            //gets current user
            var user = db.Users.ToList().Single(u => u.Email == email);
            //removes admin if confirmed
            db.Admins.Remove(user.Admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult ManageCourses(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.SubjSort = sortOrder == "Subj" ? "Subj_Desc" : "Subj";
            string sortIconN = "glyphicon-sort";
            string sortIconS = sortIconN;

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
                courses = courses.Where(c => c.Name.Contains(search) || c.Subject.Contains(search) || c.Number.ToString().Contains(search));
            }

            switch (sortOrder)
            {
                case "Name_Desc":
                    courses = courses.OrderByDescending(u => u.Name);
                    sortIconN = "glyphicon-sort-by-alphabet-alt";
                    break;
                case "Subj":
                    courses = courses.OrderBy(u => u.Subject);
                    sortIconS = "glyphicon-sort-by-alphabet";
                    break;
                case "Subj_Desc":
                    courses = courses.OrderByDescending(u => u.Subject);
                    sortIconS = "glyphicon-sort-by-alphabet-alt";
                    break;
                default:
                    courses = courses.OrderBy(u => u.Name);
                    sortIconN = "glyphicon-sort-by-alphabet";
                    break;
            }

            ViewBag.SortIconN = sortIconN;
            ViewBag.SortIconS = sortIconS;

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
                        newCourse.Description = course.Description;
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
        public ActionResult RemoveCourse(int courseID)
        {
            var course = db.Courses.ToList().Single(c => c.CourseId == courseID);
            if(course != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
            }
            return RedirectToAction("ManageCourses", "Admin", new { search = course.Name });
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
            string sortIcMajor = "glyphicon-sort";
            string sortIcConc = sortIcMajor;
            string sortIcCat = sortIcMajor;
            

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
                    sortIcMajor = "glyphicon-sort-by-alphabet-alt";
                    break;
                case "Conc":
                    plans = plans.OrderBy(p => p.Concentration);
                    sortIcConc = "glyphicon-sort-by-alphabet";
                    break;
                case "Conc_Desc":
                    plans = plans.OrderByDescending(p => p.Concentration);
                    sortIcConc = "glyphicon-sort-by-alphabet-alt";
                    break;
                case "Cat":
                    plans = plans.OrderBy(p => p.CatalogYear);
                    sortIcCat = "glyphicon-sort-by-order";
                    break;
                case "Cat_Desc":
                    plans = plans.OrderByDescending(p => p.CatalogYear);
                    sortIcCat = "glyphicon-sort-by-order-alt";
                    break;
                default:
                    plans = plans.OrderBy(p => p.Name);
                    sortIcMajor = "glyphicon-sort-by-alphabet";
                    break;
            }

            ViewBag.SortIconMaj = sortIcMajor;
            ViewBag.SortIconCon = sortIcConc;
            ViewBag.SortIconCat = sortIcCat;

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

            return RedirectToAction("EditPlan", "Admin", new { planId = plan.PlanId});
        }

        public ActionResult AddCourseToSem(int semesterId, int planId, string sortOrder, string search, string currentFilter, int? page)
        {
            ViewBag.PlanId = planId;
            ViewBag.SemesterId = semesterId;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.SubjSort = sortOrder == "Subj" ? "Subj_Desc" : "Subj";
            string sortIconN = "glyphicon-sort";
            string sortIconS = sortIconN;

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            var courses = from c in db.Courses
                          select c;
            if (!String.IsNullOrEmpty(search))
            {
                courses = courses.Where(c => c.Name.Contains(search) || c.Subject.Contains(search) || c.Number.ToString().Contains(search));
            }

            switch (sortOrder)
            {
                case "Name_Desc":
                    courses = courses.OrderByDescending(u => u.Name);
                    sortIconN = "glyphicon-sort-by-alphabet-alt";
                    break;
                case "Subj":
                    courses = courses.OrderBy(u => u.Subject);
                    sortIconS = "glyphicon-sort-by-alphabet";
                    break;
                case "Subj_Desc":
                    courses = courses.OrderByDescending(u => u.Subject);
                    sortIconS = "glyphicon-sort-by-alphabet-alt";
                    break;
                default:
                    courses = courses.OrderBy(u => u.Name);
                    sortIconN = "glyphicon-sort-by-alphabet";
                    break;
            }
            ViewBag.SortIconN = sortIconN;
            ViewBag.SortIconS = sortIconS;

            int pageSize = 25;
            int pageNumber = (page ?? 1);

            return View(courses.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult AddCourseToSem(int courseId, int semesterId, int planId)
        {
            var course = db.Courses.Single(c => c.CourseId == courseId);
            var semester = db.Semesters.Single(s => s.SemesterId == semesterId);
            if(semester.Plans.Count() > 1)
            {
                var plan = db.Plans.Single(p => p.PlanId == planId);
                plan.Semesters.Remove(semester);
                Semester newSem = new Semester()
                {
                    Plans = new List<Plan>(),
                    Courses = semester.Courses,
                    SemesterNum = semester.SemesterNum
                };
                newSem.Courses.Add(course);
                plan.Semesters.Insert(newSem.SemesterNum - 1, semester);
                db.SaveChanges();
            }
            else
            {
                var plan = db.Plans.Single(p => p.PlanId == planId);
                semester.Courses.Add(course);
                plan.Semesters = plan.Semesters.OrderBy(s => s.SemesterNum).ToList();
                
                db.SaveChanges();
            }

            return RedirectToAction("EditPlan", new { planId = planId });
        }
        [HttpPost]
        public ActionResult RemoveCourseFromSem(int courseId, int semesterId, int planId)
        {
            var semester = db.Semesters.Single(s => s.SemesterId == semesterId);
            var course = db.Courses.Single(c => c.CourseId == courseId);
            if (semester.Plans.Count > 1)
            {
                var plan = db.Plans.Single(p => p.PlanId == planId);
                plan.Semesters.Remove(semester);
                Semester newSem = new Semester()
                {
                    Plans = new List<Plan>(),
                    Courses = semester.Courses,
                    SemesterNum = semester.SemesterNum
                };
                newSem.Courses.Remove(course);
                plan.Semesters.Insert(newSem.SemesterNum - 1, newSem);
                db.SaveChanges();
            }
            else
            {
            semester.Courses.Remove(course);
            db.SaveChanges();
            }
            return RedirectToAction("EditPlan", new { planId = planId });
        }

        public ActionResult AddPlan()
        {
            var plan = new Plan()
            {
                Major = "Major",
                Concentration = "Concentration",
                CatalogYear = 2013,
                Name = "New Plan",
                Semesters = new List<Semester>()
            };
            for(int i = 1; i < 9; i++)
            {
                var semester = new Semester
                {
                    Courses = new List<Course>(),
                    SemesterNum = i
                };
                plan.Semesters.Add(semester);
            }
            db.Plans.Add(plan);
            db.SaveChanges();
            var newPlan = db.Plans.Single(p => p.PlanId == plan.PlanId);
            return RedirectToAction("EditPlanInfo", new { planId = newPlan.PlanId });
        }

        public ActionResult RemovePlan(int planId)
        {
            var plan = db.Plans.Single(p => p.PlanId == planId);
            var students = db.Students.ToList().FindAll(s => s.Plan == plan);
            foreach(var s in students)
            {
                db.Students.Remove(s);
            }
            db.Plans.Remove(plan);
            db.SaveChanges();
            return RedirectToAction("ManagePlans");
        }

        public ActionResult PublishPlan(int planId)
        {
            var plan = db.Plans.Single(p => p.PlanId == planId);
            plan.Published = true;
            db.SaveChanges();
            return RedirectToAction("ManagePlans");
        }

        public ActionResult UnpublishPlan(int planId)
        {
            var plan = db.Plans.Single(p => p.PlanId == planId);
            plan.Published = false;
            db.SaveChanges();
            return RedirectToAction("ManagePlans");
        }

        public ActionResult DuplicatePlan(int planId)
        {
            var plan = db.Plans.Single(p => p.PlanId == planId);
            var newPlan = new Plan()
            {
                CatalogYear = plan.CatalogYear,
                Concentration = plan.Concentration,
                Major = plan.Major,
                Name = plan.Name + " Duplicate",
                Published = false,
                Semesters = new List<Semester>()
                {
                    plan.Semesters.Single(s => s.SemesterNum == 1),
                    plan.Semesters.Single(s => s.SemesterNum == 2),
                    plan.Semesters.Single(s => s.SemesterNum == 3),
                    plan.Semesters.Single(s => s.SemesterNum == 4),
                    plan.Semesters.Single(s => s.SemesterNum == 5),
                    plan.Semesters.Single(s => s.SemesterNum == 6),
                    plan.Semesters.Single(s => s.SemesterNum == 7),
                    plan.Semesters.Single(s => s.SemesterNum == 8)
                }
            };
            db.Plans.Add(newPlan);
            db.SaveChanges();

            return RedirectToAction("ManagePlans", "Admin");

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