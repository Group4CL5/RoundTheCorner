using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoundTheCorner.Controllers
{
    public class OrderItemController : Controller
    {
        public ActionResult AddItem( OrderItem item) => View();
        public ActionResult GetItem(int itemID) => View();
        public ActionResult GetItems(int orderID) => View();
        public ActionResult DeleteItems(int itemID) => View();
        public ActionResult PutItems(OrderItem item ) => View();
    }
}