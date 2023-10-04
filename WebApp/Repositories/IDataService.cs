using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface IDataService
    {
        public Task<ICollection<UsersInfo>> AllUser(int pageIndex, int? Limit, string currentSort, string? currentFilter);

        public Task<Response<string>> CreateStudent(List<string> Student_code);

        Task<List<string>> AccCode();
    }
}