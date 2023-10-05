using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface ITicketStatusServices
    {
        Task<IEnumerable<TicketStatus>> GetTicketStatus();
        Task<bool> addTicketStatus(TicketStatus newTicketStatus);
        Task<bool> editTicketStatus(TicketStatus newTicketStatus);

        Task<TicketStatus> GetTicketStatusById(int id);
        Task<bool> deleteTicketStatus(int id);
    }
}

