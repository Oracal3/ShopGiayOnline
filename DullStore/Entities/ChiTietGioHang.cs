namespace DullStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGioHang")]
    public partial class ChiTietGioHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int magiohang { get; set; }

        [Key]
        [Column(Order = 1)] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int magiay { get; set; }

        [Display(Name ="Số lượng sản phẩm")]
        public int? soluong { get; set; }

        [Display(Name = "Thành tiền")]
        [StringLength(20)]
        public string dongia { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
