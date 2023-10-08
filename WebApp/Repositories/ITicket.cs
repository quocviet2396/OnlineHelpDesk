using LibraryModels;

namespace WebApp.Repositories
{
    public interface ITicket
    {
        Task<IEnumerable<Ticket>> GetAll();
        bool create(Ticket newTicket) ;
        Task<bool> update(Ticket newTicket);
        Task<bool> delete(int id);
        Task<Ticket> GetTicketById(int id);
        Task<List<Ticket>> Tickets(string email, string role, int pageIndex, int? limit, string? currentSort, string? currentFilter, string? category, string? supporter, string? status, string? priority, DateTime[] CDate, DateTime[] MDate);
        Task<TicketDTO> TicketNonCate(string email, string role, int? id = null);

        Task<bool> saveTicketDTo(TicketDTO ticketDTO);
    }
}
