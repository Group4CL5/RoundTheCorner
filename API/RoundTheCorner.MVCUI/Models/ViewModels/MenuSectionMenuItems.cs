using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.MVCUI.Models.ViewModels
{
    public class MenuSectionMenuItems
    {
        public VendorModel VendorModel { get; set; }
        public MenuModel MenuModel { get; set; }
        public List<MenuSectionModel> MenuSections { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }

    }
}