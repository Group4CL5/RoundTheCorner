using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Models
{
    public class VendorModel
    {
        public int vendorID { get; set; }
        public int ownerID { get; set; }
        public string companyName { get; set; }
        public string companyEmail { get; set; }
        public string licenseNumber { get; set; }
        public DateTime inspectionDate { get; set; }
        public string bio { get; set; }
        public string website { get; set; }

    }
}
