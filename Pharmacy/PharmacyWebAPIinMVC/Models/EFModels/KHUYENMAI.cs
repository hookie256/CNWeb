namespace PharmacyWebAPIinMVC.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUYENMAI")]
    public partial class KHUYENMAI
    {
        [Key]
        [StringLength(10)]
        public string MaKM { get; set; }

        public int TienKM { get; set; }
    }
}
