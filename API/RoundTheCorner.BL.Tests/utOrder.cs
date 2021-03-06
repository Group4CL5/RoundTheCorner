﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;
using System.Collections.Generic;
using System.Linq;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class UTOrder
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
            List<OrderModel> orders = OrderManager.GetOrders();
            OrderModel order = orders.FirstOrDefault(o => o.OrderDate.Year == 1980);
            order.OrderDate = new DateTime(1979, 04, 02);

            OrderManager.Update(order);

            OrderModel newOrder = OrderManager.GetOrder(order.OrderID);

            Assert.AreEqual(order.OrderDate, newOrder.OrderDate);
        }


        [TestMethod]
        public void Delete()
        {
            List<OrderModel> orders = OrderManager.GetOrders();
            OrderModel order = orders.FirstOrDefault(o => o.OrderDate.Year == 1979);
            bool result = OrderManager.Delete(order.OrderID);
            Assert.IsTrue(result);
        }
    }
}
