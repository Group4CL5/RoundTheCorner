using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RoundTheCorner.BL.Tests
{
    class utMenuItemTest
    {
        [TestMethod]
        public void Seed()
        {
            bool result = MenuItemManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMenuItems()
        {
            List<MenuItemModel> menuItem = MenuItemManager.GetMenuItems(2);
            int expected = 2;

            Assert.AreEqual(menuItem.Count, expected);
        }
        [TestMethod]
        public void Update()
        {
            MenuItemModel menuItem = new MenuItemModel
            {
                itemID=2,
                menuItem = 2,
                itemName = "Good Eats",
                price = 2,
                picture = new byte[] { 1 },
                description = "very spicy",
                menuSectionID = 2
            };
            MenuItemManager.Update(menuItem);

            MenuItemModel newMenuItem = MenuItemManager.GetMenuItem(2);

            Assert.AreEqual(menuItem.itemID, newMenuItem.itemName);
        }
        [TestMethod]
        public void Delete()
        {
            bool result = MenuItemManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
