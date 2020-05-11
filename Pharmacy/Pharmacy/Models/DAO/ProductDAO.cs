using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.Models.DAO
{

    public class ProductDAO
    {
        MyDBContext db = null;
        public ProductDAO()
        {
            db = new MyDBContext();
        }
        public List<THUOC> SanPhamBanChay(int top)
        {
            return db.THUOCs.OrderByDescending(x => x.SoLuongTon).Take(top).ToList();
        }
        public List<THUOC> SanPhamMoi()
        {
            return db.THUOCs.SqlQuery("SELECT TOP 4 * FROM THUOC ORDER BY SoLuongTon DESC").ToList();
        }
    }
}