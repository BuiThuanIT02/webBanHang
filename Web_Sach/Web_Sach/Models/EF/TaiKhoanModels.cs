using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class TaiKhoanModels
    {
        private WebSachDb db = null;

        public TaiKhoanModels()
        {
            db = new WebSachDb();
        }


        // Tìm tk  trùng tên userName
        public TaiKhoan GetUserName(string userName)
        {
            return db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1==userName);

        }
        // End Tìm tk  trùng tên userName


        // Phân trang bảng Tài Khoản
        public IEnumerable<TaiKhoan> listPage(string searchString,int page, int pageSize)
        {
            IQueryable<TaiKhoan> query = db.TaiKhoans;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.TaiKhoan1.Contains(searchString));
            }
            return query.OrderBy(x=>x.NgaySinh).ToPagedList(page, pageSize);

        }
        // End  Phân trang bảng Tài Khoản



        //Thêm mới user
        public int InserUser(TaiKhoan user)
        {
            db.TaiKhoans.Add(user);
            db.SaveChanges();
            return user.ID;

        }

        //End Thêm mới user


        //tìm theo tên tài khoản
        public TaiKhoan UniqueUserName(string userName)
        {
            return db.TaiKhoans.FirstOrDefault(x=>x.TaiKhoan1 == userName);

        }
        // end tìm theo tên tài khoản


        // tìm theo id user
        public TaiKhoan EditUser(int id)
        {
            return db.TaiKhoans.Find(id);
        }
        // end tìm id user
        //  tm khi update không cho trùng tên
        public bool Compare(TaiKhoan tk)
        {
            var user = db.TaiKhoans.FirstOrDefault(x => x.ID != tk.ID && x.TaiKhoan1 == tk.TaiKhoan1);
            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ten không trùng

        //update khi sửa
        public bool UpdateUser(TaiKhoan tk)
        {
            try
            {
                var user = db.TaiKhoans.Find(tk.ID);

                user.TaiKhoan1 = tk.TaiKhoan1;
                user.Password = tk.Password;
                user.GioiTinh = tk.GioiTinh;
                user.Phone = tk.Phone;
                user.Address = tk.Address;
                user.FullName = tk.FullName;
                user.Email = tk.Email;
                user.NgaySinh = tk.NgaySinh;
                user.Status = tk.Status;
                db.SaveChanges();
                return true;
            }

            catch(Exception)
            {
                return false;
            }

           
        }
        //end update khi sửa


        // xóa 1 bản ghi user
        public bool Delete(int id)
        {
            try
            {
                var userDelete = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(userDelete);
                db.SaveChanges();
                return true;


            }
            catch(Exception)
            {
                return false;
            }
        }

        // end 1 bảng ghi user



        //thay đổi trạng thái user
        public bool ChangeStatus(int id)
        {
            
                var userChange = db.TaiKhoans.Find(id);
                userChange.Status = !userChange.Status;
                db.SaveChanges();
                return userChange.Status;
             
        }

        // End thay đổi trạng thái user

















    }
}