using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using Funiture_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

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

        [HttpGet]
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpGet]
        [Route("SignUp", Name = "DangKy")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("SignUp", Name = "DangKy")]
        public IActionResult SignUp(RegisterVM taikhoan)
        {
            if (ModelState.IsValid)
            {
                if (taikhoan.Password == taikhoan.ConfirmPassword)
                {
                    taikhoan.Email = taikhoan.Email.Trim();
                    taikhoan.SDT = taikhoan.SDT.Trim();
                    var check = context.KhachHang.FirstOrDefault(s => s.Email == taikhoan.Email.Trim());
                    var check1 = context.KhachHang.FirstOrDefault(s => s.Sdt == taikhoan.SDT.Trim());
                    if (check == null)
                    {
                        if (check1 == null)
                        {
                            KhachHang user = new KhachHang
                            {
                                HoTen = taikhoan.HoTen.ToUpper(),
                                Email = taikhoan.Email,
                                Sdt = taikhoan.SDT,
                                Password = taikhoan.Password,
                                NgayTao = System.DateTime.Now,
                                GioiTinh = taikhoan.GioiTinh,
                                DiaChi = taikhoan.DiaChi
                            };
                            context.KhachHang.Add(user);
                            context.SaveChanges();
                            notyfService.Success("Đăng ký thành công");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            notyfService.Error("Số điện thoại đã được sử dụng");
                            return RedirectToAction("SignUp");
                        }
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
            return RedirectToAction("SignUp");
        }
        //login method
        [HttpPost] //không hiện lên URL
        //[Route("Login.html",Name ="Login")]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            // connect to database
            // check user or admin
            var user = context.KhachHang.AsNoTracking()
                .FirstOrDefault(x => x.Email == loginViewModel.Email_Phone || x.Sdt == loginViewModel.Email_Phone);
            var admin = context.NhanVien.AsNoTracking()
                .FirstOrDefault(a => a.Email == loginViewModel.Email_Phone || a.Sdt == loginViewModel.Email_Phone);

            // 3 default claims
            List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, loginViewModel.Email_Phone)
                };
            Claim role_claim_admin = new Claim(ClaimTypes.Role, "Admin");
            Claim role_claim_user = new Claim(ClaimTypes.Role, "User");

            // if admin is logging in
            if (admin != null)
            {
                //wrong password
                if (admin.Password != loginViewModel.Password)
                {
                    notyfService.Error("Sai thông tin đăng nhập");
                    return View();
                }
                //Lưu Session MaNV
                HttpContext.Session.SetString("MaNV", admin.MaNv.ToString());

                //true pass word: add role, sigin
                claims.Add(role_claim_admin);
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                       CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                notyfService.Success("Đăng nhập thành công");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // if user is logging in
                if (user != null)
                {
                    //wrong password
                    if (user.Password != loginViewModel.Password)
                    {
                        notyfService.Error("Sai thông tin đăng nhập");
                        return View();
                    }

                    //Lưu Session MakH
                    HttpContext.Session.SetString("MaKH", user.MaKh.ToString());
                    var taikhoanID = HttpContext.Session.GetString("MaKH");

                    //true password: add role, sign in
                    claims.Add(role_claim_user);
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                           CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    notyfService.Success("Đăng nhập thành công");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // wrong email or sdt => out
                    notyfService.Error("Sai thông tin đăng nhập");
                    return View();
                }
            }
        }
        [HttpGet]
        [Route("Logout.html", Name = "Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("MaKH");
            HttpContext.SignOutAsync();
            notyfService.Success("Đăng xuất thành công");
            return RedirectToAction("Index", "Home");
        }
    }

}
