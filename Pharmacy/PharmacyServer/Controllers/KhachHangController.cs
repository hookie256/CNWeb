using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyServer.Controllers
{
    public class KhachHangController : ApiController
    {
        public DBPharmacyDataContext db = new DBPharmacyDataContext();
        //Lấy danh sách
        [HttpGet]
        public List<KHACHHANG> DanhSachKH()
        {
            return db.KHACHHANGs.ToList();
        }
    }
}
