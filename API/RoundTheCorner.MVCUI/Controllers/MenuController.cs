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
                OrderModel order = new OrderModel
                {
                    UserID = user.UserID,
                    VendorID = msmi.VendorModel.VendorID,
                    OrderDate = DateTime.Now
                };
                order = OrderManager.Insert(order);
                foreach (var item in msmi.OrderItems )
                {
                    if (item.Quantity < 1)
                    {
                        msmi.OrderItems.Remove(item);
                        continue;

                    }
                    item.OrderItemID = order.OrderID;
                    item.Price = msmi.MenuItems.FirstOrDefault(m => m.ItemID == item.MenuItemID).Price * item.Quantity;
                    OrderItemManager.Insert(item);

                }
                return RedirectToAction("Confirmed", "Menu");
            }
            return View();
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