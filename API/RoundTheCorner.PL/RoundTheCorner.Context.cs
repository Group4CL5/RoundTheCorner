﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RoundTheCornerEntities : DbContext
    {
        public RoundTheCornerEntities()
            : base("name=RoundTheCornerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblCuisine> TblCuisines { get; set; }
        public virtual DbSet<TblMenuItem> TblMenuItems { get; set; }
        public virtual DbSet<TblMenu> TblMenus { get; set; }
        public virtual DbSet<TblMenuSection> TblMenuSections { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblReview> TblReviews { get; set; }
        public virtual DbSet<TblOrderItem> TblOrderItems { get; set; }
        public virtual DbSet<TblVendorEmployee> TblVendorEmployees { get; set; }
        public virtual DbSet<TblVendorLocation> TblVendorLocations { get; set; }
        public virtual DbSet<TblVendor> TblVendors { get; set; }
    }
}
