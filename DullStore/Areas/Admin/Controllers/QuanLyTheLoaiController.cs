using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Areas.Admin.Controllers
{
    public class QuanLyTheLoaiController : Controller
    {
        // GET: Admin/QuanLyTheLoai
        DullStoreDbContex db = new DullStoreDbContex();
        public ActionResult List()
        {
            return View(db.Style.ToList().OrderBy(x => x.ma));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Style tl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Style.Add(tl);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                    return View(tl);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Style st = db.Style.Find(id);
            if (st == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                return View(st);
            }
        }

        [HttpPost]
        public ActionResult Edit(Style stcs)
        {
            if (ModelState.IsValid)
            {
                Style st = db.Style.Find(stcs.ma);

                st.ten = stcs.ten;

                db.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                return View(stcs);
            }
        }

        public ActionResult Delete(int id)
        {
            Style st = db.Style.Find(id);
            db.Style.Remove(st);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
