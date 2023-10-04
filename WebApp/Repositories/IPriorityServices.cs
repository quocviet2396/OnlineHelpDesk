using System;
using LibraryModels;

namespace WebApp.Repositories
{
	public interface IPriorityServices
	{
        Task<IEnumerable<Priority>> GetPriority();
        Task<bool> addPriority(Priority newPriority);
        Task<bool> editPriority(Priority newPriority);

        Task<Priority> GetPriorityById(int id);
        Task<bool> deletePriority(int id);
    }
}

