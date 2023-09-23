namespace Web_Sach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ThamGias = new HashSet<ThamGia>();
        }

        public int ID { get; set; }

        public int? DanhMucID { get; set; }

        [StringLength(250)]
        [Required (ErrorMessage ="Mời bạn nhập tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Mời bạn nhập ảnh sản phẩm")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập giá sản phẩm")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập số lượng sản phẩm")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập sale sản phẩm")]
        public int? Sale { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập mô tả sản phẩm")]
        public string MoTa { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mời bạn nhập kích thước sản phẩm")]
        public string KichThuoc { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Mời bạn nhập trọng lượng sản phẩm")]
        public string TrongLuong { get; set; }

        public int? NhaCungCapID { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập số trang sản phẩm")]
        public int? SoTrang { get; set; }

        public int? NhaXuatBanID { get; set; }

        public DateTime? NgayCapNhat { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập số lượng tồn kho sản phẩm")]
        public int? SoLuongTon { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Mời bạn nhập MetaTile sản phẩm")]
        public string MetaTitle { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập TopHot)")]
        public DateTime? TopHot { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập ViewCount")]
        public int? ViewCount { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual DanhMucSP DanhMucSP { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
