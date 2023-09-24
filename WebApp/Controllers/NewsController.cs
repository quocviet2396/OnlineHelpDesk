using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (!ModelState.IsValid)
            {
                _news.CreateNews(news);
                _context.SaveChangesAsync();
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
            if (!ModelState.IsValid)
            {
_news.UpdateNews(news);

                return RedirectToAction("Index");
            }
                return View();

        }
        

        public IActionResult UpdateNews(int id) {
            var model=_context.News.FirstOrDefault(x => x.Id == id);
            return View(model);

        }

         private bool NewsExists(int id)
        {
            return _context.News.Any(n => n.Id == id);
        }

        public IActionResult Delete(int id)
        {
            _news.DeleteNews(id);

            return RedirectToAction("Index");
        }

        

    }
}
