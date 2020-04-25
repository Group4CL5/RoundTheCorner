using System;
using System.Collections.Generic;
using System.Linq;
using RoundTheCorner.BL.Models;
using System.Web.Mvc;
using RoundTheCorner.BL;
using System.Web;
using RoundTheCorner.MVCUI.Models;

namespace RoundTheCorner.MVCUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        Cart cart; 

        //[ChildActionOnly]
        public ActionResult CartDisplay()
        {
            GetShoppingCart();
            return PartialView(cart);
        }
        private void GetShoppingCart()
        {
            if (Session["Cart"] == null)
            {
                cart = new Cart();               
            }
            else
            {
                cart = (Cart)Session["Cart"];
            }
        }
        public ActionResult RemoveFromCart(int ID, string returnURL)
        {
            GetShoppingCart();
            BL.Models.OrderItemModel orderItemModel = cart.Items.FirstOrDefault(i => i.OrderItemID == ID);
            ShoppingCartManager.Remove(cart, orderItemModel);
            Session["Cart"] = cart;
            return Redirect(returnURL);            
        } 
        public ActionResult AddToCart(int ID, string returnURL, int quantity)
        {
            GetShoppingCart();
            BL.Models.MenuItemModel menuItemModel = MenuItemManager.GetMenuItem(ID);
            ShoppingCartManager.Add(cart, menuItemModel, quantity);
            Session["Cart"] = cart;
            return Redirect(returnURL);           
        }

        public ActionResult CheckOut()
        {
            GetShoppingCart();
            ShoppingCartManager.Checkout(cart);
            return View();
        }
    }
}