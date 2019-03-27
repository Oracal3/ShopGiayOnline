using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class KhachHangDAO
    {
        DullStoreDbContex db;
        public KhachHangDAO()
        {
            db = new DullStoreDbContex();
        }
        public IQueryable<KhachHang> listKH()
        {
            var res = (from kh in db.KhachHang select kh);
            return res;
        }
    }
}