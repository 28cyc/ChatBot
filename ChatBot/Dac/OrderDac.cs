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
        public string OrderFood(int OrderFormID, List<FoodListMoel> FOOD_LIST)
        {
            //新增訂單細節
            string sql = "";
            bool flag = false;
            try
            {
                sql = "Insert into OrderDetail(FoodAmt,Food_ID,OrderForm_ID) Values ({0},{1},{2})";
                FOOD_LIST.ForEach(item => DB.ExecuteCommand(sql, new object[] { item.FOOD_AMT, item.FOOD_ID, OrderFormID }));
                flag = true;
            }
            catch
            {
                
            }
            if (flag == true)
            {
                //更新桌子、訂單狀態
                int DeskNo = DB.ExecuteCommand("select DeskNo from OrderForm where OrderForm_ID = {0}", OrderFormID);
                sql = @"Update Desk set DeskStatus = '用餐中' where DeskNo = {0}
                        Update OrderForm set OrderStatus = '用餐中' where OrderForm_ID = {1} ";
                DB.ExecuteCommand(sql, DeskNo, OrderFormID);

                return "點餐成功";
            }
            else
            {
                return "點餐失敗";
            }
        }

        /// <summary>
        /// 取得目前所有訂單資訊
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderFormModel> GetOrderForm()
        {
            return DB.ExecuteQuery<OrderFormModel>("SELECT * FROM OrderForm");
        }

        /// <summary>
        /// 依照訂單編號取得訂單餐點內容
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderDetailModel> GetOrderDetail(int OrderFormID)
        {
            string sql = @"SELECT OrderDetail.Food_ID AS Food_ID, 
                                  FoodAmt AS Food_AMT, 
                                  OrderForm_ID AS OrderForm_ID, 
                                  FoodName AS Food_Name, 
                                  FoodPrice AS Food_Price
                           FROM OrderDetail JOIN Food 
                           ON OrderDetail.Food_ID=Food.Food_ID
                           WHERE OrderForm_ID = {0} ";
            return DB.ExecuteQuery<OrderDetailModel>(sql, OrderFormID);
        }

        /// <summary>
        /// 結帳
        /// </summary>
        /// <returns></returns>
        public string Checkout(int OrderFormID)
        {
            bool flag = false;
            try
            {
                //更新桌子、訂單狀態
                int DeskNo = DB.ExecuteCommand("select DeskNo from OrderForm where OrderForm_ID = {0}", OrderFormID);
                string sql = @"Update Desk set DeskStatus = '訂單完成' where DeskNo = {0}
                        Update OrderForm set OrderStatus = '空桌' where OrderForm_ID = {1} ";
                DB.ExecuteCommand(sql, DeskNo, OrderFormID);
                flag = true;
            }
            catch
            {

            }
            return (flag == true) ? "結帳成功" : "結帳失敗";
        }
    }
}