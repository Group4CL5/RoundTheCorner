using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoundTheCorner.BL;
using RoundTheCorner.BL.Models;
using RoundTheCorner.MVCUI.Models.ViewModels;

namespace RoundTheCorner.MVCUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vendor()
        {
            
            List<VendorModel> Vendors = VendorManager.GetVendors();           
            return View(Vendors);

        }

        public ActionResult VendorManagement(int id, bool? Confirm)
        {
           VendorModel vendor = VendorManager.GetVendor(id);             
            if (Confirm != null && Confirm == true)
            {
                try
                {
                    vendor.Confirmed = true;
                    VendorManager.Update(vendor);
                    return RedirectToAction("Vendor");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return View(vendor);
        }

    }
}