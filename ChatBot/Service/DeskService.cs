using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        /// 內用回傳桌號、訂單編號
        /// </summary>
        /// <returns></returns>
        public object getFitDesk(int peopleNum)
        {
            DateTime DateTimeNow = DateTime.Now;
            return deskDac.getFitDesk(peopleNum, DateTimeNow);
        }

        /// <summary>
        /// 預約回傳桌號、訂單編號
        /// </summary>
        /// <returns></returns>
        public object ReserveGetFitDesk(int peopleNum, string Name, string Phone, DateTime dateTime)
        {
            DateTime DateTimeNow = DateTime.Now;
            return deskDac.ReserveGetFitDesk(peopleNum, Name, Phone, dateTime);
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