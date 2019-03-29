namespace DullStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        [Required(ErrorMessage ="Vui lòng điền tên đăng nhập")]
        
        public string userName { get; set; }

        
        [Column(Order = 1)]
        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng mật khẩu đăng nhập")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        //[Compare("password")]
        //public string passConfirm { get; set; }
        
    }
}
