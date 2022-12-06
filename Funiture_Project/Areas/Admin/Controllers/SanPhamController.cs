using Microsoft.AspNetCore.Mvc;

namespace Funiture_Project.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult ThemSP()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult SuaSP()
        {
            return View();
        }
    }
}
