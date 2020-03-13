using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.Controllers
{
    public class OrderItemController : Controller
    {
        public ActionResult AddItem(OrderItemModel item) => View();
        public ActionResult GetItem(int itemID) => View();
        public ActionResult GetItems(int orderID) => View();
        public ActionResult DeleteItems(int itemID) => View();
        public ActionResult PutItems(OrderItemModel item ) => View();
    }
}