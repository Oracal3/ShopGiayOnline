using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DullStore.Models;
using DullStore.Entities;
using DullStore.DAO;

namespace DullStore.Areas.Admin.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        DullStoreDbContex db = new DullStoreDbContex();
        KhachHangDAO kdao = new KhachHangDAO();
        // GET: Admin/QuanLyKhachHang
        public ActionResult ListKhachHang()
        {
            IQueryable<KhachHang> ListKH = kdao.listKH();
            return View(ListKH);
        }

        public ActionResult Edit(int id)
        {
            KhachHang dm = db.KhachHang.SingleOrDefault(x => x.ma == id);
            if (dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                return View(dm);
            }
        }

        [HttpPost]
        public ActionResult Edit(KhachHang khcs)
        {
            if (ModelState.IsValid)
            {
                KhachHang kh = db.KhachHang.Find(khcs.ma);

                kh.hoten = khcs.hoten;
                kh.email = khcs.email;
                kh.diachi = khcs.diachi;
                kh.sodienthoai = khcs.sodienthoai;
                db.SaveChanges();

                return RedirectToAction("ListKhachHang");
            }
            else
            {
                return View(khcs);
            }
        }
    }
}