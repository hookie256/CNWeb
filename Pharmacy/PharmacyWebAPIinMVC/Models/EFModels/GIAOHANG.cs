namespace PharmacyWebAPIinMVC.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOHANG")]
    public partial class GIAOHANG
    {
        [Key]
        [StringLength(1)]
        public string HinhThucGiaoHang { get; set; }

        [StringLength(50)]
        public string TenHinhThuc { get; set; }
    }
}
