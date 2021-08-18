using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatBot.Models;
using Microsoft.AspNet.SignalR;

namespace ChatBot.SignalR.Hubs
{
    public class updateModifiedAdUsersHub : Hub
    {
        static IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<updateModifiedAdUsersHub>();


        public void Update(
           IEnumerable<AdUser> adUsers, String connId)
        {

            if (!String.IsNullOrEmpty(connId))
            {
                //Send back to certain client with Connection id
                HubContext.Clients.Client(connId).updateModifiedAdUsers(adUsers);
            }
            else
            {
                //Send back to all connections
                HubContext.Clients.All.updateModifiedAdUsers(adUsers);
            }
        }
    }
}