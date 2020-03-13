using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class ReviewModel
    {
        public int reviewID { get; set; }
        public int vendorID { get; set; }
        public int userID { get; set; }
        public int rating { get; set; }
        public string subject { get; set; }
        public string body { get; set; }


    }
}
