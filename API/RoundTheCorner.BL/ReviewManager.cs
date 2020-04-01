using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    public class ReviewManager
    {


       

        public static bool Seed()
        {
            ReviewModel review = new ReviewModel
            {
                vendorID = 1,
                userID = 1,
                rating = 5,
                subject = "Best food in town",
                body = "The food was yummy and made me happy. Recommend it to everyone in town."
            };

            return Insert(review);
        }

        public static bool Insert(ReviewModel review)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblReview newRow = new TblReview()
                    {
                        ReviewID = rc.TblReviews.Any()? rc.TblReviews.Max(u => u.ReviewID) +1: 1,
                        VendorID = 1,

                       Rating = review.rating,
                       Subject = review.subject,
                       Body = review.body

                    };
                    rc.TblReviews.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Insert(int rating, string subject, string body)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblReview newRow = new TblReview()
                    {
                        ReviewID = rc.TblReviews.Any() ? rc.TblReviews.Max(u => u.ReviewID) + 1 : 1,
                        VendorID = 1,
                        UserID = 1,
                        Rating = rating,
                        Subject= subject,
                        Body = body
                    };
                    rc.TblReviews.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ReviewModel GetReview(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblReview = rc.TblReviews.FirstOrDefault(u => u.ReviewID == id);

                        if (tblReview != null)
                        {
                            ReviewModel review = new ReviewModel
                            {
                                reviewID = tblReview.ReviewID,
                                rating = tblReview.Rating,
                                subject = tblReview.Subject,
                                body = tblReview.Body

                            };

                            return review;
                        }

                        throw new Exception("Review cannot be found");
                    }
                }
                else
                {
                    throw new Exception("ID cannot be 0");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ReviewModel> GetReview()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblReview = rc.TblReviews.ToList();

                    if (tblReview != null)
                    {
                        List<ReviewModel> reviews = new List<ReviewModel>();

                        tblReview.ForEach(u => reviews.Add(new ReviewModel { reviewID = u.ReviewID, vendorID = u.VendorID, userID=u.UserID, subject=u.Subject, body = u.Body, rating = u.Rating }));

                        return reviews;
                    }

                    throw new Exception("There currently are no reviews");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool Update(ReviewModel review)
        {
            try
            {
                if (review.reviewID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblReview tblReview = rc.TblReviews.FirstOrDefault(u => u.ReviewID == review.reviewID);

                        if (tblReview != null)
                        {
                            tblReview.ReviewID = review.reviewID;
                            tblReview.UserID = review.userID;
                            tblReview.VendorID = review.vendorID;
                            tblReview.Rating = review.rating;
                            tblReview.Subject = review.subject;
                            tblReview.Body = review.body;


                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Review was not found");
                        }
                    }
                }
                else
                {
                    throw new Exception("Must have a valid id");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       // Unit tests only
        public static bool Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var review = rc.TblReviews.FirstOrDefault(u => u.ReviewID == id);

                        if (review != null)
                        {
                            rc.TblReviews.Remove(review);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Review cannot be found");
                        }
                    }
                }
                else
                {
                    throw new Exception("ID cannot be 0");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
