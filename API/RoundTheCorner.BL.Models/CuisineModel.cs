﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCorner.BL.Models
{
    public class CuisineModel
    {
        public int CuisineID { get; set; }
        public string CuisineName { get; set; }
        public int VendorID { get; set; }
        public int MenuID { get; set; }
    }
}
