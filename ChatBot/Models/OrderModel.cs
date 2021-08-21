using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class OrderModel
    {
        /// <summary>
        /// 桌號
        /// </summary>
        public int DESK_NO { get; set; }

        /// <summary>
        /// 餐點清單
        /// </summary>
        public List<FoodListMoel> FOOD_LIST { get; set; }
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