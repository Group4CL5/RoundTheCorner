using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    public class VendorManager
    {
        public static bool Seed()
        {
            VendorModel vendor = new VendorModel
            {
                vendorID = 1,
                ownerID = 1,
                companyName = "100Tacos", 
                companyEmail = "100tacos@taco.com",
                licenseNumber = 1122334,
                inspectionDate = new DateTime(1950, 12, 31),
                bio = "We love bring tacos to people (even if you dont like tacos)!",
                website = "100Tacos.com",

            };

            return Insert(vendor);
        }

        public static bool Insert(VendorModel vendor)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendor newRow = new TblVendor()
                    {
                        vendorID = rc.TblVendors.Any() ? rc.TblVendors.Max(v => v.vendorID) + 1 : 1,
                        OwnerID = vendor.ownerID,
                        CompanyName = vendor.companyName,
                        CompanyEmail = vendor.companyEmail,
                        LicenseNumber = vendor.licenseNumber,
                        inspectionDate = vendor.inspectionDate,
                        bio = vendor.bio,
                        Website = vendor.website
                    };
                    rc.TblVendors.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Insert(int ownerID, string companyName, string companyEmail, DateTime inspectionDate, string bio, string website)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendor newRow = new TblVendor()
                    {
                        vendorID = rc.TblVendors.Any() ? rc.TblVendors.Max(v => v.vendorID) + 1 : 1,
                        OwnerID = ownerID,
                        CompanyName = companyName,
                        CompanyEmail = companyEmail,
                        inspectionDate = inspectionDate, 
                        bio = bio, 
                        Website = website
                    };
                    rc.TblVendors.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static VendorModel GetVendor(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblVendor = rc.TblVendors.FirstOrDefault(v => v.vendorID == id);

                        if (tblVendor != null)
                        {
                            VendorModel vendor = new VendorModel
                            {
                                vendorID = tblVendor.vendorID,
                                ownerID = tblVendor.OwnerID,
                                companyName = tblVendor.CompanyName,
                                companyEmail = tblVendor.CompanyEmail,
                                licenseNumber = tblVendor.LicenseNumber,
                                inspectionDate = tblVendor.inspectionDate,
                                bio = tblVendor.bio,
                                website = tblVendor.Website
                            };

                            return vendor;
                        }

                        throw new Exception("Vendor cannot be found");
                    }
                }
                else
                {
                    throw new Exception("ID cannot be 0");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<VendorModel> GetVendors()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblVendors = rc.TblVendors.ToList();

                    if (tblVendors != null)
                    {
                        List<VendorModel> vendors = new List<VendorModel>();

                        tblVendors.ForEach(v => vendors.Add(new VendorModel { vendorID = v.vendorID, ownerID = v.OwnerID, companyName = v.CompanyName, companyEmail = v.CompanyEmail, licenseNumber = v.LicenseNumber, inspectionDate = v.inspectionDate, bio = v.bio, website = v.Website }));

                        return vendors;
                    }

                    throw new Exception("There currently are no vendors");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool Update(VendorModel vendor)
        {
            try
            {
                if (vendor.vendorID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblVendor tblVendor = rc.TblVendors.FirstOrDefault(v => v.vendorID == vendor.vendorID);

                        if (tblVendor != null)
                        {
                            tblVendor.vendorID = vendor.vendorID;
                            tblVendor.OwnerID = vendor.ownerID;
                            tblVendor.CompanyName = vendor.companyName;
                            tblVendor.CompanyEmail = vendor.companyEmail;
                            tblVendor.LicenseNumber = vendor.licenseNumber;
                            tblVendor.inspectionDate = vendor.inspectionDate;
                            tblVendor.bio = vendor.bio;
                            tblVendor.Website = vendor.website;

                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Vendor was not found");
                        }
                    }
                }
                else
                {
                    throw new Exception("Must have a valid id");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Unit tests only
        public static bool Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var vendor = rc.TblVendors.FirstOrDefault(v => v.vendorID == id);

                        if (vendor != null)
                        {
                            rc.TblVendors.Remove(vendor);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Vendor cannot be found");
                        }
                    }
                }
                else
                {
                    throw new Exception("ID cannot be 0");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
