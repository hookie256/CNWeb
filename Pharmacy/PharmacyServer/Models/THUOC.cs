using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyServer.Models
{
    public class THUOC
    {
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string CongDung { get; set; }
        public string ThanhPhan { get; set; }
        public int SoLuongTon { get; set; }
        public string DangThuoc { get; set; }
        public string MaLoaiThuoc { get; set; }
        public int? DonGia { get; set; }
        public string MaHangSX { get; set; }
        public string MaNhaCungCap { get; set; }
        public string UrlImage { get; set; }
        public string Tien { get; set; }
        public string TimKiem { get; set; }
    }
}