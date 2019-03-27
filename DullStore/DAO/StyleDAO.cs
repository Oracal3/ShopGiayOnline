using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class StyleDAO
    {
        DullStoreDbContex db;
        public StyleDAO()
        {
            db = new DullStoreDbContex();
        }

        public IQueryable<Style> ListDanhMuc()
        {
            var res = (from st in db.Style select st);
            return res;
        }
    }
}