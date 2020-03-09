using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Controllers
{
    public class OrdersController : Controller
    {
        // From Diagrams from project 8
        public ActionResult AddOrder(Order order) => View();
        public ActionResult PutOrder(Order order) => View();
        public ActionResult GetOrder(int orderID) => View();
        public ActionResult AddOrder(Order order) => View();
        public ActionResult AddOrder(Order order) => View();

    }
}