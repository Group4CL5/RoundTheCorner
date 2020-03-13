using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RoundTheCorner.BL.Models;

namespace RoundTheCorner.Controllers
{
    public class OrdersController : Controller
    {
        // From Diagrams from project 8
        public ActionResult AddOrder(OrderModel order) => View();
        public ActionResult PutOrder(OrderModel order) => View();
        public ActionResult GetOrder(int orderID) => View();
        public ActionResult GetOrders() => View();
        public ActionResult GetOrders(int userID) => View();

    }
}