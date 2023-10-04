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
        protected IHubContext<SignalConfig> _Context;
        private readonly ITicket _ticket;
        public SignalConfig(IAccountService account, DatabaseContext db, IHubContext<SignalConfig> Context, ITicket ticket)
        {
            _account = account;
            _db = db;
            _Context = Context;
            _ticket = ticket;
        }



        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("OnConnected");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;

            var user = _db.userConn.FirstOrDefault(e => e.ConnectionId == connectionId);
            user.Connected = false;
            _db.SaveChanges();

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendNoti(string userId, string mess)
        {
            await _Context.Clients.Client(userId).SendAsync("NotifyMessage", mess);
        }

        public async Task SendNotiToAdmin(string conId, TicketDTO tickets, string mess)
        {
            await Clients.Client(conId).SendAsync("SendNotiAdmin", tickets, mess);
        }

        public async Task SendNotiToSup(string email)
        {
            var user = _db.Users.Where(e => e.Email == email);
            foreach (var item in user)
            {
                var tickets = _ticket.Tickets(email, item.Role);
                var userConn = _db.userConn.Where(a => a.UserId == item.Id).FirstOrDefault();
                await Clients.Client(userConn.ConnectionId).SendAsync("SendNotiToSup", tickets);

            }

        }

        public async Task saveUser(string email)
        {

            string connectionId = Context.ConnectionId;

            var userId = _db.Users.FirstOrDefault(u => u.Email == email);

            var ConnId = _db.userConn.FirstOrDefault(c => c.UserId == userId.Id);
            if (ConnId != null && connectionId != ConnId.ConnectionId)
            {
                ConnId.ConnectionId = connectionId;
                ConnId.Connected = true;
                _db.SaveChanges();
            }
            else
            {
                UserConn userconn = new UserConn()
                {
                    UserId = userId.Id,
                    Connected = true,
                    ConnectionId = connectionId,
                };
                _db.userConn.Add(userconn);
                _db.SaveChanges();
            }
        }

    }
}