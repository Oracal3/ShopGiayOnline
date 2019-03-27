namespace DullStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            GioHang = new HashSet<GioHang>();
        }

        [Key]

        public int ma { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Phải điền đầy đủ họ và tên")]
        [RegularExpression(@"^[ a-zA-ZẮẰẲẴẶĂẤẦẨẪẬÂÁÀÃẢẠĐẾỀỂỄỆÊÉÈẺẼẸÍÌỈĨỊỐỒỔỖỘÔỚỜỞỠỢƠÓÒÕỎỌỨỪỬỮỰƯÚÙỦŨỤÝỲỶỸỴắằẳẵặăấầẩẫậâáàãảạđếềểễệêéèẻẽẹíìỉĩịốồổỗộôớờởỡợơóòõỏọứừửữựưúùủũụýỳỷỹỵ]+$", ErrorMessage = "Họ và tên phải là chữ")]
        [StringLength(50)]
        public string hoten { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Phải điền đầy đủ thông tin địa chỉ")]
        [StringLength(100)]
        public string diachi { get; set; }

        [Display(Name = "Địện thoại liên hệ")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại phải là số")]
        [StringLength(50)]
        public string sodienthoai { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn phải nhập email")]
        [StringLength(100)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }
    }
}
