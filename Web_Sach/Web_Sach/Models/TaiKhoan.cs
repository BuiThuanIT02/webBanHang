namespace Web_Sach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int ID { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        [Column("TaiKhoan")]
        [StringLength(50)]
        [Required (ErrorMessage ="Mời bạn nhập Tên tài khoản")]
        public string TaiKhoan1 { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mời bạn nhập Họ và tên")]
    
        public string FullName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mời bạn nhập số điện thoại")]
        public string Phone { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Mời bạn nhập Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mời bạn nhập Password")]
        public string Password { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Mời bạn nhập địa chỉ")]
        public string Address { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
