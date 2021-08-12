using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class DeskModel
    {
        /// <summary>
        /// 桌號
        /// </summary>
        public int DeskNo { get; set; }

        /// <summary>
        /// 座位數
        /// </summary>
        public int Seat { get; set; }

        /// <summary>
        /// 桌子狀態：空桌/用餐中/已訂位/清潔中
        /// </summary>
        public string DeskStatus { get; set; }

        /// <summary>
        /// 呼叫：Y/N
        /// </summary>
        public string Calling { get; set; }
    }
}