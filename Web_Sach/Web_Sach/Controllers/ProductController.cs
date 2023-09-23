using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Models.EF;

namespace Web_Sach.Controllers
{
    public class ProductController : Controller
    {
        WebSachDb db = new WebSachDb();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        // gửi lên từ đg dẫn chi-tiet-/metatile-id
        public ActionResult Product(int detailId)
        {
            
            // lấy tên tác giả
            var tacgia = (from s in db.Saches
                         join tg in db.ThamGias on s.ID equals tg.MaSach
                         join outhur in db.TacGias on tg.MaTacGia equals outhur.ID
                         where s.ID == detailId
                         select new ThamGiaViewModels()
                         {
                             Name =outhur.TenTacGia,
                             ID =outhur.ID
                         }).ToList();
                       
            ViewBag.NameOuthur = tacgia;
            // sách cùng tác giả
            var sachCungTacGia = ViewBag.NameOuthur as List<ThamGiaViewModels>;
            if(sachCungTacGia !=null && sachCungTacGia.Count > 0)
            {
                // laays danh sach ID tac gia
                var id = sachCungTacGia.Select(x => x.ID).ToList();
                var result = from s in db.Saches
                             join t in db.ThamGias on s.ID equals t.MaSach
                             join tg in db.TacGias on t.MaTacGia equals tg.ID
                             where id.Contains(tg.ID) && s.ID !=detailId
                             select s;
                ViewBag.SachCungTacGia = result.ToList();
            }


          
            // lấy chi tiết sách
                          
            var query = (from dt in db.Saches
                        where dt.ID == detailId
                        select dt);

            var productDetail = query.FirstOrDefault();
      
            if (productDetail != null)
            {

                var idDm = productDetail.DanhMucID;
                var danhmuc = from dm in db.DanhMucSPs
                              where dm.ID == idDm
                              select dm.Name;
                // lấy sách cx loại 
                var sachDM = from s in db.Saches
                             where s.DanhMucID == idDm
                             select s;
                ViewBag.SachDM = sachDM.ToList();
                ViewBag.NameDM = danhmuc.FirstOrDefault();
               

                

            }
            return View(productDetail);
        }



        //tìm kiếm Home
        public ActionResult Search(string keyword , int page=1, int pageSize = 6)
        {
            if(keyword == "")
            {
                return Redirect("/");
            }
                var productList = db.Saches.Where(x => x.Name.Contains(keyword));
                  ViewBag.Keyword = keyword;
            var totalItem = productList.Count();
            var totalPage = (int)Math.Ceiling((double)totalItem / pageSize);
            var maxPage = 20;

          

        

         
            // danh sách phân trang
            productList = productList.OrderBy(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize);
            // Skip((page - 1) * pageSize): bỏ qua các phẩn tử 
            // ví dụ page =2 thì sẽ bỏ qua 3 phẩn tử trang 1
            var model = productList.ToList();


            //truyền vào view
            ViewBag.totalRecord = totalItem;
         

            ViewBag.maxPage = maxPage;
            ViewBag.page = page;
            ViewBag.totalPage = totalPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;


            return View(model);


          
        }






















    }
}