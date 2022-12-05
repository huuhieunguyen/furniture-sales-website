using Funiture_Project.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using Funiture_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Funiture_Project.Controllers
{
    public class LoginController : Controller
    {
        private FurnitureContext context;
        public INotyfService notyfService { get; } 
        public LoginController(FurnitureContext context, INotyfService notyfService)
        {
            this.context = context;
            this.notyfService = notyfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("SignUp", Name = "DangKy")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("SignUp", Name = "DangKy")]
        public IActionResult SignUp(RegisterVM taikhoan)
        {
            if (ModelState.IsValid)
            {
                if (taikhoan.HoTen != null && taikhoan.Email != null && taikhoan.SDT != null && taikhoan.Password != null && taikhoan.ConfirmPassword != null && taikhoan.GioiTinh != null)
                {
                    if (taikhoan.Password == taikhoan.ConfirmPassword)
                    {
                        taikhoan.Email = taikhoan.Email.Trim();
                        taikhoan.SDT = taikhoan.SDT.Trim();
                        var check = context.Users.FirstOrDefault(s => s.Email == taikhoan.Email.Trim());
                        if (check == null)
                        {
                            KhachHang user = new KhachHang
                            {
                                HoTen = taikhoan.HoTen.ToUpper(),
                                Email = taikhoan.Email,
                                Sdt = taikhoan.SDT,
                                Password = taikhoan.Password,
                                NgayTao = System.DateTime.Now,
                                GioiTinh = taikhoan.GioiTinh,
                            };
                            context.KhachHang.Add(user);
                            context.SaveChanges();
                            notyfService.Success("Đăng ký thành công");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            notyfService.Error("Email đã tồn tại");
                            return RedirectToAction("SignUp");
                        }
                    }
                    else
                    {
                        notyfService.Error("Mật khẩu không giống nhau");
                        return RedirectToAction("SignUp");
                    }
                }
                else
                {
                    notyfService.Warning("Vui lòng nhập đầy đủ thông tin");
                    return RedirectToAction("SignUp");
                }
            }
            notyfService.Warning("Vui lòng nhập đầy đủ thông tin");
            return RedirectToAction("SignUp");
        }
    }

}
