namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUXUAT")]
    public partial class CHITIETPHIEUXUAT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaPhieuXuat { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaThuoc { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public virtual PHIEUXUAT PHIEUXUAT { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
