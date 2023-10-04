using System;
using LibraryModels;

namespace WebApp.Repositories
{
	public interface IFacilitiesServices
	{
         Task<IEnumerable<Facilities>> GetFacilities();
        Task<bool> addFacilities(Facilities newFacilities);
        Task<bool> editFacilities(Facilities newFacilities);

        Task<Facilities> GetFacilitiesById(int id);
        Task<bool> deleteFacilities(int id);
    }
}

