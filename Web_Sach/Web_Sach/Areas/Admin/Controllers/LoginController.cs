using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Areas.Admin.Data;
using Web_Sach.Models;
using Web_Sach.Models.EF;
using Web_Sach.Session;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


          [HttpPost]
        [ValidateAntiForgeryToken]
     
        public ActionResult Login(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                var user = new LoginModels().CheckLogin(login.UserName, EncryptMD5.MD5Hash(login.Password),true);
                if(user == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if(user == 0)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
                else if (user == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập");
                }
                else if(user == 1)
                { // đăng nhập thành công lưu luôn vào session
                    var taiKhoan = new TaiKhoanModels().GetUserName(login.UserName);
                    var userSession = new UserLoginSession();
                    userSession.UserID = taiKhoan.ID;
                    userSession.UserName = taiKhoan.TaiKhoan1;
                    userSession.GroupID = taiKhoan.GroupID;
                    var listCredentails = new LoginModels().GetListCredential(login.UserName);
                    Session.Add(SessionHelper.USER_KEY, userSession);
                    Session.Add(SessionHelper.SESSION_CREDENTIALS, listCredentails);



                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
            }

            return View("Index");
        }




        [HttpGet]

        public ActionResult LogoutAd()
        {
            Session[SessionHelper.USER_KEY] = null;
            return RedirectToAction("Index", "Login");
        }








    }
}