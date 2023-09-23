using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Models.EF;
using Web_Sach.Session;
using System.Web.Script.Serialization;

namespace Web_Sach.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        WebSachDb db = new WebSachDb();
        public ActionResult Index()
        {
            if(Session[SessionHelper.USER_KEY] == null)
            {
                Session[SessionHelper.CART_KEY] = null;
                return RedirectToAction("Cart","Cart");
              
            }
            var cart = Session[SessionHelper.CART_KEY];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }


            return View(list);
        }
        // đăng nhập mới cho thêm vào Cart
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddCart(int productId, int Quantity)
        {
         
            var cart = Session[SessionHelper.CART_KEY]; // lấy giỏ hàng
            var list = new List<CartItem>();
            // lấy 1 đối tượng sách
            var sach = from s in db.Saches
                       where s.ID == productId
                       select s;

            if(cart != null)
            {// đã tồn tại giỏ hàng
                 list = (List<CartItem>)cart;
                // kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
                if(list.Exists(x=>x.sach.ID == productId))
                { // true khi có id sản phẩm giống nhau
                    foreach(var item in list)
                    {
                        if(item.sach.ID == productId)
                        {
                            item.Quantity += Quantity;
                        }
                    }

                }
                else
                { // sản phẩm đó chưa có trong giỏ  hàng
                    var item = new CartItem();
                    item.sach = sach.FirstOrDefault();
                    item.Quantity = Quantity;
                    list.Add(item);

                }

                Session[SessionHelper.CART_KEY] = list;

            }
            else
            { // chưa tồn tại giỏ hàng
               /// list = (List<CartItem>)cart; 
                var item = new CartItem();
                item.sach = sach.FirstOrDefault();
                item.Quantity = Quantity;
              
               // var list = new List<CartItem>();
                list.Add(item);
                Session[SessionHelper.CART_KEY] = list;


            }
            



          


            return RedirectToAction("Index");
        }


        [HttpPost]

        public JsonResult Update(string cartList)
        {
            // thêm không gian system.web.script.serialization
            // Lớp này được sử dụng để chuyển đổi chuỗi JSON thành các đối tượng C#
            var jsonList = new JavaScriptSerializer().Deserialize <List<CartItem>>(cartList);
            var sessionCart = (List<CartItem>)Session[SessionHelper.CART_KEY];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonList.SingleOrDefault(x => x.sach.ID == item.sach.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }

            }
            Session[SessionHelper.CART_KEY] = sessionCart;
            return Json(new
            {
                status = true

            });
        }


        [HttpPost]

        public JsonResult DeleteAll()
        {
            Session[SessionHelper.CART_KEY] = null;
            return Json(new
            {
                status = true
            });
        }


        [HttpPost]

        public JsonResult Delete(int id)
        {
           var cart =  Session[SessionHelper.CART_KEY] as List<CartItem>;
            cart.RemoveAll(x=>x.sach.ID == id);
            Session[SessionHelper.CART_KEY] = cart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult BuyNow(int id, int Quantity)
        {
            var sessionUser = (UserLoginSession)Session[SessionHelper.USER_KEY];

            if (sessionUser != null)
            {
                ViewBag.user = sessionUser;
                var item = new CartItem();
                item.sach = new Book().GetBookById(id);
                item.Quantity = Quantity;
                var sachUpdate = db.Saches.Find(id);// cập nhập lại số lượng sách và số lượng tồn kho
                sachUpdate.SoLuongTon = sachUpdate.SoLuongTon - Quantity;
                sachUpdate.Quantity = sachUpdate.Quantity - Quantity;
                db.SaveChanges();
                return View(item);
            }
            return RedirectToAction("Cart", "Cart"); // hiện thi về trang đăng nhập
           

        }
        [HttpPost]
        public ActionResult BuyNow(string TenKH, string Mobile, string Address, string Email, int total,int id, int Quantity)
        {
            var sessionUser = (UserLoginSession)Session[SessionHelper.USER_KEY];
           
               
                var order = new DonHang();
                order.TenKH = TenKH;
                order.Moblie = Mobile;
                order.Address = Address;
                order.Email = Email;
                order.TongTien = total;
                order.NgayDat = DateTime.Now;
                order.MaKH = sessionUser.UserID;
                order.Status = 1;
                db.DonHangs.Add(order);
                db.SaveChanges();
                var idOrder = order.ID;



                var sach = new Book().GetBookById(id);
                var priceRoot = (int)sach.Price;
                var priceNow = (int)(priceRoot - sach.Sale / 100);
                var orderDetails = new ChiTietDonHang();
                orderDetails.MaDonHang = idOrder;
                orderDetails.MaSach = id;
                orderDetails.SoLuong = Quantity;
                orderDetails.DonGia = priceNow;



                db.ChiTietDonHangs.Add(orderDetails);
                db.SaveChanges();
                




            
             


            return Redirect("/hoan-thanh");

        }
        [HttpGet]
        public ActionResult Payment()
        {
          
           
                var cart = Session[SessionHelper.CART_KEY];
           var userPayment = (UserLoginSession)Session[SessionHelper.USER_KEY];
            ViewBag.user = userPayment;
          
                var list = new List<CartItem>();
                if (cart != null)
                {
                         list = cart as List<CartItem>;
             
                foreach (var item in list)
                {// cập nhập list số lượng và số lượng tồn kho
                    var sachUpdate = db.Saches.Find(item.sach.ID);// cập nhật lại số lượng sản phẩm và số lượng tồn kho
                    sachUpdate.SoLuongTon = sachUpdate.SoLuongTon - item.Quantity;
                    sachUpdate.Quantity = sachUpdate.Quantity - item.Quantity;
                    db.SaveChanges();
                }
            

                } 


            

            
          
            return View(list);
        }


        [HttpPost]
        public ActionResult Payment(string TenKH, string Mobile,string Address, string Email,int total)
        {
            var sessionUser =(UserLoginSession)Session[SessionHelper.USER_KEY];
            WebSachDb db = new WebSachDb();
            var order = new DonHang();
            order.TenKH = TenKH;
            order.Moblie = Mobile;
            order.Address = Address;
            order.Email = Email;
            order.TongTien = total;
            order.NgayDat = DateTime.Now;
            order.MaKH = sessionUser.UserID;
            order.Status = 1;
            db.DonHangs.Add(order);
            db.SaveChanges();
            var idOrder = order.ID;
          
            var cart = Session[SessionHelper.CART_KEY] as List<CartItem>;
            var orderDetail = new List<ChiTietDonHang>() ;
            foreach (var item in cart)
            {
                var orderDetails = new ChiTietDonHang();
                orderDetails.MaDonHang = idOrder;
                orderDetails.MaSach = item.sach.ID;
                orderDetails.SoLuong = item.Quantity;
                orderDetails.DonGia = (int)item.sach.Price;
                orderDetail.Add(orderDetails);

            } 
            db.ChiTietDonHangs.AddRange(orderDetail);
             db.SaveChanges();
            //  TempData["Order"] = order;
            //  TempData["OrderDetail"] = orderDetail;

            Session[SessionHelper.CART_KEY] = null;// đặt hàng giỏ hàng sẽ trống


             return Redirect("/hoan-thanh");

           

        }

        public ActionResult Order()
        {
            var sessionUser = Session[SessionHelper.USER_KEY] as UserLoginSession;
            if(sessionUser != null)
            {
                var order = from dh in db.DonHangs
                            where dh.MaKH == sessionUser.UserID && (dh.Status==1 || dh.Status==2)
                            select dh;
                
                ViewBag.Order = order.ToList();
            }
           
          

        
            return View();

        }

        // xem chi tiết đơn hàng
        public ActionResult OrderDetail(int Id)
        {
            var orderDetail = from dh in db.DonHangs
                              join dt in db.ChiTietDonHangs on dh.ID equals dt.MaDonHang
                              join sach in db.Saches on dt.MaSach equals sach.ID
                              where dh.ID == Id
                              select new OrderDetail()
                              {
                                  sachId = sach.ID,
                                  sachName = sach.Name,
                                  PriceBuy = (double)sach.Price,
                                  Sale = (int)sach.Sale,
                                  QuantityBuy = (int)dt.SoLuong
                              };
            ViewBag.OrderDetail = orderDetail.ToList();
            return View();
        }
























    }
}