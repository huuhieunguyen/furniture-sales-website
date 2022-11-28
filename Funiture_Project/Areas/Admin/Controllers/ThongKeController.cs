using Microsoft.AspNetCore.Mvc;

namespace Funiture_Project.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
