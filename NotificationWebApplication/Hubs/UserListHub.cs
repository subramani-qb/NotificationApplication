using Microsoft.AspNet.SignalR;
using Notification.ModelProviders;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationWebApplication.Hubs
{
    public class UserListHub : Hub
    {
        UserTimeDetailsModelProvider modelProvider = new UserTimeDetailsModelProvider();

        public void UpdateUserList()
        {
            IEnumerable<UserTimeDetailsModel> userList = modelProvider.ReadAll();

            Clients.Others.BroadcastAll(userList);
        }
    }
}