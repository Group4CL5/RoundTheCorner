using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCorner.BL.Models
{
    public class CuisineModel
    {
        public int cuisineID { get; set; }
        public string cuisineName { get; set; }
        public int vendorID { get; set; }
        public int menuID { get; set; }
    }
}
