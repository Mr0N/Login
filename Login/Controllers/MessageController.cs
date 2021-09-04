using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    class Msg
    {
        public string Message
        {
            get
            {
                string temp = msg;
                msg = null;
                return temp;
            }
        }
        string msg;
        public Msg(string msg)
        {
            this.msg = msg;
        }
    }
    public class MessageController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Send(MessageFormModel msg)
        {
            this.context.message.Add(new MessageFormModel() { Message = msg.Message, Username = msg.Username });
            this.context.SaveChanges();

            ViewBag.Check = 1;
            return View("Index");
        }
        ContextDB context;
        public MessageController(ContextDB context)
        {
            this.context = context;
        }
    }
}
