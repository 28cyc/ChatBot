using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ChatBot.Dac
{
    public class DeskDac : _Dac
    {
        public IEnumerable<DeskModel> getAllDesk()
        {
            return DB.ExecuteQuery<DeskModel>("SELECT * FROM Desk"); ;
        }

        public int getFitDesk(int peopleNum)
        {
            return DB.ExecuteQuery<int>("SELECT DeskNo FROM Desk WHERE Seat >= {0} ORDER BY Seat ", peopleNum).FirstOrDefault();
        }
    }
}