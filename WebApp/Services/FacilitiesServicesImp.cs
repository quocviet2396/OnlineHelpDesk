using System;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Services
{
	public class FacilitiesServiceImp : IFacilitiesServices
	{
        private DatabaseContext db;
        public FacilitiesServiceImp(DatabaseContext db)
		{
            this.db = db;
        }

        public async Task<bool> addFacilities(Facilities newFacilities)
        {
            await db.Facilities.AddAsync(newFacilities);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteFacilities(int id)
        {
            var model = await db.Facilities.SingleOrDefaultAsync(t => t.Id.Equals(id));
            if (model != null)
            {
                db.Facilities.Remove(model);
                await db.SaveChangesAsync();
                return true;


            }
            else
            {
                return false;
            }
        }

        public async Task<bool> editFacilities(Facilities newFacilities)
        {
            var model = await db.Facilities.SingleOrDefaultAsync(f => f.Id == newFacilities.Id);
            if (model != null)
            {
                model.Name = newFacilities.Name;
                model.Description = newFacilities.Description;
                model.SupporterId = newFacilities.SupporterId;
                await db.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }

        public async Task<IEnumerable<Facilities>> GetFacilities()
        {
            return await db.Facilities.ToListAsync();
        }

        public async Task<Facilities> GetFacilitiesById(int id)
        {
            return await db.Facilities.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

