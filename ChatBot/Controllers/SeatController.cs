using ChatBot.Dac;
using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatBot.Controllers
{
    public class SeatController : Controller
    {
        Dac.SeatDac seatDac = new Dac.SeatDac();
        public ActionResult Index()
        {
            return View("SeatIndex");
        }

        public JsonResult a()
        {
            return Json(seatDac.a(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult b(int id)
        {
            return Json(seatDac.b(id));
        }
    }
}