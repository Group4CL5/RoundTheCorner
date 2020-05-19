using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.PL;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.BL
{
    public static class MenuManager
    {
        public static bool Seed()
        {
            MenuModel menu = new MenuModel
            {
                VendorID = 1,
                IsActive = true
            };

            return true;
        }

        public static MenuModel Insert(MenuModel menu)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenu newRow = new TblMenu()
                    {
                        MenuID = rc.TblMenus.Any() ? rc.TblMenus.Max(u => u.MenuID) + 1 : 1,
                        VendorID = menu.VendorID,
                        IsActive = menu.IsActive
                    };
                    rc.TblMenus.Add(newRow);
                    rc.SaveChanges();
                    MenuModel menuModel = new MenuModel();
                    menuModel.MenuID = newRow.MenuID;
                    return menuModel;
                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MenuModel Insert(int vendor)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenu newRow = new TblMenu()
                    {
                        MenuID = rc.TblMenus.Any() ? rc.TblMenus.Max(u => u.MenuID) + 1 : 1,
                        VendorID = vendor,
                        IsActive = true
                    };
                    rc.TblMenus.Add(newRow);
                    rc.SaveChanges();
                    MenuModel menuModel = new MenuModel();
                    menuModel.MenuID = newRow.MenuID;
                    return menuModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MenuModel GetMenu(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblMenu = rc.TblMenus.FirstOrDefault(u => u.MenuID == id);

                        if (tblMenu != null)
                        {
                            MenuModel menu = new MenuModel
                            {
                                MenuID = tblMenu.MenuID,
                                VendorID = tblMenu.VendorID,
                                IsActive = tblMenu.IsActive
                            };

                            return menu;
                        }

                        throw new Exception("Menu cannot be found");
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
         public static MenuModel GetVendorMenu(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblMenu = rc.TblMenus.FirstOrDefault(u => u.VendorID == id);

                        if (tblMenu != null)
                        {
                            MenuModel menu = new MenuModel
                            {
                                MenuID = tblMenu.MenuID,
                                VendorID = tblMenu.VendorID,
                                IsActive = tblMenu.IsActive
                            };

                            return menu;
                        }

                        return new MenuModel();
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

        public static List<MenuModel> GetVendorMenus(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblMenu = rc.TblMenus.Where(u => u.VendorID == id).ToList();

                        if (tblMenu != null)
                        {
                            List<MenuModel> menuModel = new List<MenuModel>();
                            foreach (var item in tblMenu)
                            {
                                MenuModel menu = new MenuModel
                                {
                                    MenuID = item.MenuID,
                                    VendorID = item.VendorID,
                                    IsActive = item.IsActive
                                };
                                menuModel.Add(menu);
                            }


                            return menuModel;
                        }

                        throw new Exception("Menu cannot be found");
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

        public static bool Deactivate(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblMenu tblMenu = rc.TblMenus.FirstOrDefault(u => u.MenuID == id);

                        if (tblMenu != null)
                        {
                            tblMenu.IsActive = false;

                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Menu was not found");
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
                        var menu = rc.TblMenus.FirstOrDefault(u => u.MenuID == id);

                        if (menu != null)
                        {
                            rc.TblMenus.Remove(menu);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Menu cannot be found");
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
