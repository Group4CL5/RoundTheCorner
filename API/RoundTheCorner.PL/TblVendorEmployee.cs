//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoundTheCorner.PL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblVendorEmployee
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public int vendorID { get; set; }
    
        public virtual TblUser TblUser { get; set; }
        public virtual TblVendor TblVendor { get; set; }
    }
}
