using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using NotificationWebApplication.Models;

namespace NotificationWebApplication.Hubs
{
    public class NotificationHub : Hub
    {
        private static List<UserConnectionModel> _userList = new List<UserConnectionModel>();
        private static DateTime dateTime;

        public void ReceiveNewAndBroadCastAllUsers(string newUser)
        {
            if(newUser != string.Empty)
                _userList.Add(new UserConnectionModel()
                {
                    ConnectionId = Context.ConnectionId,
                    Name = newUser
                });

            Clients.All.BroadcastAllUsers(_userList);
        }

        public override Task OnConnected()
        {
            dateTime = DateTime.Now;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if(_userList.Any(x=>x.ConnectionId == Context.ConnectionId))
            {
                _userList.RemoveAll(x => x.ConnectionId == Context.ConnectionId);
                Clients.All.BroadcastAllUsers(_userList);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}