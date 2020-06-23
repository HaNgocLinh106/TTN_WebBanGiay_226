using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiay_226.Common;
using WebBanGiay_226.Models.User;
using WebBanGiay_226.Models.Fun;
using WebBanGiay_226.Models.EF;

namespace WebBanGiay_226.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserF();
                var result = dao.Login(model.UserName, model.Pass);
                if (result)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.MaNguoiDung = user.MaNguoiDung;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công.");
                }
            }
            return View("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserF();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckSDT(model.SDT))
                {
                    ModelState.AddModelError("", "Số điện thoại đã tồn tại");
                }
                else
                {
                    var user = new NguoiDung();
                    user.TenNguoiDung = model.TenNguoiDung;
                    user.UserName = model.UserName;
                    user.Pass = model.Pass;
                    user.DiaChi = model.DiaChi;
                    user.SDT = model.SDT;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }
        public ActionResult TaiKhoan(long MaNguoiDung)
        {
            var model = new UserF().GHUser(MaNguoiDung);
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}