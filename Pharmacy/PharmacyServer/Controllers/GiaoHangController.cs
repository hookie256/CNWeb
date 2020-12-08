using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyServer.Controllers
{
    public class GiaoHangController : ApiController
    {
        public DBPharmacyDataContext db = new DBPharmacyDataContext();
        //Lấy danh sách
        [HttpGet]
        public List<GIAOHANG> DanhSachGiaoHang()
        {
            return db.GIAOHANGs.ToList();
        }
    }
}
