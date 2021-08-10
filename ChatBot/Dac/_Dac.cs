using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ChatBot.Dac
{
    public class _Dac
    {
        protected DataContext DB;
        public _Dac()
        {
            DB = new DataContext(ConfigurationManager.ConnectionStrings["ChatBotConn"].ConnectionString);
        }
    }
}