using ChatBot.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChatBot.Dac
{
    public class OrderDac : _Dac
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
            string sql = @"select Phone from OrderForm O 
                                    join Customer C on O.Customer_ID = C.Customer_ID 
                                    where Phone = {0}";
            return DB.ExecuteQuery<string>(sql, Phone).Any();
        }

        /// <summary>
        /// 外帶
        /// </summary>
        /// <returns></returns>
        public int Takeout(string Name, string Phone, DateTime dateTime)
        {
            //新增顧客資料
            DB.ExecuteCommand("Insert into Customer (Name,Phone) Values ({0},{1}) select SCOPE_IDENTITY()", Name, Phone);
            //建立訂單(根據取得之桌號與顧客編號建立訂單)
            int CustomerID = DB.ExecuteQuery<int>("SELECT Customer_ID from Customer order by Customer_ID desc").FirstOrDefault();
            DB.ExecuteCommand("Insert into OrderForm Values ({0},{1},{2},{3},{4},{5},{6})",
                    new object[] { 1, "Out", "外帶", dateTime, "", "", CustomerID });
            //取得訂單編號
            int OrderFormID = DB.ExecuteQuery<int>("select OrderForm_ID from OrderForm where Customer_ID = {0} ", CustomerID).FirstOrDefault();

            return OrderFormID;
        }

        /// <summary>
        /// 點餐
        /// </summary>
        /// <returns></returns>
        public string OrderFood(int OrderFormID, List<FoodListMoel> FOOD_LIST)
        {
            //新增訂單細節
            string sql = "";

            try
            {
                sql = "Insert into OrderDetail(FoodAmt,Food_ID,OrderForm_ID) Values ({0},{1},{2})";
                FOOD_LIST.ForEach(item => DB.ExecuteCommand(sql, new object[] { item.FOOD_AMT, item.FOOD_ID, OrderFormID }));
                //更新桌子、訂單狀態
                int DeskNo = DB.ExecuteQuery<int>("select DeskNo from OrderForm where OrderForm_ID = {0}", OrderFormID).FirstOrDefault();
                sql = @"Update Desk set DeskStatus = '用餐中' where DeskNo = {0}
                        Update OrderForm set OrderStatus = '未出餐' where OrderForm_ID = {1} ";
                DB.ExecuteCommand(sql, DeskNo, OrderFormID);

                return "點餐成功";
            }
            catch
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
            return DB.ExecuteQuery<OrderFormModel>("SELECT * FROM OrderForm WHERE OrderStatus!='訂單完成'");
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
								  FoodPrice AS Food_Unit_Price,
                                  FoodPrice*FoodAmt AS Food_Total_Price
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
            try
            {
                string Ostatus = DB.ExecuteQuery<string>("select OrderStatus from OrderForm where OrderForm_ID = {0}", OrderFormID).FirstOrDefault();
                if (Ostatus == "已出餐")
                {
                    //更新桌子、訂單狀態
                    int DeskNo = DB.ExecuteQuery<int>("select DeskNo from OrderForm where OrderForm_ID = {0}", OrderFormID).FirstOrDefault();
                    string sql = @"Update Desk set DeskStatus = '空桌' where DeskNo = {0}
                        Update OrderForm set OrderStatus = '訂單完成' where OrderForm_ID = {1} ";
                    DB.ExecuteCommand(sql, DeskNo, OrderFormID);
                    return "結帳成功";
                }
                else
                {
                    return "尚未出餐完成，請等出餐完畢再行結帳！";
                }
            }
            catch
            {
                return "結帳失敗";
            }
        }

        /// <summary>
        /// 外帶結帳
        /// </summary>
        /// <returns></returns>
        public string TakeOutCheckout(int OrderFormID)
        {
            try
            {
                string sql = @"Update OrderForm set OrderStatus = '未出餐' where OrderForm_ID = {0} ";
                DB.ExecuteCommand(sql, OrderFormID);
                return "結帳成功";
            }
            catch
            {
                return "結帳失敗";
            }

        }

        /// <summary>
        /// 回傳預計取餐時間
        /// </summary>
        /// <returns></returns>
        public DateTime TakeFoodTime(int OrderFormID)
        {
            DateTime time = DB.ExecuteQuery<DateTime>("select Eatingtime + '00:20:00' from OrderForm where OrderForm_ID = {0}", OrderFormID).FirstOrDefault();
            return time;
        }

        /// <summary>
        /// 填寫回饋表單
        /// </summary>
        /// <returns></returns>
        public string FillFeedBack(int OrderFormID, DateTime DateTimeNow, int ServiceSatisfaction, int FoodSatisfaction, int HealthSatisfaction, string Suggest)
        {
            string sql = "";
            try
            {
                sql = "Insert QA values({0},{1},{2},{3},{4},{5})";
                DB.ExecuteCommand(sql, new object[] { DateTimeNow, ServiceSatisfaction, FoodSatisfaction, HealthSatisfaction, Suggest, OrderFormID });
                return "填寫成功";
            }
            catch
            {
                return "填寫失敗";
            }
        }

        /// <summary>
        /// 完成出餐
        /// </summary>
        /// <param name="OrderFormID"></param>
        /// <returns></returns>
        public string foodDeliver(int OrderFormID)
        {
            try
            {
                string sql = "update orderform set orderstatus = '已出餐' where orderform_ID = {0} AND orderstatus = '未出餐'";
                DB.ExecuteCommand(sql, OrderFormID);
                return "出餐成功";
            }
            catch
            {
                return "出餐失敗";
            }
        }
    }
}