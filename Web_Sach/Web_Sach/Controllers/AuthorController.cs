using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;

namespace Web_Sach.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        WebSachDb db = new WebSachDb();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Info(int authorID, int page =1, int pageSize =1)
        {
            var author = db.TacGias.Find(authorID);// thông tin tác giả
            // sản phẩm cùng tác giả
          

            var sach = from tg in db.ThamGias
                       join au in db.TacGias on tg.MaTacGia equals au.ID
                       join s in db.Saches on tg.MaSach equals s.ID
                       where au.ID == authorID
                       select s;
           

            // phân trang
            var totalItem = sach.Count();
            var totalPage = (int)Math.Ceiling((double)totalItem / pageSize);
            var maxPage = 20;






            // danh sách phân trang
            sach = sach.OrderBy(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize);
            // Skip((page - 1) * pageSize): bỏ qua các phẩn tử 
            // ví dụ page =2 thì sẽ bỏ qua 3 phẩn tử trang 1
            ViewBag.ListSach = sach.ToList();



            //truyền vào view
            ViewBag.totalRecord = totalItem;


            ViewBag.maxPage = maxPage;
            ViewBag.page = page;
            ViewBag.totalPage = totalPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(author);
        }











    }
}