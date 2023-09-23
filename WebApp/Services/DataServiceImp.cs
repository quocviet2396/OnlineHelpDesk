﻿using System;
using LibraryModels;
using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Ultils;

namespace WebApp.Services
{
    public class DataServiceImp : IDataService
    {
        private readonly DatabaseContext _db;
        private readonly Helper _helper;
        private readonly Mailultil _mailultil;
        public Response res = new Response();
        public DataServiceImp(DatabaseContext db, Helper helper, Mailultil mailultil)
        {
            _db = db;
            _helper = helper;
            _mailultil = mailultil;
        }

        public async Task<ICollection<UsersInfo>> AllUser(int pageNumber, int? Limit, string currentSort)
        {
            currentSort = string.IsNullOrEmpty(currentSort) ? "asc_Id" : currentSort;
            var sort = await Sort<UsersInfo>.SortAsync(_db.UsersInfo.ToList(), currentSort);
            //goi phuong thuc paginate de phan chia trang           goi csdl de phan trang      skip     lay bao nhieu   orderby
            var result = await Paginated<UsersInfo>.CreatePaginate(sort.ToList(), pageNumber, (int)Limit, x => x.Id);
            return result;
        }


        public async Task<Response> CreateStudent(List<string> Student_code)
        {
            try
            {
                foreach (var item in Student_code)
                {
                    var Account = _db.Users.SingleOrDefault(a => a.Code == item);
                    var userinfo = _db.UsersInfo.SingleOrDefault(u => u.Student_code == item);
                    if (Account == null && userinfo != null)
                    {
                        string pass = _helper.randomString(10);
                        Users user = new Users
                        {
                            Email = _helper.CreateEmail(userinfo.FirstName, userinfo.LastName, userinfo.DateOfBirth),
                            UserName = userinfo.FullName,
                            Password = BCrypt.Net.BCrypt.HashPassword(pass),
                            Status = true,
                            Code = userinfo.Student_code,
                            Role = Role.Student,

                        };


                        _db.Users.Add(user);
                        int userId = user.Id;

                        UserInfo userInfo = new UserInfo()
                        {
                            Address = userinfo.Address,
                            DateOfBirth = userinfo.DateOfBirth,
                            Gender = userinfo.Gender,
                            Phone = userinfo.Phone,
                            Photo = null,
                            UserId = userId
                        };

                        _db.SaveChanges();

                        Console.WriteLine(BCrypt.Net.BCrypt.Verify(pass, user.Password));
                        //string content = System.IO.File.ReadAllText("Mail/account.html");
                        //content = content.Replace("{{email}}", user.Email);
                        //content = content.Replace("{{password}}", pass);

                        //_mailultil.SendMailGoogle(userinfo.Email, "Create account", content, Role.Admin);
                    }

                }
                return res = _helper.CreateResponse("Successfully", true);
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse(ex.Message, false);
            }
        }


        public async Task<Response> CreateAccount(Users users)
        {
            try
            {
                await _db.AddAsync(users);
                await _db.SaveChangesAsync();
                return res = _helper.CreateResponse("Successfully", true);
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse(ex.Message, false);
            }
        }
    }
}

