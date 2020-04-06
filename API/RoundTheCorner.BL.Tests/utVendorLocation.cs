﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utVendorLocation
    {
        [TestMethod]
        public void Seed()
        {
            bool result = VendorLocationManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetVendorLocations()
        {
            List<VendorLocationModel> vendorLocations = VendorLocationManager.GetVendorLocations();
            int expected = 2;
            Assert.AreEqual(vendorLocations.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            VendorLocationModel vendorLocation = new VendorLocationModel
            {
                vendorID = 2,
                locationX = 111, 
                locationY = 222,
                date = new DateTime(1950, 12, 31)
            };

            VendorLocationManager.Update(vendorLocation);
            VendorLocationModel newVendorLocation = VendorLocationManager.GetVendorLocation(2);
            Assert.AreEqual(vendorLocation.vendorID, newVendorLocation.vendorID);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = VendorLocationManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}