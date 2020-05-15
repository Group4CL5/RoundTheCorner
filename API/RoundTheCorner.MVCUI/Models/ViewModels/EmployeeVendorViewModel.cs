using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.MVCUI.Models.ViewModels
{
    public class EmployeeVendorViewModel
    {
        public VendorModel Vendor { get; set; }
        public VendorEmployeeModel Employee { get; set; }
        public UserModel User { get; set; }
    }
}