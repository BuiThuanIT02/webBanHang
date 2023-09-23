using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class Register
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Mời bạn nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        [StringLength(20,MinimumLength =8 , ErrorMessage ="Độ dài mật khẩu ít nhất 8 ký tự.")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Mời bạn xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Mời bạn nhập họ và tên")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Mời bạn nhập địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Mời bạn nhập Email")]
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Mời bạn nhập số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
    }
}