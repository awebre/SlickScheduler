using PagedList;
using SlickScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlickScheduler.Controllers
{
    public class AdvisorController : Controller
    {
        private DataModelContext db = new DataModelContext();
        // GET: Advisor
        public ActionResult Index(string search, string sortOrder, string currentFilter, int? page)
        {
            //holds the current sort order for use across multiple pages
            ViewBag.CurrentSort = sortOrder;
            //Determines which sort to link to for name and Wnumber
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.WNumSort = sortOrder == "WNum" ? "WNum_Desc" : "WNum";
            var students = db.Users.Where(u => u.Student != null);
            if(search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            if (search != null)
            {
                students = students.Where(u => u.WNumber.Contains(search) || u.FirstName.Contains(search) || u.LastName.Contains(search));
            }

            ViewBag.CurrentFilter = search;
            //sorts the data
            switch (sortOrder)
            {
                case "Name_Desc":
                    students = students.OrderByDescending(u => u.FirstName);
                    break;
                case "WNum":
                    students = students.OrderBy(u => u.WNumber);
                    break;
                case "WNum_Desc":
                    students = students.OrderByDescending(u => u.WNumber);
                    break;
                default:
                    students = students.OrderBy(u => u.FirstName);
                    break;
            }
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View((PagedList<User>)students.ToPagedList(pageNumber, pageSize));
        }
    }
}