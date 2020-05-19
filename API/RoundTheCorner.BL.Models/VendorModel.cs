using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoundTheCorner.BL.Models
{
    public class VendorModel
    {
        public int VendorID { get; set; }
        public int OwnerID { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }
        [Display(Name = "License Number")]
        public int LicenseNumber { get; set; }
        [Display(Name = "Inspection Date")]
        public DateTime InspectionDate { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public bool Confirmed { get; set; }
        

    }
}
