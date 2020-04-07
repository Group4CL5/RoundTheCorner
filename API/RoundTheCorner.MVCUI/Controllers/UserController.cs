﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL;
using RoundTheCorner.BL.Models;
using RoundTheCorner.MVCUI.Models;


namespace RoundTheCorner.Controllers
{
    public class UserController : Controller
    {
        //From Our Class Diagram from Project Step 8 Diagrams
        public ActionResult UserRegistration(UserModel user )
        {
            return View();
        }
        public ActionResult DeactivateUser(int UserID)
        {
            return View();
        }
        public ActionResult PutUser(UserModel user ) => View();
        public ActionResult GetUser(int UserID) => View();
        public ActionResult GetUsers() => View();

        //[ChildActionOnly]

        public ActionResult LogIn()
        {
            if (!Authenticate.IsAuthenticated())
            {
                PartialView();
            }
            return null;
        }

        //[ChildActionOnly]
        [HttpPost]
        
        public ActionResult LogIn(UserModel user)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    Session["User"] = user;
                    return RedirectToAction("FindFood");
                }

                ViewBag.LogInError = "Sorry no Soup for you.";
                return PartialView(user);

            }
            catch (Exception ex)
            {
                ViewBag.LogInError = ex.Message;
                return PartialView(user);
            }
                
        }
    }
}