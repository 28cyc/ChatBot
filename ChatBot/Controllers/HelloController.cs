using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpPost("[action]")]
        public string Test([FromForm] string name)
        {
            return $"hello {name}!!!";
        }
    }
}