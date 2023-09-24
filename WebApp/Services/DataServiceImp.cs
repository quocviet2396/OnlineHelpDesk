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
        [Obsolete]
        private readonly IHostEnvironment _environment;
        public Response<string> res = new Response<string>();

        [Obsolete]
        public DataServiceImp(DatabaseContext db, Helper helper, Mailultil mailultil, IHostEnvironment environment)
        {
            _db = db;
            _helper = helper;
            _mailultil = mailultil;
            _environment = environment;
        }

        public async Task<ICollection<UsersInfo>> AllUser(int pageNumber, int? Limit, string currentSort)
        {
            currentSort = string.IsNullOrEmpty(currentSort) ? "asc_Id" : currentSort;
            var sort = await Sort<UsersInfo>.SortAsync(_db.UsersInfo.ToList(), currentSort);
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
                            DateOfBirth = DateTime.ParseExact(userinfo.DateOfBirth.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Gender = userinfo.Gender,
                            Phone = userinfo.Phone,
                            Photo = userinfo.Photo,
                            City = userinfo.City,
                            UserId = userId
                        };
                        _db.UserInfos.Add(userInfo);
                        _db.SaveChanges();

                        Console.WriteLine(BCrypt.Net.BCrypt.Verify(pass, user.Password));
                        //string content = System.IO.File.ReadAllText("Mail/account.html");
                        //content = content.Replace("{{email}}", user.Email);
                        //content = content.Replace("{{password}}", pass);

                        //_mailultil.SendMailGoogle(userinfo.Email, "Create account", content, Role.Admin);
                    }

                }
                return res = _helper.CreateResponse<string>("Successfully", true);
            }
            catch (Exception ex)
            {
                return res = _helper.CreateResponse<string>(ex.Message, false);
            }
        }


        public async Task<Response<string>> CreateAccount(IFormCollection users)
        {
            try
            {

                long fileSize = users.Files["photo"].Length;
                long maxSize = 2 * 1024 * 1024;
                if (fileSize > maxSize)
                {
                    return res = _helper.CreateResponse<string>("File size must be less than 2MB. Please choose a smaller file.", false);
                }
                var fileName = users.Files["photo"].FileName;
                var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot/assets/img/avatars", fileName);

                // Kiểm tra tệp trùng lặp
                if (!System.IO.File.Exists(filePath))
                {
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await users.Files["photo"].CopyToAsync(fileSteam);
                    }
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
                    Address = users["Address"].FirstOrDefault() ?? "",
                    City = users["City"].FirstOrDefault() ?? "",
                    Gender = bool.Parse(users["Gender"].FirstOrDefault()),
                    DateOfBirth = DateTime.ParseExact(users["DateOfBirth"].FirstOrDefault().ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Phone = users["Phone"].FirstOrDefault() ?? "",
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
    }
}

