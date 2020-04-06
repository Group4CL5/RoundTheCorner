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
                VendorID = 1,
                OwnerID = 1,
                CompanyName = "100Tacos", 
                CompanyEmail = "100tacos@taco.com",
                LicenseNumber = 1122334,
                InspectionDate = new DateTime(1950, 12, 31),
                Bio = "We love bring tacos to people (even if you dont like tacos)!",
                Website = "100Tacos.com",

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
                        VendorID = rc.TblVendors.Any() ? rc.TblVendors.Max(v => v.VendorID) + 1 : 1,
                        OwnerID = vendor.OwnerID,
                        CompanyName = vendor.CompanyName,
                        CompanyEmail = vendor.CompanyEmail,
                        LicenseNumber = vendor.LicenseNumber,
                        InspectionDate = vendor.InspectionDate,
                        Bio = vendor.Bio,
                        Website = vendor.Website
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

        public static bool Insert(int OwnerID, string CompanyName, string CompanyEmail, DateTime InspectionDate, string Bio, string Website)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendor newRow = new TblVendor()
                    {
                        VendorID = rc.TblVendors.Any() ? rc.TblVendors.Max(v => v.VendorID) + 1 : 1,
                        OwnerID = OwnerID,
                        CompanyName = CompanyName,
                        CompanyEmail = CompanyEmail,
                        InspectionDate = InspectionDate, 
                        Bio = Bio, 
                        Website = Website
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
                        var tblVendor = rc.TblVendors.FirstOrDefault(v => v.VendorID == id);

                        if (tblVendor != null)
                        {
                            VendorModel vendor = new VendorModel
                            {
                                VendorID = tblVendor.VendorID,
                                OwnerID = tblVendor.OwnerID,
                                CompanyName = tblVendor.CompanyName,
                                CompanyEmail = tblVendor.CompanyEmail,
                                LicenseNumber = tblVendor.LicenseNumber,
                                InspectionDate = tblVendor.InspectionDate,
                                Bio = tblVendor.Bio,
                                Website = tblVendor.Website
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

                        tblVendors.ForEach(v => vendors.Add(new VendorModel { VendorID = v.VendorID, OwnerID = v.OwnerID, CompanyName = v.CompanyName, CompanyEmail = v.CompanyEmail, LicenseNumber = v.LicenseNumber, InspectionDate = v.InspectionDate, Bio = v.Bio, Website = v.Website }));

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
                if (vendor.VendorID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblVendor tblVendor = rc.TblVendors.FirstOrDefault(v => v.VendorID == vendor.VendorID);

                        if (tblVendor != null)
                        {
                            tblVendor.VendorID = vendor.VendorID;
                            tblVendor.OwnerID = vendor.OwnerID;
                            tblVendor.CompanyName = vendor.CompanyName;
                            tblVendor.CompanyEmail = vendor.CompanyEmail;
                            tblVendor.LicenseNumber = vendor.LicenseNumber;
                            tblVendor.InspectionDate = vendor.InspectionDate;
                            tblVendor.Bio = vendor.Bio;
                            tblVendor.Website = vendor.Website;

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
                        var vendor = rc.TblVendors.FirstOrDefault(v => v.VendorID == id);

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
