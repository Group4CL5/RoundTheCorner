using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;
using RoundTheCorner.MVCUI.Models.ViewModels;
using RoundTheCorner.BL;
using RoundTheCorner.MVCUI.Models;

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
            foreach (var item in msmi.MenuItems)
            {
                OrderItemModel orderItemModel = new OrderItemModel
                {
                    MenuItemID = item.ItemID,
                    Quantity = 0
                };
                msmi.OrderItems.Add(orderItemModel);
                
            }
            msmi.VendorModel = VendorManager.GetVendor(ID);
            return View(msmi);
        }
        [HttpPost]
        public ActionResult Details(int ID, MenuSectionMenuItems msmi)
        {
            if (Authenticate.IsAuthenticated())
            {
                UserModel user = (UserModel)HttpContext.Session["User"];
                ShoppingCartManager.Checkout((Cart)HttpContext.Session["Cart"], user.UserID);
                return RedirectToAction("Confirmed", "Menu");
            }
            return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url.AbsolutePath });
        }

        public ActionResult Confirmed()
        {
            return View();
        }

        //public ActionResult Purchase(MenuSectionMenuItems msmi)
        //{
            
        //    return View();
        //}
        public ActionResult DeactivateMenu(int menuID) => View();

    }
}