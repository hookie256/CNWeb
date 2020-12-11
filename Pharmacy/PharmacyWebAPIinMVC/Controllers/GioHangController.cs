using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyWebAPIinMVC.Controllers
{
    public class GioHangController : ApiController
    {
        public DBPharmacyDataContext db = new DBPharmacyDataContext();
        //Lấy danh sách
        [HttpGet]
        public List<GIOHANG> DanhSachGioHang()
        {
            return db.GIOHANGs.ToList();
        }
    }
}
