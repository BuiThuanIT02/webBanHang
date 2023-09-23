using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Models.EF;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebSachDb db = new WebSachDb();
        public ActionResult Index(int page =1, int pageSize =10)
        {
            var order = new Order().listPage(page,pageSize);

            return View(order);
        }

        // xem chi tiết

        public ActionResult OrderDetail(int id)
        {
          
            var order = db.DonHangs.Find(id);
            ViewBag.order = order;
            var detail = from dh in db.DonHangs
                         join dt in db.ChiTietDonHangs on dh.ID equals dt.MaDonHang
                         join sach in db.Saches on dt.MaSach equals sach.ID
                         where dh.ID == id
                         select new OrderDetail()
                         {
                             sachId = sach.ID,
                             sachName = sach.Name,
                             PriceBuy = (double)sach.Price,
                             Sale = (int)sach.Sale,
                             QuantityBuy = (int)dt.SoLuong
                         };
            
            return View(detail.ToList());
        }

   
        // thay doi trang thai
        public ActionResult ChangeStatus(int id)
        {
            var order = db.DonHangs.Find(id);
            if (order != null)
            {
                order.Status = 2;
                db.SaveChanges();
               
            }

            return RedirectToAction("Index","Order");

        }






    }
}