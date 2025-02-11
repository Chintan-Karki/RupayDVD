using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupCourseWork.Models
{
    public class ResponseWrite
    {
        public static string create( string message )
        {
            return "<script>"  + " document.getElementById('error-message').innerHtml = '"+message+"';" + "</script>";
        }
    }
}