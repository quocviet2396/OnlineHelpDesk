using Microsoft.AspNetCore.Mvc;
using WebApp.Authorize;

namespace WebApp.Controllers
{
    [Authorize]
    public class FrontendController : Controller
    {
        private readonly ILogger<FrontendController> logger;


        public FrontendController(ILogger<FrontendController> logger)
        {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
