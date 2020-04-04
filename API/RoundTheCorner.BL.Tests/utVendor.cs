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
    public class utVendor
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
                vendorID = 2,
                ownerID = 2,
                companyName = "100Tacos",
                companyEmail = "100tacos@taco.com",
                licenseNumber = 1122334,
                inspectionDate = new DateTime(1950, 12, 31),
                bio = "We love bring tacos to people (even if you dont like tacos)!",
                website = "100Tacos.com",
            };

            VendorManager.Update(vendor);

            VendorModel newVendor = VendorManager.GetVendor(2);

            Assert.AreEqual(vendor.vendorID, newVendor.vendorID);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = VendorManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
