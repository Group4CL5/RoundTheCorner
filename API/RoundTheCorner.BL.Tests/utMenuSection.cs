using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;
using System.Linq;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utMenuSection
    {

        [TestMethod]
        public void Seed()
        {
            bool result = MenuSectionManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMenuSections()
        {
            List<MenuSectionModel> menuSections = MenuSectionManager.GetMenuSections();
            int expected = 2;

            Assert.AreEqual(menuSections.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            List<MenuSectionModel> menuSections = MenuSectionManager.GetMenuSections();

            MenuSectionModel menuSection = menuSections.FirstOrDefault(m => m.displayOrderNum == 100);
            menuSection.displayOrderNum = 99;

            MenuSectionManager.Update(menuSection);

            MenuSectionModel newMenuSection = MenuSectionManager.GetMenuSection(menuSection.menuSectionID);

            Assert.AreEqual(menuSection.displayOrderNum, newMenuSection.displayOrderNum);
        }

        [TestMethod]
        public void Delete()
        {
            List<MenuSectionModel> menuSections = MenuSectionManager.GetMenuSections();

            MenuSectionModel menuSection = menuSections.FirstOrDefault(m => m.displayOrderNum == 99);
            
            bool result = MenuSectionManager.Delete(menuSection.menuSectionID);
            Assert.IsTrue(result);
        }
    }
    
}
