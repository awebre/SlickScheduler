using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using SlickScheduler.Models;
using System.Data.Entity.Validation;

namespace SlickScheduler.Controllers
{
    public class UsersController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/LogIn
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.User user)
        {
            if(IsValid(user.Email, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect Email or Password");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new DataModelContext())
                    {
                        var crypto = new SimpleCrypto.PBKDF2();
                        var encryptPass = crypto.Compute(user.Password);
                        var newUser = db.Users.Create();
                        newUser.Email = user.Email;
                        newUser.Password = encryptPass;
                        newUser.PasswordSalt = crypto.Salt;
                        newUser.FirstName = user.FirstName;
                        newUser.LastName = user.LastName;
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach(var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }




        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool valid = false;

            using (var db = new DataModelContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if(user != null)
                {
                    if(user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        valid = true;
                    }
                }
            }

            return valid;
        }

       
    }
}
