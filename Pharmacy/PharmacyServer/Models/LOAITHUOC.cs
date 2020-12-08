using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyServer.Models
{
    public class LOAITHUOC
    {
        public string MaLoaiThuoc { get; set; }
        public string TenLoaiThuoc { get; set; }
        public string ParentID { get; set; }
    }
}
