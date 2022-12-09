using AspNetCoreHero.ToastNotification.Abstractions;
using Funiture_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Funiture_Project.Controllers
{
    public class ProfileController : Controller
    {
        private FurnitureContext context;
        public INotyfService notyfService { get; }
        public ProfileController(FurnitureContext context, INotyfService notyfService)
        {
            this.context = context;
            this.notyfService = notyfService;
        }
        [Route("Profile", Name = "Dashboard")]
        public IActionResult Index()
        {
            var taikhoanID = HttpContext.Session.GetString("MaKH");
            if (taikhoanID != null)
            {
                var khachhang = context.KhachHang.AsNoTracking().SingleOrDefault(x => x.MaKh == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    //lấy các hóa đơn của khách hàng
                    var lsDonHang = context.HoaDon
                        .AsNoTracking().Where(x => x.MaKh == khachhang.MaKh)
                        .OrderByDescending(x => x.NgayHd).ToList();
                    ViewBag.DonHang = lsDonHang;

                    //lấy các sản phẩm của các hóa đơn
                    List<DSSanPham> lsSP = new List<DSSanPham>();
                    foreach (var itemDH in lsDonHang)
                    {
                        foreach (var itemCT in context.Cthd)
                        {
                            if (itemDH.MaHd == itemCT.MaHd)
                            {
                                foreach (var itemSP in context.SanPham)
                                {
                                    if (itemCT.MaSp == itemSP.MaSp)
                                        lsSP.Add(new DSSanPham(itemCT.MaHd, itemCT.MaSp, itemCT.SoLuong, itemCT.DonGia, itemSP.TenSp, itemSP.HinhAnh, itemSP.Nsx));
                                }
                            }
                        }
                    }
                    ViewBag.dsSanPham = lsSP;
                    var ds = context.NhanVien;
                    return View(khachhang);
                }
            }
            return RedirectToAction("Login");
        }

    }
}
