using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult AddMenu(Menu menu) => View();
        public ActionResult PutMenu(Menu menu) => View();
        public ActionResult GetMenu(int menuID) => View();
        public ActionResult DeactivateMenu(int menuID) => View();

    }
}