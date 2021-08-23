using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;


namespace ChatBot.Dac
{
    public class DeskDac : _Dac
    {
        /// <summary>
        /// 取得所有桌子資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DeskModel> getAllDesk()
        {
            return DB.ExecuteQuery<DeskModel>("SELECT * FROM Desk"); ;
        }

        /// <summary>
        /// 內用回傳桌號、訂單編號
        /// </summary>
        /// <returns></returns>
        public object getFitDesk(int peopleNum, DateTime DateTimeNow)
        {
            int CustomerID = 0;

            //取得可入座桌號
            int DeskNo = DB.ExecuteQuery<int>(@"SELECT D.DeskNo
                                                FROM orderform as O , Desk as D
                                                WHERE D.Seat >= '5' AND EatingTime > EatingTime - '01:30:00' and EatingTime < EatingTime + '01:30:00' AND DeskStatus= '空桌'
                                                Order by Seat ", peopleNum).FirstOrDefault();
            if (DeskNo != 0)
            {
                //新增顧客資料(內用故無需輸入個資預設"內用顧客")
                DB.ExecuteCommand("Insert into Customer(Name) Values ('內用顧客') select SCOPE_IDENTITY()");
               
                //建立訂單(根據取得之桌號與顧客編號建立訂單)
                CustomerID = DB.ExecuteQuery<int>("SELECT Customer_ID from Customer order by Customer_ID desc").FirstOrDefault();
                DB.ExecuteCommand("Insert into OrderForm Values ({0},{1},{2},{3},{4},{5},{6})",
                    new object[] { peopleNum, "In", "未點餐", DateTimeNow, "", DeskNo, CustomerID });
                //更新桌子狀態
                DB.ExecuteCommand("Update Desk set DeskStatus = '已訂位' where DeskNo = {0}", DeskNo);
                
                //取得訂單編號
                int OrderFormID = DB.ExecuteQuery<int>("select OrderForm_ID from OrderForm where Customer_ID = {0} ", CustomerID).FirstOrDefault();

                //將桌號、訂單編號存入Json格式並回傳
                var DeskOrderNo = new { DeskNo = DeskNo, OrderFormID = OrderFormID };
                return DeskOrderNo;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 預約回傳桌號、訂單編號
        /// </summary>
        /// <returns></returns>
        public object ReserveGetFitDesk(int peopleNum,string Name, int Phone, DateTime DateTimeNow)
        {
            int CustomerID = 0;

            //取得可入座桌號
            int DeskNo = DB.ExecuteQuery<int>(@"SELECT D.DeskNo
                                                FROM orderform as O , Desk as D
                                                WHERE D.Seat >= '5' AND EatingTime > EatingTime - '01:30:00' and EatingTime < EatingTime + '01:30:00' AND DeskStatus= '空桌'
                                                Order by Seat ", peopleNum).FirstOrDefault();
            if (DeskNo != 0)
            {
                //新增顧客資料
                DB.ExecuteCommand("Insert into Customer (Name,Phone) Values ({0},{1}) select SCOPE_IDENTITY()", Name, Phone);

                //建立訂單(根據取得之桌號與顧客編號建立訂單)
                CustomerID = DB.ExecuteQuery<int>("SELECT Customer_ID from Customer order by Customer_ID desc").FirstOrDefault();
                DB.ExecuteCommand("Insert into OrderForm Values ({0},{1},{2},{3},{4},{5},{6})",
                    new object[] { peopleNum, "In", "預約", DateTimeNow, "", DeskNo, CustomerID });

                //更新桌子狀態
                DB.ExecuteCommand("Update Desk set DeskStatus = '已訂位' where DeskNo = {0}", DeskNo);

                //取得訂單編號
                int OrderFormID = DB.ExecuteQuery<int>("select OrderForm_ID from OrderForm where Customer_ID = {0} ", CustomerID).FirstOrDefault();

                //將桌號、訂單編號存入Json格式並回傳
                var DeskOrderNo = new { DeskNo = DeskNo, OrderFormID = OrderFormID };
                return DeskOrderNo;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 預約報到根據輸入之電話號碼查詢桌號
        /// </summary>
        /// <returns></returns>
        public int getReserveDesk(string Phone)
        {
            return DB.ExecuteQuery<int>(@"select O.DeskNo from Desk D 
                                            join OrderForm O on D.DeskNo = O.DeskNo
                                            join Customer C on O.Customer_ID = C.Customer_ID
                                            where OrderStatus = '預約' and Phone = {0}", Phone).FirstOrDefault();
        }

        /// <summary>
        /// 根據桌號呼叫服務or完成服務
        /// </summary>
        /// <param name="deskNo"></param>
        /// <returns></returns>
        public string callServer(int deskNo, string calling)
        {
            try
            {
                DB.ExecuteCommand("UPDATE Desk SET Calling = {0} WHERE DeskNo = {1}", new object[] { calling, deskNo });
                return "執行成功";
            }
            catch
            {
                return "執行失敗";
            }
        }
    }
}