using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Service
{
    public class DeskService
    {
        Dac.DeskDac deskDac = new Dac.DeskDac();
        public int getFitDesk(int peopleNum)
        {
            return deskDac.getFitDesk(peopleNum);
        }
    }
}