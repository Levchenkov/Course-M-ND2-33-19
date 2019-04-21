using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Prikhodko._5thLab.Hubs
{
    public class CharadesHub : Hub
    {
        private static Dictionary<string, string> members = new Dictionary<string, string>();
        private static bool _gameStarted;
        private static string drawerConnectionId; //drawerConnectionId will be stored as a Connection ID string
        private static string _charade;


        private static List<string> _words = new List<string>()
        {
            "pyramid", "triangle", "square", "circle", "earth"
        };

        public async Task SendMessage(string message)
        {
            var sender = members[Context.ConnectionId];
            if (string.IsNullOrEmpty(sender))
            {
                throw new AccessViolationException($"Anonymous access, Connection Id: {Context.ConnectionId}");
            }
            await Clients.All.SendAsync("ReceiveMessage", sender, message);
            if (message.ToLower() == _charade)
            {
                await Clients.All.SendAsync("NameWinner", sender, _charade);
                EndCharades();
            }
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
            members.Remove(Context.ConnectionId);
            if (_gameStarted)
            {
                if (Context.ConnectionId == drawerConnectionId)
                {
                    await Clients.All.SendAsync("DrawerDisconnected");
                }
            }
            await base.OnDisconnectedAsync(e);
        }

        public async Task RegisterMember(string name)
        {
            members[Context.ConnectionId] = name;
            await Clients.Others.SendAsync("Notify", $"{members[Context.ConnectionId]} entered the room");
            if (members.Count > 1)
            {
                if (!_gameStarted)
                {
                    await InitCharades();
                }
            }
        }

        public async Task UpdateCanvas(int x, int y, bool dragging)
        {
            await Clients.All.SendAsync("AddClick", x, y, dragging);
            await Clients.All.SendAsync("Draw");
        }

        public async Task ClearCanvas()
        {
            await Clients.All.SendAsync("ClearCanvas");
        }

        private async Task InitCharades()
        {
            await Clients.Caller.SendAsync("EnableDrawing");
            _charade = _words[new Random().Next(0, _words.Count - 1)];
            await Clients.Caller.SendAsync("ProvideCharade", _charade);
            await Clients.AllExcept(Context.ConnectionId).SendAsync("NotifyGameStarted");
            drawerConnectionId = Context.ConnectionId;
            _gameStarted = true;
        }

        private void EndCharades()
        {
            members = new Dictionary<string, string>();
            _gameStarted = false;
            drawerConnectionId = null;
            _charade = null;
        }
    }
}
