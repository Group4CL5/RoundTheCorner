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
                VendorID = 1,
                UserID = 1,
                Rating = 5,
                Subject = "Test",
                Body = "The food was yummy and made me happy. Recommend it to everyone in town."
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

                       Rating = review.Rating,
                       Subject = review.Subject,
                       Body = review.Body

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

        public static bool Insert(int Rating, string Subject, string Body)
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
                        Rating = Rating,
                        Subject= Subject,
                        Body = Body
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
                                ReviewID = tblReview.ReviewID,
                                Rating = tblReview.Rating,
                                Subject = tblReview.Subject,
                                Body = tblReview.Body

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


        public static List<ReviewModel> GetReviews()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblReview = rc.TblReviews.ToList();

                    if (tblReview != null)
                    {
                        List<ReviewModel> reviews = new List<ReviewModel>();

                        tblReview.ForEach(u => reviews.Add(new ReviewModel { ReviewID = u.ReviewID, VendorID = u.VendorID, UserID = u.UserID, Subject = u.Subject, Body = u.Body, Rating = u.Rating }));

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

        public static List<ReviewModel> GetReviews(int VendorId)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblReview = rc.TblReviews.Where(r => r.VendorID == VendorId).ToList();

                    if (tblReview != null)
                    {
                        List<ReviewModel> reviews = new List<ReviewModel>();

                        tblReview.ForEach(u => reviews.Add(new ReviewModel { ReviewID = u.ReviewID, VendorID = u.VendorID, UserID = u.UserID, Subject = u.Subject, Body = u.Body, Rating = u.Rating }));

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
                if (review.ReviewID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblReview tblReview = rc.TblReviews.FirstOrDefault(u => u.ReviewID == review.ReviewID);

                        if (tblReview != null)
                        {
                            tblReview.ReviewID = review.ReviewID;
                            tblReview.UserID = review.UserID;
                            tblReview.VendorID = review.VendorID;
                            tblReview.Rating = review.Rating;
                            tblReview.Subject = review.Subject;
                            tblReview.Body = review.Body;


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
