using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class TicketServiceImp : ITicket
    {
        private readonly DatabaseContext db;
        public TicketServiceImp(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> create(Ticket newTicket)
        {
            await db.AddAsync(newTicket);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> delete(int id)
        {
            var model = db.Ticket.SingleOrDefault(t => t.Id == id);
            if (model != null) {
            db.Ticket.Remove(model);
                await db.SaveChangesAsync();
                return true;
            }else return false;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await db.Ticket
                .Include(ticket => ticket.TicketStatus)
                .OrderBy(ticket => ticket.CreateDate)
                .ToListAsync();
        }



        public async Task<Ticket> GetTicketById(int id)
        {
            return await db.Ticket.SingleOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task<bool> update(Ticket newTicket)
        {
            var existingTicket = await db.Ticket.SingleOrDefaultAsync(t => t.Id == newTicket.Id);

            if (existingTicket == null)
            {
                return false; // Ticket with the specified ID not found.
            }

            // Update the properties of the existing ticket with the new values.
            existingTicket.Title = newTicket.Title;
            existingTicket.Description = newTicket.Description;
            existingTicket.ModifiedDate =newTicket.ModifiedDate;
            existingTicket.Attachment = newTicket.Attachment;
            existingTicket.TicketStatusId = newTicket.TicketStatusId;
            existingTicket.CategoryId = newTicket.CategoryId;
            existingTicket.CreatorId = newTicket.CreatorId;
            existingTicket.SupporterId = newTicket.SupporterId;

            await db.SaveChangesAsync();
            return true; // Ticket updated successfully.
        }

    }
}
