using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class AuthenServiceImp : IAuthenService
    {
        private readonly DatabaseContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AuthenServiceImp(DatabaseContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }
        public bool IsAdmin()
        {
            string accEmail = httpContextAccessor.HttpContext.Session.GetString("accEmail");
            var user = db.Users.FirstOrDefault(u => u.Email == accEmail);
            return user != null && user.Role.ToLower() == "admin";
        }

        public bool IsSupporter()
        {
            string accEmail = httpContextAccessor.HttpContext.Session.GetString("accEmail");
            var user = db.Users.FirstOrDefault(u => u.Email == accEmail);
            return user != null && user.Role.ToLower() == "supporter";
        }

        public bool IsUserLoggedIn()
        {
            string accEmail = httpContextAccessor.HttpContext.Session.GetString("accEmail");
            return !string.IsNullOrEmpty(accEmail);
        }
    }
}
