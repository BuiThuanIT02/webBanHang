using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class SlideModel
    {
        private WebSachDb db = null;

        public SlideModel()
        {
            db = new WebSachDb();
        }


        public List<Silde> getSilde()
        {
            return db.Sildes.Where(x => x.Status == true).ToList();

        }






    }
}