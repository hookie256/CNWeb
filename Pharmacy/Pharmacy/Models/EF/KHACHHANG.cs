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
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(90)]
        public string MatKhau { get; set; }
    }
}
