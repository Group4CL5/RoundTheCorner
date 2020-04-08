using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoundTheCorner.BL.Tests
{
    class UTCuisine
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
                VendorID = 2,
                MenuID = 2,
                CuisineName = "Good Eats 4 all"
            };
            CuisineManager.Update(cuisine);

            CuisineModel newCuisine = CuisineManager.GetCuisine(2);

            Assert.AreEqual(cuisine.CuisineID, newCuisine.CuisineID);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = VendorManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
}
