using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Models.EF;
using Web_Sach.Session;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        WebSachDb db = new WebSachDb();
        // GET: Admin/User
        // phân quyền hashCredential
        [HashCredential(RoleID ="VIEW_USER")]
        public ActionResult Index(string searchString,int page=1 ,  int pageSize =20 )
        {
            var listPage = new TaiKhoanModels().listPage(searchString,page,pageSize );
            ViewBag.SearchString = searchString;
            return View(listPage);
        }

        //Thêm mới User
        [HttpGet]
        [HashCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {

          
                setViewBagGroupID();
            
            return View();
        }
        // dropdowlist GroupID
        public void setViewBagGroupID(string selectedId =""  )
        {
            if (string.IsNullOrEmpty(selectedId))
            {
                selectedId = null;
            }
            var drowdoad =  db.UserGroups.ToList();
            ViewBag.GroupID = new SelectList(drowdoad, "ID", "Name", selectedId);
          
        }


        [HttpPost]
        [HashCredential(RoleID = "ADD_USER")]
        public ActionResult Create(TaiKhoan user)
        {
            var userUnique = new TaiKhoanModels().UniqueUserName(user.TaiKhoan1);
            if(userUnique != null)
            {
                ModelState.AddModelError("TaiKhoan1","Tài khoản đã tồn tại");

        
                return View(user);
            }
            if ( user.Password != null)
            { 
                var password = user.Password;

                if ( !password.Any(char.IsUpper) || !password.Any(char.IsDigit) || password.Length <8)
                {
                    ModelState.AddModelError("Password", "Mật khẩu có độ dài lớn hơn 8 và chứa ít nhất 1 chữ viết hoa và 1 số");
                    return View(user);
                }

            }
               

     
            



            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = EncryptMD5.MD5Hash(user.Password);
                }
                var addUser = new TaiKhoanModels().InserUser(user);
                if(addUser > 0)
                {// thêm user thành công
                    SetAlert("Thêm User thành công", "success");
                    return RedirectToAction("Index", "User");
                }
               
            }
            else
            {
                SetAlert("Thêm User thất bại", "error");
             
               

            }
            return View("Create");
        }



        /*Sửa bản ghi User*/

        [HttpGet]
        [HashCredential(RoleID = "EDIT_USER")]
        public ActionResult Update(int id)
        {
            var userEdit = new TaiKhoanModels().EditUser(id);
         //   setViewBagGroupID(userEdit.GroupID);
            return View(userEdit);
        }


        [HttpPost]
        [HashCredential(RoleID = "EDIT_USER")]
        public ActionResult Update(TaiKhoan tk )
        {
            if (ModelState.IsValid)
            {
                var userUpdate = new TaiKhoanModels();
                // so sánh mật khẩu cũ và mật khẩu mới
                var pasOld = userUpdate.EditUser(tk.ID).Password;
                if (userUpdate.Compare(tk))
                {
                    ModelState.AddModelError("TaiKhoan1", "Tên tài khoản đã tồn tại");
                    return View(tk);
                }
            
                if (pasOld != tk.Password)
                {
                    var password = tk.Password;

                    if (!password.Any(char.IsUpper) || !password.Any(char.IsDigit) || password.Length < 8)
                    {
                        ModelState.AddModelError("Password", "Mật khẩu có độ dài lớn hơn 8 và chứa ít nhất 1 chữ viết hoa và 1 số");
                        return View(tk);
                    }
                    tk.Password = EncryptMD5.MD5Hash(tk.Password);
                }
                if (userUpdate.UpdateUser(tk))
                {
                    SetAlert("Update bản ghi thành công", "success");
                    return RedirectToAction("Index", "User");
                }
              

            } 
            else
                {
                    SetAlert("Update thất bại", "error");
                return View(tk);
            }
            return View("Index");
        }


        // End sửa bản ghi

        // Xóa bản ghi
        [HttpDelete]
        [HashCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
             new TaiKhoanModels().Delete(id);
          
              
            return RedirectToAction("Index", "User");
           
        }


        // thay đổi trạng thái user
        [HttpPost]
        [HashCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(int id)
        {
            var userChange = new TaiKhoanModels().ChangeStatus(id);
           
                return Json(new
                {
                    status = userChange

                }); 
           
        }

        // End thay đổi trạng thái user

















    }
}