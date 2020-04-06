using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCorner.BL.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        // 0 for active and 1 for deactivated
        public bool Deactivated { get; set; }
    }
}
