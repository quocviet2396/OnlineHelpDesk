using System;
using System.Globalization;
using LibraryModels;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
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
        public Response<string> res = new Response<string>();

        public DataServiceImp(DatabaseContext db, Helper helper, Mailultil mailultil)
        {
            _db = db;
            _helper = helper;
            _mailultil = mailultil;
        }

        public async Task<ICollection<UsersInfo>> AllUser(int pageNumber, int? Limit, string currentSort, string? currentFilter)
        {
            currentSort = string.IsNullOrEmpty(currentSort) ? "asc_Id" : currentSort;
            var sort = await Sort<UsersInfo>.SortAsync(_db.UsersInfo.ToList(), currentSort, currentFilter);
            //goi phuong thuc paginate de phan chia trang                csdl       skip     lay bao nhieu   orderby
            var result = await Paginated<UsersInfo>.CreatePaginate(sort.ToList(), pageNumber, (int)Limit, x => x.Id);
            return result;
        }

        public async Task<List<string>> AccCode()
        {
            return await _db.Users.Where(u => !string.IsNullOrEmpty(u.Code)).Select(u => u.Code).ToListAsync();
        }


        public async Task<Response<string>> CreateStudent(List<string> Student_code)
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
                            Email = _helper.CreateEmail(userinfo.FirstName, userinfo.LastName),
                            UserName = userinfo.FullName,
                            Password = BCrypt.Net.BCrypt.HashPassword(pass),
                            Status = true,
                            Code = userinfo.Student_code,
                            Role = Role.Student,

                        };


                        _db.Users.Add(user);
                        _db.SaveChanges();
                        int userId = user.Id;

                        UserInfo userInfo = new UserInfo()
                        {
                            Address = userinfo.Address,
                            DateOfBirth = DateTime.ParseExact(userinfo.DateOfBirth.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                            Gender = userinfo.Gender,
                            Phone = userinfo.Phone,
                            City = userinfo.City,
                            UserId = userId
                        };
                        _db.UserInfos.Add(userInfo);
                        _db.SaveChanges();

                        string content = _mailultil.formEmail(user.Email, pass);

                        _mailultil.SendMailGoogle(userinfo.Email, "Create account", content, Role.Admin);
                    }

                }
                return res = _helper.CreateResponse<string>("Successfully", true);
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse<string>(ex.Message, false);
            }
        }

    }
}