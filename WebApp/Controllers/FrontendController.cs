using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class FrontendController : Controller
    {
        private readonly ILogger<FrontendController> logger;
        private readonly INewsService service;
        

        public FrontendController(ILogger<FrontendController> logger, INewsService service)
        {
            this.logger = logger;
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> News()
        {
            var news = await service.GetNewsList();
            return View(news);
        }
        [HttpGet]
        public async Task<IActionResult> NewsDetail(int id)
        {

            var newsItem = await service.GetNewsById(id);

            if (newsItem == null)
            {
                return NotFound();
            }
            return View(newsItem);
        }
    }
}
