using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.MVCUI.Models.ViewModels
{
    public class MenuMenuItemViewModel
    {
        public MenuModel Menu { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }

        public List<MenuSectionModel> MenuSection { get; set; }
    }
}