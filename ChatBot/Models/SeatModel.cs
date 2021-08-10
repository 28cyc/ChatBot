using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class SeatModel
    {
        public int Seat_ID { get; set; }
        public string Capacity { get; set; }
        public string Status { get; set; }
        public string Demand { get; set; }
    }
}