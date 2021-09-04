using Login.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Check(UserModel model)
        {
            var res = contextDB.user.FirstOrDefault(a => (a.Passwork == model.Passwork) && (a.UserName == model.UserName));
            if (res != null)
            {
                // создаем один claim
                var claims = new List<Claim>
                 {
                     new Claim(ClaimsIdentity.DefaultNameClaimType, model.UserName)
                 };
                // создаем объект ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                // установка аутентификационных куки
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                return Redirect("/");
            }
            ViewBag.Message = "Пароль чи логін не вірні";
            return View("Index");
        }
        ContextDB contextDB;
        public LoginController(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }
    }
}
