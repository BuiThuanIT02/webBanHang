using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Session
{
   
    public static class SessionHelper
    {
        public static string USER_KEY = "USER_KEY"; // admin
        public static string CART_KEY = "CART_KEY"; // giỏ hàng client
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CurrentCulture { get; set; }
    }
}