using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pharmacy.Models.EF;
namespace Pharmacy.Models.DAO
{

    public class ProductDAO
    {
        MyDBContext db = null;
        public ProductDAO()
        {
            db = new MyDBContext();
        }
        public List<THUOC> SanPhamBanChay()
        {
            return db.THUOCs.SqlQuery("SELECT TOP 6 * FROM THUOC ORDER BY SoLuongTon ASC").ToList();
        }
        public List<THUOC> SanPhamMoi()
        {
            return db.THUOCs.SqlQuery("SELECT TOP 8 * FROM THUOC ORDER BY SoLuongTon DESC").ToList();
        }
    }
}