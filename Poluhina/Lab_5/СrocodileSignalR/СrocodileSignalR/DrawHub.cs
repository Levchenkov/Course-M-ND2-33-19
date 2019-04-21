using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using СrocodileSignalR.Models;

namespace СrocodileSignalR
{
    public class DrawHub : Hub
    {
        public void Send(Data data)
        {
            Clients.AllExcept(Context.ConnectionId).addLine(data);
        }
    }
}