namespace Pharmacy.Models.EF
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
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            CHITIETHOADONs1 = new HashSet<CHITIETHOADON>();
        }

        [Key]
        [StringLength(20)]
        public string MaThuoc { get; set; }

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

        public int? DonGia { get; set; }

        [StringLength(15)]
        public string MaHangSX { get; set; }

        [StringLength(15)]
        public string MaNhaCungCap { get; set; }

        [StringLength(50)]
        public string UrlImage { get; set; }

        [StringLength(9)]
        public string Tien { get; set; }

        public string TimKiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs1 { get; set; }

        public virtual HANGSANXUAT HANGSANXUAT { get; set; }

        public virtual LOAITHUOC LOAITHUOC { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
