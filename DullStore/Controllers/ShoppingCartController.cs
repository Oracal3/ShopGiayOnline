using DullStore.Bean;
using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        DullStoreDbContex db = new DullStoreDbContex();

        public ActionResult AddGioHang(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            SanPham sp = db.SanPham.Find(id);
            cart.AddItem(sp.ma, sp.ten, 1, (double)sp.giaban, sp.linkanh);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult list()
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            List<ItemCart> ls = new List<ItemCart>();
            if (cart != null)
            {
                ls = cart.listItem;
            }
            return View(ls);
        }

        public ActionResult UpdateTang(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart.updatetang(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult UpdateGiam(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart.updategiam(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteGioHang(int id)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart != null)
                Cart.delete(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult DatHang(string ten, string email, string diachi, string sdt)
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //them vao chi tiet gio hang
            KhachHang kh = new KhachHang();
            KhachHang test=db.KhachHang.SingleOrDefault(x=>x.hoten==ten&&x.email==email&&x.diachi==diachi&&x.sodienthoai==sdt);
            if (test!=null)
            {
                kh.ma = test.ma;
                kh.hoten = test.hoten;
                kh.sodienthoai = test.sodienthoai;
                kh.email = test.email;
                kh.diachi = test.diachi;
            }
            else
            {
                kh.hoten = ten;
                kh.sodienthoai = sdt;
                kh.email = email;
                kh.diachi = diachi;
                db.KhachHang.Add(kh);
                db.SaveChanges();
            }
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            GioHang gh = new GioHang();
            gh.ngaydathang = DateTime.Now;
            gh.ngaygiaohang = DateTime.Now;
            gh.tinhtranggiaohang = "Đang giao hàng";
            gh.makhachhang = kh.ma;
            db.GioHang.Add(gh);
            db.SaveChanges();
            foreach (ItemCart item in cart.listItem)
            {
                ChiTietGioHang ct = new ChiTietGioHang();
                ct.magiohang = gh.ma;
                ct.magiay = item.id;
                ct.soluong = item.soluong;
                ct.dongia = item.tonggia().ToString();
                db.ChiTietGioHang.Add(ct);
                db.SaveChanges();
            }
            ViewData["DonHang"] = gh;
            return View();
        }
    }
}