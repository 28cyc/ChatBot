using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class OrderModel
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        public int OrderFormID { get; set; }

        /// <summary>
        /// 餐點清單
        /// </summary>
        public List<FoodListMoel> FOOD_LIST { get; set; }

        /// <summary>
        /// 用餐時間
        /// </summary>
        public DateTime EatingTime { get; set; }
    }

    public class FoodListMoel
    {
        /// <summary>
        /// 餐點ID
        /// </summary>
        public int FOOD_ID { get; set; }

        /// <summary>
        /// 餐點數量
        /// </summary>
        public int FOOD_AMT { get; set; }
    }
}