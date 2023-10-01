/*using LibraryModels;
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
                var email = HttpContext.Session.GetString("accEmail") != null ? HttpContext.Session.GetString("accEmail") : "";
                _news.CreateNews(news, email);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(news);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(News news, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string path = Path.Combine("wwwroot/images/News", file.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    news.Img = file.FileName;
                }
                await _news.CreateNews(news);
                TempData["msg"] = "Congratulation !!! Create a news success";
                return RedirectToAction("Index", "News");
            }
            catch (Exception ex)
            {
                ViewBag.errormsg = "Create a news fail";
                ModelState.AddModelError(String.Empty, ex.Message);
            }
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


        public IActionResult UpdateNews(int id)
        {
            var model = _context.News.FirstOrDefault(x => x.Id == id);
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

        public async Task<IActionResult> NewsDetail(int id)
        {
            var newsItem = await _news.GetNewsById(id);
            if (newsItem == null)
            {
                return NotFound();
            }
            return View(newsItem);
        }

        public async Task<IActionResult> News()
        {
            var allNews = _news.GetAllNews();

            return View(allNews);
        }
    }
}*/


using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using WebApp.Authorize;
using WebApp.Database_helper;
using WebApp.Repositories;
using static WebApp.Services.NewsServiceImp;


namespace ProjectSoccerClubApp.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private IAuthenService _authenService;
        private INewsService service;
        public NewsController(INewsService service, IAuthenService authenService)
        {
            this.service = service;
            _authenService = authenService;
        }
        public async Task<IActionResult> Index()
        {
            var news = await service.GetNewsList();
            return View(news);
        }

        public async Task<IActionResult> News()
        {
            var allNews = await service.GetNewsList();

            return View(allNews);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(News newNews, IFormFile file)
        {
            if (_authenService.IsAdmin())
            {
                try
                {
                    if (file != null)
                    {
                        string path = Path.Combine("wwwroot/images/News", file.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        await file.CopyToAsync(stream);
                        newNews.Img = file.FileName;
                    }
                    await service.addNews(newNews);
                    TempData["msg"] = "Congratulation !!! Create a news success";
                    return RedirectToAction("Index", "News");
                }
                catch (Exception ex)
                {
                    ViewBag.errormsg = "Create a news fail";
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await service.removeNews(id);
                TempData["msg"] = "Delete News Success";
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                ViewBag.errormsg = "Delete News Fail";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var model = await service.GetNewsById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(News editNews, IFormFile file)
        {

            var oldNews = await service.GetNewsById(editNews.ID);
            if (oldNews != null)
            {
                if (file != null)
                {
                    string path = Path.Combine("wwwroot/images/News", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    if (!string.IsNullOrEmpty(oldNews.Img))
                    {

                        string OldPath = Path.Combine("wwwroot/images/News", oldNews.Img);

                        if (System.IO.File.Exists(OldPath))
                        {
                            System.IO.File.Delete(OldPath);
                        }
                    }
                }
            }
            else
            {
                ViewBag.error = "Edit fail";
                return View();
            }
            editNews.Img = file != null ? file.FileName : oldNews.Img;
            oldNews.Title = editNews.Title;
            oldNews.Content = editNews.Content;
            oldNews.Author = editNews.Author;
            oldNews.PublishDate = editNews.PublishDate;
            oldNews.Img = editNews.Img;
            await service.updateNews(editNews);
            TempData["msg"] = "Congratulation !!! Edit Success";
            return RedirectToAction("Index");
        }

        
    }  
}

