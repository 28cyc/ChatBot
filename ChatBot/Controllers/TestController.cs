using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatBot.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Hello(string name)
        {
            return Json(new ApiResult<string>($"hello {name}"));
        }

        [HttpPost]
        public string Hi(string name)
        {
            return $"hello {name}";
        }
    }
}