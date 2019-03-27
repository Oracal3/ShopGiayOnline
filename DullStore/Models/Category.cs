using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.Models
{
    public class Category
    {
        public List<string> listdm { get; set; }
        public Category()
        {
            listdm = new List<string>();
            listdm.Add("Nike");
            listdm.Add("Adidas");
            listdm.Add("Converse");
            listdm.Add("Vans");
            listdm.Add("Crocs");
        }
    }
}