using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;
namespace RoundTheCorner.Controllers
{
    public class MenuItemController : Controller
    {
        public ActionResult AddItem(MenuItemModel item) => View();
        public ActionResult GetItem(int itemID) => View();
        public ActionResult GetItems(int menuID) => View();
        public ActionResult DeleteItems(int itemID) => View();
        public ActionResult PutItems(MenuItemModel item) => View();

    }
}