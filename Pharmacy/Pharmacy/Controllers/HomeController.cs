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
        public void DuyTriDangNhap()
        {
            if (Request.Cookies["login"] != null)
            {
                string email = Request.Cookies["login"].Value;
                var user = db.KHACHHANGs.Where(x => x.Email.Contains(email)).First();
                var userSession = new UserLogin();
                userSession.userID = user.Email;
                userSession.userName = user.TenKhachHang;
                Session.Add(Common.CommonConstants.USER_SESSION, userSession);
            }
        }
        [HttpPost]
        public ActionResult TimKiem(string searchstr)
        {
            var model = db.THUOCs.SqlQuery("SELECT * FROM THUOC WHERE TenThuoc LIKE '%" + searchstr + "%' OR TimKiem LIKE '%" + searchstr + "%'").ToList();
            return View(model);
        }
        public ActionResult DanhMuc(string id, int? page)
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

            return View("Shop", item.ToPagedList(pageNumber, pageSize));
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
        public static int dem=0;
        public ActionResult Cart()
        {
            //lấy dữ liệu db đổ vào cart nếu có
            if (dem==0)          
            {
                if (Request.Cookies["login"] != null)
                {
                    string str = Request.Cookies["login"].Value;
                    var user = db.KHACHHANGs.Where(x => x.Email.Contains(str)).First();
                    var items = db.GIOHANGs.Where(x => x.MaKhachHang.Contains(user.MaKhachHang)).ToList();
                    var gioHang = (Cart)Session["GioHangTam"];
                    if (items.Count() == 0)
                    {
                        gioHang = new Cart();
                    }
                    else
                    {
                        gioHang = new Cart();
                        foreach (GIOHANG it in items)
                        {
                            var sp = db.THUOCs.Find(it.MaThuoc);
                            gioHang.themSP(sp, Convert.ToInt32(it.SoLuong));
                            Session["GioHangTam"] = gioHang;
                        }
                    }
                    return View(gioHang);
                }
                else
                {
                    var items = db.GIOHANGs.Where(x => x.MaKhachHang == null).ToList();
                    var gioHang = (Cart)Session["GioHangTam"];
                    if (items.Count() == 0)
                    {
                        gioHang = new Cart();
                    }
                    else
                    {
                        gioHang = new Cart();
                        foreach (GIOHANG it in items)
                        {
                            var sp = db.THUOCs.Find(it.MaThuoc);
                            gioHang.themSP(sp, Convert.ToInt32(it.SoLuong));
                            Session["GioHangTam"] = gioHang;
                        }
                    }
                    return View(gioHang);
                }
            }
            else
            {
                var gioHang = (Cart)Session["GioHangTam"];
                return View(gioHang);
            }
        } 

        //Thêm sản phẩm vào giỏ hàng
        public ActionResult ThemSP(string id,string soluong)
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
            //thêm thuốc vào db giỏ hàng
            var item = db.GIOHANGs.Where(x => x.MaThuoc.Contains(sp.MaThuoc)).ToList();
            if (item.Count() == 0)
            {
                GIOHANG g = new GIOHANG();
                g.MaThuoc = sp.MaThuoc;
                g.SoLuong = Convert.ToInt32(soluong);
                if (Request.Cookies["login"] != null)
                {
                    string str = Request.Cookies["login"].Value;
                    var user = db.KHACHHANGs.Where(x => x.Email.Contains(str)).First();
                    g.MaKhachHang = user.MaKhachHang;
                }
                db.GIOHANGs.Add(g);
            }
            else
            {
                if (Request.Cookies["login"] != null)
                {
                    string str = Request.Cookies["login"].Value;
                    var user = db.KHACHHANGs.Where(x => x.Email.Contains(str)).First();
                    var itemcart = db.GIOHANGs.Where(x => x.MaThuoc.Contains(sp.MaThuoc)&& x.MaKhachHang.Contains(user.MaKhachHang)).First();
                    itemcart.SoLuong = itemcart.SoLuong + Convert.ToInt32(soluong);
                }
                else
                {
                    var itemcart = db.GIOHANGs.Where(x => x.MaThuoc.Contains(sp.MaThuoc)).First();
                    itemcart.SoLuong = itemcart.SoLuong + Convert.ToInt32(soluong);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        //Cập nhật giỏ hàng
        [HttpPost]
        public ActionResult CapNhatGH(string[] masp, int[] sl,string coupon)
        {
            var gioHang = (Cart)Session["GioHangTam"];
            gioHang.coupon = coupon;
            if (gioHang != null)
            {
                for (int i = 0; i < masp.Count(); i++)
                {
                    var sp = db.THUOCs.Find(masp[i]);
                    gioHang.capnhatSP(sp, sl[i]);
                    //update thuốc trong db giỏ hàng
                    if (Request.Cookies["login"] != null)
                    {
                        string str = Request.Cookies["login"].Value;
                        var user = db.KHACHHANGs.Where(x=>x.Email.Contains(str)).First();
                        var itemcart = db.GIOHANGs.Where(x => x.MaThuoc.Contains(sp.MaThuoc) && x.MaKhachHang.Contains(user.MaKhachHang)).First();
                        itemcart.SoLuong = sl[i];
                    }
                    else
                    {
                        var itemcart = db.GIOHANGs.Where(x => x.MaThuoc.Contains(sp.MaThuoc)).First();
                        itemcart.SoLuong = sl[i];
                    }
                    db.SaveChanges();
                }
                Session["GioHangTam"] = gioHang;
            }
            dem++;
            if (dem>10)
            {
                dem = 1;
            }
            return RedirectToAction("Cart");

        }
        //Xóa Sản phẩm
        public ActionResult XoaSP(string id)
        {
            var sp = db.THUOCs.Find(id);
            var gioHang = (Cart)Session["GioHangTam"];
            if (gioHang != null)
            {
                gioHang.XoaSP(sp);
                db.GIOHANGs.Remove(db.GIOHANGs.Where(x => x.MaThuoc == sp.MaThuoc).First());
                //Gán sp vào Session
                Session["CartSession"] = gioHang;
            }
            dem = 1;
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
        public ActionResult ThanhToan(HOADON model,string ho, string ten, string diachiduong,string sonha,string email, string sdt,string ghichu,string makhuyenmai,string giaohang)
        {
            model.TenKhachHang = ho + " " + ten;
            model.DiaChi = sonha + " " + diachiduong;
            model.Email = email;
            model.SoDienThoai = sdt;
            model.GhiChu = ghichu;
            model.MaKhuyenMai = makhuyenmai;
            model.HinhThucGiaoHang = giaohang;
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
                if (Request.Cookies["login"] != null)
                {
                    string str = Request.Cookies["login"].Value;
                    var user = db.KHACHHANGs.Where(x=>x.Email.Contains(str)).First();
                    db.GIOHANGs.Remove(db.GIOHANGs.Where(x => x.MaThuoc == item.SanPham.MaThuoc && x.MaKhachHang.Contains(user.MaKhachHang)).First());
                }
                else
                {
                    db.GIOHANGs.Remove(db.GIOHANGs.Where(x => x.MaThuoc == item.SanPham.MaThuoc).First());
                }
                db.SaveChanges();
            }
            gioHang.XoaToanBo();
            //xóa cả trong db giỏ hàng
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
            return View();
        }

        public ActionResult Logout()
        {
            Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);
            Session[Common.CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult LoginControl(string email, string password, string duytri)
        {
            var user = db.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG WHERE Email = '" + email + "' AND MatKhau='" + MaHoaMD5(password) + "'").ToList();
            if (user.Count() != 0)
            {
                foreach (KHACHHANG us in user)
                {
                    var userSession = new UserLogin();
                    userSession.userID = us.Email;
                    userSession.userName = us.TenKhachHang;
                    Session.Add(Common.CommonConstants.USER_SESSION, userSession);
                    if ( duytri!=null)
                    {
                        Response.Cookies["login"].Value = us.Email.ToString();
                        Response.Cookies["login"].Expires = DateTime.Now.AddDays(1);
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Login");
            }
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
        public ActionResult Question()
        {
            return View();
        }
        public ActionResult Shipping()
        {
            return View();
        }
        public ActionResult Exchange()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Security()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}