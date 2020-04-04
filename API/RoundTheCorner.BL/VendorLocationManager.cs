using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.PL;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL
{
    public class VendorLocationManager
    {
        public static bool Seed()
        {
            VendorLocationModel vendorLocation = new VendorLocationModel
            {
                vendorID = 1,
                locationX = 100,
                locationY = 200,
                date = new DateTime(1950, 12, 31),

            };

            return Insert(vendorLocation);
        }

        public static bool Insert(VendorLocationModel vendorLocation)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendorLocation newRow = new TblVendorLocation()
                    {
                        VendorID = rc.TblVendorLocations.Any() ? rc.TblVendorLocations.Max(v => v.VendorID) + 1 : 1,
                        locationX = vendorLocation.locationX, 
                        locationY = vendorLocation.locationY, 
                        datetime = vendorLocation.date
                    };
                    rc.TblVendorLocations.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Insert(int VendorID, int locationX, int locationY, DateTime date)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendorLocation newRow = new TblVendorLocation()
                    {
                        VendorID = rc.TblVendorLocations.Any() ? rc.TblVendorLocations.Max(v => v.VendorID) + 1 : 1,
                        locationX = locationX,
                        locationY = locationY,
                        datetime = date
                    };
                    rc.TblVendorLocations.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static VendorLocationModel GetVendorLocation(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblVendorLocation = rc.TblVendorLocations.FirstOrDefault(v => v.VendorID == id);

                        if (tblVendorLocation != null)
                        {
                            VendorLocationModel vendorLocation = new VendorLocationModel
                            {
                                vendorID = tblVendorLocation.VendorID,
                                locationX = tblVendorLocation.locationX,
                                locationY = tblVendorLocation.locationY,
                                date = (DateTime)tblVendorLocation.datetime
                            };
                            return vendorLocation;
                        }
                        throw new Exception("Vendor location cannot be found");
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

        public static List<VendorLocationModel> GetVendorLocations()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblVendorLocations = rc.TblVendorLocations.ToList();

                    if (tblVendorLocations != null)
                    {
                        List<VendorLocationModel> vendorLocations = new List<VendorLocationModel>();

                        tblVendorLocations.ForEach(v => vendorLocations.Add(new VendorLocationModel { vendorID = v.VendorID, locationX = v.locationX, locationY = v.locationY, date = (DateTime)v.datetime }));

                        return vendorLocations;
                    }

                    throw new Exception("There currently are no vendors");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Update(VendorLocationModel vendorLocation)
        {
            try
            {
                if (vendorLocation.vendorID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblVendorLocation tblVendorLocation = rc.TblVendorLocations.FirstOrDefault(v => v.VendorID == vendorLocation.vendorID);

                        if (tblVendorLocation != null)
                        {
                            tblVendorLocation.VendorID = vendorLocation.vendorID;
                            tblVendorLocation.locationX = vendorLocation.locationX;
                            tblVendorLocation.locationY = vendorLocation.locationY;
                            tblVendorLocation.datetime = vendorLocation.date;

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
                        var vendorLocation = rc.TblVendorLocations.FirstOrDefault(v => v.VendorID == id);

                        if (vendorLocation != null)
                        {
                            rc.TblVendorLocations.Remove(vendorLocation);
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
