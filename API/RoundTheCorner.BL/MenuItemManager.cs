using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    public class MenuItemManager
    {
        public static bool Seed()
        {
            MenuItemModel menuItem = new MenuItemModel
            {
                MenuItem = 1,
                ItemName = "Good Eats",
                Price = 1,
                Picture = "picture_here",
                Description = "sooo good",
                MenuSectionID = 1

            };

            return true;
        }

        public static MenuItemModel Insert(MenuItemModel menuItem)/*,int menuItem, string itemName,
            int price,string picture,string description,int menuSectionID)*/
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenuItem newRow = new TblMenuItem()
                    {
                        ItemID = rc.TblMenuItems.Any() ? rc.TblMenuItems.Max(u => u.ItemID) + 1 : 1,
                        ItemName = menuItem.ItemName,
                        MenuID = menuItem.MenuItem,
                        Price = menuItem.Price,
                        Picture= menuItem.Picture,
                        Description= menuItem.Description,
                        MenuSectionID= menuItem.MenuSectionID
                    };
                    rc.TblMenuItems.Add(newRow);
                    rc.SaveChanges();
                    menuItem.ItemID = newRow.ItemID;
                    return menuItem;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Insert(string menuItemname, int menuID, decimal price, string picture,int menusectionID,string desc)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenuItem newRow = new TblMenuItem()
                    {
                        ItemID = rc.TblMenuItems.Any() ? rc.TblMenuItems.Max(u => u.ItemID) + 1 : 1,
                        MenuID = menuID,                        
                        ItemName = menuItemname,
                        Price = price,
                        Picture = picture,
                        Description = desc,
                        MenuSectionID = menusectionID

                    };
                    rc.TblMenuItems.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static MenuItemModel GetMenuItem(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var TblMenuItem = rc.TblMenuItems.FirstOrDefault(u => u.ItemID == id);

                        if (TblMenuItem != null)
                        {
                            MenuItemModel menuItem = new MenuItemModel
                            {
                                ItemID = TblMenuItem.ItemID,
                                MenuItem = TblMenuItem.MenuID,
                                ItemName = TblMenuItem.ItemName,
                                Price = TblMenuItem.Price,
                                Picture = TblMenuItem.Picture,
                                Description = TblMenuItem.Description,
                                MenuSectionID = TblMenuItem.MenuSectionID
                            };

                            return menuItem;
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
        public static bool Update(MenuItemModel menuItem)
        {
            try
            {
                if (menuItem.ItemID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblMenuItem TblMenuItem = rc.TblMenuItems.FirstOrDefault(u => u.ItemID == menuItem.ItemID);

                        if (TblMenuItem != null)
                        {
                            TblMenuItem.ItemID = menuItem.ItemID;
                            TblMenuItem.ItemName = menuItem.ItemName;
                            TblMenuItem.Picture = menuItem.Picture;
                            TblMenuItem.Price = menuItem.Price;
                            TblMenuItem.Description = menuItem.Description;
                            TblMenuItem.MenuSectionID = menuItem.MenuSectionID;
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
                        var menuItem = rc.TblMenuItems.FirstOrDefault(u => u.ItemID == id);

                        if (menuItem != null)
                        {
                            rc.TblMenuItems.Remove(menuItem);
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

        public static List<MenuItemModel> GetMenuItems()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var TblMenuItems = rc.TblMenuItems.ToList();

                    if (TblMenuItems != null)
                    {
                        List<MenuItemModel> menuItems = new List<MenuItemModel>();

                        TblMenuItems.ForEach(u => menuItems.Add(new MenuItemModel
                        {
                           ItemID=u.ItemID,
                            MenuItem = u.MenuID,
                            ItemName = u.ItemName,
                            Price = u.Price,
                            Picture = u.Picture,
                            Description = u.Description,
                            MenuSectionID = u.MenuSectionID

                        }));

                        return menuItems;
                    }

                    throw new Exception("There currently are no menuItems");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<MenuItemModel> GetMenuItems(int menuID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var TblMenuItems = rc.TblMenuItems.Where(w => menuID == w.MenuID).ToList();

                    if (TblMenuItems != null)
                    {
                        List<MenuItemModel> menuItems = new List<MenuItemModel>();

                        TblMenuItems.ForEach(u => menuItems.Add(new MenuItemModel
                        {
                            ItemID = u.ItemID,
                            MenuItem = u.MenuID,
                            ItemName = u.ItemName,
                            Price = u.Price,
                            Picture = u.Picture,
                            Description = u.Description,
                            MenuSectionID = u.MenuSectionID
                        }));

                        return menuItems;
                    }

                    throw new Exception("There currently are no menuItems");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



