using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ChatBot.Interface
{
    public interface ISeatDac
    {
        DataTable Test();
        DataTable TestId(int id);
    }
}
