using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Ultils;

namespace WebApp.Controllers
{
    public class AuthenController : Controller
    {
        private readonly DatabaseContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly Helper _helper;
        private IAuthenService authenService;
        public AuthenController(DatabaseContext db, IHttpContextAccessor httpContextAccessor, IAuthenService authenService, Helper helper)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
            this.authenService = authenService;
            _helper = helper;
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
                return RedirectToAction("Index", "Frontend");
            }
            return View();
        }

        public Response<Users> IsLoginValid(string email, string password)
        {
            var user = db.Users.FirstOrDefault(a => a.Email == email);
            if (user != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (isPasswordValid)
                {
                    return _helper.CreateResponse<Users>("Successfully", true, user);
                }
                else
                {
                    return _helper.CreateResponse<Users>("Failure", false);

                }
            }
            else
            {
                return _helper.CreateResponse<Users>("Username or Password is invalid! Please try again or create a new one", false);

            }
            //trả về user nếu khác null, ngược lại thì false
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            if (IsLoginValid(user.Email, user.Password).Success)
            {

                HttpContext.Session.SetString("accEmail", user.Email);
                Console.WriteLine(IsLoginValid(user.Email, user.Password).Data.Code);
                HttpContext.Session.SetString("accCode", IsLoginValid(user.Email, user.Password).Data.Code);

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
                    return RedirectToAction("Index", "Frontend"); // Chuyển hướng đến trang frontend
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
