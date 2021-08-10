using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ChatBot.Dac
{
    public class SeatDac : _Dac
    {
        public IEnumerable<SeatModel> a()
        {
            var a = DB.ExecuteQuery<SeatModel>("SELECT * FROM SEAT");
            return a;
        }

        public IEnumerable<SeatModel> b(int id)
        {
            var a = DB.ExecuteQuery<SeatModel>("SELECT * FROM SEAT WHERE Seat_ID = {0}", id);
            return a;
        }
    }
}