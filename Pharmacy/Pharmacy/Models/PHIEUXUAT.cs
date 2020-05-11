namespace Pharmacy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUXUAT")]
    public partial class PHIEUXUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUXUAT()
        {
            CHITIETPHIEUXUATs = new HashSet<CHITIETPHIEUXUAT>();
        }

        [Key]
        [StringLength(20)]
        public string MaPhieuXuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuat { get; set; }

        [StringLength(35)]
        public string MaKhachHang { get; set; }

        public int? Tong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
