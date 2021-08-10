using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ChatBot.Dac;
using ChatBot.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatDac seatDac;

        public SeatController(ISeatDac seatDac)
        {
            this.seatDac = seatDac;
        }

        [HttpGet("[action]")]
        public DataTable Test()
        {
            var a = seatDac.Test();
            return a;
        }
    }
}