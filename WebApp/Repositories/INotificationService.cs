using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface INotificationService
    {
        void sendNoti(string email, List<TicketDTO> ticket);

        Task<List<Notifications>> Notifications(string email);
    }
}