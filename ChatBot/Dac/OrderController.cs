using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatBot.Controllers
{

	public class OrderController : Controller
    {
		Service.OrderService orderService = new Service.OrderService();

		/// <summary>
		/// 取得所有餐點資料
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public JsonResult getAllFood()
		{
			return Json(orderService.getAllFood(), JsonRequestBehavior.AllowGet);
		}

	}
}