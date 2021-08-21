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
        /// 
        /// </summary>
        public List<FoodListMoel> FOOD_LIST { get; set; }
    }

    public class FoodListMoel
    {
        public int FOOD_ID { get; set; }
        public int FOOD_AMT { get; set; }
    }
}