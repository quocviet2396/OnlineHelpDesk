using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface IAccountService
    {
        Task<ICollection<Users>> AllUsers(int pageNumber, int? Limit, string currentSort);
        UserInfoDTO UserInfo(string stuCodeTd);



        Task<Response<string>> ResetPassword(string code);
        Task<Response<string>> CheckPassword(string value, string key, string code, string newPas, string conPas);

        Task<Response<string>> ChangePassword(string pass, string code);
    }
}

