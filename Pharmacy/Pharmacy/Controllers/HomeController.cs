using System.Linq;
using System.Web.Mvc;
using PagedList;
using Pharmacy.Models.EF;
using Pharmacy.Models.DAO;
using System;
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
        public ActionResult TimKiem(string searchstr)
        {
            var model = db.THUOCs.SqlQuery("SELECT * FROM THUOC WHERE TenThuoc LIKE '%" + searchstr + "%' OR TimKiem LIKE '%" + searchstr + "%'").ToList();           
            return View(model);
        }
        public ActionResult DanhMuc(string id,int? page)
        {          
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var item = db.THUOCs.Where(x => x.MaLoaiThuoc.Trim() == id.Trim()).ToList();
            foreach (THUOC it in item)
            {
                if (it.TenThuoc.Length > 30)
                {
                    it.TenThuoc = it.TenThuoc.Substring(0, 29) + "...";
                }
            }

            return View("Shop",item.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult ChiTietSanPham(string id)
        {
            var model = db.THUOCs.Where(x => x.MaThuoc.Trim() == id.Trim()).FirstOrDefault();
            return View("ShopSingle", model);
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = db.LOAITHUOCs.ToList();
            return PartialView(model);
        }
        public ActionResult Xemtatca(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var item = db.THUOCs.SqlQuery("SELECT * FROM THUOC ORDER BY SoLuongTon ASC").ToList();
            foreach (THUOC it in item)
            {
                if (it.TenThuoc.Length > 30)
                {
                    it.TenThuoc = it.TenThuoc.Substring(0, 29) + "...";
                }
            }
            return View(item.ToPagedList(pageNumber, pageSize));
        }

        //PHẦN LÀM CART
        public ActionResult Cart()
        {
            var gioHang = (Cart)Session["GioHangTam"];
            if (gioHang==null)
            {
                gioHang = new Cart();
            }
            return View(gioHang);
        }
        //Thêm sản phẩm
        public ActionResult ThemSP(string id,string soluong,string returnURL)
        {
            var sp = db.THUOCs.Find(id);
            if (sp.TenThuoc.Length > 30)
            {
                sp.TenThuoc = sp.TenThuoc.Substring(0, 25) + "...";
            }
            var gioHang = (Cart)Session["GioHangTam"];
            if (gioHang !=null)
            {
                gioHang.themSP(sp, Convert.ToInt32(soluong));
                Session["GioHangTam"] = gioHang;
            }
            else
            {
                gioHang = new Cart();
                gioHang.themSP(sp, Convert.ToInt32(soluong));
                Session["GioHangTam"] = gioHang;
            }
            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Cart");
            }
            return Redirect(returnURL);
        }
        //Cập nhật giỏ hàng
        public ActionResult CapNhatGH(string[] masp, int[] sl)
        {
            var gioHang = (Cart)Session["GioHangTam"];

            if (gioHang != null)
            {
                for (int i = 0; i < masp.Count(); i++)
                {
                    var sp = db.THUOCs.Find(masp[i]);
                    gioHang.capnhatSP(sp, sl[i]);
                }

                Session["CartSession"] = gioHang;
            }

            return RedirectToAction("Cart");

        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ThanhToan()
        {
            return View();
        }

        public ActionResult ShopSingle(string id)
        {
            var model = db.THUOCs.Where(x => x.MaThuoc.Trim() == id.Trim()).FirstOrDefault();
            return View(model);
        }

        public ActionResult Shop(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var item = db.THUOCs.ToList();
            foreach (THUOC it in item)
            {
                if (it.TenThuoc.Length > 30)
                {
                    it.TenThuoc = it.TenThuoc.Substring(0, 29) + "...";
                }
            }
            return View(item.ToPagedList(pageNumber, pageSize));
        }
    }
}