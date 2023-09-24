using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface IAccountService
    {
        Task<ICollection<Users>> AllUsers(int pageNumber, int? Limit, string currentSort);
        List<UserInfoDTO> UserInfo(string stuCodeTd);



        Task<Response> ResetPassword(string code);
        Task<Response> CheckPassword(string value, string key, string code, string newPas, string conPas);

        Task<Response> ChangePassword(string pass, string code);
    }
}

