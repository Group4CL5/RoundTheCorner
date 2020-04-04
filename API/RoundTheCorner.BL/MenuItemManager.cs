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
                menuItem = 1,
                itemName = "Good Eats",
                price = 1,
                picture = new byte[] { 1},
                description = "sooo good",
                menuSectionID = 1

            };

            return Insert(menuItem);
        }

        public static bool Insert(MenuItemModel menuItem)/*,int menuItem, string itemName,
            int price,string picture,string description,int menuSectionID)*/
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenuItem newRow = new TblMenuItem()
                    {
                        itemID = rc.TblMenuItems.Any() ? rc.TblMenuItems.Max(u => u.itemID) + 1 : 1,
                        itemName = menuItem.itemName,
                        menuID = menuItem.menuItem,
                        price = menuItem.price,
                        picture=menuItem.picture,
                        description=menuItem.description,
                        MenuSectionID=menuItem.menuSectionID
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
        public static bool Insert(string menuItemname, int menuID, int vendorID, decimal price,byte[] picture,int menusectionID,string desc)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenuItem newRow = new TblMenuItem()
                    {
                        itemID = rc.TblMenuItems.Any() ? rc.TblMenuItems.Max(u => u.itemID) + 1 : 1,
                        menuID = menuID,
                        itemName = menuItemname,
                        price = price,
                        picture = picture,
                        description = desc,
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
                        var TblMenuItem = rc.TblMenuItems.FirstOrDefault(u => u.itemID == id);

                        if (TblMenuItem != null)
                        {
                            MenuItemModel menuItem = new MenuItemModel
                            {
                                itemID = TblMenuItem.itemID,
                                menuItem = TblMenuItem.menuID,
                                itemName = TblMenuItem.itemName,
                                price = TblMenuItem.price,
                                picture = TblMenuItem.picture,
                                description = TblMenuItem.description,
                                menuSectionID = TblMenuItem.MenuSectionID
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
                if (menuItem.itemID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblMenuItem TblMenuItem = rc.TblMenuItems.FirstOrDefault(u => u.itemID == menuItem.itemID);

                        if (TblMenuItem != null)
                        {
                            TblMenuItem.itemID = menuItem.itemID;
                            TblMenuItem.itemName = menuItem.itemName;
                            TblMenuItem.picture = menuItem.picture;
                            TblMenuItem.price = menuItem.price;
                            TblMenuItem.description = menuItem.description;
                            TblMenuItem.MenuSectionID = menuItem.menuSectionID;
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
                        var menuItem = rc.TblMenuItems.FirstOrDefault(u => u.itemID == id);

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
                           itemID=u.itemID,
                            menuItem = u.menuID,
                            itemName = u.itemName,
                            price = u.price,
                            picture = u.picture,
                            description = u.description,
                            menuSectionID = u.MenuSectionID

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
        public static List<MenuItemModel> GetMenuItems(int menuItemID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var TblMenuItems = rc.TblMenuItems.Where(w => menuItemID == w.itemID).ToList();

                    if (TblMenuItems != null)
                    {
                        List<MenuItemModel> menuItems = new List<MenuItemModel>();

                        TblMenuItems.ForEach(u => menuItems.Add(new MenuItemModel
                        {
                            itemID = u.itemID,
                            menuItem = u.menuID,
                            itemName = u.itemName,
                            price = u.price,
                            picture = u.picture,
                            description = u.description,
                            menuSectionID = u.MenuSectionID
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



