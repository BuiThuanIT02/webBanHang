using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models.EF;
using Web_Sach.Session;

namespace Web_Sach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productNew = new Book();
            var slide = new SlideModel().getSilde();
            ViewBag.listProductNew = productNew.listNew(10);
            ViewBag.listProductTopHot = productNew.listTopHot(10);

            return View(slide);
        }
        

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var category = new ProductCategory().ListAll();
            return PartialView(category);
        }

        [ChildActionOnly]

        public ActionResult HeaderCart()
        {
            var cart = Session[SessionHelper.CART_KEY];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list= cart as List<CartItem>;
            }
            return PartialView(list);

        }










    }
}