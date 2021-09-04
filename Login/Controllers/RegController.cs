using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class RegController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Set(Models.UserModel user)
        {
            if (context.user.FirstOrDefault(a => a.Email == user.Email) != null)
            {
                ViewBag.Message = "Користувач з такою поштою вже зареєстрований";
                return View("Index");
            }
            if (context.user.FirstOrDefault(a=>a.UserName == user.UserName) != null)
            {
                ViewBag.Message = "Логін зайнятий";
                return View("Index");
            }
            context.user.Add(new UserModel()
            {
                Email = user.Email,
                Passwork = user.Passwork,
                UserName = user.UserName
            }) ;
            context.SaveChanges();
             return Redirect("/Login");
        }
        ContextDB context;
        public RegController(ContextDB contextDB)
        {
            this.context = contextDB;
        }
    }
}
