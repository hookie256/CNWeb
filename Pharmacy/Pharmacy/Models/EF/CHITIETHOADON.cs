namespace Pharmacy.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaThuoc { get; set; }

        public int? DonGia { get; set; }

        public int? SoLuong { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual THUOC THUOC { get; set; }

        public virtual THUOC THUOC1 { get; set; }
    }
}
