namespace Pharmacy.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
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
    }
}
