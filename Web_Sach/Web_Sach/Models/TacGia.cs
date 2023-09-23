namespace Web_Sach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacGia()
        {
            ThamGias = new HashSet<ThamGia>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        [Required (ErrorMessage ="Mời bạn nhập tên tác giả")]
        public string TenTacGia { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Mời bạn nhập địa chỉ ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập tiểu sử tác giả")]
        public string TieuSu { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mời bạn nhập SDT tác giả")]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
