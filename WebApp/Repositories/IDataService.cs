using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface IDataService
    {
        public Task<ICollection<UsersInfo>> AllUser(int pageIndex, int? Limit, string currentSort);

        public Task<Response> CreateStudent(List<string> Student_code);

        public Task<Response> CreateAccount(Users users);

        Task<List<string>> AccCode();
    }
}

