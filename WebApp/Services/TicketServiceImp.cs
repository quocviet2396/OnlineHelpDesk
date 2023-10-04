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
            db.Add(newTicket);
            db.SaveChanges();
            return true;
        }

        public async Task<bool> delete(int id)
        {
            var model = db.Ticket.SingleOrDefault(t => t.Id == id);
            if (model != null)
            {
                db.Ticket.Remove(model);
                await db.SaveChangesAsync();
                return true;
            }
            else return false;
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
            existingTicket.ModifiedDate = newTicket.ModifiedDate;
            existingTicket.Attachment = newTicket.Attachment;
            existingTicket.TicketStatusId = newTicket.TicketStatusId;
            existingTicket.CategoryId = newTicket.CategoryId;
            existingTicket.CreatorId = newTicket.CreatorId;
            existingTicket.SupporterId = newTicket.SupporterId;
            existingTicket.PriorityId = newTicket.PriorityId;
            existingTicket.feedback = newTicket.feedback;

            await db.SaveChangesAsync();
            return true; // Ticket updated successfully.
        }


        public async Task<List<Ticket>> Tickets(string email, string role)
        {
            var query = await db.Ticket
                    .Include(t => t.Creator).Include(f => f.Category).Include(ts => ts.TicketStatus).Include(sp => sp.Supporter).Include(pr => pr.Priority)
                .OrderByDescending(t => t.CreateDate).ToListAsync();

            if (!string.IsNullOrEmpty(email) && role != Role.Admin)
            {
                query = query.Where(a =>
                        (a.Creator != null && a.Creator.Email.Equals(email)) ||
                        (a.Supporter != null && a.Supporter.Email.Equals(email))).ToList();
            }
            return query;
        }


        public async Task<List<TicketDTO>> TicketNonCate(string email, string role)
        {
            var user = db.Users.FirstOrDefault(u => u.Email.Equals(email));
            var query = await db.Ticket
                        .Include(t => t.Creator)
                        .Include(f => f.Category)
                        .Include(ts => ts.TicketStatus)
                        .Include(sp => sp.Supporter)
                        .Select(c => new TicketDTO()
                        {
                            TicketId = c.Id,
                            Title = c.Title,
                            Decription = c.Description,
                            PhotoPerson = c.Creator.userInfo.Photo,
                            UserNameCreator = c.Creator.UserName,
                            UserNameSupporter = c.Supporter != null ? c.Supporter.UserName : null,
                            EmailCreator = c.Creator.Email,
                            EmailSupporter = c.Supporter != null ? c.Supporter.Email : null,
                            TicketStatus = c.TicketStatus != null ? c.TicketStatus.Name : null,
                        }).ToListAsync();



            if (!string.IsNullOrEmpty(email) && role != Role.Admin)
            {
                query = query.Where(a =>
                        (a.EmailCreator != null && a.EmailCreator.Equals(email)) ||
                        (a.EmailSupporter != null && a.EmailSupporter.Equals(email))).ToList();
            }
            else if (role == Role.Admin)
            {
                query = query.Where(a => a.TicketStatus == null).ToList();
            }
            return query;
        }

    }
}
