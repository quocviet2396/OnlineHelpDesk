using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class FrontendController : Controller
    {
        private readonly ILogger<FrontendController> logger;
        private readonly IQnAService qnAService;

        public FrontendController(ILogger<FrontendController> logger, IQnAService qnAService)
        {
            this.logger = logger;
            this.qnAService = qnAService;
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
    }
}
