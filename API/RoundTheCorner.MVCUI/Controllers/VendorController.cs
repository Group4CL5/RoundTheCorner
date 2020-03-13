using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult FindFood()
        {
            return View();
        }

        // Diagrams for Project 8
        public ActionResult VendorRegistration(VendorModel Vendor) => View();
        public ActionResult AddEmployee(int userID, int vendorID) => View();
        public ActionResult PutEmployee(int userID, int vendorID) => View();
        public ActionResult GetEmployee(int userID, int vendorID) => View();
        public ActionResult GetEmployees(int vendorID) => View();
        public ActionResult PutVendor(VendorModel vendor) => View();
        public ActionResult DeactivateVendor(int vendorID) => View();
        public ActionResult VendorTracker(int vendorID) => View();

    }
}