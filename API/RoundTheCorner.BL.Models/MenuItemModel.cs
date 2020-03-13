using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class MenuItemModel
    {
        public int itemID { get; set; }
        public int menuItem { get; set; }
        public string itemName { get; set; }
        public double price { get; set; }
        public string picture { get; set; }
        public string description { get; set; }
        public int menuSectionID { get; set; }       

    }
}
