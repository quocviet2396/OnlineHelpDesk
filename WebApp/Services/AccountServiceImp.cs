﻿using System;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Ultils;
using BCrypt.Net;

namespace WebApp.Services
{
    public class AccountServiceImp : IAccountService
    {
        private readonly DatabaseContext _db;
        private readonly Helper _helper;
        public Response res = new Response();
        public AccountServiceImp(DatabaseContext db, Helper helper)
        {
            _db = db;
            _helper = helper;
        }

        public async Task<ICollection<Users>> AllUsers(int pageNumber, int? Limit, string currentSort)
        {
            currentSort = string.IsNullOrEmpty(currentSort) ? "asc_Id" : currentSort;
            var sort = await Sort<Users>.SortAsync(_db.Users.ToList(), currentSort);
            //goi phuong thuc paginate de phan chia trang           goi csdl de phan trang      skip     lay bao nhieu   orderby
            var result = await Paginated<Users>.CreatePaginate(sort.ToList(), pageNumber, (int)Limit, x => x.Id);
            return result;
        }

        public async Task<Users> UserInfo(string stuCodeTd)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Code == stuCodeTd);
            return user;
        }

        public async Task<Users> UserProfile(string mail)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email.Equals(mail));
            return user;
        }

        public async Task<Response> ResetPassword(string code)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Code == code);
                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword("123456");
                    _db.SaveChanges();
                    return res = _helper.CreateResponse("Success", true);
                }
                else { return res = _helper.CreateResponse("Failure", false); }
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse(ex.Message, false);
            }
        }

        public async Task<Response> CheckPassword(string value, string key, string code, string newPas, string conPas)
        {
            var oldPass = await _db.Users.FirstOrDefaultAsync(p => p.Code == code);
            switch (key)
            {
                case "oldPassword":
                    var result = oldPass != null ? BCrypt.Net.BCrypt.Verify(value, oldPass.Password) : false;
                    if (result)
                    {
                        return res = _helper.CreateResponse("", result);
                    }
                    else
                    {
                        return res = _helper.CreateResponse("Old password is not valid", result);
                    }
                case "newPassword":
                    var result2 = BCrypt.Net.BCrypt.Verify(value, oldPass.Password);
                    var result3 = conPas == value;
                    if (result2)
                    {
                        return res = _helper.CreateResponse("The new password cannot be the same as the old password", !result2);
                    }
                    else if (result3)
                    {
                        return res = _helper.CreateResponse("", result3);
                    }
                    else
                    {
                        return res = _helper.CreateResponse("Confirm password not same", result3);

                    }
                case "confirmPassword":
                    var result4 = newPas == value;
                    if (result4)
                    {
                        return res = _helper.CreateResponse("", result4);
                    }
                    else
                    {
                        return res = _helper.CreateResponse("Confirm password not same", result4);
                    }
                default:
                    break;
            }
            return res = _helper.CreateResponse("fail", false);
        }

        public async Task<Response> ChangePassword(string pass, string code)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(p => p.Code == code);
                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(pass);
                    _db.SaveChanges();
                    return res = _helper.CreateResponse("Change password successfully", true);
                }
                else
                {
                    return res = _helper.CreateResponse("Some thing wrongs", false);
                }
            }
            catch (Exception ex)
            {

                return res = _helper.CreateResponse(ex.Message, false);
            }
        }
    }
}

