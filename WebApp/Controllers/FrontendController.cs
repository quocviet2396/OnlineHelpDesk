using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class FrontendController : Controller
    {
        private readonly ILogger<FrontendController> logger;
        private readonly IQnAService qnAService;
        private readonly INewsService service;

        public FrontendController(ILogger<FrontendController> logger, IQnAService qnAService, INewsService service)
        {
            this.logger = logger;
            this.qnAService = qnAService;
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> QnA()
        {
            var qna = await qnAService.GetAll();
            return View(qna);
        }
        public async Task<IActionResult> QnADetail(int id)
        {
            var qna = await qnAService.GetById(id);
            if (qna == null)
            {
                return NotFound();
            }
            return View(qna);
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
