using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Funiture_Project.Models;
using Funiture_Project.ModelViews;
using Funiture_Project.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace Funiture_Project.Controllers
{
    public class PaymentController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly FurnitureContext _context;
        public INotyfService _notyfService { get; }
        public PaymentController(FurnitureContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        //        public List<CartItem> GioHang
        //        {
        //            get
        //            {
        //                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
        //                if (gh == default(List<CartItem>))
        //                {
        //                    gh = new List<CartItem>();
        //                }
        //                return gh;
        //            }
        //        }
        //        [Route("Payment.html", Name = "Payment")]
        //        public IActionResult Index(string returnUrl = null)
        //        {
        //            //Lay gio hang ra de xu ly
        //            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
        //            var taikhoanID = HttpContext.Session.GetString("MaKH");
        //            MuaHangVM model = new MuaHangVM();
        //            if (taikhoanID != null)
        //            {
        //                var khachhang = _context.KhachHang.AsNoTracking().SingleOrDefault(x => x.MaKh == Convert.ToInt32(taikhoanID));
        //                model.CustomerId = khachhang.MaKh;
        //                model.FullName = khachhang.HoTen;
        //                model.Email = khachhang.Email;
        //                model.Phone = khachhang.Sdt;
        //                model.Address = khachhang.DiaChi;
        //            }
        //            /*ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");*/
        //            ViewBag.GioHang = cart;
        //            return View(model);
        //        }

        //        [HttpPost]
        //        [Route("payment.html", Name = "payment")]
        //        public IActionResult Index(MuaHangVM muaHang)
        //        {
        //            //Lay ra gio hang de xu ly
        //            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
        //            var taikhoanID = HttpContext.Session.GetString("MaKH");
        //            MuaHangVM model = new MuaHangVM();
        //            if (taikhoanID != null)
        //            {
        //                var khachhang = _context.KhachHang.AsNoTracking().SingleOrDefault(x => x.MaKh == Convert.ToInt32(taikhoanID));
        //                model.CustomerId = khachhang.MaKh;
        //                model.FullName = khachhang.HoTen;
        //                model.Email = khachhang.Email;
        //                model.Phone = khachhang.Sdt;
        //                model.Address = khachhang.DiaChi;

        //                khachhang.DiaChi = muaHang.Address;
        //                _context.Update(khachhang);
        //                _context.SaveChanges();
        //            }
        //            try
        //            {
        //                if (ModelState.IsValid)
        //                {
        //                    //Khoi tao don hang
        //                    HoaDon donhang = new HoaDon();
        //                    donhang.MaKh = model.CustomerId;
        //                    donhang.DiaChi = model.Address;
        //                    donhang.ThanhPho = model.TinhThanh;

        //                    donhang.NgayHd = DateTime.Now;
        //                    donhang.Ttdh = "Đang chờ"; //Don hang moi
        //                    donhang.Tttt = "Chưa thanh toán";//Don hang moi
        //                    donhang.TriGia = cart.Sum(x => x.TotalMoney);
        //                    _context.Add(donhang);
        //                    _context.SaveChanges();

        //                    //tao CTHD
        //                    foreach (var item in cart)
        //                    {
        //                        Cthd orderDetail = new Cthd();
        //                        orderDetail.MaHd = donhang.MaHd;
        //                        orderDetail.MaSp = item.sanPham.MaSp;
        //                        orderDetail.SoLuong = item.amount;
        //                        orderDetail.DonGia = item.TotalMoney;
        //                        _context.Add(orderDetail);
        //                    }
        //                    _context.SaveChanges();
        //                    //clear gio hang
        //                    HttpContext.Session.Remove("GioHang");
        //                    //Xuat thong bao
        //                    _notyfService.Success("Đơn hàng đặt thành công");
        //                    //cap nhat thong tin khach hang
        //                    return RedirectToAction("Index", "Product");
        //                }
        //            }
        //            catch
        //            {
        ///*                ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");*/
        //                ViewBag.GioHang = cart;
        //                return View(model);
        //            }
        ///*            ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");*/
        //            ViewBag.GioHang = cart;
        //            return View(model);
        //        }

        public IActionResult Index()
        {
            int makh = int.Parse(HttpContext.Session.GetString("MaKH"));
            KhachHang khachhang = _context.KhachHang.AsNoTracking()
                    .Where(x => x.MaKh == makh)
                    .FirstOrDefault();

            var giohang = _context.GioHang.AsNoTracking()
                .Where(x => x.MaKh == makh)
                .ToList();
            List<SanPham> lsSanPham = new List<SanPham>();
            double tong = 0;

            foreach (var item in giohang)
            {
                var sanpham = _context.SanPham.AsNoTracking()
                    .Where(x => x.MaSp == item.MaSp)
                    .FirstOrDefault();
                var tendanhmuc = _context.DanhMucSp.AsNoTracking()
                    .Where(x => x.MaDm == sanpham.MaDm)
                    .Select(x => x.TenDm)
                    .FirstOrDefault();
                sanpham.TongSl = item.SoLuong;
                sanpham.MaDm = tendanhmuc;
                lsSanPham.Add(sanpham);
                tong += sanpham.Gia * sanpham.TongSl;
            }

            ViewBag.lsSanPham = lsSanPham;
            ViewBag.KhachHang = khachhang;
            ViewBag.TongThanhTien = tong;
            return View();
        }
        [Route("/Payment/InsertHoaDon")]
        public IActionResult InsertHoaDon()
        {
            int makh = int.Parse(HttpContext.Session.GetString("MaKH"));
            var khachhang = _context.KhachHang.AsNoTracking()
                    .Where(x => x.MaKh == makh)
                    .FirstOrDefault();
            var giohang = _context.GioHang.AsNoTracking()
                .Where(x => x.MaKh == makh);
            if (giohang != null)
            {
                //public int MaHd { get; set; }
                //public string Ttdh { get; set; }
                //public string Tttt { get; set; }
                //public int MaKh { get; set; }
                //public int MaNv { get; set; }
                //public DateTime NgayHd { get; set; }
                //public DateTime NgayGh { get; set; }
                //public string Sdt { get; set; }
                //public string DiaChi { get; set; }
                //public string ThanhPho { get; set; }
                //public int? MaKm { get; set; }
                //public double TriGia { get; set; }
                //DateTime today = DateTime.Today();
                var new_hoadon = new HoaDon
                {
                    MaKh = makh,
                    Ttdh = "Đang giao",
                    Tttt = "Chưa thanh toán",
                    DiaChi = khachhang.DiaChi,
                    NgayHd = DateTime.Now,
                    NgayGh = DateTime.Now,
                    ThanhPho = khachhang.ThanhPho
                };
                _context.HoaDon.Add(new_hoadon);
                _context.SaveChanges();
                var mahd = _context.HoaDon.AsNoTracking()
                    .OrderByDescending(x => x.MaHd)
                    .Select(x => x.MaHd)
                    .FirstOrDefault();
                double thanhtien = 0;
                foreach (var item in giohang)
                {
                    var sanpham = _context.SanPham.AsNoTracking()
                        .Where(x => x.MaSp == item.MaSp)
                        .FirstOrDefault();
                    var new_cthd = new Cthd
                    {
                        MaHd = mahd,
                        MaSp = item.MaSp,
                        SoLuong = item.SoLuong,
                        DonGia = sanpham.Gia
                    };
                    thanhtien += new_cthd.DonGia * new_cthd.SoLuong;

                    _context.Cthd.Add(new_cthd);
                    var gh = _context.GioHang.AsNoTracking()
                        .Where(x => x.MaSp == item.MaSp && x.MaKh == makh);
                    _context.GioHang.Remove(item);
                }
                new_hoadon.TriGia = thanhtien;
                _context.HoaDon.Update(new_hoadon);
                _context.SaveChanges();
                _notyfService.Success("Đặt hàng thành công");
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        /*        [Route("Payment-Success.html", Name = "Success")]
                public IActionResult Success()
                {
                    try
                    {
                        var taikhoanID = HttpContext.Session.GetString("CustomerId");
                        if (string.IsNullOrEmpty(taikhoanID))
                        {
                            return RedirectToAction("Login", "Accounts", new { returnUrl = "/dat-hang-thanh-cong.html" });
                        }
                        var khachhang = _context.KhachHang.AsNoTracking().SingleOrDefault(x => x.MaKh == Convert.ToInt32(taikhoanID));
                        var donhang = _context.HoaDon
                            .Where(x => x.MaKh == Convert.ToInt32(taikhoanID))
                            .OrderByDescending(x => x.NgayHd)
                            .FirstOrDefault();
                        PaymentSuccessVM successVM = new PaymentSuccessVM();
                        successVM.FullName = khachhang.HoTen;
                        successVM.DonHangID = donhang.MaHd;
                        successVM.Phone = khachhang.Sdt;
                        successVM.Address = khachhang.DiaChi;
                        successVM.TinhThanh = donhang.ThanhPho;
                        return View(successVM);
                    }
                    catch
                    {
                        return View();
                    }
                }
                public string GetNameLocation(string locationName)
                {
                    try
                    {
                        var location = _context.KhachHang.AsNoTracking().SingleOrDefault(x => x.ThanhPho == locationName);
                        if (location != null)
                        {
                            return location.ThanhPho;
                        }
                    }
                    catch
                    {
                        return string.Empty;
                    }
                    return string.Empty;
                }

        */
    }
}
