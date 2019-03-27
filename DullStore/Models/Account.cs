using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DullStore.Models
{
    public class Account
    {
        [Required]
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public bool RememberMe { get; set; }
    }
}