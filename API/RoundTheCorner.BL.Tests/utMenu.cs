using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    // UT For the Menus
    [TestClass]
    public class UTMenu
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
            List<MenuModel> menus = MenuManager.GetMenus();
            int expected = 2;

            Assert.AreEqual(menus.Count, expected);
        }

        [TestMethod]
        public void Deactivate()
        {
            MenuModel menu = MenuManager.GetMenu(2);
            MenuManager.Deactivate(2);
            MenuModel newMenu = MenuManager.GetMenu(2);

            Assert.AreNotEqual(menu.IsActive, newMenu.IsActive);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = MenuManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
