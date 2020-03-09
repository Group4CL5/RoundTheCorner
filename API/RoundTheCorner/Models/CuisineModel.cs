using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Models
{
    public class CuisineModel
    {
        public int cuisineID { get; set; }
        public string cuisineName { get; set; }
        public int vendorID { get; set; }
    }
}
