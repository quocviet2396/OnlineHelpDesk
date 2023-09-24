using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class AuthenController : Controller
    {
        private readonly DatabaseContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private IAuthenService authenService;
        public AuthenController(DatabaseContext db, IHttpContextAccessor httpContextAccessor, IAuthenService authenService)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
            this.authenService = authenService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (authenService.IsUserLoggedIn() && authenService.IsAdmin())
            {
                return RedirectToAction("Index", "Backend");
            }
            else if (authenService.IsUserLoggedIn() && authenService.IsSupporter())
            {
                return RedirectToAction("Index", "Backend");
            }
            else if (authenService.IsUserLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public bool IsLoginValid(string email, string password)
        {
            var user = db.Users.FirstOrDefault(a => a.Email == email && a.Password == password);
            //trả về user nếu khác null, ngược lại thì false
            return user != null;
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            if (IsLoginValid(user.Email, user.Password))
            {
                HttpContext.Session.SetString("accEmail", user.Email);
                /*HttpContext.Session.SetString("accCode", user.Code);*/
                // Chuyển trang theo role
                if (authenService.IsAdmin())
                {
                    user.Role = "Admin";
                    HttpContext.Session.SetString("accRole", user.Role);
                    return RedirectToAction("Index", "Backend");
                }
                else if (authenService.IsSupporter())
                {
                    user.Role = "Supporter";
                    HttpContext.Session.SetString("accRole", user.Role);
                    return RedirectToAction("Index", "Backend");
                }
                else
                {
                    user.Role = "User";
                    HttpContext.Session.SetString("accRole", user.Role);
                    return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang frontend
                }
            }
            else
            {
                TempData["Message"] = "Username or Password is invalid! Please try again or create a new one.";
                TempData["MessageType"] = "danger";
            }

            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("accEmail") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                HttpContext.Session.Remove("accEmail");
                /*Chỗ này rồi sẽ sửa thành frontend home*/
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
