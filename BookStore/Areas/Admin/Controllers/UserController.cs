using BookStore.Common;
using Microsoft.Ajax.Utilities;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        private bool CheckUser(User user)
        {
            if (user.Password.Length < 6)
            {
                SetAlert("Mật khẩu quá ngắn", "error");
                return false;
            }
            return true;
        }
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
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
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(user))
                {
                    var dao = new UserDao();
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                    user.CreatedDate = DateTime.Now;
                    int id = dao.Insert(user);
                    if (id > 0)
                    {
                        SetAlert("Thêm người dùng thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm người dùng không thành công");
                    }
                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng thành công");
                }
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}