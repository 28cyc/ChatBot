using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ChatBot.Interface;
using Microsoft.Extensions.Configuration;

namespace ChatBot.Dac
{
    public class SeatDac : ISeatDac
    {
        private readonly IConfiguration _configuration;

        public SeatDac(IConfiguration config)
        {
            this._configuration = config;
        }

        public string Test()
        {
            var connString = _configuration.GetConnectionString("ChatBotConn");

            DataTable dt = new DataTable();
            string sql = @"select Capacity from SEAT";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }

            return dt.Rows[0]["Capacity"].ToString();
        }
    }
}
