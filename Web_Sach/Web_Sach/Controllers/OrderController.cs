using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Session;

namespace Web_Sach.Controllers
{
    public class OrderController : Controller
    {
        WebSachDb db = new WebSachDb();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult RemoveOrder(int id)
        {
          
                var order = db.DonHangs.Find(id);
            if(order != null)
            {
                var orderDetail = db.ChiTietDonHangs.Where(x => x.MaDonHang == id).ToList();
                foreach(var item in orderDetail)
                {// cập nhật số lượng
                    var sachUpdate = db.Saches.Find(item.MaSach);// cập nhật lại số lượng sản phẩm và số lượng tồn kho
                    sachUpdate.SoLuongTon = sachUpdate.SoLuongTon + item.SoLuong;
                    sachUpdate.Quantity = sachUpdate.Quantity + item.SoLuong;
                    db.SaveChanges();
                }
                order.Status = 0;
               
                db.SaveChanges();
                return Json(new
                {
                    status = true
                });

            }


            return Json(new
            {
                status = false
            });



          
        }



        // nhận hàng
        [HttpPost]
        public JsonResult GetOrder(int id)
        {
            var order = db.DonHangs.Find(id);
            if(order!= null)
            {
                order.Status = 3;
                db.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }


        // đơn hàng thành công
        public ActionResult OrderSuccess()
        {
            var sessionUser = Session[SessionHelper.USER_KEY] as UserLoginSession;
            var order = db.DonHangs.Where(x => x.Status == 3 && x.MaKH == sessionUser.UserID).ToList();
            return View(order);
        }













    }
}