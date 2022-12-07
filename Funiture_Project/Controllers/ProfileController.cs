using AspNetCoreHero.ToastNotification.Abstractions;
using Funiture_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Funiture_Project.Controllers
{
    public class ProfileController : Controller
    {
        private FurnitureContext context;
        public INotyfService notyfService { get; }
        public ProfileController(FurnitureContext context, INotyfService notyfService)
        {
            this.context = context;
            this.notyfService = notyfService;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
