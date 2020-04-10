using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;
using RoundTheCorner.MVCUI.Models.ViewModels;
using RoundTheCorner.BL;

namespace RoundTheCorner.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult AddMenu(MenuModel menu) => View();
        public ActionResult PutMenu(MenuModel menu) => View();
        public ActionResult Details(int ID)
        {
            MenuModel menu = MenuManager.GetVendorMenu(ID); 
            MenuSectionMenuItems msmi = new MenuSectionMenuItems();

            msmi.MenuModel = menu;
            msmi.MenuSections = MenuSectionManager.GetMenuSections(menu.MenuID);
            msmi.MenuItems = MenuItemManager.GetMenuItems(menu.MenuID);
            msmi.VendorModel = VendorManager.GetVendor(ID);
            return View(msmi);
        }
        public ActionResult DeactivateMenu(int menuID) => View();

    }
}