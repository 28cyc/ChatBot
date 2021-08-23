using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Service
{
	public class OrderService
	{
		Dac.OrderDac orderDac = new Dac.OrderDac();

		/// <summary>
		/// 取得所有餐點資料
		/// </summary>
		/// <returns></returns>
		public IEnumerable<FoodModel> getAllFood()
		{
			return orderDac.getAllFood();
		}

        /// <summary>
        /// 輸入電話號碼報到
        /// </summary>
        /// <returns></returns>
        public bool CompareWithPhone(string Phone)
        {
            return orderDac.CompareWithPhone(Phone);
        }

        /// <summary>
        /// 點餐
        /// </summary>
        /// <returns></returns>
        public string OrderFood(int OrderFormID, List<FoodListMoel> FOOD_LIST)
        {
            return orderDac.OrderFood(OrderFormID, FOOD_LIST);
        }

        /// <summary>
        /// 取得目前所有訂單資訊
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderFormModel> GetOrderForm()
        {
            return orderDac.GetOrderForm();
        }

        /// <summary>
        /// 依照訂單編號取得訂單餐點內容
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderDetailModel> GetOrderDetail(int OrderFormID)
        {
            return orderDac.GetOrderDetail(OrderFormID);
        }

        /// <summary>
        /// 結帳
        /// </summary>
        /// <returns></returns>
        public string Checkout(int OrderFormID)
        {
            return orderDac.Checkout(OrderFormID);
        }

        /// <summary>
        /// 回傳預計取餐時間
        /// </summary>
        /// <returns></returns>
        public DateTime TakeFoodTime(int OrderFormID)
        {
            return orderDac.TakeFoodTime(OrderFormID);
        }

        /// <summary>
        /// 填寫回饋表單
        /// </summary>
        /// <returns></returns>
        public string FillFeedBack(int OrderFormID, int ServiceSatisfaction, int FoodSatisfaction, int HealthSatisfaction, string Suggest)
        {
            DateTime DateTimeNow = DateTime.Now;
            return orderDac.FillFeedBack(OrderFormID, DateTimeNow, ServiceSatisfaction, FoodSatisfaction, HealthSatisfaction, Suggest);
        }

        /// <summary>
        /// 完成出餐
        /// </summary>
        /// <param name="OrderFormID"></param>
        /// <returns></returns>
        public string foodDeliver(int OrderFormID)
        {
            return orderDac.foodDeliver(OrderFormID);
        }
    }
}