using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupCourseWork
{
    public static class User
    {
        public static bool IsLoggedIn()
        {
            if (HttpContext.Current.Session["user_id"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int LoggedInUserId()
        {
            if ( IsLoggedIn() == true)
            {
                return Convert.ToInt32(HttpContext.Current.Session["user_id"].ToString());
            }
            else
            {
                return 0;
            }
        }

        public static bool signout()
        {
            HttpContext.Current.Session.Clear();
           
            return true;

        }

        public static string LoggedInUserType ()
        {
            if (HttpContext.Current.Session["user_type"] != null)
            {
                return HttpContext.Current.Session["user_type"].ToString();
            }
            else
            {
                return "no-type";
            }
        }

        public static bool CreateLogin(string Number, string Type)
        {
            HttpContext.Current.Session["user_id"]   = Number;
            HttpContext.Current.Session["user_type"] = Type;
            return true;
        }
    }
}