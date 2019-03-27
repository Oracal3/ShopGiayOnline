using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class DanhMucDAO
    {
        DullStoreDbContex db;
        public DanhMucDAO()
        {
            db = new DullStoreDbContex();
        }

        public IQueryable<DanhMuc> ListDanhMuc()
        {
            var res = (from dm in db.DanhMuc select dm);
            return res;
        }

    }
}