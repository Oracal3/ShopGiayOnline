using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Areas.Admin.Controllers
{
    public class AdHomeController : Controller
    {
        // GET: Admin/AdHome
        public ActionResult AdIndex()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "LoginAd");
            }
            else
            {
                Account acc = new Account();
                acc.taikhoan = Session["UserName"].ToString();
                acc.matkhau = "";
                return View(acc);
            }
            
        }
    }
}