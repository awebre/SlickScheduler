using SlickScheduler.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SlickScheduler.Controllers
{
    internal class AuthorizeUserAttribute : AuthorizeAttribute
    {
        private DataModelContext db = new DataModelContext();
        public string AccessLevel { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            var user = db.Users.Single(u => u.Email == httpContext.User.Identity.Name);
            string role = "";
            if (user.Student != null)
            {
                role += "Student";
            }
            if (user.Advisor != null)
            {
                role += "Advisor";
            }
            if (user.Admin != null)
            {
                role += "Admin";
            }

            if (role.Contains(this.AccessLevel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Error",
                                action = "Error401"
                            })
                        );
        }
    }
}