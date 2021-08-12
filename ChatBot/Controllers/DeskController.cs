using ChatBot.Dac;
using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatBot.Controllers
{
    public class DeskController : Controller
    {
        Dac.DeskDac deskDac = new Dac.DeskDac();
        public ActionResult Index()
        {
            return View("DeskIndex");
        }

        public JsonResult GetAllDesk()
        {
            return Json(deskDac.getAllDesk(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int GetFitDesk(int peopleNum)
        {
            return deskDac.getFitDesk(peopleNum);
        }
    }
}