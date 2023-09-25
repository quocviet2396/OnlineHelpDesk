﻿using System;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Ultils;
using BCrypt.Net;
using System.Globalization;

namespace WebApp.Services
{
    public class AccountServiceImp : IAccountService
    {
        private readonly DatabaseContext _db;
        private readonly Helper _helper;
        public Response<string> res = new Response<string>();
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

        public UserInfoDTO UserInfo(string stuCodeId)
        {
            var user = _db.Users.Where(u => u.Code == stuCodeId).Include(c => c.userInfo).Select(
                c => new UserInfoDTO()
                {
                    Id = c.Id,
                    UserName = c.UserName,
                    Email = c.Email,
                    Code = c.Code,
                    Password = c.Password,
                    Status = c.Status,
                    Role = c.Role,
                    Gender = c.userInfo.Gender,
                    DateOfBirth = c.userInfo.DateOfBirth,
                    Phone = c.userInfo.Phone,
                    Photo = c.userInfo.Phone,
                    Address = c.userInfo.Address,
                    City = c.userInfo.City
                }).SingleOrDefault();
            return user;
        }

        public async Task<Users> users(string stuCodeId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Code == stuCodeId);
            return user;
        }


        public async Task<Response<string>> ResetPassword(string code)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Code == code);
                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword("123456");
                    _db.SaveChanges();
                    return res = _helper.CreateResponse<string>("Success", true);
                }
                else { return res = _helper.CreateResponse<string>("Failure", false); }
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse<string>(ex.Message, false);
            }
        }

        public async Task<Response<string>> CheckPassword(string value, string key, string code, string newPas, string conPas)
        {
            var oldPass = await _db.Users.FirstOrDefaultAsync(p => p.Code == code);
            switch (key)
            {
                case "oldPassword":
                    var result = oldPass != null ? BCrypt.Net.BCrypt.Verify(value, oldPass.Password) : false;
                    if (result)
                    {
                        return res = _helper.CreateResponse<string>("", result);
                    }
                    else
                    {
                        return res = _helper.CreateResponse<string>("Old password is not valid", result);
                    }
                case "newPassword":
                    var result2 = BCrypt.Net.BCrypt.Verify(value, oldPass.Password);
                    var result3 = conPas == value;
                    if (result2)
                    {
                        return res = _helper.CreateResponse<string>("The new password cannot be the same as the old password", !result2);
                    }
                    else if (result3)
                    {
                        return res = _helper.CreateResponse<string>("", result3);
                    }
                    else
                    {
                        return res = _helper.CreateResponse<string>("Confirm password not same", result3);

                    }
                case "confirmPassword":
                    var result4 = newPas == value;
                    if (result4)
                    {
                        return res = _helper.CreateResponse<string>("", result4);
                    }
                    else
                    {
                        return res = _helper.CreateResponse<string>("Confirm password not same", result4);
                    }
                default:
                    break;
            }
            return res = _helper.CreateResponse<string>("fail", false);
        }


        public async Task<Response<string>> ChangePassword(string pass, string code)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(p => p.Code == code);
                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(pass);
                    _db.SaveChanges();
                    return res = _helper.CreateResponse<string>("Change password successfully", true);
                }
                else
                {
                    return res = _helper.CreateResponse<string>("Some thing wrongs", false);
                }
            }
            catch (Exception ex)
            {

                return res = _helper.CreateResponse<string>(ex.Message, false);
            }
        }



        public async Task<Response<string>> CheckPhoto(IFormCollection photo)
        {
            if (photo.Files["photo"] != null)
            {
                long fileSize = photo.Files["photo"].Length;
                long maxSize = 2 * 1024 * 1024;
                if (fileSize > maxSize)
                {
                    return res = _helper.CreateResponse<string>("File size must be less than 2MB. Please choose a smaller file.", false);
                }

                var fileName = photo.Files["photo"].FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img/avatars", fileName);

                // Kiểm tra tệp trùng lặp
                if (!System.IO.File.Exists(filePath))
                {
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.Files["photo"].CopyToAsync(fileSteam);
                    }
                }
                return res = _helper.CreateResponse<string>("Upload file successfully", true, filePath);
            }
            else
            {
                return res = _helper.CreateResponse<string>("Upload file failure", false);
            }
        }

        public async Task<Response<string>> CreateAccount(IFormCollection users)
        {
            try
            {
                if (string.IsNullOrEmpty(users["Email"]) || string.IsNullOrEmpty(users["Role"]) || string.IsNullOrEmpty(users["Password"]) || string.IsNullOrEmpty(users["Username"]))
                {
                    return res = _helper.CreateResponse<string>("Field is not blank", false);
                }

                var checkphoto = await CheckPhoto(users);
                var filePath = checkphoto.Data;
                var hasEmail = await _db.Users.FirstOrDefaultAsync(e => e.Email.Equals(users["Email"].FirstOrDefault()));
                if (hasEmail != null)
                {
                    return res = _helper.CreateResponse<string>("Email has already", false);
                }

                Users user = new Users()
                {
                    Email = users["Email"].FirstOrDefault(),
                    Password = BCrypt.Net.BCrypt.HashPassword(users["Password"]),
                    Status = true,
                    UserName = users["Username"].FirstOrDefault(),
                    Role = users["Role"],
                    Code = $"{users["Role"]}{_helper.randomString(10)}",
                };

                _db.Add(user);
                _db.SaveChanges();
                int userId = user.Id;
                UserInfo userInfo = new UserInfo()
                {
                    Address = users["Address"].FirstOrDefault() ?? null,
                    City = users["City"].FirstOrDefault() ?? null,
                    Gender = bool.TryParse(users["Gender"].FirstOrDefault(), out var parsedGender) ? (bool?)parsedGender : null,
                    DateOfBirth = DateTime.TryParseExact(users["DateOfBirth"].FirstOrDefault()?.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDateOfBirth) ? (DateTime?)parsedDateOfBirth : null,
                    Phone = users["Phone"].FirstOrDefault() ?? null,
                    Photo = filePath,
                    UserId = userId
                };

                _db.UserInfos.Add(userInfo);
                _db.SaveChanges();


                return res = _helper.CreateResponse<string>("Successfully", true);
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse<string>(ex.Message, false);
            }
        }


        public async Task<Response<string>> InfoChange(IFormCollection form)
        {
            try
            {
                UserInfo userinfo = new UserInfo()
                {
                    Address = form["Address"].FirstOrDefault() ?? null,
                    DateOfBirth = DateTime.TryParseExact(form["DateOfBirth"].FirstOrDefault()?.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDateOfBirth) ? (DateTime?)parsedDateOfBirth : null,
                    City = form["City"].FirstOrDefault() ?? null,
                    Gender = bool.TryParse(form["Gender"].FirstOrDefault(), out var parsedGender) ? (bool?)parsedGender : null,
                    Phone = form["Phone"].FirstOrDefault() ?? null,
                    UserId = int.Parse(form["AccId"].FirstOrDefault()),
                };


                return res = _helper.CreateResponse<string>("Change password successfully", true);
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse<string>(ex.Message, false);
            }
        }

    }
}

