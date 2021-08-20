using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Dac
{
	public class OrderDac: _Dac
	{
		/// <summary>
		/// 取得所有餐點資料
		/// </summary>
		/// <returns></returns>
		public IEnumerable<FoodModel> getAllFood()
		{
			return DB.ExecuteQuery<FoodModel>("SELECT * FROM Food");
		}
    }
}