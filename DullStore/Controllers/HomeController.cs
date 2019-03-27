using DullStore.DAO;
using DullStore.Entities;
using DullStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DullStoreDbContex db = new DullStoreDbContex();
        public static SanPhamDAO sp = new SanPhamDAO();
        IQueryable<SanPham> ListSanPham = sp.ListSP();

        public ActionResult SPTheoMuc(int madm)
        {
            SanPhamDAO sp = new SanPhamDAO();
            IQueryable < SanPham > ListSP= sp.ListSP(madm);
            return View(ListSP);
        }
        public ActionResult SPStyle(int mast)
        {
            SanPhamDAO sp = new SanPhamDAO();
            IQueryable<SanPham> ListSPTL = sp.ListSPTL(mast);
            return View(ListSPTL);
        }

        public ActionResult Index(int ? trang)
        {
            //return View(ListSanPham);
            int sosptrentrang = 6;
            int stttrang = (trang ?? 1);
            return View(db.SanPham.ToList().OrderBy(x => x.ma).ToPagedList(stttrang, sosptrentrang));
        }
        public ActionResult KMProduct()
        {
            return View(ListSanPham);
        }
        public ActionResult BCProduct()
        {
            return View(ListSanPham);
        }

        public ActionResult ChitietSP(int id)
        {

            SanPham sptk = new SanPham();
            foreach (var item in ListSanPham)
            {
                if (item.ma == id) sptk = item;
            }
            ViewBag.spct = sptk;
            return View();
        }
        public ActionResult timkiem(string tensp)
        {
            SanPhamDAO sp = new SanPhamDAO();
            ViewData["TimKiem"] = sp.listspTimkiem(tensp);
            return View();
        }
    }
}