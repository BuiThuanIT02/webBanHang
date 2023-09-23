using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class NXB
    {
        private WebSachDb db = null;
        public NXB()
        {
            db = new WebSachDb();

        }


        //drowload
        public List<NhaXuatBan> ListAll()
        {
            return db.NhaXuatBans.ToList();
        }

        //end  drowdoad







    }
}