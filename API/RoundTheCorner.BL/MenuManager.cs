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
                vendorID = 1,
                isActive = true
            };

            return Insert(menu);
        }

        public static bool Insert(MenuModel menu)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenu newRow = new TblMenu()
                    {
                        menuID = rc.TblMenus.Any() ? rc.TblMenus.Max(u => u.menuID) + 1 : 1,
                        vendorID = menu.vendorID,
                        isActive = menu.isActive
                    };
                    rc.TblMenus.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Insert(int vendor)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenu newRow = new TblMenu()
                    {
                        menuID = rc.TblMenus.Any() ? rc.TblMenus.Max(u => u.menuID) + 1 : 1,
                        vendorID = vendor,
                        isActive = true
                    };
                    rc.TblMenus.Add(newRow);
                    rc.SaveChanges();
                    return true;
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
                        var tblMenu = rc.TblMenus.FirstOrDefault(u => u.menuID == id);

                        if (tblMenu != null)
                        {
                            MenuModel menu = new MenuModel
                            {
                                menuID = tblMenu.menuID,
                                vendorID = tblMenu.vendorID,
                                isActive = tblMenu.isActive
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

        public static List<MenuModel> GetMenu()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblMenu = rc.TblMenus.ToList();

                    if (tblMenu != null)
                    {
                        List<MenuModel> menus = new List<MenuModel>();

                        tblMenu.ForEach(u => menus.Add(new MenuModel { menuID = u.menuID, vendorID = u.vendorID, isActive = u.isActive }));

                        return menus;
                    }

                    throw new Exception("There currently are no menus");
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
                        TblMenu tblMenu = rc.TblMenus.FirstOrDefault(u => u.menuID == id);

                        if (tblMenu != null)
                        {
                            tblMenu.isActive = false;

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
                        var menu = rc.TblMenus.FirstOrDefault(u => u.menuID == id);

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
