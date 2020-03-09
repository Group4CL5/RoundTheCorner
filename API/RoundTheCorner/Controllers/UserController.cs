using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundTheCorner.Models;


namespace RoundTheCorner.Controllers
{
    public class UserController : Controller
    {
        //From Our Class Diagram from Project Step 8 Diagrams
        public ActionResult AddUser(UserModel user )
        {
            return View();
        }
        public ActionResult DeactivateUser(int UserID)
        {
            return View();
        }
        public ActionResult PutUser(UserModel user ) => View();
        public ActionResult GetUser(int UserID) => View();
        public ActionResult GetUsers() => View();

        
    }
}