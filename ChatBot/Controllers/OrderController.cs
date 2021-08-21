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

        public ActionResult Index()
        {
            List<OrderFormModel> orders = new List<OrderFormModel>();
            orders.Add(new OrderFormModel()
            {
                OrderForm_ID = 1,
                DeskNo = 3,
                PeopleNum = 5,
                OrderStatus = "未出餐",
                Memo = "要一個兒童椅",
                EatingTime = DateTime.Now
            });
            orders.Add(new OrderFormModel()
            {
                OrderForm_ID = 2,
                DeskNo = 4,
                PeopleNum = 4,
                OrderStatus = "已出餐",
                Memo = "無",
                EatingTime = DateTime.Now
            });

            ViewBag.oederList = orders;
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
            return orderService.OrderFood(model.DESK_NO, model.FOOD_LIST);
		}


		public JsonResult getOrderDetail(int OrderFormID)
        {

            List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();
            orderDetails.Add(new OrderDetailModel()
            {
                OrderForm_ID = 1,
                Food_Name = "豬排飯",
                Food_Price = 1180,
                Food_AMT = 2,
                Food_ID = 3
            });
            orderDetails.Add(new OrderDetailModel()
            {
                OrderForm_ID = 2,
                Food_Name = "玉米濃湯",
                Food_Price = 45,
                Food_AMT = 1,
                Food_ID = 4
            });
            return Json(orderDetails);
        }
    }
}