using ChatBot.Models;
using Newtonsoft.Json;
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

        public ActionResult Index()
        {
            var result = orderService.GetOrderForm().ToList();
            ViewBag.orderListCurrent = result.Where(x => x.OrderStatus != "預約").ToList();
            ViewBag.orderListReserve = result.Where(x => x.OrderStatus == "預約").ToList();
            return View("OrderIndex");
        }

        /// <summary>
        /// 取得所有餐點資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getAllFood()
        {
            return Json(orderService.getAllFood(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 輸入電話號碼報到
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool CompareWithPhone(string Phone)
        {
            return orderService.CompareWithPhone(Phone);
        }

        /// <summary>
        /// 點餐
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string OrderFood(OrderModel model)
        {
            return orderService.OrderFood(model.OrderFormID, model.FOOD_LIST);
		}


		public JsonResult getOrderDetail(int OrderFormID)
        {
            return Json(orderService.GetOrderDetail(OrderFormID).ToList());
        }

        /// <summary>
        /// 結帳
        /// </summary>
        /// <returns></returns>
        public string Checkout(int OrderFormID)
        {
            return orderService.Checkout(OrderFormID);
        }

        /// <summary>
        /// 填寫回饋表單
        /// </summary>
        /// <returns></returns>
        public string FillFeedBack(int OrderFormID, int ServiceSatisfaction, int FoodSatisfaction, int HealthSatisfaction, string Suggest)
        {
            return orderService.FillFeedBack(OrderFormID, ServiceSatisfaction, FoodSatisfaction, HealthSatisfaction, Suggest);
        }

    }
}