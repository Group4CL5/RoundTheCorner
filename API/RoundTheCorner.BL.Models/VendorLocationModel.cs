using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class VendorLocationModel
    {
        public int vendorID { get; set; }
        public DateTime date { get; set; }
        public int locationX { get; set; }
        public int locationY { get; set; }

    }
}
