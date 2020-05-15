using System;
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
        public ActionResult UserRegistration()
        {

            if (!Authenticate.IsAuthenticated())
            {
                UserModel userModel = new UserModel();
                return View(userModel);
            }            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]

        public ActionResult UserRegistration(UserModel user)
        {
            try
            {
                UserManager.Insert(user);
                return RedirectToAction("Login", "User");
            }
            catch (Exception)
            {

                return View();
            }
            
        }

        public ActionResult DeactivateUser(int UserID)
        {
            return View();
        }
        public ActionResult PutUser(UserModel user ) => View();
        public ActionResult GetUser(int UserID) => View();
        public ActionResult GetUsers() => View();

        

        public ActionResult LogIn(string returnurl)
        {
            if (!Authenticate.IsAuthenticated())
            {

                return View();
            }

            if (string.IsNullOrEmpty(returnurl))
                return RedirectToAction("Index", "Home");
            else
                return Redirect(returnurl);
        }

        
        [HttpPost]
        
        public ActionResult LogIn(UserModel user, string returnurl)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    Session["User"] = user;
                    if (string.IsNullOrEmpty(returnurl))
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(returnurl);
                }

                ViewBag.LogInError = "Sorry no Soup for you.";
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.LogInError = ex.Message;
                return View(user);
            }               
        }
    }
}