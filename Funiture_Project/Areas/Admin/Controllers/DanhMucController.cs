using Microsoft.AspNetCore.Mvc;

namespace Funiture_Project.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult ThemDM()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult SuaDM()
        {
            return View();
        }
    }
}
