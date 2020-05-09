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

        #region vendor

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
        public ActionResult PutVendor(VendorModel vendor) => View();
        public ActionResult DeactivateVendor(int vendorID) => View();
        public ActionResult VendorTracker(int vendorID) => View();

        #endregion

        #region Employee

        public ActionResult AddEmployee(int userID, int vendorID) => View();
        public ActionResult PutEmployee(int userID, int vendorID) => View();
        public ActionResult GetEmployee(int userID, int vendorID) => View();
        public ActionResult GetEmployees(int vendorID) => View();

        #endregion


        #region menu

        public ActionResult CreateMenu()
        {
            UserModel userModel = (UserModel)Session["User"];
            MenuModel menuModel = new MenuModel()
            {
                VendorID = VendorManager.GetOwnerVendor(userModel.UserID).VendorID,
                IsActive = false
            };
            menuModel = MenuManager.Insert(menuModel);
            return RedirectToAction("EditMenu", "Vendor", new { id = menuModel.MenuID });
        }
        public ActionResult EditMenu(int ID)
        {
            MenuModel menuModel = MenuManager.GetMenu(ID);
            MenuMenuItemViewModel mmivm = new MenuMenuItemViewModel()
            {
                Menu = menuModel,
                MenuItems = MenuItemManager.GetMenuItems(menuModel.MenuID),
                MenuSection = MenuSectionManager.GetMenuSections(menuModel.MenuID)
            };
                        
            return View(mmivm);
        }

        public ActionResult CreateSection(int ID)
        {
            MenuSectionModel menuSectionModel = new MenuSectionModel();
            menuSectionModel.MenuID = ID;
            return View(menuSectionModel);
        }

        [HttpPost]
        public ActionResult CreateSection(MenuSectionModel menuSectionModel, int id)
        {
            try
            {
                menuSectionModel.MenuID = id;
                MenuSectionManager.Insert(menuSectionModel);
                return RedirectToAction("EditMenu", "Vendor", new {ID = id});
            }
            catch (Exception)
            {

               return View(menuSectionModel);
            }
           
        }

        public ActionResult EditSection(int ID)
        {
            MenuSectionModel menuSectionModel = MenuSectionManager.GetMenuSection(ID);
            return View(menuSectionModel);
        }

        [HttpPost]
        public ActionResult EditSection(MenuSectionModel menuSectionModel, int id)
        {
            try
            {
                MenuSectionManager.Update(menuSectionModel);
                return RedirectToAction("EditMenu", "Vendor", new { ID = menuSectionModel.MenuID });
            }
            catch (Exception)
            {

                return View(menuSectionModel);
            }

        }
        public ActionResult VendorMenus()
        {
            if (Authenticate.IsVendorOwner())
            {
                UserModel userModel = (UserModel)Session["User"];
                List<MenuModel> menuModels = MenuManager.GetVendorMenus(VendorManager.GetOwnerVendor(userModel.UserID).VendorID);
                return View(menuModels);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CreateItem(int id)
        {
            MenuItemModel menuItemModel = new MenuItemModel
            {
                MenuItem = id
            };
            return View(menuItemModel);
        }

        [HttpPost]
        public ActionResult CreateItem(int ID, MenuItemModel item)
        {
            if (ModelState.IsValid)
            {
                MenuItemManager.Insert(item);
                return RedirectToAction("EditMenu", "Vendor", new { id = item.MenuItem });
            }
            else
            {
                return View(item);
            }
        }

        public ActionResult EditItem(int ID)
        {
            MenuItemModel item = MenuItemManager.GetMenuItem(ID);

            return View(item);
        }

        [HttpPost]
        public ActionResult EditItem(int ID, MenuItemModel item)
        {
            if (ModelState.IsValid)
            {
                MenuItemManager.Update(item);
                return RedirectToAction("EditMenu", "Vendor", new { id = item.MenuItem });
            }
            else
            {
                return View(item);
            }
        }

        #endregion
    }
}