using System;
using LibraryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Signal
{
    public class SignalConfig : Hub
    {
        private readonly IAccountService _account;
        private readonly DatabaseContext _db;
        public SignalConfig(IAccountService account, DatabaseContext db)
        {
            _account = account;
            _db = db;
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("OnConnected");
            return base.OnConnectedAsync();
        }

        public async Task SendNoti(string userId, string mess, string url)
        {

            await Clients.Client(userId).SendAsync("NotifyMessage", mess, url);
        }

        public async Task saveUser(string email)
        {

            string connectionId = Context.ConnectionId;

            var userId = _db.Users.FirstOrDefault(u => u.Email == email);

            var ConnId = _db.userConn.FirstOrDefault(c => c.UserId == userId.Id);
            if (ConnId != null && connectionId != ConnId.ConnectionId)
            {
                ConnId.ConnectionId = connectionId;
                _db.SaveChanges();
            }
            else
            {
                UserConn userconn = new UserConn()
                {
                    UserId = userId.Id,
                    ConnectionId = connectionId,
                };
                _db.userConn.Add(userconn);
                _db.SaveChanges();
            }
        }

    }
}

