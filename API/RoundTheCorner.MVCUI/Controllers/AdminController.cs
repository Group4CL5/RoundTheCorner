using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoundTheCorner.BL;
using RoundTheCorner.BL.Models;
using RoundTheCorner.MVCUI.Models.ViewModels;
using RoundTheCorner.MVCUI.Models;

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

        public ActionResult UserManagement()
        {
            List<UserModel> userModels = UserManager.GetUsers();
            return View(userModels);
        }
        
        [HttpGet]
        public ActionResult UserEdit(int ID)
        {
            UserModel user = UserManager.GetUser(ID);
            return View(user);
        }

        [HttpPost]
        public ActionResult UserEdit(int ID, UserModel user)
        {
            try
            {
                UserManager.Update(user);
                return RedirectToAction("UserManagement");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult UserDetails(int ID)
        {
            UserModel user = UserManager.GetUser(ID);
            return View(user);
        }

        public ActionResult UserDelete(int ID)
        {
            try
            {
                UserModel user = UserManager.GetUser(ID);
                return View(user);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        [HttpPost]
        public ActionResult UserDelete(int ID, UserModel user)
        {
            try
            {
                UserManager.Delete(ID);
                return RedirectToAction("UserManagement");
            }
            catch (Exception)
            {
                throw;
            }

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