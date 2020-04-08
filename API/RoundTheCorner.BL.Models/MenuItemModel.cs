using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class MenuItemModel
    {
        public int ItemID { get; set; }
        public int MenuItem { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int MenuSectionID { get; set; }       

    }
}
