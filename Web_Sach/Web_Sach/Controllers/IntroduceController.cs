using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;

namespace Web_Sach.Controllers
{
    public class IntroduceController : Controller
    {
        WebSachDb db = new WebSachDb();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult News()
        {

            var news = db.Tin_Tuc.ToList();
           

            return View(news);
        }


        public ActionResult NewDetail(int newID)
        {
            var tinTuc = db.Tin_Tuc.Find(newID);
            return View(tinTuc);
        }





    }
}