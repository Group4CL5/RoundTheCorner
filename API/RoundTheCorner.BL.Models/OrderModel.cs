using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class OrderModel
    {
        public int orderID {get; set;}
        public int userID {get; set;}
        public int vendorID {get; set;}
        public DateTime orderDate {get; set;}

    }
}
