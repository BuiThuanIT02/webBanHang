namespace Web_Sach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSP")]
    public partial class DanhMucSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucSP()
        {
            Saches = new HashSet<Sach>();
        }

        public int ID { get; set; }

        [StringLength(80)]
        [Required (ErrorMessage ="Mời nhập tên danh mục")]
        public string Name { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Mời nhập MetaTitle")]
        public string MetaTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
