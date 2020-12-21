using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pharmacy.Models.EF;
namespace Pharmacy.Models.DAO
{

    public class ProductDAO
    {
        public QL_SR.QLBanThuocServiceSoapClient client = new QL_SR.QLBanThuocServiceSoapClient();
        public List<THUOC> SanPhamBanChay()
        {
            var dsSPBC = client.SanPhamBanChay();
            List<THUOC> ds = new List<THUOC>();
            foreach (QL_SR.THUOC t in dsSPBC)
            {
                THUOC lt = new THUOC();
                lt.MaThuoc = t.MaThuoc;
                lt.TenThuoc = t.TenThuoc;
                lt.CongDung = t.CongDung;
                lt.ThanhPhan = t.ThanhPhan;
                lt.SoLuongTon = t.SoLuongTon;
                lt.MaNhaCungCap = t.MaNhaCungCap;
                lt.Tien = t.Tien;
                lt.DangThuoc = t.DangThuoc;
                lt.DonGia = t.DonGia;
                lt.MaHangSX = t.MaHangSX;
                lt.MaLoaiThuoc = t.MaLoaiThuoc;
                lt.UrlImage = t.UrlImage;
                lt.TimKiem = t.TimKiem;
                ds.Add(lt);
            }
            return ds;
        }
        public List<THUOC> SanPhamMoi()
        {
            var dsSPM = client.SanPhamMoi();
            List<THUOC> ds = new List<THUOC>();
            foreach (QL_SR.THUOC t in dsSPM)
            {
                THUOC lt = new THUOC();
                lt.MaThuoc = t.MaThuoc;
                lt.TenThuoc = t.TenThuoc;
                lt.CongDung = t.CongDung;
                lt.ThanhPhan = t.ThanhPhan;
                lt.SoLuongTon = t.SoLuongTon;
                lt.MaNhaCungCap = t.MaNhaCungCap;
                lt.Tien = t.Tien;
                lt.DangThuoc = t.DangThuoc;
                lt.DonGia = t.DonGia;
                lt.MaHangSX = t.MaHangSX;
                lt.MaLoaiThuoc = t.MaLoaiThuoc;
                lt.UrlImage = t.UrlImage;
                lt.TimKiem = t.TimKiem;
                ds.Add(lt);
            }
            return ds;
        }
    }
}