using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Models
{
    public class OrderModel
    {
        public int orderID {get; set;}
        public int userID {get; set;}
        public int vendorID {get; set;}
        public DateTime orderDate {get; set;}

    }
}
