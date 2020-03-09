using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCorner.Models
{
    public class UserModel
    {
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime DOB { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }
}
