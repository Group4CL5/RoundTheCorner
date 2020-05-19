using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.MVCUI.Models.ViewModels
{
    public class MenusCuisineViewModel
    {
        public List<MenuModel> Menus { get; set; }
        public CuisineModel Cuisine { get; set; }
    }
}