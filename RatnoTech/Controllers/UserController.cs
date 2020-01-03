
using RatnoTech.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Mvc;



namespace RatnoTech.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Register()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Register(Registration U)
        {
            if (ModelState.IsValid)
            {
                using (RatnoTechEntities1 dc = new RatnoTechEntities1())
                {
                    dc.Registrations.Add(U);
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return View(U);
        }

        public ActionResult Login()
        {
            Login_Credentials lc = new Login_Credentials();
            return View(lc);
        }


        [HttpPost]
        public ActionResult Login(Login_Credentials lc)
        {
           ObjectParameter output = new ObjectParameter("IsValid", typeof(int));
            if (ModelState.IsValid)
            {
                RatnoTechEntities1 rt = new RatnoTechEntities1();
                
                var i=rt.Sp_Login(lc.Username, lc.Password,output);
                if (i == 1)
                {

                    Session["login"] = 1;
                    return RedirectToAction("Index", "Home");

                }

            }
           
            return RedirectToAction("Register", "User");
        }







       
        public ActionResult logout()
        {
            return View();
        }







       
    }
}
