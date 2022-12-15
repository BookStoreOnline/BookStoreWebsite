using BookStore.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                int id = dao.Insert(category);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục không thành công");
                }
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = new CategoryDao().ViewDetail(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(category);
                if (result)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thể loại không thành công");
                }
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public JsonResult ChangeStatus(int id)
        //{
        //    var result = new UserDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}