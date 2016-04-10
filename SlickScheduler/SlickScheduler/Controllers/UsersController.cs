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
using System.Net.Mail;
using System.Threading.Tasks;

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

        [HttpGet]
        [AuthorizeUser(AccessLevel ="Student")]
        public ActionResult StudentAccount()
        {
            //Passes plans and advisors to view
            ViewBag.Plans = db.Plans.ToList();
            ViewBag.Advisors = db.Advisors.ToList();
            return View();
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel ="Student")]
        public ActionResult StudentAccount(Plan plan)
        {
            var allUsers = db.Users.ToList();
            var currentUser = allUsers.Single(u => u.Email == HttpContext.User.Identity.Name);
            var _plan = Request.Form["selectPlan"];
            int id = Convert.ToInt32(_plan);
            if (currentUser.Student == null)
            {
                //Adds new student to current user
                currentUser.Student = new Student
                {
                    Plan = db.Plans.ToList().Single(p => p.PlanId == id)
                };
                //saves database changes
                db.SaveChanges();
            }
            else
            {
                db.Grades.RemoveRange(currentUser.Student.Grades);
                db.SaveChanges();
                //removes student before adding new plan
                db.Students.Remove(currentUser.Student);
                currentUser.Student = new Student
                {
                    Plan = db.Plans.ToList().Single(p => p.PlanId == id)
                };
                db.SaveChanges();
            }
            
            /* GOING TO MOVE THIS TO A SEPERATE VIEW
            //Creates a message to be sent via MailMessage
            var message = new MailMessage();
            message.To.Add(new MailAddress(advisor.User.Email));
            message.From = new MailAddress(currentUser.Email);
            message.Subject = "Slick Scheduler: " + currentUser.FirstName + " " + currentUser.LastName + " - Student Request";
            message.Body = "<h5>" + currentUser.FirstName + currentUser.LastName +
                "</h5><p> has requested you be their advisor. You can find them at <a>SlickScheduler</a> by searching" +
                "their WNumber: " + currentUser.WNumber + "</p>";

            //creates an smtp client to use to send the mail
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "selu.slick@gmail.com",
                    Password = "creamofthecrop"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
            */

            return RedirectToAction("Index", "Users");
        }
        [Authorize]
        public async Task<ActionResult> AdvisorAccount(bool sendRequest)
        {
            if (sendRequest)
            {
                var admin = db.Admins.First(a => a.AdminId == 1);
                var currentUser = db.Users.ToList().Single(u => u.Email == HttpContext.User.Identity.Name);
                var message = new MailMessage();
                message.To.Add(new MailAddress(admin.User.Email));
                message.From = new MailAddress(currentUser.Email);
                message.Subject = "Slick Scheduler: " + currentUser.FirstName + " " + currentUser.LastName + " - Advisor Request";
                message.Body = "<p><h4>" + currentUser.FirstName + " " + currentUser.LastName +
                    "</h4> has requested you be made an advisor. You can find their profile at <a>SlickScheduler</a> by searching" +
                    " WNumber: " + currentUser.WNumber + "</p>";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "selu.slick@gmail.com",
                        Password = "creamofthecrop"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }

                return RedirectToAction("Index", "Users");
            }
            else
            {
                return View();
            }

        }

        /*
        [HttpPost]
        public async Task<ActionResult> AdvisorAccount(Admin admin)
        {
            var currentUser = db.Users.ToList().Single(u => u.Email == HttpContext.User.Identity.Name);
            var message = new MailMessage();
            message.To.Add(new MailAddress(admin.User.Email));
            message.From = new MailAddress(currentUser.Email);
            message.Subject = "Slick Scheduler: " + currentUser.FirstName + " " + currentUser.LastName + " - Advisor Request";
            message.Body = "<h5>" + currentUser.FirstName + currentUser.LastName +
                "</h5><p> has requested you be made an advisor. You can find their profile at <a>SlickScheduler</a> by searching" +
                " WNumber: " + currentUser.WNumber + "</p>";

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "selu.slick@gmail.com",
                    Password = "creamofthecrop"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }

            return RedirectToAction("Index", "Users");
        }
        */

        [HttpGet]
        public ActionResult ChangePassword(string email, string securityToken)
        {
            if (Request.IsAuthenticated)
            {
                var allUsers = db.Users.ToList();
                var user = allUsers.Single(u => u.Email == HttpContext.User.Identity.Name);

                EditUser model = new EditUser();
                model.WNumber = user.WNumber;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;

                return View(model);
            }
            else if (!String.IsNullOrEmpty(email) && IsValid(email))
            {
                var user = db.Users.Single(u => u.Email == email);
                if(user.SecurityToken == securityToken)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    user.SecurityToken = SimpleCrypto.RandomPassword.Generate(20, 100);
                    db.SaveChanges();
                    return RedirectToAction("ChangePassword", "Users");
                }
                else
                {
                    return RedirectToAction("Oops", "Error");
                }
            } else
            {
                return RedirectToAction("Oops", "Error");
            }
            #region
            /* OBSOLETE OR UNUSED
            model.Email = user.Email;
            model.Password = user.Password;
            model.NewPassword = "";
            model.ConfirmPassword = "";
            */
            #endregion
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(EditUser user)
        {
            if (ModelState.IsValid)
            {

                //gets the user
                var allUsers = db.Users.ToList();
                var currentUser = allUsers.Single(u => u.Email == HttpContext.User.Identity.Name);

                //updates information
                currentUser.WNumber = user.WNumber;
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = currentUser.Email;
                currentUser.Password = currentUser.Password;
                currentUser.ConfirmPassword = currentUser.ConfirmPassword;
                currentUser.SecurityToken = SimpleCrypto.RandomPassword.Generate(20, 100);

         
                //saves changes
                //requires that the confirm password be mapped to database to validate user.
                db.Entry(currentUser).State = EntityState.Modified;
                db.GetValidationErrors();
                db.SaveChanges();
                //Sends the user to their profile page
                return RedirectToAction("Index", "Users");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Save()
        {
            var allUsers = db.Users.ToList();
            User user = allUsers.Single(u => u.Email == HttpContext.User.Identity.Name);

            EditUser model = new EditUser();
            model.WNumber = user.WNumber;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
           // model.Email = user.Email;
           // model.Password = user.Password;
          //  model.NewPassword = "";
            //model.ConfirmPassword = "";
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Save(EditUser user)
        {
            if (ModelState.IsValid)
            {
                //gets the user
                var allUsers = db.Users.ToList();
                var currentUser = allUsers.Single(u => u.Email == HttpContext.User.Identity.Name);
                //updates information
                currentUser.WNumber = user.WNumber;
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                //currentUser.Email = user.Email;
                //saves changes
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                //Sends the user to their profile page
                return RedirectToAction("Index", "Users");
            }
            return View(user);
        }

        public async Task<ActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                ViewBag.Message = "";
                return View();
            }
            else if (IsValid(email))
            {
                var user = db.Users.Single(u => u.Email == email);
                var message = new MailMessage();
                var link = Url.Action("ChangePassword", "Users", new { email = user.Email, securityToken = user.SecurityToken });
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress("selu.slick@gmail.com");
                message.Subject = "Slick Scheduler: Forgot Password Request";
                message.Body = "<p>Someone requested a password change for a Slick Scheduler Account" +
                    "at " + email + ". If you are not the one who requested this change, ignore this email." +
                    " If you did request this change, follow the following link: " + "<a href =" + link + ">" + link + "</a>" + "</p>";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "selu.slick@gmail.com",
                        Password = "creamofthecrop"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
                return RedirectToAction("ConfirmSent", "Users", new { email = user.Email });
            }
            else
            {
                ViewBag.Message = "The email you entered is not valid!";
                return View();
            }
        }

        public ActionResult ConfirmSent(string email)
        {
            ViewBag.Email = email;
            return View();
        }

        //checks if in email or password already exists
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

        //checks if an email or password exists
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
