using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    public class VendorEmployeeManager
    {
        // Just a comment
        public static bool Seed()
        {
            VendorEmployeeModel vendorEmployee = new VendorEmployeeModel
            {
                VendorID = 1,
                UserID = 1,
                ID =1
            };

            return Insert(vendorEmployee);
        }

        public static bool Insert(VendorEmployeeModel vendorEmployee)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendorEmployee newRow = new TblVendorEmployee()
                    {
                        ID = rc.TblVendorEmployees.Any() ? rc.TblVendorEmployees.Max(u => u.ID) + 1 : 1,
                        VendorID = vendorEmployee.VendorID,
                        UserID = vendorEmployee.UserID
                    };
                    rc.TblVendorEmployees.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Insert( int UserID, int VendorID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendorEmployee newRow = new TblVendorEmployee()
                    {
                        ID = rc.TblVendorEmployees.Any() ? rc.TblVendorEmployees.Max(u => u.ID) + 1 : 1,
                        UserID = UserID,
                        VendorID = VendorID

                    };
                    rc.TblVendorEmployees.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static VendorEmployeeModel GetVendorEmployee(int ID)
        {
            try
            {
                if (ID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblVendorEmployee = rc.TblVendorEmployees.FirstOrDefault(u => u.ID == ID);

                        if (tblVendorEmployee != null)
                        {
                            VendorEmployeeModel vendorEmployee = new VendorEmployeeModel
                            {
                                ID = tblVendorEmployee.ID,
                                UserID = tblVendorEmployee.UserID,
                                VendorID = tblVendorEmployee.VendorID

                            };

                            return vendorEmployee;
                        }

                        throw new Exception("VendorEmployee cannot be found");
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

        public static List<VendorEmployeeModel> GetVendorEmployee()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblVendorEmployee = rc.TblVendorEmployees.ToList();

                    if (tblVendorEmployee != null)
                    {
                        List<VendorEmployeeModel> vendorEmployees = new List<VendorEmployeeModel>();

                        tblVendorEmployee.ForEach(u => vendorEmployees.Add(new VendorEmployeeModel { ID = u.ID, VendorID = u.VendorID, UserID = u.UserID }));

                        return vendorEmployees;
                    }

                    throw new Exception("There currently are no vendorEmployees");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool Update(VendorEmployeeModel vendorEmployee)
        {
            try
            {
                if (vendorEmployee.ID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblVendorEmployee tblVendorEmployee = rc.TblVendorEmployees.FirstOrDefault(u => u.ID == vendorEmployee.ID);

                        if (tblVendorEmployee != null)
                        {
                            tblVendorEmployee.ID = vendorEmployee.ID;
                            tblVendorEmployee.UserID = vendorEmployee.UserID;
                            tblVendorEmployee.VendorID = vendorEmployee.VendorID;
                            

                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("VendorEmployee was not found");
                        }
                    }
                }
                else
                {
                    throw new Exception("Must have a valID ID");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Unit tests only
        public static bool Delete(int ID)
        {
            try
            {
                if (ID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var vendorEmployee = rc.TblVendorEmployees.FirstOrDefault(u => u.ID == ID);

                        if (vendorEmployee != null)
                        {
                            rc.TblVendorEmployees.Remove(vendorEmployee);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("VendorEmployee cannot be found");
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
