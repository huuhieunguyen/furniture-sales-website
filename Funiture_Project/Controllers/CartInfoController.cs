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

namespace Funiture_Project.Controllers
{
    public class CartInfoController : Controller
    {
        private readonly FurnitureContext _context;
        public INotyfService _notyfService { get; }
        public CartInfoController(FurnitureContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // Khởi tạo một Giỏ hàng
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

        // Thêm sản phẩm vào Giỏ hàng
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productID, int? amount)
        {
            List<CartItem> cart = GioHang;

            try
            {
                //Them san pham vao gio hang
                CartItem item = cart.SingleOrDefault(p => p.sanPham.MaSp == productID);
                if (item != null) // da co => cap nhat so luong
                {
                    item.amount = item.amount + amount.Value;
                    //luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                else
                {
                    SanPham sp = _context.SanPham.SingleOrDefault(p => p.MaSp == productID);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        sanPham = sp
                    };
                    cart.Add(item);//Them vao gio
                }

                //Luu lai Session vào Giỏ hàng
                HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                _notyfService.Success("Thêm sản phẩm thành công");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int productID, int? amount)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {
                if (cart != null)
                {
                    CartItem item = cart.SingleOrDefault(p => p.sanPham.MaSp == productID);
                    if (item != null && amount.HasValue) // da co -> cap nhat so luong
                    {
                        item.amount = amount.Value;
                    }
                    //Luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/remove")]
        public ActionResult Remove(int productID)
        {

            try
            {
                List<CartItem> gioHang = GioHang;
                CartItem item = gioHang.SingleOrDefault(p => p.sanPham.MaSp == productID);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                //luu lai session
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        public IActionResult Index()
        {
            //if(HttpContext.Session.GetString("MaKH") == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            int makh = int.Parse(HttpContext.Session.GetString("MaKH"));
            var r_sp = _context.SanPham.AsNoTracking();
            int count = r_sp.Count();

            var giohang = _context.GioHang.AsNoTracking()
                .Where(x => x.MaKh == makh)
                .ToList();
            List<SanPham> lsSanPham = new List<SanPham>();
            foreach (var item in giohang)
            {
                var sanpham = _context.SanPham.AsNoTracking()
                    .Where(x => x.MaSp == item.MaSp)
                    .FirstOrDefault();
                var tendanhmuc = _context.DanhMucSp.AsNoTracking()
                    .Where(x => x.MaDm == sanpham.MaDm)
                    .Select(x=>x.TenDm)
                    .FirstOrDefault();
                sanpham.TongSl = item.SoLuong;
                sanpham.MaDm = tendanhmuc;
                lsSanPham.Add(sanpham);
            }

            List<SanPham> lsSanPhamDeXuat = new List<SanPham>();
            for (int i = 0; i < 4; i++)
            {
                int index = new Random().Next(count);
                var randomSanPham = r_sp.Skip(index).FirstOrDefault();
                int dem = 0;
                for (int j = 0; j < lsSanPhamDeXuat.Count; j++)
                {
                    if (lsSanPhamDeXuat[j].MaSp == randomSanPham.MaSp)
                    {
                        dem++;
                    }
                }
                if (dem == 0)
                {
                    lsSanPhamDeXuat.Add(randomSanPham);
                }
                else
                {
                    i--;
                }
            }

            ViewBag.SanPham = lsSanPham;
            ViewBag.SanPhamDeXuat = lsSanPhamDeXuat;
            return View();
        }

    }
}
