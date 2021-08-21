using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Service
{
    public class DeskService
    {
        Dac.DeskDac deskDac = new Dac.DeskDac();

        /// <summary>
        /// 取得所有桌子資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DeskModel> getAllDesk()
        {
            return deskDac.getAllDesk();
        }

        /// <summary>
        /// 內用回傳桌號
        /// </summary>
        /// <returns></returns>
        public int getFitDesk(int peopleNum)
        {
            return deskDac.getFitDesk(peopleNum);
        }

        /// <summary>
        /// 預約報到根據輸入之電話號碼查詢桌號
        /// </summary>
        /// <returns></returns>
        public int getReserveDesk(string Phone)
        {
            return deskDac.getReserveDesk(Phone);
        }

        /// <summary>
        /// 根據桌號呼叫服務or完成服務
        /// </summary>
        /// <param name="deskNo"></param>
        /// <returns></returns>
        public string callServer(int deskNo, string calling)
        {
            return deskDac.callServer(deskNo, calling);
        }
    }
}