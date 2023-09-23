using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Web_Sach.Models.EF
{
    public class ProductCategory
    {
        private WebSachDb db = null;
        public ProductCategory()
        {
            db = new WebSachDb();

        }

       public IEnumerable<DanhMucSP> listPage(string searchString , int page, int pageSize)
        {
            IQueryable<DanhMucSP> model = db.DanhMucSPs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x=>x.Name).ToPagedList(page, pageSize);
        }

        // tìm tên danh mục để tạo danh mục xem có trùng tên không
        public DanhMucSP uniqueName(string name)
        {
            return db.DanhMucSPs.FirstOrDefault(x=>x.Name==name);
        }


        //End tìm tên danh mục để tạo danh mục xem có trùng tên không

        // thêm mới danh mục
        public int Insert(DanhMucSP dm)
        {
            db.DanhMucSPs.Add(dm);
            db.SaveChanges();
            return dm.ID;
        }

        // end thêm mới danh mục


        // tim danh mục theo id
        public DanhMucSP Edit(int id)
        {
            return db.DanhMucSPs.Find(id);
        }

        // tm 
        public bool  Compare(DanhMucSP dm)
        {
           var category=  db.DanhMucSPs.FirstOrDefault(x => x.ID != dm.ID && x.Name == dm.Name);
            if(category != null)
            {// đã tồn tại
                return true;
            }
            else
            {// chưa  tồn tại
                return false;
            }
           
        }

        public bool Update(DanhMucSP dm)
        {
            try
            {
                var category = db.DanhMucSPs.Find(dm.ID);
                category.Name = dm.Name;
                category.MetaTitle = dm.MetaTitle;
                category.CreatedDate = DateTime.Now;
                category.Status = dm.Status;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        // end tìm theo id


        // xóa
        public bool Delete(int id)
        {
            try
            {
                var category = db.DanhMucSPs.Find(id);
                db.DanhMucSPs.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        //end xóa

        // thay doi trang thai
        public bool Change(int id)
        {
            var category = db.DanhMucSPs.Find(id);
            category.Status = !category.Status;
            db.SaveChanges();
            return category.Status;
        }

        //end thay doi trang thai






        // drown danh mục
        public List<DanhMucSP> ListAll()
        {
            return db.DanhMucSPs.Where(x => x.Status == true).ToList();
        }
       
        //end drowdoad


     


























    }
}