using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class UserLoginClients
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Tài khoản")]
        [Required(ErrorMessage ="Mời nhập tài khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Password { get; set; }

        public bool Remeber { get; set; }


    }
}