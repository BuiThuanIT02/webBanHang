using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class Order
    {
        private WebSachDb db = null;
        public Order()
        {
            db = new WebSachDb();
        }

        // phan tran order
        public IEnumerable<DonHang> listPage(int page, int pageSize)
        {
            return db.DonHangs.OrderBy(x => x.NgayDat).Where(x=>x.Status ==1 || x.Status ==2).ToPagedList(page,pageSize);
          

        }












    }
}