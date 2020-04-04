using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;


namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void Seed()
        {
            bool result = OrderItemManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetOrderItem()
        {
            List<OrderItemModel> orderItems = OrderItemManager.GetOrderItems(1);
            int expected = 2;

            Assert.AreEqual(orderItems.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            List<OrderItemModel> orderItems = OrderItemManager.GetOrderItems();
            OrderItemModel orderItem = orderItems.FirstOrDefault(u => u.price == 123);
            orderItem.price = 321;
            OrderItemManager.Update(orderItem);

            OrderItemModel newOrderItem = OrderItemManager.GetOrderItem(orderItem.orderItemID);

            Assert.AreEqual(orderItem.price,newOrderItem.price);
        }


        [TestMethod]
        public void Delete()
        {
            List<OrderItemModel> orderItems = OrderItemManager.GetOrderItems();
            OrderItemModel orderItem = orderItems.FirstOrDefault(u => u.price == 321);
            bool result = OrderItemManager.Delete(orderItem.orderItemID);
            Assert.IsTrue(result);
        }
    }
}
