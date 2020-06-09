namespace Pharmacy.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIOHANG")]
    public partial class GIOHANG
    {
        [Key]
        public int MaGH { get; set; }

        [Required]
        [StringLength(20)]
        public string MaThuoc { get; set; }

        [StringLength(35)]
        public string MaKhachHang { get; set; }

        public int SoLuong { get; set; }
    }
}
