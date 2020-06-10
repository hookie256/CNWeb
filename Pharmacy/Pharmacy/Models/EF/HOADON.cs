namespace Pharmacy.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string GhiChu { get; set; }

        [StringLength(15)]
        public string MaKhuyenMai { get; set; }
        [StringLength(1)]
        public string HinhThucGiaoHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
    }
}
