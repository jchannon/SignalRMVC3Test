using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRMVC3Test
{
    [HubName("myHub")]
    public class MyHub : Hub
    {
        public void Send(string message)
        {
            // Call the addMessage method on all clients
            Clients.All.addMessage(message);
        }

        public void SendToSpecificId(string message, string connectionId)
        {
            Clients.Group(connectionId).addMessage(message);
            Clients.Client(connectionId).addMessage(message);
        }
    }
}