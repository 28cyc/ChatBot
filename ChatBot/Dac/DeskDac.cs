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

        public int getFitDesk(int peopleNum)
        {
            return DB.ExecuteQuery<int>("SELECT DeskNo FROM Desk WHERE Seat >= {0} ORDER BY Seat ", peopleNum).FirstOrDefault();
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