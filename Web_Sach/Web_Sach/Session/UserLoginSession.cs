using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Session
{
    [Serializable]
    //Nơi lưu trữ dữ liệu của Session
    public class UserLoginSession
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string GroupID { get; set; }

    }
}