using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.PL;
using RoundTheCorner.BL.Models;
namespace RoundTheCorner.BL
{
    public class UserManager
    {
        public static bool Insert(UserModel user)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblUser newRow = new TblUser()
                    {
                        userID = rc.TblUsers.Any()? rc.TblUsers.Max(u => u.userID) +1: 1,
                        email = user.email,
                        firstName = user.firstName,
                        lastName = user.lastName,
                        password = user.password,
                        phone = user.phone
                    };
                    rc.TblUsers.Add(newRow);
                    rc.SaveChanges();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
