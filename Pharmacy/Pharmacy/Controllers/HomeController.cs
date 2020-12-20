﻿using System.Linq;
using System.Web.Mvc;
using PagedList;
using Pharmacy.Models.EF;
using Pharmacy.Models.DAO;
using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        public MyDBContext db = new MyDBContext();
        public QL_SR.QLBanThuocServiceSoapClient client = new QL_SR.QLBanThuocServiceSoapClient();

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
            var model = client.TimKiemThuoc(searchstr);
            return View(model);
        }

        public ActionResult DanhMuc(string id, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var item = client.LayTenLoaiThuoc(id);
            foreach (QL_SR.THUOC it in item)
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
            var model = client.ChiTietSP(id);            
            return View("ShopSingle", model);
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = client.LayDSLoaiThuoc("");
            List<LOAITHUOC> dslt = new List<LOAITHUOC>();
            foreach(QL_SR.LOAITHUOC m in model)
            {
                LOAITHUOC lt = new LOAITHUOC();
                lt.MaLoaiThuoc = m.MaLoaiThuoc;
                lt.ParentID = m.ParentID;
                lt.TenLoaiThuoc = m.TenLoaiThuoc;
                dslt.Add(lt);
            }
            return PartialView(dslt);
        }

        public ActionResult Xemtatca(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var item = client.LayDS("");
            foreach (QL_SR.THUOC it in item)
            {
                if (it.TenThuoc.Length > 30)
                {
                    it.TenThuoc = it.TenThuoc.Substring(0, 29) + "...";
                }
            }
            return View(item.ToPagedList(pageNumber, pageSize));
        }

        public static int dem=0;
        public ActionResult Cart()
        {
            //lấy dữ liệu db đổ vào cart nếu có
            if (dem == 0)          
            {
                if (Request.Cookies["login"] != null)
                {
                    var gioHang = (Cart)Session["GioHangTam"];
                    string str = Request.Cookies["login"].Value;
                    var user = client.ThongTinKH(str);
                    foreach (QL_SR.KHACHHANG us in user)
                    {
                        var items = client.ThongTinGH(us.MaKhachHang, "");
                        if (items.Count() == 0)
                        {
                            gioHang = new Cart();
                        }
                        else
                        {
                            gioHang = new Cart();
                            foreach (QL_SR.GIOHANG it in items)
                            {
                                var sp = client.LayDS(it.MaThuoc);
                                foreach (QL_SR.THUOC t in sp)
                                {
                                    gioHang.themSP(t, Convert.ToInt32(it.SoLuong));
                                }
                                Session["GioHangTam"] = gioHang;
                            }
                        }
                    }                    
                    return View(gioHang);
                }
                else
                {
                    var items = client.ThongTinGH(null, "");
                    var gioHang = (Cart)Session["GioHangTam"];
                    if (items.Count() == 0)
                    {
                        gioHang = new Cart();
                    }
                    else
                    {
                        gioHang = new Cart();
                        foreach (QL_SR.GIOHANG it in items)
                        {
                            var sp = client.LayDS(it.MaThuoc);
                            foreach (QL_SR.THUOC t in sp)
                            {
                                gioHang.themSP(t, Convert.ToInt32(it.SoLuong));
                                Session["GioHangTam"] = gioHang;
                            }                           
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

        public ActionResult ThemSP(string id, string soluong)
        {
            var gioHang = (Cart)Session["GioHangTam"];
            var sp = client.LayDS(id);
            foreach (QL_SR.THUOC t in sp)
            {
                if (t.TenThuoc.Length > 30)
                {
                    t.TenThuoc = t.TenThuoc.Substring(0, 25) + "...";
                }
                if (gioHang != null)
                {
                    gioHang.themSP(t, Convert.ToInt32(soluong));
                    Session["GioHangTam"] = gioHang;
                }
                else
                {
                    gioHang = new Cart();
                    gioHang.themSP(t, Convert.ToInt32(soluong));
                    Session["GioHangTam"] = gioHang;
                }
                var item = client.ThongTinGH("", t.MaThuoc);
                if (item.Count() == 0)
                {
                    if (Request.Cookies["login"] != null)
                    {
                        string str = Request.Cookies["login"].Value;
                        var user = client.ThongTinKH(str);
                        foreach (QL_SR.KHACHHANG k in user)
                        {
                            client.ThemSP(t.MaThuoc, k.MaKhachHang, Convert.ToInt32(soluong));
                        }
                    }                    
                }
                else
                {
                    if (Request.Cookies["login"] != null)
                    {
                        string str = Request.Cookies["login"].Value;
                        var user = client.ThongTinKH(str);
                        foreach (QL_SR.KHACHHANG k in user)
                        {
                            var itemcart = client.ThongTinGH(k.MaKhachHang, t.MaThuoc);
                            foreach (QL_SR.GIOHANG i in itemcart)
                            {
                                i.SoLuong = i.SoLuong + Convert.ToInt32(soluong);
                            }
                        }                                                
                    }
                    else
                    {
                        string str = Request.Cookies["login"].Value;
                        var user = client.ThongTinKH(str);
                        foreach (QL_SR.KHACHHANG k in user)
                        {
                            var itemcart = client.ThongTinGH(k.MaKhachHang, t.MaThuoc);
                            foreach (QL_SR.GIOHANG i in itemcart)
                            {
                                i.SoLuong = i.SoLuong + Convert.ToInt32(soluong);
                            }
                        }
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult CapNhatGH(string[] masp, int[] sl, string coupon)
        {
            var gioHang = (Cart)Session["GioHangTam"];
            gioHang.coupon = coupon;
            if (gioHang != null)
            {
                for (int i = 0; i < masp.Count(); i++)
                {
                    var sp = client.LayDS(masp[1]);
                    foreach (QL_SR.THUOC t in sp)
                    {
                        gioHang.capnhatSP(t, sl[i]);
                        if (Request.Cookies["login"] != null)
                        {
                            string str = Request.Cookies["login"].Value;
                            var user = client.ThongTinKH(str);
                            foreach (QL_SR.KHACHHANG k in user)
                            {
                                var itemcart = client.ThongTinGH(k.MaKhachHang, t.MaThuoc);
                                foreach (QL_SR.GIOHANG it in itemcart)
                                {
                                    it.SoLuong = sl[i];
                                }
                            }
                        }
                        else
                        {
                            var itemcart = client.ThongTinGH("", t.MaThuoc);
                            foreach (QL_SR.GIOHANG it in itemcart)
                            {
                                it.SoLuong = sl[i];
                            }
                        }
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
        //
        //Xóa Sản phẩm
        public ActionResult XoaSP(string id)
        {
            var sp = client.LayDS(id);
            var gioHang = (Cart)Session["GioHangTam"];
            if (gioHang != null)
            {
                foreach (QL_SR.THUOC t in sp)
                {
                    gioHang.XoaSP(t);
                    client.XoaSP("", t.MaThuoc);                    
                }                
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
        //
        //
        [HttpPost]
        public ActionResult ThanhToan(string ho, string ten, string diachiduong, string sonha, string email, string sdt, string ghichu, string makhuyenmai, string giaohang)
        {
            Random rd = new Random();
            int maHD = rd.Next(1, 99999);
            client.ThemHoaDon(maHD, ho, ten, diachiduong, sonha, email, sdt, ghichu, makhuyenmai, giaohang);
            db.SaveChanges();
            var gioHang = (Cart)Session["GioHangTam"];
            foreach (var item in gioHang.dongSP)
            {
                client.ThemCCHoaDon(maHD, item.SanPham.MaThuoc, item.SanPham.DonGia, item.SoLuong);
                if (Request.Cookies["login"] != null)
                {
                    string str = Request.Cookies["login"].Value;
                    var user = client.ThongTinKH(str);
                    foreach (QL_SR.KHACHHANG k in user)
                    {
                        client.XoaSP(k.MaKhachHang, item.SanPham.MaThuoc);
                    }
                }
                else
                {
                    client.XoaSP("", item.SanPham.MaThuoc);
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
            int i = client.Register(kh.Email,kh.MatKhau,kh.TenKhachHang,kh.MaKhachHang);
            if (i == 1)
            {
                return View("Login");
            }
            else
            {
                return View("Register");
            }
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
            var user = client.Login(email, MaHoaMD5(password));
            if (user.Count() != 0)
            {
                foreach (QL_SR.KHACHHANG us in user)
                {
                    var userSession = new UserLogin();
                    userSession.userID = us.Email;
                    userSession.userName = us.TenKhachHang;
                    Session.Add(Common.CommonConstants.USER_SESSION, userSession);
                    if (duytri != null)
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
            var model = client.LayDS(id);
            return View(model);
        }

        public ActionResult Shop(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var item = client.LayDS("");
            foreach (QL_SR.THUOC it in item)
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