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

        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
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
            SetViewBag();
            return View(user);
        }

        [HttpGet]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var dao = new UserDao();
            var user = dao.GetById(id);
            SetViewBag(user.GroupID);
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
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
            SetViewBag(user.GroupID);
            return View(user);
        }

        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(int id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        public void SetViewBag(string selectedId = null)
        {
            var userGroupDao = new UserGroupDao();
            ViewBag.GroupID = new SelectList(userGroupDao.ListAll(), "ID", "Name", selectedId);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/Admin/Login");
        }
    }
}