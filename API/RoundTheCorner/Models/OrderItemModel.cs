using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Models
{
    public class OrderItemModel
    {
        public int orderItemID { get; set; }
        public int menuItemID { get; set; }
        public double price { get; set; }
    }
}
