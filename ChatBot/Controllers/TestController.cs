using ChatBot.Models;
using ChatBot.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChatBot.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Chat()
        {
            return View("Chat");
        }

        public ActionResult adUser()
        {
            return View("adUser");
        }

        [HttpPost]
        public string Post(IEnumerable<AdUser> adUsers)
        {
            try
            {
                new updateModifiedAdUsersHub().Update(adUsers, connId: String.Empty);
                return "Ok";//Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return "Error";//Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}