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
	}
}