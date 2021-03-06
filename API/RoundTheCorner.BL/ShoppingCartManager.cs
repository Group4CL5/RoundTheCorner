﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using System.Web;


namespace RoundTheCorner.BL
{
    public class ShoppingCartManager
    {
        public static void Checkout(Cart cart, int userID)
        {
            OrderModel order = new OrderModel();
            
            order.UserID= userID;
            order.OrderDate = DateTime.Now;
            order.VendorID = cart.VendorID;
            order = OrderManager.Insert(order);
            foreach (var item in cart.Items)
            {
                item.OrderID = order.OrderID;
                OrderItemManager.Insert(item);
            }
            cart.Checkout();
        }



        public static void Add(Cart cart, Models.MenuItemModel menuItem, int quantity)
        {
            cart.Add(menuItem, quantity);
        }



        public static void Remove(Cart cart, Models.OrderItemModel orderItem)
        {
            cart.Remove(orderItem);
        }
    }
}
