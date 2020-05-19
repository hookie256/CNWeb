using System.Linq;
using System.Web.Mvc;
using PagedList;
using Pharmacy.Models.EF;
using Pharmacy.Models.DAO;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        public MyDBContext db = new MyDBContext();
        public ActionResult Index()
        {
            var productDAO = new ProductDAO();
            ViewBag.TopProducts = productDAO.SanPhamBanChay();
            ViewBag.NewProducts = productDAO.SanPhamMoi();
            return View();
        }
        [HttpPost]
        public ActionResult TimKiem(string searchstr,int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var model = db.THUOCs.Where(x => x.TimKiem.Contains(searchstr)).ToList();
            return View("Shop", model.ToPagedList(pageNumber, pageSize));
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