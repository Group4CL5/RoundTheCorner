using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCorner.BL.Models
{
    public class VendorModel
    {
        public int VendorID { get; set; }
        public int OwnerID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public int LicenseNumber { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public bool Confirmed { get; set; }
        

    }
}
