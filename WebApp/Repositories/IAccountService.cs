using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface IAccountService
    {
        Task<ICollection<Users>> AllUsers(int pageNumber, int? Limit, string currentSort);
        Task<Users> UserInfo(string stuCodeTd);
        Task<Users> UserProfile(string mail);
        Task<Response> ResetPassword(string code);
        Task<Response> CheckPassword(string value, string key, string code, string newPas, string conPas);

        Task<Response> ChangePassword(string pass, string code);
    }
}

