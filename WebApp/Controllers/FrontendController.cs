using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
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
