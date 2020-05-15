using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;
using RoundTheCorner.BL;
using RoundTheCorner.MVCUI.Models.ViewModels;
using RoundTheCorner.MVCUI.Models;
using System.Runtime.Remoting.Messaging;

namespace RoundTheCorner.Controllers
{
    public class VendorController : Controller
    {
        public ActionResult Index() => View();

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

        public ActionResult AddEmployee()
        {
            List<UserModel> users = UserManager.GetUsers();
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in users)
            {
                selectListItems.Add(new SelectListItem { Text = $"{item.FirstName} {item.LastName}", Value = item.UserID.ToString() });
            }
            ViewBag.UserList = selectListItems;
            UserModel userModel = (UserModel)Session["User"];
            ViewBag.Vendor = (VendorManager.GetOwnerVendor(userModel.UserID)).VendorID;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(string UserList, VendorEmployeeModel vm)
        {
            UserModel userModel = (UserModel)Session["User"];
            vm.VendorID = VendorManager.GetOwnerVendor(userModel.UserID).VendorID;
            vm.UserID = int.Parse(UserList);
            VendorEmployeeManager.Insert(vm);

            TempData["Message"] = "Employee has been hired";
            return RedirectToAction("GetEmployees", "Vendor");
        }

        public ActionResult FireEmployee(int id)
        {
            VendorEmployeeModel vm = VendorEmployeeManager.GetVendorEmployee(id);
            EmployeeVendorViewModel evvm = new EmployeeVendorViewModel();
            evvm.User = UserManager.GetUser(vm.UserID);
            evvm.Vendor = VendorManager.GetVendor(vm.VendorID);

            return View(evvm);
        }

        [HttpPost]
        public ActionResult FireEmployee(int id, EmployeeVendorViewModel vm)
        {
            VendorEmployeeManager.Delete(id);
            return RedirectToAction("GetEmployees", "Vendor");
        }

        public ActionResult GetEmployee(int id)
        {
            VendorEmployeeModel vm = VendorEmployeeManager.GetVendorEmployee(id);
            EmployeeVendorViewModel evvm = new EmployeeVendorViewModel();
            evvm.Employee = vm;
            evvm.User = UserManager.GetUser(vm.UserID);
            evvm.Vendor = VendorManager.GetVendor(vm.VendorID);

            return View(evvm);
        }

        public ActionResult GetEmployees()
        {
            if (Authenticate.IsVendorOwner())
            {
                UserModel userModel = (UserModel)Session["User"];
                
                VendorModel vendor = VendorManager.GetOwnerVendor(userModel.UserID);
                List<VendorEmployeeModel> employees = VendorEmployeeManager.GetVendorEmployees(vendor.VendorID);

                List<EmployeeVendorViewModel> evvm = new List<EmployeeVendorViewModel>();

                foreach (var item in employees)
                {
                    evvm.Add(new EmployeeVendorViewModel
                    {
                        User = UserManager.GetUser(item.UserID),
                        Employee = item,
                        Vendor = vendor
                    });
                }

                return View(evvm);
            }
            return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url.AbsolutePath });
        }

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