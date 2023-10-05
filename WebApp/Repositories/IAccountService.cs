using System;
using LibraryModels;

namespace WebApp.Repositories
{
    public interface IAccountService
    {
        Task<ICollection<Users>> AllUsers(int pageNumber, int? Limit, string currentSort);
        UserInfoDTO UserInfo(string stuCodeTd);

        Task<Users> users(string stuCodeId);

        Task<Response<string>> CreateAccount(IFormCollection users);

        Task<Response<string>> CheckPhoto(IFormFile photo);

        Task<Response<string>> InfoChange(IFormCollection form);

        Task<Response<string>> ResetPassword(string code);

        Task<Response<string>> CheckPassword(string value, string key, string code, string newPas, string conPas);

        Task<Response<string>> ChangePassword(string pass, string code);

        Task<Response<string>> ForgotPassword(string email);

        Task<Response<string>> ChangeAvatar(IFormCollection avatar);
    }
}