using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pharmacy.Models.EF;

namespace Pharmacy.Models.DAO
{
    [Serializable]
    public class CartItem
    {
        public THUOC SanPham { get; set; }
        public int SoLuong { get; set; }
    }

    public class Cart
    {
        private List<CartItem> gioHang = new List<CartItem>();

        public void themSP(THUOC sp, int sl)
        {
            CartItem dongSP = gioHang
                .Where(p => p.SanPham.MaThuoc == sp.MaThuoc)
                .FirstOrDefault();

            if (dongSP == null)
            {
                gioHang.Add(new CartItem
                {
                    SanPham = sp,
                    SoLuong = sl
                });
            }
            else 
            {
                dongSP.SoLuong += sl;
                if (dongSP.SoLuong <= 0)
                {
                    gioHang.RemoveAll(l => l.SanPham.MaThuoc == sp.MaThuoc);
                }
            }
        }

        public void capnhatSP(THUOC sp, int sl)
        {
            CartItem dongSP = gioHang
                .Where(p => p.SanPham.MaThuoc == sp.MaThuoc)
                .FirstOrDefault();

            if (dongSP != null)
            {
                if (sl > 0)
                {
                    dongSP.SoLuong = sl;
                }
                else
                {
                    gioHang.RemoveAll(l => l.SanPham.MaThuoc == sp.MaThuoc);
                }
            }
        }

        public void xoaSP(THUOC sp)
        {
            gioHang.RemoveAll(l => l.SanPham.MaThuoc == sp.MaThuoc);
        }

        public int? TongTien()
        {
            return gioHang.Sum(e => e.SanPham.DonGia * e.SoLuong);
        }

        public int? TongSL()
        {
            return gioHang.Sum(e => e.SoLuong);
        }

        public void XoaToanBo()
        {
            gioHang.Clear();
        }

        public IEnumerable<CartItem> dongSP
        {
            get { return gioHang; }
        }
    }
}