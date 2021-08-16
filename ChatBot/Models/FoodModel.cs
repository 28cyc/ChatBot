using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class FoodModel
    {
        /// <summary>
        /// 餐點編號
        /// </summary>
        public int Food_ID { get; set; }

        /// <summary>
        /// 餐點名稱
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// 餐點價格
        /// </summary>
        public int FoodPrice { get; set; }

        /// <summary>
        ///餐點描述
        /// </summary>
        public string FoodDescription { get; set; }

        /// <summary>
        /// 餐點產地
        /// </summary>
        public string FoodFrom { get; set; }
    }
}