using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class Book
    {

        private WebSachDb db = null;

        public Book()
        {
            db = new WebSachDb();
        }

        //lấy ra 1 đối tượng sách
        public Sach GetBookById(int id)
        {
            return db.Saches.Find(id);
        }

        // kiểm tra tên sách trc khi tạo
        public bool Compare(Sach sach)
        {
            var book = db.Saches.FirstOrDefault( x=>x.Name == sach.Name);
           if(book != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //End kiểm tra tên sách trc khi tạo


        // thêm mới sách
         public int Insert(Sach sach)
        {
            db.Saches.Add(sach);
            db.SaveChanges();
            return sach.ID;
        }


        // Update sách

        public Sach Edit(int id)
        {
            return db.Saches.Find(id);
        }

        // update check tên sách
        public bool CompareUpdate(Sach sach)
        {
            var book = db.Saches.FirstOrDefault(x => x.ID != sach.ID && x.Name == sach.Name);
            if(book != null)
            {// đã tồn tại
                return true;
            }
            else
            {// chưa tồn tại
                return false;
            }

        }


       // update sách
       public bool Update(Sach sach)
        {
            try
            {
                var book = db.Saches.Find(sach.ID);
                book.Name = sach.Name;
                book.Image = sach.Image;
                book.NhaCungCapID = sach.NhaCungCapID;
                book.NhaXuatBanID = sach.NhaXuatBanID;
                book.Price = sach.Price;
                book.Quantity = sach.Quantity;
                book.Sale = sach.Sale;
                book.MoTa = sach.MoTa;
                book.KichThuoc = sach.KichThuoc;
                book.TrongLuong = sach.TrongLuong;
                book.SoTrang = sach.SoTrang;
                book.SoLuongTon = sach.SoLuongTon;
                book.MetaTitle = sach.MetaTitle;
                book.TopHot = sach.TopHot;
                book.ViewCount = sach.ViewCount;
                db.SaveChanges();
                return true;



            }
            catch (Exception)
            {
                return false;
            }

        }


        // xóa bản ghi

        public bool Delete(int id)
        {
            try
            {
                var bookDelete = db.Saches.Find(id);
                db.Saches.Remove(bookDelete);
                db.SaveChanges();
                return true;

            }

            catch (Exception)
            {
                return false;

            }

        }

        // thay đổi trạng thái

        public bool ChangeStatus(int id)
        {
            
                var bookStatus = db.Saches.Find(id);
                bookStatus.Status = !bookStatus.Status;
            db.SaveChanges();
                return bookStatus.Status;
            
        }


        public IEnumerable<Sach> listPage(string search, int page, int pageSize)
        {
            IQueryable<Sach> product = db.Saches;
            if (!string.IsNullOrEmpty(search))
            {
                product = product.Where(x => x.Name.Contains(search));
            }
            return product.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }

        // lấy list sách mởi
        public List<Sach> listNew(int top)
        {
            return db.Saches.OrderByDescending(x => x.NgayCapNhat).Take(top).ToList();
        }

        // lấy sách tophot

        public List<Sach> listTopHot(int top)
        {
            return db.Saches.Where(x => x.TopHot > DateTime.Now && x.TopHot !=null).Take(top).ToList();
        }


        // phân trang danh sách sản phẩm theo danh mục
        public List<Sach> ListByCategoryId(long categoryId, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.Saches.Where(x => x.DanhMucID == categoryId).Count();
            return db.Saches.Where(x => x.DanhMucID == categoryId).OrderByDescending(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            // skip :lấy từ bản ghi 0 ,lấy 2 bản ghi , khi page 1
        }



    }
}