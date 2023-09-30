using System;
using Microsoft.AspNetCore.SignalR;

namespace WebApp.Signal
{
    public class SignalConfig : Hub
    {
        public async Task SendNoti(string userId, string mess, string url)
        {

            await Clients.Client(userId).SendAsync("NotifyMessage", mess, url);
        }

        public SignalConfig()
        {
        }
    }
}

