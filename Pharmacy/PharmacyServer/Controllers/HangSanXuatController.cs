using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyServer.Controllers
{
    public class HangSanXuatController : ApiController
    {
        public DBPharmacyDataContext db = new DBPharmacyDataContext();
        //Lấy danh sách
        [HttpGet]
        public List<HANGSANXUAT> DanhSachHSX()
        {
            return db.HANGSANXUATs.ToList();
        }
    }
}
