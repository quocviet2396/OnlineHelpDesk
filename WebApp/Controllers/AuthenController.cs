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
                return View();
                //return RedirectToAction("Index", "Backend");
            }
            else if (authenService.IsUserLoggedIn() && authenService.IsSupporter())
            {
                return RedirectToAction("Index", "Backend");
            }
            else if (authenService.IsUserLoggedIn() && !authenService.IsAdmin() && !authenService.IsSupporter())
            {
                return RedirectToAction("Index", "Frontend");
            }
            return View();
        }

        public bool IsLoginValid (string email, string password)
        {
            var user = db.Users.FirstOrDefault(a => a.Email == email && a.Password == password);
            //trả về user nếu khác null, ngược lại thì false
            return user != null;
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            if(IsLoginValid(user.Email, user.Password))
            {
                HttpContext.Session.SetString("accEmail", user.Email);
                //chuyển trang theo role
                if(authenService.IsAdmin() || authenService.IsSupporter())
                {
                    return RedirectToAction("Index", "Backend");
                }
                else
                {
                    /*Chỗ này rồi sẽ sửa thành frontend home*/
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Message"] = "Username or Password is invalid!! Please try again or create new one";
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
