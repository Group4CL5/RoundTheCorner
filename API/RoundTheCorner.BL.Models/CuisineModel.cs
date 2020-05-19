using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCorner.BL.Models
{
    public class CuisineModel
    {
        [Key]
        public int CuisineID { get; set; }
        public string CuisineName { get; set; }
        public int VendorID { get; set; }
        public int MenuID { get; set; }
    }
}
