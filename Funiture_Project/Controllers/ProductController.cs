using Funiture_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;


namespace Funiture_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly FurnitureContext _context;
        public ProductController(FurnitureContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 9;

                var lsdanhmuc = _context.DanhMucSp.AsNoTracking().ToList();

                //var lsSanPham = _context.SanPham
                //    .AsNoTracking()
                //    .OrderBy(x => x.MaSp);
                //PagedList<SanPham> models = new PagedList<SanPham>(lsSanPham, pageNumber, pageSize);
                var models = _context.SanPham.OrderBy(x => x.MaSp)
                    .Where(x => x.TongSl > 0)
                    .ToPagedList(pageNumber, pageSize);
                int count = _context.SanPham.Where(x => x.TongSl > 0).Count();
                ViewBag.SoLuongSP = count;
                ViewBag.lsDanhMuc = lsdanhmuc;
                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Route("/ProductDetail/{id}", Name = "ProductDetail")]
        public IActionResult ProductDetail(int id)
        {
            HttpContext.Session.SetString("Masp", id.ToString());
            //var sanpham = _context.SanPham.Include(x => x.MaSp).FirstOrDefault(x => x.MaSp == id);
            string masp = id.ToString();
            HttpContext.Session.SetString("Masp", masp);
            /* HttpContext.Session.SetString("Makh", "1");*/
            var sanpham = _context.SanPham.AsNoTracking()
                .Where(x => x.MaSp == id)
                .FirstOrDefault();

            if (sanpham != null)
            {
                SanPham sp = new SanPham();
                sp.MaSp = sanpham.MaSp;
                sp.TenSp = sanpham.TenSp;
                sp.Nsx = sanpham.Nsx;
                sp.ThuongHieu = sanpham.ThuongHieu;
                sp.Gia = sanpham.Gia;
                sp.TongSl = sanpham.TongSl;
                sp.HinhAnh = sanpham.HinhAnh;
                sp.MaDm = sanpham.MaDm;
                sp.ChiTiet = sanpham.ChiTiet;
                var tenDM = _context.DanhMucSp.AsNoTracking()
                    .Where(x => x.MaDm == sp.MaDm)
                    .Select(x => x.TenDm)
                    .FirstOrDefault();

                var r_sp = _context.SanPham.AsNoTracking()
                    .Where(x => x.MaDm == sp.MaDm);
                int count = r_sp.Count();
                int n = r_sp.Count();

                if (n > 4)
                    n = 4;

                List<SanPham> lsSanPham = new List<SanPham>();
                for (int i = 0; i < n; i++)
                {
                    int index = new Random().Next(count);
                    var randomSanPham = r_sp.Skip(index).FirstOrDefault();
                    int dem = 0;
                    for (int j = 0; j < lsSanPham.Count; j++)
                    {
                        if (lsSanPham[j].MaSp == randomSanPham.MaSp)
                        {
                            dem++;
                        }
                    }
                    if (dem == 0)
                    {
                        lsSanPham.Add(randomSanPham);
                    }
                    else
                    {
                        i--;
                    }
                }
                ViewBag.SanPham = lsSanPham;
                return View(sp);
            }
            return View("Index");
        }
        [Route("/Product/{madm}/{gia}", Name = "LocSanPham")]
        public IActionResult Index(int? page, string madm, int gia)
        {
            try
            {
                if (gia == 0)
                {
                    var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                    var pageSize = 9;
                    var models = _context.SanPham.OrderBy(x => x.MaSp)
                        .Where(x => x.MaDm == madm)
                        .ToPagedList(pageNumber, pageSize)
                        .Where(x => x.TongSl > 0);
                    int count = _context.SanPham.AsNoTracking()
                        .Where(x => x.MaDm == madm && x.TongSl > 0)
                        .Count();
                    var lsdanhmuc = _context.DanhMucSp.AsNoTracking().ToList();
                    ViewBag.SoLuongSP = count;
                    ViewBag.lsDanhMuc = lsdanhmuc;
                    ViewBag.CurrentPage = pageNumber;
                    return View(models);
                }
                if (gia == 1)
                {
                    var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                    var pageSize = 9;
                    var models = _context.SanPham.OrderBy(x => x.MaSp)
                        .Where(x => x.Gia < 10000000 && x.TongSl > 0)
                        .ToPagedList(pageNumber, pageSize);
                    int count = _context.SanPham.AsNoTracking()
                        .Where(x => x.Gia < 10000000 && x.TongSl > 0)
                        .Count();
                    var lsdanhmuc = _context.DanhMucSp.AsNoTracking().ToList();
                    ViewBag.SoLuongSP = count;
                    ViewBag.lsDanhMuc = lsdanhmuc;
                    ViewBag.CurrentPage = pageNumber;
                    return View(models);
                }
                if (gia == 2)
                {
                    var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                    var pageSize = 9;
                    var models = _context.SanPham.OrderBy(x => x.MaSp)
                        .Where(x => x.Gia >= 10000000 && x.Gia <= 15000000 && x.TongSl > 0)
                        .ToPagedList(pageNumber, pageSize);
                    int count = _context.SanPham.AsNoTracking()
                        .Where(x => x.Gia >= 10000000 && x.Gia <= 15000000 && x.TongSl > 0)
                        .Count();
                    var lsdanhmuc = _context.DanhMucSp.AsNoTracking().ToList();
                    ViewBag.SoLuongSP = count;
                    ViewBag.lsDanhMuc = lsdanhmuc;
                    ViewBag.CurrentPage = pageNumber;
                    return View(models);
                }
                else
                {
                    var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                    var pageSize = 9;
                    var models = _context.SanPham.OrderBy(x => x.MaSp)
                        .Where(x => x.Gia > 15000000 && x.TongSl > 0)
                        .ToPagedList(pageNumber, pageSize);
                    int count = _context.SanPham.AsNoTracking()
                        .Where(x => x.Gia > 15000000 && x.TongSl > 0)
                        .Count();
                    var lsdanhmuc = _context.DanhMucSp.AsNoTracking().ToList();
                    ViewBag.SoLuongSP = count;
                    ViewBag.lsDanhMuc = lsdanhmuc;
                    ViewBag.CurrentPage = pageNumber;
                    return View(models);
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Index(int? page, string searchkey)
        {
            string key = searchkey;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 9;
            var models = _context.SanPham.OrderBy(x => x.MaSp)
                .Where(x => x.TenSp.Contains(searchkey) && x.TongSl > 0)
                .ToPagedList(pageNumber, pageSize);
            int count = _context.SanPham.AsNoTracking()
                .Where(x => x.TenSp.Contains(searchkey) && x.TongSl > 0)
                .Count();
            var lsdanhmuc = _context.DanhMucSp.AsNoTracking().ToList();
            ViewBag.SoLuongSP = count;
            ViewBag.lsDanhMuc = lsdanhmuc;
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

    }
}
