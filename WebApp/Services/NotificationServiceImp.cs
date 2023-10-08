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
        public NotificationServiceImp(DatabaseContext db)
        {
            _db = db;
        }


        public async Task<List<TicketDTO>> Notifications(string email)
        {
            var user = _db.Users.FirstOrDefault(e => e.Email.Equals(email));

            var query = await _db.TickdetDTOs.ToListAsync();

            if (!string.IsNullOrEmpty(email) && user?.Role != Role.Admin)
            {
                if (user?.Role == Role.FacilityHead)
                {
                    query = query.Where(a => (a.EmailSupporter != null && a.EmailSupporter.Equals(email))).ToList();
                }
                else
                {
                    query = query.Where(a => a.EmailCreator.Equals(email)).Where(a => a.TicketStatus == "Completed" || a.TicketStatus == "Rejected").ToList();
                }
            }
            else if (user?.Role == Role.Admin)
            {
                query = query.ToList();
            }

            return query;
        }

    }
}