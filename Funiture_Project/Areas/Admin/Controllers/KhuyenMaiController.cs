using Microsoft.AspNetCore.Mvc;

namespace Funiture_Project.Areas.Admin.Controllers
{
    public class KhuyenMaiController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult ThemKM()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult SuaKM()
        {
            return View();
        }
    }
}
