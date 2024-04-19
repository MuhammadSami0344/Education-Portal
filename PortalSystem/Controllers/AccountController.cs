using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PortalSystem.View_Models;
using System.Security.Claims;
using PortalSystem.Services;

namespace PortalSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersAccountServices _usersAccountServices;
        private static readonly AuthenticationProperties COOKIE_SESSION = new AuthenticationProperties();
        public AccountController(IUsersAccountServices usersAccountServices)
        {
            _usersAccountServices = usersAccountServices;
        }
        private static readonly AuthenticationProperties COOKIE_EXPIRES = new AuthenticationProperties()
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            IsPersistent = true,
        };
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVm loginUserVm)
        {
            var user = await _usersAccountServices.UserLogin(loginUserVm);

            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.UserRole),
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = COOKIE_EXPIRES;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(claimsIdentity),
                                              authProperties);

                return Redirect("/");
            }
            else
            {
                return Redirect("/Account/Identity/Login/0");
            }
        }
    
        public async Task<ActionResult> SignOutPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Identity/Login");
        }
    }
}
