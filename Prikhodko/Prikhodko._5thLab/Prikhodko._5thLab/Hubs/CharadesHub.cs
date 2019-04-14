using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Prikhodko._5thLab.Hubs
{
    public class CharadesHub : Hub
    {
        private static Dictionary<string, string> members = new Dictionary<string, string>();

        public async Task SendMessage(string message)
        {
            var sender = members[Context.ConnectionId];
            if (string.IsNullOrEmpty(sender))
            {
                throw new AccessViolationException($"Anonymous access, Connection Id: {Context.ConnectionId}");
            }
            await Clients.All.SendAsync("ReceiveMessage", sender, message);
            //TODO: after the message is sent, this method will call another method that will check whether the message and the key to charades are equal
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("AskName");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            await Clients.Others.SendAsync("Notify", $"{members[Context.ConnectionId]} left the room");
            await base.OnDisconnectedAsync(e);
        }

        public async Task RegisterMember(string name)
        {
            members[Context.ConnectionId] = name;
            await Clients.Others.SendAsync("Notify", $"{members[Context.ConnectionId]} entered the room");
            if (members.Count > 1)
            {
                //InitCharades();
            }
        }

        //public async Task InitCharades()
        //{
        //    await Clients.All.SendAsync
        //}
    }
}
