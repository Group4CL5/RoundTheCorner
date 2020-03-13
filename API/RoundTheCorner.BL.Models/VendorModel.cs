using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCorner.BL.Models
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
