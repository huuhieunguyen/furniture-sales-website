using Microsoft.AspNetCore.Mvc;
using Funiture_Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


/* Mô hình Authentication
 * ClaimsPrincipal chứa tất cả thông tin cần thiết cho việc chứng thực của người dùng
 * 1 user cần 1 ClaimsPrincipal là đủ
 * ClaimsPrincipal chứ một hoặc nhiều ClaimsIdentity (ID)
 * ClaimsIdentity là cách để nhận dạng user (giống như CCCD, GPLX, thẻ SV, ...)
 * 1 ClaimsIdentity có thể có 1 hoặc nhiều Claim
 * 1 Claim chứa 1 giá trị để xác thực
 */

namespace Funiture_Project.Controllers
{
    public class LoginController : Controller
    {
        private FurnitureContext context;
        public LoginController(FurnitureContext context)
        {
            this.context = context;
        }      

        [HttpGet]
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        //login method
        [HttpPost] //không hiện lên URL
        //[Route("Login.html",Name ="Login")]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            // connect to database
            // check user or admin
            var user = context.Users.AsNoTracking()
                .FirstOrDefault (x => x.Email == loginViewModel.Email_Phone || x.Sdt == loginViewModel.Email_Phone);
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
                if (admin.Password != loginViewModel.Password )
                    return View();

                //true pass word: add role, sigin
                claims.Add(role_claim_admin);
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                       CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            else
                // if user is logging in
                if (user != null )
                {
                    //wrong password
                    if (user.Password != loginViewModel.Password)
                        return View();

                    //true password: add role, sign in
                    claims.Add(role_claim_user);
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                           CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("Index", "Home");
                }   
            else
                // wrong email or sdt => out
                return View();
        }

        [HttpGet]
        [Route("Logout.html", Name = "Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

