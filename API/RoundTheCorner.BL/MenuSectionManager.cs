using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    public static class MenuSectionManager
    {
        public static bool Seed()
        {
            MenuSectionModel menuSectionModel = new MenuSectionModel()
            {
                MenuID = 1,
                DisplayOrderNum = 100
            };

            return Insert(menuSectionModel);
        }

        public static bool Insert(MenuSectionModel menuSection)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenuSection newRow = new TblMenuSection()
                    {
                        MenuSectionID = rc.TblMenuSections.Any() ? rc.TblMenuSections.Max(u => u.MenuSectionID) + 1 : 1,
                        MenuID = menuSection.MenuID,
                        DisplayOrderNum = menuSection.DisplayOrderNum
                    };
                    rc.TblMenuSections.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Insert(int menu, int order)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblMenuSection newRow = new TblMenuSection()
                    {
                        MenuSectionID = rc.TblMenuSections.Any() ? rc.TblMenuSections.Max(u => u.MenuSectionID) + 1 : 1,
                        MenuID = menu,
                        DisplayOrderNum = order
                    };
                    rc.TblMenuSections.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MenuSectionModel GetMenuSection(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblMenuSection = rc.TblMenuSections.FirstOrDefault(u => u.MenuSectionID == id);

                        if (tblMenuSection != null)
                        {
                            MenuSectionModel menuSection = new MenuSectionModel
                            {
                                MenuSectionID = tblMenuSection.MenuSectionID,
                                MenuID = tblMenuSection.MenuID,
                                DisplayOrderNum = tblMenuSection.DisplayOrderNum
                            };

                            return menuSection;
                        }

                        throw new Exception("Menu Section cannot be found");
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

        public static List<MenuSectionModel> GetMenuSections()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblMenuSection = rc.TblMenuSections.ToList();

                    if (tblMenuSection != null)
                    {
                        List<MenuSectionModel> menuSections = new List<MenuSectionModel>();

                        tblMenuSection.ForEach(u => menuSections.Add(new MenuSectionModel { MenuSectionID = u.MenuSectionID, MenuID = u.MenuID, DisplayOrderNum = u.DisplayOrderNum }));

                        return menuSections;
                    }

                    throw new Exception("There currently are no menu sections");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Update(MenuSectionModel menuSection)
        {
            try
            {
                if (menuSection.MenuSectionID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblMenuSection tblMenuSection = rc.TblMenuSections.FirstOrDefault(u => u.MenuSectionID == menuSection.MenuSectionID);

                        if (tblMenuSection != null)
                        {
                            tblMenuSection.DisplayOrderNum = menuSection.DisplayOrderNum;

                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Menu section was not found");
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
                        var menuSection = rc.TblMenuSections.FirstOrDefault(u => u.MenuSectionID == id);

                        if (menuSection != null)
                        {
                            rc.TblMenuSections.Remove(menuSection);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Menu section cannot be found");
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
