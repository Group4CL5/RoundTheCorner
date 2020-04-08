using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class OrderItemModel
    {
        public int OrderItemID { get; set; }
        public int MenuItemID { get; set; }
        public decimal Price { get; set; }
    }
}
