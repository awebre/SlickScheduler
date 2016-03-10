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
using System.Diagnostics;
using System.Data.Entity.Migrations;

namespace SlickScheduler.Controllers
{
    public class UsersController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Users
        public ActionResult Index()
        {
            //Checks for forms authentication
            if (Request.IsAuthenticated)
            {
                //Passes plan model to view
                ViewBag.Plans = db.Plans.ToList();
                //Calls view, passing Users model to view
                return View(db.Users.ToList());
            } 
            else
            {
                //Redirects to login page if not authenticated
                return RedirectToAction("LogIn", "Users");
            }
        }

        // GET: Users/LogIn
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        //Called when user logs in
        [HttpPost]
        public ActionResult LogIn(Models.User user)
        {
            //Checks if user exists with the e-mail and password given
            if(IsValid(user.Email, user.Password))
            {
                //Gives the user an authentication cookie
                FormsAuthentication.SetAuthCookie(user.Email, false);
                //Sends the user to their profile page
                return RedirectToAction("Index", "Users");
            }
            else
            {
                //Sends an error if user is not valid
                ModelState.AddModelError("AuthError", "Incorrect Email or Password");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //Called when user registers
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //creates a database context
                    using (var db = new DataModelContext())
                    {
                        //Checks if user already exists
                        if (!(IsValid(user.Email)))
                        {
                            //creates instance of crypto
                            var crypto = new SimpleCrypto.PBKDF2();
                            //encrypts password
                            var encryptPass = crypto.Compute(user.Password);
                            //encrypts confirm password
                            var encryptConfirm = crypto.Compute(user.ConfirmPassword);
                            //creates a new user in data context
                            var newUser = db.Users.Create();
                            //Passes info to the new user
                            newUser.WNumber = user.WNumber;
                            newUser.Email = user.Email;
                            newUser.Password = encryptPass;
                            newUser.ConfirmPassword = encryptConfirm;
                            newUser.PasswordSalt = crypto.Salt;
                            newUser.FirstName = user.FirstName;
                            newUser.LastName = user.LastName;
                            newUser.UserName = user.FirstName + " " + user.LastName;
                            //Adds user to database
                            db.Users.Add(newUser);
                            db.SaveChanges();
                            //Logs user in and redirects them to the profile page
                            FormsAuthentication.SetAuthCookie(user.Email, false);
                            return RedirectToAction("Index", "Users");
                        }
                        else
                        {
                            ModelState.AddModelError("", "A user with that email already exists.");
                            return View();
                        }

                    }
                }
                else
                {
                    return View(user);
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach(var eve in e.EntityValidationErrors)
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

        public ActionResult LogOut()
        {
            //Logs the user out
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult StudentAccount()
        {
            ViewBag.Plans = db.Plans.ToList();
            return View(db.Users.ToList());
        }

        public ActionResult AdvisorAccount()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
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
        private bool IsValid(string email)
        {
            bool valid = false;
            using (var db = new DataModelContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if(user != null)
                {
                    valid = true;
                }
            }
            return valid;
        }


    }
}
