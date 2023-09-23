using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Models.EF;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string search, int page=1, int pageSize =20)
        {
            var product = new Book().listPage(search,page,pageSize);
            ViewBag.Search = search;
            return View(product);
        }
        [HttpGet]

        public ActionResult Create()
        {
            setViewBagCategory();
            setViewBagNCC();
            setViewBagNXB();
           
            return View();
        }


      

        [HttpPost]
        [ValidateInput(false)]  // tắt tính năng kiểm tra đầu vào
        // Thêm sản phẩm
        public ActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                var book = new Book();// kiểm tra tên sách có trùng không
                  if (book.Compare(sach))
                  {// nếu trùng thông báo
                      ModelState.AddModelError("Name", "Tên sách đã tồn tại");
                      
                    setViewBagCategory();
                    setViewBagNCC();
                    setViewBagNXB();
                    return View(sach);

                }
                
                if (book.Insert(sach) > 0)
                {// chèn
                    SetAlert("Thêm bản ghi thành công", "success");
                    return RedirectToAction("Index", "Product");

                }
                else
                {
                    SetAlert("Thêm bản ghi thất bại", "error");
                    return RedirectToAction("Create", "Product");
                }


            }
            
                setViewBagCategory();
                 setViewBagNCC();
                 setViewBagNXB();

            


           

            return View("Create");

        }

        // end thêm sản phẩm
        [HttpGet]

        // sửa sản phẩm
        public ActionResult Update(int id)
        {
            var bookEdit = new Book().Edit(id);// tim sach theo ID

            setViewBagCategory(bookEdit.DanhMucID);
            setViewBagNCC(bookEdit.NhaCungCapID);
            setViewBagNXB(bookEdit.NhaXuatBanID);


            return View(bookEdit);

        }

        //end sửa sản phẩm

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Sach sach)
        {
            if (ModelState.IsValid)
            {
                var bookUpdate = new Book();
                if (bookUpdate.CompareUpdate(sach))
                {// trùng tên sách
                    ModelState.AddModelError("Name", "Tên sách bị trùng");
                    return View(sach);

                }
                if (bookUpdate.Update(sach))
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Product");
                }


            }
            else
            {
                SetAlert("Cập nhật thất bại", "error");
            }




            return View("Update");

        }

        [HttpDelete]
        // xóa bản ghi
        public ActionResult Delete(int id)
        {
            new Book().Delete(id);
            return RedirectToAction("Index","Product");
        }


        // thay đổi trạng thái
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var resulf = new Book().ChangeStatus(id);
            return Json(new
            {
                status = resulf
            });
        }




























        public void setViewBagCategory(int? selectedId = null)
        {
            var drowdoad = new ProductCategory();
            ViewBag.DanhMucID = new SelectList(drowdoad.ListAll(), "ID", "Name", selectedId);// hiện thị droplisst theo Name
        }

        public void setViewBagNCC(int? selectedId = null)
        {
            var drowdoad = new Supplier();
            ViewBag.NhaCungCapID = new SelectList(drowdoad.ListAll(), "ID", "Name", selectedId);
        }
        public void setViewBagNXB(int? selectedId = null)
        {
            var drowdoad = new NXB();
            ViewBag.NhaXuatBanID = new SelectList(drowdoad.ListAll(), "ID", "TenNXB", selectedId);
        }

















    }
}