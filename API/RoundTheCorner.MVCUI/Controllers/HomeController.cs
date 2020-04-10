using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoundTheCorner.BL;
using RoundTheCorner.BL.Models;
using RoundTheCorner.MVCUI.Models.ViewModels;
using RoundTheCorner.PL;

namespace RoundTheCorner.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public ActionResult Index(string Cuisine)
        {
            List<VendorCuisineLocationRating> VCLR = new List<VendorCuisineLocationRating>();
            List<VendorModel> Vendors = VendorManager.GetVendors();

            if (!string.IsNullOrEmpty(Cuisine))

            {

                ViewBag.Cuisine = Cuisine;
            }

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

        public ActionResult AboutUs()
        {
            return View();
        }

  
        public ActionResult Privacy()
        {
            return View();
        }

       

    }
}
