using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class UserDao
    {
        Pharmacy pm = null;
        public UserDao()
        {
            pm = new Pharmacy();
        }
        public string Insert (NHANVIEN nv)
        {
            pm.NHANVIENs.Add(nv);
            pm.SaveChanges();
            return nv.CMND_TCCCD;
        }
        public bool Login(string MaDinhDanh,string Password)
        {
            var result = pm.NHANVIENs.Count(x => x.CMND_TCCCD == MaDinhDanh && x.SoDienThoai == Password);
            if (result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
