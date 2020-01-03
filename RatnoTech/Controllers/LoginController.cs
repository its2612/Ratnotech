using RatnoTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace RatnoTech.Controllers
{
    public class LoginController : Controller
    {
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.Authorize]
        public ActionResult Profile()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Index(User1 user)
        {
            RatnoTechEntities1 usersEntities = new RatnoTechEntities1();
            int? userId = usersEntities.Validate_User(user.Username, user.Password).FirstOrDefault();

            string message = string.Empty;
            switch (userId.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Account has not been activated.";
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    return RedirectToAction("Profile");
                    break;
                default:
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    return RedirectToAction("Profile");
            }

            ViewBag.Message = message;
            return View(user);
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}
