using System;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Signal;

namespace WebApp.Services
{
    public class NotificationServiceImp : INotificationService
    {
        public readonly DatabaseContext _db;
        public readonly SignalConfig _signal;
        public NotificationServiceImp(DatabaseContext db, SignalConfig signal)
        {
            _db = db;
            _signal = signal;
        }


        public async Task<List<Notifications>> Notifications(string email)
        {
            var user = _db.Users.FirstOrDefault(e => e.Email.Equals(email));

            Console.WriteLine(user.Id);
            var userConnected = _db.userConn.FirstOrDefault(c => c.UserId == user.Id);


            var result = userConnected != null ? await _db.Notifications.Where(n => n.userConnId == userConnected.Id).ToListAsync() : null;

            return result;
        }


        public async void sendNoti(string email, string url)
        {
            var user = _db.Users.FirstOrDefault(e => e.Email.Equals(email));

            var userConnected = _db.userConn.FirstOrDefault(c => c.UserId == user.Id);

            Notifications noti = new Notifications()
            {
                readed = false,
                status = false,
                userConnId = userConnected.Id,
                url = url,
            };
            _db.Notifications.Add(noti);
            _db.SaveChanges();
            await _signal.SendNoti(userConnected.ConnectionId, "You have new notification");
        }
    }
}

