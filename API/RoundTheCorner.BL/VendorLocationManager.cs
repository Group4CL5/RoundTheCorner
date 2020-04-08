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
                VendorID = 1,
                LocationX = 100,
                LocationY = 200,
                Date = new DateTime(1950, 12, 31),

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
                        LocationX = vendorLocation.LocationX, 
                        LocationY = vendorLocation.LocationY, 
                        Datetime = vendorLocation.Date
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

        public static bool Insert( int LocationX, int LocationY, DateTime Date)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendorLocation newRow = new TblVendorLocation()
                    {
                        VendorID = rc.TblVendorLocations.Any() ? rc.TblVendorLocations.Max(v => v.VendorID) + 1 : 1,
                        LocationX = LocationX,
                        LocationY = LocationY,
                        Datetime = Date
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
                                VendorID = tblVendorLocation.VendorID,
                                LocationX = tblVendorLocation.LocationX,
                                LocationY = tblVendorLocation.LocationY,
                                Date = (DateTime)tblVendorLocation.Datetime
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

                        tblVendorLocations.ForEach(v => vendorLocations.Add(new VendorLocationModel { VendorID = v.VendorID, LocationX = v.LocationX, LocationY = v.LocationY, Date = (DateTime)v.Datetime }));

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
                if (vendorLocation.VendorID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblVendorLocation tblVendorLocation = rc.TblVendorLocations.FirstOrDefault(v => v.VendorID == vendorLocation.VendorID);

                        if (tblVendorLocation != null)
                        {
                            tblVendorLocation.VendorID = vendorLocation.VendorID;
                            tblVendorLocation.LocationX = vendorLocation.LocationX;
                            tblVendorLocation.LocationY = vendorLocation.LocationY;
                            tblVendorLocation.Datetime = vendorLocation.Date;

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
