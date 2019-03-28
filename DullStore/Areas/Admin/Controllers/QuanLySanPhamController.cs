using DullStore.DAO;
using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace DullStore.Areas.Admin.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        DullStoreDbContex db = new DullStoreDbContex();
        // GET: Admin/QuanLySanPham
        public ActionResult Product(int? trang)
        {
            int sosptrentrang = 4;
            int stttrang = (trang ?? 1);
            return View(db.SanPham.ToList().OrderBy(x => x.ma).ToPagedList(stttrang, sosptrentrang));
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.madanhmuc = new SelectList(db.DanhMuc.ToList().OrderBy(x => x.tendanhmuc), "ma", "tendanhmuc");
            ViewBag.mastyle = new SelectList(db.Style.ToList().OrderBy(x => x.ten), "ma", "ten");
            SetAlert("Thêm mới thành công", "success");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(SanPham sp, HttpPostedFileBase fileanh)
        {
            ViewBag.madanhmuc = new SelectList(db.DanhMuc.ToList().OrderBy(x => x.tendanhmuc), "ma", "tendanhmuc");
            ViewBag.mastyle = new SelectList(db.Style.ToList().OrderBy(x => x.ten), "ma", "ten");


            if (fileanh != null)
            {
                var filename = Path.GetFileName(fileanh.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image"),filename);
                fileanh.SaveAs(path);
                sp.linkanh = fileanh.FileName;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.SanPham.Add(sp);
                    db.SaveChanges();
                    return RedirectToAction("Product", "QuanLySanPham");
                }
                else
                {
                    return View(sp);
                }
            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.ma == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                ViewBag.madanhmuc = new SelectList(db.DanhMuc.ToList().OrderBy(x => x.tendanhmuc), "ma", "tendanhmuc");
                ViewBag.mastyle = new SelectList(db.Style.ToList().OrderBy(x => x.ten), "ma", "ten");
                SetAlert("Sửa thành công", "success");
                return View(sp);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham sptm, HttpPostedFileBase fileanh1)
        {
            ViewBag.madanhmuc = new SelectList(db.DanhMuc.ToList().OrderBy(x => x.tendanhmuc), "ma", "tendanhmuc");
            ViewBag.mastyle = new SelectList(db.Style.ToList().OrderBy(x => x.ten), "ma", "ten");
            SanPham sp = db.SanPham.Find(sptm.ma);
            if (fileanh1 == null)
            {
                //var filename1 = Path.GetFileName(fileanh1.FileName);
                //var path = Path.Combine(Server.MapPath("~/Content/Image"), filename1);
                //fileanh1.SaveAs(path);
                //sp.linkanh = fileanh1.FileName;
                sp.ten = sptm.ten;
                sp.giaban = sptm.giaban;
                sp.madanhmuc = sptm.madanhmuc;
                sp.mastyle = sptm.mastyle;
                sp.xuatxu = sptm.xuatxu;
            }
            else
            {
                var filename1 = Path.GetFileName(fileanh1.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image"), filename1);
                fileanh1.SaveAs(path);
                sp.linkanh = fileanh1.FileName;
                sp.ten = sptm.ten;
                sp.giaban = sptm.giaban;
                sp.madanhmuc = sptm.madanhmuc;
                sp.mastyle = sptm.mastyle;
                sp.xuatxu = sptm.xuatxu;
            }
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }
            else
            {
                return View(sptm);
            }
            return RedirectToAction("Product", "QuanLySanPham");
        }


        public ActionResult Delete(int? id)
        {
            SanPham sp = db.SanPham.SingleOrDefault(x => x.ma == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                try
                {
                    db.SanPham.Remove(sp);
                    db.SaveChanges();
                    return Redirect(Request.UrlReferrer.ToString());
                }
                catch(Exception)
                {
                    SetAlert("Không thể xóa sản phẩm đã được tạo hóa đơn","danger");
                }
                
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.ma == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
                return View(sp);
        }

        public void SetAlert(string message,string type)
        {
            TempData["AlertMessage"] = message;
            if(type == "success")
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