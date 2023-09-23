using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Sach.Models;
using Web_Sach.Models.EF;

namespace Web_Sach.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchString , int page=1, int pageSize=20)
        {
            var product = new ProductCategory().listPage(searchString, page, pageSize);
            ViewBag.SearchString = searchString;

            return View(product);
        }

        //thêm mới danh mục sản phẩm

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(DanhMucSP dm)
        {
            if (ModelState.IsValid)
            {
                var productCategory = new ProductCategory().uniqueName(dm.Name);
                if (productCategory != null)
                {
                    ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
                    return View(dm);
                }
               
                    var productCategoryID = new ProductCategory().Insert(dm);
                if(productCategoryID > 0)
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index");
                }
               
                

            }
            else
            {
                
                    SetAlert("Thêm danh mục thất bại", "error");
                
            }

            return View("Create");
        }


        //End thêm mới danh mục sản phẩm

        // sửa bản ghi danh mục

        [HttpGet]
        public ActionResult Update(int id)
        {
            var productCategory = new ProductCategory().Edit(id);
            return View(productCategory);
        }

       [HttpPost]
       public ActionResult Update(DanhMucSP dm)
        {
            if (ModelState.IsValid)
            {
                var category = new ProductCategory();
                
                if (category.Compare(dm) )
                {
                    ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
                    return View(dm);
                }

                if (category.Update(dm))
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");

                }
                else
                {
                    SetAlert("Cập nhật thất bại", "error");
                    return RedirectToAction("Index", "ProductCategory");
                }


                
            }
            return View("Update");
        }



        [HttpDelete]

        public ActionResult Delete(int id)
        {
            new ProductCategory().Delete(id);
            return RedirectToAction("Index","ProductCategory");
        }




        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var resulf = new ProductCategory().Change(id);
            return Json(new
            {
                status = resulf
            });
        }












    }
}