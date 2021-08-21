using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class OrderDetailModel
    {
        public int Food_ID { get; set; }
        public string Food_Name { get; set; }
        public int Food_Price { get; set; }
        public int Food_AMT { get; set; }
        public int OrderForm_ID { get; set; }
    }
}