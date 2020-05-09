using System.Linq;
using System.Web.Mvc;
using Pharmacy.Models;
namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        public MyDBContext db = new MyDBContext();
        public ActionResult Index()
        {
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

        public ActionResult Shop()
        {

            var item = db.THUOCs.Where(x=>x.MaLoaiThuoc.Equals("TTY")).ToList();
            return View(item);
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