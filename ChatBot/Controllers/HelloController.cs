using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ChatBot.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HelloController(IConfiguration config)
        {
            this._configuration = config;
        }

        [HttpPost("[action]")]
        public string Test([FromForm] string name)
        {
            return $"hello {name}!!!";
        }

        [HttpGet("[action]")]
        public string Test2()
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