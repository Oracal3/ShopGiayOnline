using DullStore.DAO;
using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Areas.Admin.Controllers
{
    public class QuanLyHoaDonController : Controller
    {
        // GET: Admin/QuanLyHoaDon
        DullStoreDbContex db = new DullStoreDbContex();
        public ActionResult ListHoaDon()
        {
            return View(db.GioHang.ToList().OrderBy(x => x.ma));
        }

        public ActionResult Edit(int id)
        {
            GioHang hd = db.GioHang.Find(id);
            if (hd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                return View(hd);
            }
        }

        [HttpPost]
        public ActionResult Edit(GioHang ghcs)
        {
            if (ModelState.IsValid)
            {
                GioHang hd = db.GioHang.Find(ghcs.ma);
                hd.tinhtranggiaohang = "Đã giao hàng và khách hàng đã thanh toán đầy đủ";
                db.SaveChanges();
                return RedirectToAction("ListHoaDon");
            }
            else
            {
                return View(ghcs);
            }
        }
        public ActionResult Details(int id)
        {
            GioHang gh = db.GioHang.SingleOrDefault(x => x.ma == id);
            ChiTietGioHangDAO dao = new ChiTietGioHangDAO();
            IQueryable<ChiTietGioHang> listgh = dao.ChiTietGH(id);
            ViewData["GiorHangf"] = gh;
            return View(listgh);
        }
    }
}