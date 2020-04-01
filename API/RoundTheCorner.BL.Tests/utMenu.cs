using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utMenu
    {
        [TestMethod]
        public void Seed()
        {
            bool result = MenuManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMenus()
        {
            List<MenuModel> menus = MenuManager.GetMenu();
            int expected = 2;

            Assert.AreEqual(menus.Count, expected);
        }

        [TestMethod]
        public void Deactivate()
        {
            MenuModel menu = MenuManager.GetMenu(2);
            MenuManager.Deactivate(2);
            MenuModel newMenu = MenuManager.GetMenu(2);

            Assert.AreNotEqual(menu.isActive, newMenu.isActive);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = MenuManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
