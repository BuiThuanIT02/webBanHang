using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models
{
    public class LoginModels
    {
        private WebSachDb db = null;

        public LoginModels()
        {
            db = new WebSachDb();
        }
       public List<string> GetListCredential(string userName) // phân quyền
        {
            var user = db.TaiKhoans.Single(x => x.TaiKhoan1 == userName);
            var data = (from a in db.Credentials
                       join b in db.UserGroups on a.UserGroupID equals b.ID
                       join c in db.Roles on a.RoleID equals c.ID
                       where b.ID == user.GroupID
                       select new
                       {
                          RoleID = a.RoleID,
                          UserGroupID = a.UserGroupID,

                       }).AsEnumerable().Select(x=>new Credential() { 
                              RoleID = x.RoleID,
                              UserGroupID = x.UserGroupID
                       });

            return data.Select(x=>x.RoleID).ToList(); 
                     
        }
        public int CheckLogin(string userName, string passWord , bool isLoginAdmin=false)
        {
            var resulf = db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == userName);
            if (resulf == null)
            {
                return -1;// không tồn tại
            }
            else
            {// admin
                if (isLoginAdmin == true)
                {
                    // đăng nhập bằng admin or mod
                    if (resulf.GroupID == "ADMIN" || resulf.GroupID == "MOD")
                    {
                        if (resulf.Status == false)
                        {
                            return 0; // bị khóa
                        }
                        else
                        {
                            if (resulf.Password == passWord)
                            {
                                return 1; // tk tồn tại
                            }
                            else
                            {
                                return 2;
                            }
                        }
                    }
                        else
                        {
                            return -3;
                        }
                    
                }
              
                //clients
                else
                { // đăng nhập client
                    if (resulf.GroupID == "MEMBER")
                    {
                        if (resulf.Status == false)
                        {
                            return 0; // bị khóa
                        }
                        else
                        {
                            if (resulf.Password == passWord)
                            {
                                return 1; // tk tồn tại
                            }
                            else
                            {
                                return 2;
                            }
                        }
                    }
                    else
                    {
                        
                            if (resulf.Password == passWord)
                            {
                                return 3; // tk tồn tại
                            }

                        return 4;
                          
                     }
                      
                } 

              
            }




               

         }

        

















    }
}