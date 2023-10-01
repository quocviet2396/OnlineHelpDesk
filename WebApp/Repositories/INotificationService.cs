using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface INotificationService
    {
        void sendNoti(string email, string url);

        Task<List<Notifications>> Notifications(string email);

    }
}

