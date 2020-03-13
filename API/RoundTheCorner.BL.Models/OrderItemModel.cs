using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class OrderItemModel
    {
        public int orderItemID { get; set; }
        public int menuItemID { get; set; }
        public double price { get; set; }
    }
}
