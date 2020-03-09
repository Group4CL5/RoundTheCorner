using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoundTheCorner.Controllers
{
    public class MenuItemController : Controller
    {
        public ActionResult AddItem(MenuItem item) => View();
        public ActionResult GetItem(int itemID) => View();
        public ActionResult GetItems(int menuID) => View();
        public ActionResult DeleteItems(int itemID) => View();
        public ActionResult PutItems(MenuItem item) => View();

    }
}