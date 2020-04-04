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
                vendorID = 1,
                userID = 1,
                id =1
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
                        id = rc.TblVendorEmployees.Any() ? rc.TblVendorEmployees.Max(u => u.id) + 1 : 1,
                        vendorID = 1,
                        userID = 1
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

        public static bool Insert(int id, int userID, int vendorID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblVendorEmployee newRow = new TblVendorEmployee()
                    {
                        id = rc.TblVendorEmployees.Any() ? rc.TblVendorEmployees.Max(u => u.id) + 1 : 1,
                        userID = 1,
                        vendorID = 1

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

        public static VendorEmployeeModel GetVendorEmployee(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblVendorEmployee = rc.TblVendorEmployees.FirstOrDefault(u => u.id == id);

                        if (tblVendorEmployee != null)
                        {
                            VendorEmployeeModel vendorEmployee = new VendorEmployeeModel
                            {
                                id = tblVendorEmployee.id,
                                userID = tblVendorEmployee.userID,
                                vendorID = tblVendorEmployee.vendorID

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

                        tblVendorEmployee.ForEach(u => vendorEmployees.Add(new VendorEmployeeModel { id = u.id, vendorID = u.vendorID, userID = u.userID }));

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
                if (vendorEmployee.id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblVendorEmployee tblVendorEmployee = rc.TblVendorEmployees.FirstOrDefault(u => u.id == vendorEmployee.id);

                        if (tblVendorEmployee != null)
                        {
                            tblVendorEmployee.id = vendorEmployee.id;
                            tblVendorEmployee.userID = vendorEmployee.userID;
                            tblVendorEmployee.vendorID = vendorEmployee.vendorID;
                            

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
                        var vendorEmployee = rc.TblVendorEmployees.FirstOrDefault(u => u.id == id);

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
