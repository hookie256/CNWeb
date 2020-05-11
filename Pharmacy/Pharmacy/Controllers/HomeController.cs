using System.Linq;
using System.Web.Mvc;
using PagedList;
using Pharmacy.Models;
using Pharmacy.Models.DAO;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        public MyDBContext db = new MyDBContext();
        public ActionResult Index()
        {
            var productDAO = new ProductDAO();
            ViewBag.TopProducts = productDAO.SanPhamBanChay(6);
            ViewBag.NewProducts = productDAO.SanPhamMoi();
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult ThanhToan()
        {
            return View();
        }

        public ActionResult ShopSingle()
        {
            return View();
        }

        public ActionResult Shop(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var item = db.THUOCs.Where(x=>x.MaLoaiThuoc=="TPCN").ToList();
            foreach (THUOC it in item)
            {
                if (it.TenThuoc.Length >30)
                {
                    it.TenThuoc = it.TenThuoc.Substring(0, 29) + "...";
                }
            }
            return View(item.ToPagedList(pageNumber,pageSize));
        }
        //public  SanPhamBanChay()
        //{
        //    var top_item = db.THUOCs.SqlQuery("SELECT TOP 6 * FROM THUOC ORDER BY SoLuongTon ").ToList();
        //    return (top_item);
        //}
        public ActionResult Question()
        {
            return View();
        }

        public ActionResult Security()
        {
            return View();
        }

        public ActionResult Exchange()
        {
            return View();
        }

        public ActionResult Shipping()
        {
            return View();
        }
    }
}