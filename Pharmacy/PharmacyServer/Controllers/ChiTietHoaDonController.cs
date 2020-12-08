using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyServer.Controllers
{
    public class ChiTietHoaDonController : ApiController
    {
        public DBPharmacyDataContext db = new DBPharmacyDataContext();
        //Lấy danh sách
        [HttpGet]
        public List<CHITIETHOADON> DanhSachChiTietHD()
        {
            return db.CHITIETHOADONs.ToList();
        }
    }
}
