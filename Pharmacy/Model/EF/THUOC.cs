namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOC")]
    public partial class THUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOC()
        {
            CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            CHITIETPHIEUXUATs = new HashSet<CHITIETPHIEUXUAT>();
        }

        [Key]
        [StringLength(20)]
        public string MaThuoc { get; set; }

        [Required]
        [StringLength(15)]
        public string MaLoThuoc { get; set; }

        [Required]
        public string TenThuoc { get; set; }

        [Required]
        public string CongDung { get; set; }

        [Required]
        public string ThanhPhan { get; set; }

        public int SoLuongTon { get; set; }

        [Required]
        [StringLength(20)]
        public string DangThuoc { get; set; }

        [Required]
        [StringLength(15)]
        public string MaLoaiThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUXUAT> CHITIETPHIEUXUATs { get; set; }

        public virtual LOAITHUOC LOAITHUOC { get; set; }

        public virtual LOTHUOC LOTHUOC { get; set; }
    }
}
