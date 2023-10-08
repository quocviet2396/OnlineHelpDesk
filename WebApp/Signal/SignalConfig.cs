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
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendNoti(string userId, string mess)
        {
            await _Context.Clients.Client(userId).SendAsync("NotifyMessage", mess);
        }

        [HubMethodName("SendNotiAdmin")]
        public async Task SendNotiToAdmin(string conId, TicketDTO tickets, string mess)
        {
            await Clients.Client(conId).SendAsync("SendNotiAdmin", tickets, mess);
        }

        //[HubMethodName("CheckNoti")]
        //public async Task CheckNoti(string email)
        //{
        //    var User = _db.Users.FirstOrDefault(u => u.Email == email);
        //    var TicketNoti = await _ticket.TicketNonCate(email, User.Role);
        //    var conId = _db.userConn.FirstOrDefault(a => a.UserId == User.Id);
        //    await Clients.Client(conId.ConnectionId).SendAsync("SendNotiAdmin", TicketNoti, "hello");
        //}

        [HubMethodName("saveUser")]
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