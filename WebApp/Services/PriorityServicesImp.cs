using System;
using LibraryModels;
using WebApp.Database_helper;
using WebApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services
{
	public class PriorityServicesImp : IPriorityServices
	{
        private DatabaseContext db;
        public PriorityServicesImp(DatabaseContext db)
        { 
            this.db = db;
		}

        public async Task<bool> addPriority(Priority newPriority)
        {
            await db.Priority.AddAsync(newPriority);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deletePriority(int id)
        {
            var model = await db.Priority.SingleOrDefaultAsync(t => t.Id.Equals(id));
            if (model != null)
            {
                db.Priority.Remove(model);
                await db.SaveChangesAsync();
                return true;


            }
            else
            {
                return false;
            }
        }

        public async Task<bool> editPriority(Priority newPriority)
        {
            db.Priority.Update(newPriority);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Priority>> GetPriority()
        {
            return await db.Priority.ToListAsync();
        }

        public async Task<Priority> GetPriorityById(int id)
        {
            return await db.Priority.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

