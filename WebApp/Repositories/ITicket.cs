using LibraryModels;

namespace WebApp.Repositories
{
    public interface ITicket
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<bool> create(Ticket newTicket);
        Task<bool> update(Ticket newTicket);
        Task<bool> delete(int id);
        Task<Ticket> GetTicketById(int id);

        Task<List<Ticket>> Tickets(string email, string role);
        Task<List<TicketDTO>> TicketNonCate(string email, string role);
    }
}
