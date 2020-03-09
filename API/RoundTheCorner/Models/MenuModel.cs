using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Models
{
    public class MenuModel
    {
        public int menuID { get; set; }
        public int vendorID { get; set; }
        public bool isActive { get; set; }

    }
}
