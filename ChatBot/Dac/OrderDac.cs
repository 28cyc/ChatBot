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
        /// <summary>
        /// 輸入電話號碼報到
        /// </summary>
        /// <returns></returns>
        public bool CompareWithPhone(string Phone)
        {
            string sql = "select Phone from OrderForm O join Customer C on O.Customer_ID = C.Customer_ID where Phone = {0}";
            return DB.ExecuteQuery<string>(sql, Phone).Any();
        }
    }}