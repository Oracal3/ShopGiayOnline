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
        public int Login(string tk, string mk)
        {
            //var res = db.User.Count(x => x.userName == tk && x.password == mk);
            //if (res > 0)
            //    return true;
            //else
            //    return false;
            if (tk == null || mk == null)
            {
                return -1;
            }
            else
            {
                var res = db.User.SingleOrDefault(x => x.userName == tk);
                if (res == null)
                {
                    return 0;
                }
                else
                {
                    if (res.password == mk)
                        return 1;
                    else
                        return -2;
                }
            }
            
        }
    }
}