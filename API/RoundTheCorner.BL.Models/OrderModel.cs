using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class OrderModel
    {
        public int OrderID {get; set;}
        public int UserID {get; set;}
        public int VendorID {get; set;}
        public DateTime OrderDate {get; set;}

    }
}
