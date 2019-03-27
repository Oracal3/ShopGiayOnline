namespace DullStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietGioHang = new HashSet<ChiTietGioHang>();
        }

        [Key]
        public int ma { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [RegularExpression(@"^[ a-zA-Z0-9ẮẰẲẴẶĂẤẦẨẪẬÂÁÀÃẢẠĐẾỀỂỄỆÊÉÈẺẼẸÍÌỈĨỊỐỒỔỖỘÔỚỜỞỠỢƠÓÒÕỎỌỨỪỬỮỰƯÚÙỦŨỤÝỲỶỸỴắằẳẵặăấầẩẫậâáàãảạđếềểễệêéèẻẽẹíìỉĩịốồổỗộôớờởỡợơóòõỏọứừửữựưúùủũụýỳỷỹỵ]+$", ErrorMessage = "Không được sử dụng ký tự đặc biệt")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(50)]
        public string ten { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán không được để trống")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Giá sản phẩm phải là số")]
        public decimal? giaban { get; set; }

        [Display(Name = "Hình ảnh")]
        [StringLength(200)]
        public string linkanh { get; set; }

        [Display(Name = "Xuất xứ")]
        [Required(ErrorMessage = "Bạn phải nhập xuất xứ của sản phẩm")]
        [RegularExpression(@"^[ a-zA-ZẮẰẲẴẶĂẤẦẨẪẬÂÁÀÃẢẠĐẾỀỂỄỆÊÉÈẺẼẸÍÌỈĨỊỐỒỔỖỘÔỚỜỞỠỢƠÓÒÕỎỌỨỪỬỮỰƯÚÙỦŨỤÝỲỶỸỴắằẳẵặăấầẩẫậâáàãảạđếềểễệêéèẻẽẹíìỉĩịốồổỗộôớờởỡợơóòõỏọứừửữựưúùủũụýỳỷỹỵ]+$", ErrorMessage = "Không được sử dụng số và ký tự đặc biệt")]
        [StringLength(50)]
        public string xuatxu { get; set; }

        [Display(Name = "Danh mục")]
        public int? madanhmuc { get; set; }

        [Display(Name = "Thể loại")]
        public int? mastyle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHang { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual Style Style { get; set; }
    }
}
