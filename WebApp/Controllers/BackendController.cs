using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class BackendController : Controller
    {
        private readonly DatabaseContext db;
        private readonly IAuthenService authenService;
        public BackendController(DatabaseContext db, IAuthenService authenService)
        {
            this.db = db;
            this.authenService = authenService;
        }

        public IActionResult Index()
        {
            if (!authenService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }
            if (!authenService.IsAdmin() && !authenService.IsSupporter())
            {
                return RedirectToAction("Login", "Authen");
            }
            /*if (!authenService.IsSupporter())
            {
                return RedirectToAction("Login", "Authen");
            }*/
            return View();
        }


    }
}
