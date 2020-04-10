using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.MVCUI.Models.ViewModels
{
    public class VendorCuisineLocationRating
    {
        public VendorModel Vendor { get; set; }
        public CuisineModel Cuisine { get; set; }
        public VendorLocationModel VendorLocation { get; set; }
        public List<ReviewModel> Reviews { get; set; } 

        public double Rating 
        {
            get 
            {
                double Total = 0;

                foreach (ReviewModel item in Reviews)
                {
                    Total += item.Rating;
                }
                return Total / Reviews.Count;
            } 
            
        }


        public string Location { get => $"{VendorLocation.LocationX}, {VendorLocation.LocationY}"; }
    }
}