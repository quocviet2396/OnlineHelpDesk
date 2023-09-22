using System;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class TicketStatusServicesImp : ITicketStatusServices
    {
        private DatabaseContext db;
        public TicketStatusServicesImp(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<bool> addTicketStatus(TicketStatus newTicketStatus)
        {
            await db.TicketStatus.AddAsync(newTicketStatus);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteTicketStatus(int id)
        {
            var model = await db.TicketStatus.SingleOrDefaultAsync(t => t.Id.Equals(id));
            if (model != null)
            {
                db.TicketStatus.Remove(model);
                await db.SaveChangesAsync();
                return true;


            }
            else
            {
                return false;
            }
        }

        public async Task<bool> editTicketStatus(TicketStatus newTicketStatus)
        {
            db.TicketStatus.Update(newTicketStatus);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TicketStatus>> GetTicketStatus()
        {
            return await db.TicketStatus.ToListAsync();
        }

        public async Task<TicketStatus> GetTicketStatusById(int id)
        {
            return await db.TicketStatus.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

