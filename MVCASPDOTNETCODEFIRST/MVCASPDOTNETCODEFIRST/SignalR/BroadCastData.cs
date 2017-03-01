using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MVCASPDOTNETCODEFIRST.Repository;
using MVCASPDOTNETCODEFIRST.Models;

namespace MVCASPDOTNETCODEFIRST.SignalR
{
    [HubName("NofiFyDBChangeshub")]
    public class BroadCastData : Hub
    {
       
        [HubMethodName("Notify")]
        public static void NotifyToAllClients()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BroadCastData>();

            // the update client method will update the connected client about any recent changes in the server data
            context.Clients.All.updatedClients();
        }

        
    }
}