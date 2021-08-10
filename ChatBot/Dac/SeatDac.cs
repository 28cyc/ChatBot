using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ChatBot.Interface;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace ChatBot.Dac
{
    public class SeatDac : ISeatDac
    {
        private readonly IConfiguration _configuration;

        public SeatDac(IConfiguration config)
        {
            this._configuration = config;
        }

        public DataTable Test()
        {
            var connString = _configuration.GetConnectionString("ChatBotConn");
            DataTable dt = new DataTable();
            string sql = @"select * from SEAT";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        public DataTable TestId(int id)
        {
            var connString = _configuration.GetConnectionString("ChatBotConn");
            DataTable dt = new DataTable();
            string sql = @"select * from SEAT WHERE Seat_ID = @ID ";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }
    }
}
