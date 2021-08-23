using ChatBot.Dac;
using ChatBot.Models;
using ChatBot.SignalR.Hubs;
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

        /// <summary>
        /// 內用回傳桌號、訂單編號
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetFitDesk(int peopleNum)
        {
            return Json(deskService.getFitDesk(peopleNum));
        }

        /// <summary>
        /// 預約回傳桌號、訂單編號
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object ReserveGetFitDesk(int peopleNum, string Name, int Phone, DateTime dateTime)
        {
            return deskService.ReserveGetFitDesk(peopleNum, Name, Phone, dateTime);
        }

        /// <summary>
        /// 預約報到根據輸入之電話號碼查詢桌號
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int getReserveDesk(string Phone)
        {
            return deskService.getReserveDesk(Phone);
        }

        /// <summary>
        /// 根據桌號呼叫服務or完成服務
        /// </summary>
        /// <param name="deskNo"></param>
        /// <returns></returns>
        [HttpPost]
        public string callServer(int deskNo, string calling)
        {
            if (calling == "Y")
            {
                new CallHub().Update(deskNo, connId: String.Empty);
            }
            return deskService.callServer(deskNo, calling);
        }

        
    }
}