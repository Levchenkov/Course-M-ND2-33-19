using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using Microsoft.AspNet.SignalR;

namespace KrokoRignalR.Models
{
    public class ChatHub : Hub
    {
        public static List<User> Users = new List<User>();
        private static string Word;

        // Отправка сообщений
        public void Send(string name, string message, bool isMaster)
        {
            if (isMaster)
            {
                Word = message.ToLower();
            }
            else
            {
                Clients.All.addMessage(name, message, isMaster);
                if (message.ToLower() == Word.ToLower())
                {
                    var str = string.Format("Поздравляю, пользователь {0} выиграл!", name);
                    Clients.All.addMessage(name, str, isMaster);
                    EndGame();
                }
            }
        }

        // Подключение нового пользователя
        public void Connect(string userName, bool isMaster)
        {
            var id = Context.ConnectionId;
            if (!Users.Any(x => x.ConnectionId == id))
            {
                if (Users.Any(x => x.IsMaster))
                {
                    isMaster = false;
                }
                Users.Add(new User { ConnectionId = id, Name = userName, IsMaster = isMaster});
                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users, isMaster);
                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName, isMaster);
            }
        }

        public void UpdateCanvas(int ex, int ey, int x, int y, string color)
        {
            Clients.All.updateDot(ex, ey, x, y, color);
        }

        public void ClearCanvas()
        {
            Clients.All.clearCanvas();
        }

        public void EndGame()
        {
            ClearCanvas();
            Clients.All.endGame();
        }

        //public override System.Threading.Tasks.Task OnConnected()
        //{
        //    AddUser(Context.ConnectionId, User.Identity.Name);
        //    return base.OnConnected();
        //}
        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}