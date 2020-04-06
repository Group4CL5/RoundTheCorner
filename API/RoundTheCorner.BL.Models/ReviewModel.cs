using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class ReviewModel
    {
        public int ReviewID { get; set; }
        public int VendorID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


    }
}
