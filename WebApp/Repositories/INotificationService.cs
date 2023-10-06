using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface INotificationService
    {

        Task<List<TicketDTO>> Notifications(string email);
    }
}