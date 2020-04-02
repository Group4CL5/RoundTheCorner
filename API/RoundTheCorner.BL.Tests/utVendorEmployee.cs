using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utVendorEmployee
    {
        // Just a comment
        public void Seed()
        {
            bool result = VendorEmployeeManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetVendorEmployees()
        {
            List<VendorEmployeeModel> vendorEmployees = VendorEmployeeManager.GetVendorEmployee();
            int expected = 2;

            Assert.AreEqual(vendorEmployees.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            VendorEmployeeModel vendorEmployee = new VendorEmployeeModel
            {
                id = 2,
                vendorID = 2,
                userID = 2,
                
            };

            VendorEmployeeManager.Update(vendorEmployee);

            VendorEmployeeModel newVendorEmployee = VendorEmployeeManager.GetVendorEmployee(2);

            Assert.AreEqual(vendorEmployee.id, newVendorEmployee.id);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = VendorEmployeeManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
