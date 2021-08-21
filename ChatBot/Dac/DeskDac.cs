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
        /// 內用回傳桌號
        /// </summary>
        /// <returns></returns>
        public int getFitDesk(int peopleNum)
        {
            return DB.ExecuteQuery<int>("SELECT DeskNo FROM Desk WHERE Seat >= {0} ORDER BY Seat ", peopleNum).FirstOrDefault();
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