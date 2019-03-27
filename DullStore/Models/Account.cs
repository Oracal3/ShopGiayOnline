using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DullStore.Models
{
    public class Account
    {
        [Required(ErrorMessage ="Vui lòng điền thông tin tài khoản")]
        public string taikhoan { get; set; }
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        public string matkhau { get; set; }
        public bool RememberMe { get; set; }
    }
}