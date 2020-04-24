namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOTHUOC")]
    public partial class LOTHUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOTHUOC()
        {
            THUOCs = new HashSet<THUOC>();
        }

        [Key]
        [StringLength(15)]
        public string MaLoThuoc { get; set; }

        [StringLength(15)]
        public string MaHangSX { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySanXuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        public virtual HANGSANXUAT HANGSANXUAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUOC> THUOCs { get; set; }
    }
}
