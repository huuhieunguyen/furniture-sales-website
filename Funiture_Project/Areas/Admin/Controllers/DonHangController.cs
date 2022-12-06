using Microsoft.AspNetCore.Mvc;

namespace Funiture_Project.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        [Area("Admin")]
        public IActionResult DangCho()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult DangGiao()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult DaGiao()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult BiHuy()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult TatCa()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult DangCho_Update()
        {
            return View();
        }
    }
}
