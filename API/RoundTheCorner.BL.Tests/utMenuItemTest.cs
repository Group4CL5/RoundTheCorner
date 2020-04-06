using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RoundTheCorner.BL.Tests
{
    class UTMenuItemTest
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
                ItemID=2,
                MenuItem = 2,
                ItemName = "Good Eats",
                Price = 2,
                Picture = "picture_here",
                Description = "very spicy",
                MenuSectionID = 2
            };
            MenuItemManager.Update(menuItem);

            MenuItemModel newMenuItem = MenuItemManager.GetMenuItem(2);

            Assert.AreEqual(menuItem.ItemID, newMenuItem.ItemName);
        }
        [TestMethod]
        public void Delete()
        {
            bool result = MenuItemManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
