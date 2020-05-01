using RoundTheCorner.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoundTheCorner.BL;

namespace RoundTheCorner.MVCUI.Models
{
    public class Authenticate
    {
        public static bool IsAuthenticated()
        {
            if (HttpContext.Current.Session==null)
            {
                return false;
            }
            else
            {
                return HttpContext.Current.Session["User"] != null;
            }
        }

        public static bool IsAdmin()
        {
            UserModel user = (UserModel)HttpContext.Current.Session["User"];

            if (user == null)
            {
                return false;
            }
            else
            {               
                return UserManager.GetUser(user.UserID).Admin;
            }
        }

        public static bool IsVendorOwner()
        {
            UserModel user = (UserModel)HttpContext.Current.Session["User"];
            
            if (user == null)
            {
                return false;
            }
            else
            {
                VendorModel vendor = VendorManager.GetVendors().FirstOrDefault(v => v.OwnerID == user.UserID);
                if (vendor == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}