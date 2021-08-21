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
        public string OrderFood(int DeskNo, List<FoodListMoel> FOOD_LIST)
        {
            return orderDac.OrderFood(DeskNo, FOOD_LIST);
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
    }
}