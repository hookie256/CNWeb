using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyWebAPIinMVC.Models
{
    public class CHITIETHOADON
    {
        public int MaHoaDon { get; set; }
        public string MaThuoc { get; set; }
        public int? DonGia { get; set; }
        public int? SoLuong { get; set; }
    }
}
