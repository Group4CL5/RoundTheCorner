using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Models
{

    public class Cart
    {
        public List<OrderItemModel> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }
        public decimal TotalCost { get; set; }

        public int VendorID { get; set; }



        public Cart()
        {
            Items = new List<OrderItemModel>();
        }



        public void Add(MenuItemModel menuItem, int quantity)
        {
            OrderItemModel orderItemModel = new OrderItemModel();
            orderItemModel.MenuItemID = menuItem.ItemID;
            orderItemModel.Price = menuItem.Price;
            orderItemModel.Quantity = quantity;
            
            Items.Add(orderItemModel);
            TotalCost += menuItem.Price * quantity;
        }



        public void Remove(OrderItemModel orderItemModel)
        {
            Items.Remove(orderItemModel);
            TotalCost -= orderItemModel.Price * orderItemModel.Quantity;
        }



        public void Checkout()
        {
            Items = new List<OrderItemModel>();
            TotalCost = 0;
        }

    }
}