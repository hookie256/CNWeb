using System.Linq;
using System.Web.Mvc;
using PagedList;
using Pharmacy.Models.EF;
using Pharmacy.Models.DAO;
using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;

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

        //Thêm sản phẩm vào giỏ hàng
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

                Session["GioHangTam"] = gioHang;
            }

            return RedirectToAction("Cart");

        }

        // Xóa SP khỏi giỏ hàng
        public ActionResult XoaSP(string id)
        {
            var sp = db.THUOCs.Find(id);
            var gioHang = (Cart)Session["GioHangTam"];

            if (gioHang != null)
            {
                gioHang.XoaSP(sp);
                //Gán sp vào Session
                Session["GioHangTam"] = gioHang;
            }

            return RedirectToAction("Cart");
        }


        //Thanh Toán
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var gioHang = (Cart)Session["GioHangTam"];
            if (gioHang == null)
            {
                gioHang = new Cart();
            }
            return View(gioHang);
        }
        [HttpPost]
        public ActionResult ThanhToan(HOADON model,string ho, string ten, string diachiduong,string sonha,string email, string sdt,string ghichu)
        {
            model.TenKhachHang = ho + " " + ten;
            model.DiaChi = sonha + " " + diachiduong;
            model.Email = email;
            model.SoDienThoai = sdt;
            model.GhiChu = ghichu;
            db.HOADONs.Add(model);
            db.SaveChanges();
            var gioHang = (Cart)Session["GioHangTam"];
            foreach (var item in gioHang.dongSP)
            {
                CHITIETHOADON obj = new CHITIETHOADON();
                obj.MaHoaDon = model.MaHoaDon;
                obj.MaThuoc = item.SanPham.MaThuoc;
                obj.DonGia = item.SanPham.DonGia;
                obj.SoLuong = item.SoLuong;

                db.CHITIETHOADONs.Add(obj);
                db.SaveChanges();
            }
            gioHang.XoaToanBo();
            Session["GioHangTam"] = gioHang;
            return View("ThankYou");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public string MaHoaMD5(string str)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        [HttpPost]
        public ActionResult Register(string ho, string ten, string email, string pas1, string pas2)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.TenKhachHang = ho + " " + ten;
            kh.MaKhachHang = MaHoaMD5(kh.TenKhachHang);
            kh.Email = email;
            if (pas1 == pas2)
            {
                kh.MatKhau = MaHoaMD5(pas1);
            }
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            return View("Login");
        }

        public ActionResult Login()
        {
            //phần đăng nhập ý cái mật khẩu sử dụng hàm MaHoaMD5 rồi hãng so sánh nhé, vì t mã hóa mật khẩu rồi!

            return View();
        }

        public ActionResult ThankYou()
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