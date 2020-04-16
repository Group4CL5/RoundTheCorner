using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;
using RoundTheCorner.BL;
using RoundTheCorner.MVCUI.Models.ViewModels;
using RoundTheCorner.MVCUI.Models;

namespace RoundTheCorner.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor


        // Diagrams for Project 8
        public ActionResult VendorRegistration()
        {
            if (Authenticate.IsAuthenticated()) return View();
            else return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult VendorRegistration(VendorModel Vendor)
        {
            try
            {
                UserModel user = (UserModel)Session["User"];
                Vendor.OwnerID = user.UserID;
                VendorManager.Insert(Vendor);
                ViewBag.Success = "Thank you for registering. Your form is being reviewed.";
                return View();
            }
            catch (Exception ex)
            {
               ViewBag.Message = ex;
               return View();
            }
        }
        public ActionResult AddEmployee(int userID, int vendorID) => View();
        public ActionResult PutEmployee(int userID, int vendorID) => View();
        public ActionResult GetEmployee(int userID, int vendorID) => View();
        public ActionResult GetEmployees(int vendorID) => View();
        public ActionResult PutVendor(VendorModel vendor) => View();
        public ActionResult DeactivateVendor(int vendorID) => View();
        public ActionResult VendorTracker(int vendorID) => View();

    }
}