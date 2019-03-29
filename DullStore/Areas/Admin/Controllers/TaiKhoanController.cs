using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        DullStoreDbContex db = new DullStoreDbContex();
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            return View(db.User.ToList().OrderBy(x => x.userName));
        }
      
        public ActionResult Edit(string name)
        {
            User dm = db.User.SingleOrDefault(x => x.userName == name);
            if (dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                SetAlert("Đổi mật khẩu thành công", "success");
                return View(dm);
            }
        }

        // POST: Admin/TaiKhoan/Edit/5
        [HttpPost]
        public ActionResult Edit(User dmcs)
        {
            if (ModelState.IsValid)
            {
                User dm = db.User.Find(dmcs.userName);

                dm.password = dmcs.password;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(dmcs);
            }
        }
        public void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "wanning")
            {
                TempData["AlertType"] = "alert-wanning";
            }
            else if (type == "danger")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

    }
}
