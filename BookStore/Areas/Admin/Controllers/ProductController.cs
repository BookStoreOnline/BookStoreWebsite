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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                int id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm không thành công");
                }
            }
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new ProductDao();
            var product = dao.GetById(id);
            SetViewBag(product.CategoryID);
            return View(product);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm thành công");
                }
            }
            SetViewBag(product.CategoryID);
            return View(product);
        }

        public void SetViewBag(int? selectedId = null)
        {
            var categoryDao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(categoryDao.ListAll(), "ID", "Name", selectedId);
        }
    }
}