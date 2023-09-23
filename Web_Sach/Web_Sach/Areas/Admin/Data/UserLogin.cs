using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Sach.Areas.Admin.Data
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Mời nhập vào tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Mời nhập vào mật khẩu")]
        public string Password { get; set; }
        public bool Remeber { get; set; }
    }
}