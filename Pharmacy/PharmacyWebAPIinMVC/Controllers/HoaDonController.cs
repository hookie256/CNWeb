using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyWebAPIinMVC.Controllers
{
    public class HoaDonController : ApiController
    {
        public DBPharmacyDataContext db = new DBPharmacyDataContext();
        //Lấy danh sách
        [HttpGet]
        public List<HOADON> DanhSachHD()
        {
            return db.HOADONs.ToList();
        }
    }
}
