using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
            string sql =@"select Phone from OrderForm O 
                                    join Customer C on O.Customer_ID = C.Customer_ID 
                                    where Phone = {0}";
            return DB.ExecuteQuery<string>(sql, Phone).Any();
        }
        /// <summary>
        /// 點餐
        /// </summary>
        /// <returns></returns>
        public string OrderFood(int DeskNo, List<FoodListMoel> FOOD_LIST)
        {
            try
            {
                string sql = "Insert into OrderDetail(FoodAmt,Food_ID,OrderForm_ID) Values ({0},{1},{2})";
                FOOD_LIST.ForEach(item => DB.ExecuteCommand(sql, new object[] { item.FOOD_AMT, item.FOOD_ID, DeskNo }));
                return "點餐成功";
            }
            catch
            {
                return "點餐失敗";
            }
        }
    }
}