using System;
using System.Runtime.InteropServices;
using LibraryModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Signal;

namespace WebApp.Services
{
    public class NotificationServiceImp : INotificationService
    {
        public readonly DatabaseContext _db;
        public readonly SignalConfig _signal;
        public readonly IHubContext<SignalConfig> _hubContext;
        public NotificationServiceImp(DatabaseContext db, SignalConfig signal, IHubContext<SignalConfig> hubContext)
        {
            _db = db;
            _signal = signal;
            _hubContext = hubContext;
        }


        public async Task<List<Notifications>> Notifications(string email)
        {
            var user = _db.Users.FirstOrDefault(e => e.Email.Equals(email));

            var userConnected = _db.userConn.FirstOrDefault(c => c.UserId == user.Id);


            var result = userConnected != null ? await _db.Notifications.Include(a => a.userConn).Where(n => n.userConnId == userConnected.Id).ToListAsync() : null;

            return result;
        }


        public async void sendNoti(string email, List<TicketDTO> ticket)
        {
            var user = _db.Users.FirstOrDefault(e => e.Email.Equals(email));

            var userConnected = _db.userConn.FirstOrDefault(c => c.UserId == user.Id);


            Notifications noti = new Notifications()
            {
                readed = false,
                status = false,
                userConnId = userConnected.Id,
                url = null,
            };
            _db.Notifications.Add(noti);

            var tickets = JsonConvert.SerializeObject(ticket);
            await _hubContext.Clients.Client(userConnected.ConnectionId).SendAsync("SendNotiAdmin", tickets, "Hello");
        }
    }
}

