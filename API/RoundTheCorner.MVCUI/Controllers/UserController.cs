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
            UserModel userModel = new UserModel();
            return View(userModel);
        }

        [HttpPost]

        public ActionResult UserRegistration(UserModel user)
        {
            try
            {
                UserManager.Insert(user);
                return RedirectToAction("FindFood", "Vendor");
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

        

        public ActionResult LogIn()
        {
            if (!Authenticate.IsAuthenticated())
            {

                return PartialView();
            }
            return null;
        }

        
        [HttpPost]
        
        public ActionResult LogIn(UserModel user)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    Session["User"] = user;
                    return Redirect("Vendor/FindFood");
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