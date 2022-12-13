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
        
        public IActionResult Index()
        {
            int makh = int.Parse(HttpContext.Session.GetString("MaKH"));
            KhachHang khachhang = _context.KhachHang.AsNoTracking()
                    .Where(x => x.MaKh == makh)
                    .FirstOrDefault();
            List<SanPham> lsSanPham = new List<SanPham>();
            var giohang = _context.GioHang.AsNoTracking()
                .Where(x => x.MaKh == makh)
                .ToList();

            double tong = 0;

            foreach (var item in giohang)
            {
                var sanpham = _context.SanPham.AsNoTracking()
                    .Where(x => x.MaSp == item.MaSp)
                    .FirstOrDefault();
                if (item.SoLuong <= sanpham.TongSl)
                {
                    sanpham.TongSl = item.SoLuong;
                    lsSanPham.Add(sanpham);
                    tong += sanpham.Gia * sanpham.TongSl;
                }
                else
                {
                    sanpham.TongSl = 0;
                }
            }
            if (lsSanPham.Count == 0)
            {
                _notyfService.Error("Đơn hàng rỗng");
                return RedirectToAction("Index", "CartInfo");
            }
            ViewBag.lsSanPham = lsSanPham;
            ViewBag.KhachHang = khachhang;
            ViewBag.TongThanhTien = tong;
            return View();
        }

        //public IActionResult InsertHoaDon()
        //{
        //    int makh = int.Parse(HttpContext.Session.GetString("MaKH"));
        //    var khachhang = _context.KhachHang.AsNoTracking()
        //            .Where(x => x.MaKh == makh)
        //            .FirstOrDefault();
        //    var giohang = _context.GioHang.AsNoTracking()
        //        .Where(x => x.MaKh == makh);
        //    if (giohang != null)
        //    {
        //        //public int MaHd { get; set; }
        //        //public string Ttdh { get; set; }
        //        //public string Tttt { get; set; }
        //        //public int MaKh { get; set; }
        //        //public int MaNv { get; set; }
        //        //public DateTime NgayHd { get; set; }
        //        //public DateTime NgayGh { get; set; }
        //        //public string Sdt { get; set; }
        //        //public string DiaChi { get; set; }
        //        //public string ThanhPho { get; set; }
        //        //public int? MaKm { get; set; }
        //        //public double TriGia { get; set; }
        //        //DateTime today = DateTime.Today();
        //        var new_hoadon = new HoaDon
        //        {
        //            MaKh = makh,
        //            Ttdh = "Đang giao",
        //            Tttt = "Chưa thanh toán",
        //            DiaChi = khachhang.DiaChi,
        //            NgayHd = DateTime.Now,
        //            NgayGh = DateTime.Now,
        //            ThanhPho = khachhang.ThanhPho
        //        };
        //        _context.HoaDon.Add(new_hoadon);
        //        _context.SaveChanges();

        //        var mahd = _context.HoaDon.AsNoTracking()
        //            .OrderByDescending(x => x.MaHd)
        //            .Select(x => x.MaHd)
        //            .FirstOrDefault();
        //        double thanhtien = 0;
        //        foreach (var item in giohang)
        //        {
        //            var sanpham = _context.SanPham.AsNoTracking()
        //                .Where(x => x.MaSp == item.MaSp)
        //                .FirstOrDefault();
        //            var new_cthd = new Cthd
        //            {
        //                MaHd = mahd,
        //                MaSp = item.MaSp,
        //                SoLuong = item.SoLuong,
        //                DonGia = sanpham.Gia
        //            };
        //            thanhtien += new_cthd.DonGia * new_cthd.SoLuong;

        //            _context.Cthd.Add(new_cthd);
        //            var gh = _context.GioHang.AsNoTracking()
        //                .Where(x => x.MaSp == item.MaSp && x.MaKh == makh);
        //            _context.GioHang.Remove(item);
        //        }
        //        new_hoadon.TriGia = thanhtien;
        //        _context.HoaDon.Update(new_hoadon);
        //        _context.SaveChanges();
        //        _notyfService.Success("Đặt hàng thành công");
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View();
        //}
        [Route("/Payment/InsertHoaDon")]
        public IActionResult InsertHoaDon()
        {
            int makh = int.Parse(HttpContext.Session.GetString("MaKH"));
            var khachhang = _context.KhachHang.AsNoTracking()
                    .Where(x => x.MaKh == makh)
                    .FirstOrDefault();
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
                Sdt = khachhang.Sdt,
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
            var giohang = _context.GioHang.AsNoTracking()
                .Where(x => x.MaKh == makh).ToList();
            foreach (var item in giohang)
            {
                var sanpham = _context.SanPham.AsNoTracking()
                    .Where(x => x.MaSp == item.MaSp)
                    .FirstOrDefault();
                if (sanpham.TongSl > item.SoLuong)
                {
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

                    sanpham.TongSl -= item.SoLuong;
                    _context.SanPham.Update(sanpham);

                    _context.GioHang.Remove(item);
                }

            }
            new_hoadon.TriGia = thanhtien;
            _context.HoaDon.Update(new_hoadon);
            _context.SaveChanges();
            _notyfService.Success("Đặt hàng thành công");
            return RedirectToAction("Index", "Home");

        }

    }
}
