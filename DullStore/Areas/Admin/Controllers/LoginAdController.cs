using DullStore.DAO;
using DullStore.Entities;
using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DullStore.Areas.Admin.Controllers
{
    public class LoginAdController : Controller
    {
        // GET: Admin/LoginAd
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAction(User acc)
        {
            if(ModelState.IsValid)
            {
                UserDAO user = new UserDAO();
                var res = user.Login(acc.userName, acc.password);
                if (res == 1)
                {
                    Session["UserName"] = acc.userName;
                    return RedirectToAction("AdIndex", "AdHome");
                    
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if(res == -1)
                {
                    ModelState.AddModelError("", "Vui lòng điền đầy đủ thông tin tài khoản.");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View("Login");
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "LoginAd");
        }
    }
}