using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class UTVendor
    {
        [TestMethod]
        public void Seed()
        {
            bool result = VendorManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetVendors()
        {
            List<VendorModel> vendors = VendorManager.GetVendors();
            int expected = 2;

            Assert.AreEqual(vendors.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            VendorModel vendor = new VendorModel
            {
                VendorID = 2,
                OwnerID = 2,
                CompanyName = "100Tacos",
                CompanyEmail = "100tacos@taco.com",
                LicenseNumber = 1122334,
                InspectionDate = new DateTime(1950, 12, 31),
                Bio = "We love bring tacos to people (even if you dont like tacos)!",
                Website = "100Tacos.com",
            };

            VendorManager.Update(vendor);

            VendorModel newVendor = VendorManager.GetVendor(2);

            Assert.AreEqual(vendor.VendorID, newVendor.VendorID);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = VendorManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
