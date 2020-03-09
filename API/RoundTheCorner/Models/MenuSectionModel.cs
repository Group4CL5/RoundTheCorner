using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;

namespace RoundTheCorner.Models
{
    public class MenuSectionModel
    {
        public int menuSectionID { get; set; }
        public int menuID { get; set; }
        public int displayOrderNum { get; set; }
    }
}
