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
        Service.DeskService deskService = new Service.DeskService();
        public ActionResult Index()
        {
            return View("DeskIndex");
        }

        /// <summary>
        /// 取得所有桌子資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllDesk()
        {
            return Json(deskService.getAllDesk(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int GetFitDesk(int peopleNum)
        {
            return deskService.getFitDesk(peopleNum);
        }
    }
}