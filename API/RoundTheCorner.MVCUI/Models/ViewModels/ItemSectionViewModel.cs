using RoundTheCorner.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoundTheCorner.MVCUI.Models.ViewModels
{
    public class ItemSectionViewModel
    {
        public MenuItemModel Item { get; set; }
        public List<MenuSectionModel> Sections { get; set; }
    }
}