namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            PHIEUXUATs = new HashSet<PHIEUXUAT>();
        }

        [Key]
        [StringLength(35)]
        public string MaKhachHang { get; set; }

        [Required]
        [StringLength(40)]
        public string TenKhachHang { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Column("CMND/TCCCD")]
        [Required]
        [StringLength(12)]
        public string CMND_TCCCD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUATs { get; set; }
    }
}
