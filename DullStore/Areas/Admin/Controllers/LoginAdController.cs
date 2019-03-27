using DullStore.DAO;
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
        public ActionResult LoginAction(Account acc)
        {
            UserDAO user = new UserDAO();
            bool check = user.Login(acc.taikhoan, acc.matkhau);
            if (check)
            {
                Session["UserName"] = acc.taikhoan;
                return RedirectToAction("AdIndex", "AdHome");
            }
            else
                return RedirectToAction("Login", "LoginAd");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "LoginAd");
        }
    }
}