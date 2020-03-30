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
    
    public partial class TblVendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblVendor()
        {
            this.TblCuisines = new HashSet<TblCuisine>();
            this.TblMenus = new HashSet<TblMenu>();
            this.TblOrders = new HashSet<TblOrder>();
            this.TblReviews = new HashSet<TblReview>();
            this.TblVendorEmployees = new HashSet<TblVendorEmployee>();
            this.TblVendorLocations = new HashSet<TblVendorLocation>();
        }
    
        public int vendorID { get; set; }
        public int OwnerID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public int LicenseNumber { get; set; }
        public System.DateTime inspectionDate { get; set; }
        public string bio { get; set; }
        public string Website { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblCuisine> TblCuisines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblMenu> TblMenus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblReview> TblReviews { get; set; }
        public virtual TblUser TblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblVendorEmployee> TblVendorEmployees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblVendorLocation> TblVendorLocations { get; set; }
    }
}
