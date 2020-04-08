using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL.Tests
{
    [TestClass]
    public class UTReview
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
            List<ReviewModel> reviews = ReviewManager.GetReviews();
            int expected = 2;

            Assert.AreEqual(reviews.Count, expected);
        }

        [TestMethod]
        public void Update()
        {
            List<ReviewModel> reviewModels = ReviewManager.GetReviews();

            ReviewModel review = reviewModels.FirstOrDefault(r => r.Subject == "Test");
            review.Subject = "something else";
            

            ReviewManager.Update(review);

            ReviewModel newReview = ReviewManager.GetReview(review.ReviewID);


            Assert.AreEqual(review.Subject, newReview.Subject);
        }

        [TestMethod]
        public void Delete()
        {
            List<ReviewModel> reviewModels = ReviewManager.GetReviews();

            ReviewModel review = reviewModels.FirstOrDefault(r => r.Subject == "something else");
            bool result = ReviewManager.Delete(review.ReviewID);
            Assert.IsTrue(result);
        }
    }
    
}
