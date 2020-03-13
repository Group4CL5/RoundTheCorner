using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult AddMenu(MenuModel menu) => View();
        public ActionResult PutMenu(MenuModel menu) => View();
        public ActionResult Details() => View();
        public ActionResult DeactivateMenu(int menuID) => View();

    }
}