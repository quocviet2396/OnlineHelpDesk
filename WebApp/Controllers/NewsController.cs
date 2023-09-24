using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using WebApp.Database_helper;
using WebApp.Repositories;
using static WebApp.Services.NewsServiceImp;

namespace WebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly DatabaseContext _context;

        private readonly INewsService _news;

        public NewsController(DatabaseContext context, INewsService news)
        {
            _context = context;
            _news = news;
        }
        public IActionResult Index()
        {
            var allNews = _news.GetAllNews();

            return View(allNews);
        }
        [HttpPost]
        public IActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {

                _news.CreateNews(news);
                return RedirectToAction("Index");
            }
            return View(news);
        }
        public IActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult UpdateNews(News news)
        {
            if (ModelState.IsValid)
            {
                _news.UpdateNews(news);

                return RedirectToAction("Index");
            }
            return View(news);
        }

        public IActionResult Delete(int id)
        {
            _news.DeleteNews(id);

            return RedirectToAction("Index");
        }

        

    }
}
