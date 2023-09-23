using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class Supplier
    {
        private WebSachDb db = null;
        public Supplier()
        {
            db = new WebSachDb();

        }

        public List<NhaCungCap> ListAll()
        {
            return db.NhaCungCaps.ToList();
        }



    }
}