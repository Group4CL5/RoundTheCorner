using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoundTheCorner.BL.Tests
{
    class utCuisine
    {
        [TestMethod]
        public void Seed()
        {
            bool result = CuisineManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCuisines()
        {
                List<CuisineModel> cuisines= CuisineManager.GetCuisines(2);
                int expected = 2;

                Assert.AreEqual(cuisines.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            CuisineModel cuisine = new CuisineModel
            {
                vendorID = 2,
                menuID = 2,
                cuisineName = "Good Eats 4 all"
            };
            CuisineManager.Update(cuisine);

            CuisineModel newCuisine = CuisineManager.GetCuisine(2);

            Assert.AreEqual(cuisine.cuisineID, newCuisine.cuisineID);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = VendorManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
