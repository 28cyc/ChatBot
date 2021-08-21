using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class OrderFormModel
    {
        public int OrderForm_ID { get; set; }
        public int PeopleNum { get; set; }
        public string InOrOut { get; set; }
        public string OrderStatus { get; set; }
        public DateTime EatingTime { get; set; }
        public string Memo { get; set; }
        public int DeskNo { get; set; }
        public int Customer_ID { get; set; }
    }
}