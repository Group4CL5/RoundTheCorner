using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;
using RoundTheCorner.BL;
using RoundTheCorner.MVCUI.Models.ViewModels;

namespace RoundTheCorner.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult FindFood()
        {
            List<VendorCuisineLocationRating> VCLR = new List<VendorCuisineLocationRating>();
            List<VendorModel> Vendors = VendorManager.GetVendors();

            foreach (VendorModel item in Vendors)
            {
                VCLR.Add(new VendorCuisineLocationRating
                {
                    Vendor = item,
                    VendorLocation = VendorLocationManager.GetVendorLocation(item.VendorID),
                    Reviews = ReviewManager.GetReviews(item.VendorID),
                    Cuisine = CuisineManager.GetCuisine(item.VendorID)

                });
            }
            return View(VCLR);
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