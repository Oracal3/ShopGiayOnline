using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DullStore.Entities;
namespace DullStore.DAO
{
    public class UserDAO
    {
        DullStoreDbContex db;
        public UserDAO()
        {
            db = new DullStoreDbContex();
        }
        public bool Login(string tk,string mk)
        {
            var res = db.User.Count(x => x.userName == tk && x.password == mk);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}