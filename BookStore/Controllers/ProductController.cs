using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var model = new CategoryDao().ListAll();
            return PartialView(model);
        }

        public ActionResult DetailCategory(int cateId, int page = 1, int pageSize = 10)
        {
            var category = new CategoryDao().ViewDetail(cateId);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateId, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 10;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new CategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProduct(id);
            return View(product);
        }
    }
}