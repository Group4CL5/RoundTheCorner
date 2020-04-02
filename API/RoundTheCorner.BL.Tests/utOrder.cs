using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;
using System.Collections.Generic;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void Seed()
        {
            bool result = OrderManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetOrder()
        {
            List<OrderModel> order = OrderManager.GetOrders();
            int expected = 2;

            Assert.AreEqual(order.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            OrderModel order = new OrderModel
            {
                orderID = 1,
                userID = 1,
                vendorID = 1,
                orderDate = new DateTime(2020, 04, 01)

            };

            OrderManager.Update(order);

            OrderModel newOrder = OrderManager.GetOrder(1);

            Assert.AreEqual(order.orderID, newOrder.orderID);
        }


        [TestMethod]
        public void Delete()
        {
            bool result = OrderManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
