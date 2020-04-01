using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class utReview
    {

        [TestMethod]
        public void Seed()
        {
            bool result = ReviewManager.Seed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetReviews()
        {
            List<ReviewModel> reviews = ReviewManager.GetReview();
            int expected = 2;

            Assert.AreEqual(reviews.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            ReviewModel review = new ReviewModel
            {
                reviewID = 2,
                vendorID = 2,
                userID =2,
                rating = 4,
                subject = "subject here",
                body = "body goes in here"
            };

            ReviewManager.Update(review);

            ReviewModel newReview = ReviewManager.GetReview(2);

            Assert.AreEqual(review.reviewID, newReview.reviewID);
        }

        [TestMethod]
        public void Delete()
        {
            bool result = ReviewManager.Delete(2);
            Assert.IsTrue(result);
        }
    }
    
}
