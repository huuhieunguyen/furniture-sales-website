using Funiture_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Funiture_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly FurnitureContext _context;
        public HomeController(FurnitureContext context)
        {
            _context = context;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var sanpham = _context.SanPham.AsNoTracking()
                .OrderBy(x => x.TongSl)
                .Take(10)
                .ToList();

            var lsdanhmuc = _context.DanhMucSp.AsNoTracking().ToList();
            List<string> lsanhDM = new List<string>();
            foreach (var d in lsdanhmuc)
            {
                var hinhanh = _context.SanPham.AsNoTracking()
                    .Where(x => x.MaDm == d.MaDm)
                    .Select(x => x.HinhAnh)
                    .FirstOrDefault();
                lsanhDM.Add(hinhanh);
            }
            ViewBag.DanhMucSP = lsdanhmuc;
            ViewBag.AnhDanhMuc = lsanhDM;
            return View(sanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
