using AspNetCoreHero.ToastNotification.Abstractions;
using Funiture_Project.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using Funiture_Project.Models;
using Funiture_Project.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(string returnUrl = null)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.KhachHang.AsNoTracking().SingleOrDefault(x => x.MaKh == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.MaKh;
                model.FullName = khachhang.HoTen;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sdt;
                model.Address = khachhang.DiaChi;
            }
            /*ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");*/
            ViewBag.GioHang = cart;
            return View(model);
        }

        [HttpPost]
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(MuaHangVM muaHang)
        {
            //Lay ra gio hang de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.KhachHang.AsNoTracking().SingleOrDefault(x => x.MaKh == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.MaKh;
                model.FullName = khachhang.HoTen;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sdt;
                model.Address = khachhang.DiaChi;

                khachhang.DiaChi = muaHang.Address;
                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //Khoi tao don hang
                    HoaDon donhang = new HoaDon();
                    donhang.MaKh = model.CustomerId;
                    donhang.DiaChi = model.Address;
                    donhang.ThanhPho = model.TinhThanh;

                    donhang.NgayHd = DateTime.Now;
                    donhang.TransactStatusId = 1;//Don hang moi
                    donhang.Deleted = false;
                    donhang.Paid = false;
                    donhang.Note = Utilities.StripHTML(model.Note);
                    donhang.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                    _context.Add(donhang);
                    _context.SaveChanges();
                    //tao danh sach don hang

                    foreach (var item in cart)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderId = donhang.OrderId;
                        orderDetail.ProductId = item.product.ProductId;
                        orderDetail.Amount = item.amount;
                        orderDetail.TotalMoney = donhang.TotalMoney;
                        orderDetail.Price = item.product.Price;
                        orderDetail.CreateDate = DateTime.Now;
                        _context.Add(orderDetail);
                    }
                    _context.SaveChanges();
                    //clear gio hang
                    HttpContext.Session.Remove("GioHang");
                    //Xuat thong bao
                    _notyfService.Success("Đơn hàng đặt thành công");
                    //cap nhat thong tin khach hang
                    return RedirectToAction("Success");


                }
            }
            catch
            {
/*                ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");*/
                ViewBag.GioHang = cart;
                return View(model);
            }
/*            ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");*/
            ViewBag.GioHang = cart;
            return View(model);
        }

        [Route("dat-hang-thanh-cong.html", Name = "Success")]
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
    }
}
