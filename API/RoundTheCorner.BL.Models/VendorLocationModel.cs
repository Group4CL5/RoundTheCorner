using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class VendorLocationModel
    {
        public int VendorID { get; set; }
        public DateTime Date { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

    }
}
