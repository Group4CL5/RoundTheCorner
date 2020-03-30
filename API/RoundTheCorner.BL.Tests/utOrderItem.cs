using System;
using System.Collections.Generic;
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
        public void GetOrderItems()
        {
            List<OrderItemModel> orderItems = OrderItemManager.GetOrderItems();
            int expected = 1;

            Assert.AreEqual(orderItems.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            OrderItemModel orderItem = new OrderItemModel
            {
                menuItemID = 1,
                orderItemID = 1 ,
                price = 25.56m

            };

            OrderItemManager.Update(orderItem);

            OrderItemModel newOrderItem = OrderItemManager.GetOrderItem(1);

            Assert.AreEqual(orderItem.price, newOrderItem.price);
        }


        [TestMethod]
        public void Delete()
        {
            bool result = OrderItemManager.Delete(1);
            Assert.IsTrue(result);
        }
    }
}
