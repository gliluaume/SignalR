using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Essai_SignalRTesting
{
    public class ChatHub : Hub
    {
        private IHubContext _testerHubContext;

        public ChatHub()
        {
            // Get the context for the Pusher hub
            _testerHubContext = GlobalHost.ConnectionManager.GetHubContext<TesterHub>();
        }
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
        public void SendMessageId(string messageId)
        {
            // Call the broadcastMessage method to update clients.
            _testerHubContext.Clients.All.readMessageId(messageId);
        }
    }
}