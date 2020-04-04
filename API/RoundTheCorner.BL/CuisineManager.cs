using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    class CuisineManager
    {
        public static bool Seed()
        {
            CuisineModel cuisine = new CuisineModel
            {
                vendorID = 1,
                menuID = 1,
                cuisineName="Good Eats"
            };

            return Insert(cuisine);
        }

        public static bool Insert(CuisineModel cuisine)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblCuisine newRow = new TblCuisine()
                    {
                        CuisineID = rc.TblCuisines.Any() ? rc.TblCuisines.Max(u => u.CuisineID) + 1 : 1,
                        MenuID = cuisine.menuID,
                        VendorID = cuisine.vendorID,
                        CuisineName= cuisine.cuisineName

                    };
                    rc.TblCuisines.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Insert(string cuisinename, int menuID, int vendorID )
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblCuisine newRow = new TblCuisine()
                    {
                        CuisineID = rc.TblCuisines.Any() ? rc.TblCuisines.Max(u => u.CuisineID) + 1 : 1,
                        VendorID = vendorID,
                        MenuID = menuID,
                        CuisineName = cuisinename

                    };
                    rc.TblCuisines.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CuisineModel GetCuisine(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblCuisine = rc.TblCuisines.FirstOrDefault(u => u.CuisineID == id);

                        if (tblCuisine != null)
                        {
                            CuisineModel cuisine = new CuisineModel
                            {
                                cuisineID = tblCuisine.CuisineID,
                                vendorID = tblCuisine.VendorID,
                                menuID = tblCuisine.MenuID,
                                cuisineName = tblCuisine.CuisineName
                            };

                            return cuisine;
                        }

                        throw new Exception("Item cannot be found");
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
        public static bool Update(CuisineModel cuisine)
        {
            try
            {
                if (cuisine.cuisineID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblCuisine tblCuisine = rc.TblCuisines.FirstOrDefault(u => u.CuisineID == cuisine.cuisineID);

                        if (tblCuisine != null)
                        {
                            tblCuisine.CuisineID = cuisine.cuisineID;
                            tblCuisine.VendorID = cuisine.vendorID;
                            tblCuisine.MenuID = cuisine.menuID;
                            tblCuisine.CuisineName = cuisine.cuisineName;



                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Item was not found");
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
        public static bool Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var cuisine = rc.TblCuisines.FirstOrDefault(u => u.CuisineID == id);

                        if (cuisine != null)
                        {
                            rc.TblCuisines.Remove(cuisine);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Item cannot be found");
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

        public static List<CuisineModel> GetCuisines()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblCuisines = rc.TblCuisines.ToList();

                    if (tblCuisines != null)
                    {
                        List<CuisineModel> cuisines = new List<CuisineModel>();

                        tblCuisines.ForEach(u => cuisines.Add(new CuisineModel { cuisineID = u.CuisineID, menuID= u.MenuID,
                          vendorID =u.VendorID, cuisineName = u.CuisineName }));

                        return cuisines;
                    }

                    throw new Exception("There currently are no cuisines");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CuisineModel> GetCuisines(int cuisineID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblCuisines = rc.TblCuisines.Where(w => cuisineID == w.CuisineID).ToList();

                    if (tblCuisines != null)
                    {
                        List<CuisineModel> cuisines = new List<CuisineModel>();

                        tblCuisines.ForEach(u => cuisines.Add(new CuisineModel { cuisineID = u.CuisineID, menuID = u.MenuID, 
                            vendorID=u.VendorID, cuisineName = u.CuisineName }));

                        return cuisines;
                    }

                    throw new Exception("There currently are no cuisines");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



