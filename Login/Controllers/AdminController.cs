using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var res = context.message.Take(30);
            return View(res);
        }
        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if(id == null) return View("Index",context.message.Take(30));
            var res =  context.message.FirstOrDefault(a => a.Id == id.Value);
            if(res == null) return View("Index",context.message.Take(30));
            context.message.Remove(res);
            context.SaveChanges();
            return View("Index", context.message.Take(30));
        }
        ContextDB context;
        public AdminController(ContextDB context)
        {
            this.context = context;
        }
    }
}
