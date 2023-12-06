using Asm1_WebMVC_vinhttph19362.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asm1_WebMVC_vinhttph19362.Controllers
{
    public class LoginController : Controller
    {
        // Danh sách người dùng cứng (thay thế cho SQL)
        private static readonly List<Login> HardcodedUsers = new List<Login>
        {
            new Login { Email = "vinhttph19362@fpt.edu.vn", Password = "123456789" }
            // Thêm các người dùng khác nếu cần thiết
        };

        public IActionResult Login()
        {
            ClaimsPrincipal clamUser = HttpContext.User;
            if (clamUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login modelLogin)
        {
            // Kiểm tra xác thực người dùng cứng
            var user = HardcodedUsers.Find(u => u.Email == modelLogin.Email && u.Password == modelLogin.Password);

            if (user != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim("OtherProperties", "Example Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "User not found";
            return View();
        }
    }
}
