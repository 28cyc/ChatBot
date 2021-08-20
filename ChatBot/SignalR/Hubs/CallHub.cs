using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatBot.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatBot.SignalR.Hubs
{
    [HubName("CallHub")]
    public class CallHub : Hub
    {
        static IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<CallHub>();

        public void Update(int deskNo, String connId)
        {

            if (!String.IsNullOrEmpty(connId))
            {
                //Send back to certain client with Connection id
                HubContext.Clients.Client(connId).callService(deskNo);
            }
            else
            {
                //Send back to all connections
                HubContext.Clients.All.callService(deskNo);
            }
        }

    }
}