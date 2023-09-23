using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Models.EF;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        // GET: Admin/Author
        WebSachDb db = new WebSachDb();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 20)
        {
            var listPage = new TacGiaModels().listPage(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(listPage);
        }



        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]

        public ActionResult Create(TacGia author)
        {
            if (ModelState.IsValid)
            {
                var tacGia = new TacGiaModels();
                if(tacGia.Compare(author.TenTacGia) != null)
                {// đã tồn tại tên  tác giả
                    ModelState.AddModelError("TenTacGia", "Tên tác giả đã tồn tại!");
                    return View(author);

                }
                // tên tác giả chưa tồn tại

               var index = tacGia.InsertAuthor(author);
                if (index > 0)
                {// thêm user thành công
                    SetAlert("Thêm tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }




            }
            else
            {
                SetAlert("Thêm tác giả thất bại", "error");
            }

            return View(author);

        }


        // update

        public ActionResult Update(int id)
        {
            var author = db.TacGias.Find(id);
            return View(author);
        }


        [HttpPost]

        public ActionResult Update(TacGia tk)
        {

            if (ModelState.IsValid)
            {
                var authorUpdate = new TacGiaModels();
                // so sánh mật khẩu cũ và mật khẩu mới
               
                if (authorUpdate.Compare(tk))
                {
                    ModelState.AddModelError("TenTacGia", "Tên tác giả đã tồn tại");
                    return View(tk);
                }

               
                if (authorUpdate.Update(tk))
                {
                    SetAlert("Update bản ghi thành công", "success");
                    return RedirectToAction("Index", "Author");
                }


            }
            else
            {
                SetAlert("Update thất bại", "error");
                return View(tk);
            }
            return View("Index");
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var author = db.TacGias.Find(id);
            db.TacGias.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index", "Author");
        }










    }
}