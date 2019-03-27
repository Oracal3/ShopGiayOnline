namespace DullStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            ChiTietGioHang = new HashSet<ChiTietGioHang>();
        }

        [Key]
        [Display(Name = "Mã hóa đơn")]
        public int ma { get; set; }

        [Display(Name = "Mã khách hàng")]
        public int? makhachhang { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        [Column(TypeName = "date")]
        public DateTime? ngaydathang { get; set; }

        [Display(Name = "Ngày giao hàng")]
        [Column(TypeName = "date")]
        public DateTime? ngaygiaohang { get; set; }

        [Display(Name = "Tình trạng giao hàng")]
        [StringLength(50)]
        public string tinhtranggiaohang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
