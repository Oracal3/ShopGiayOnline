using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class GioHangDAO
    {
        DullStoreDbContex db;
        public GioHangDAO()
        {
            db = new DullStoreDbContex();
        }
    }
}