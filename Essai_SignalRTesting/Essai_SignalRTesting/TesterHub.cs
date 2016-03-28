using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Essai_SignalRTesting
{
    public class TesterHub : Hub
    {
        private IHubContext _chatHubContext;

        public TesterHub()
        {
            // Get the context for the Pusher hub
            _chatHubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        }

        public void Hello()
        {
            Clients.All.hello();
        }
        public string Bidon()
        {
            return "Bidon";
        }
        public void Send(string message)
        {
            // Call the broadcastMessage method to update clients.
            _chatHubContext.Clients.All.broadcastMessage(message);
        }
        public object GetMessageId()
        {
            // Call the broadcastMessage method to update clients.
            Task<object> t = _chatHubContext.Clients.All.GetMessageId();
            return t.Result;
        }
    }
}