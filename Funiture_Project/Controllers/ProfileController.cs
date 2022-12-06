using Microsoft.AspNetCore.Mvc;

namespace Funiture_Project.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
