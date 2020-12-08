using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyServer.Controllers
{
    public class ThuocController : ApiController
    {
        public DBPharmacyDataContext db = new DBPharmacyDataContext();
        //Lấy danh sách
        [HttpGet]
        public List<THUOC> DanhSachThuoc()
        {
            return db.THUOCs.ToList();
        }

        //[HttpGet]
        //public List<THUOC> SanPhamBanChay()
        //{
        //    DBPharmacyDataContext db = new DBPharmacyDataContext();
        //    return db.THUOCs.FirstOrDefault(x => x.);
        //}
    }
}
