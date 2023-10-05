using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using WebApp.Authorize;
using WebApp.Database_helper;
using WebApp.Repositories;
using static WebApp.Services.NewsServiceImp;


namespace WebApp.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private IAuthenService _authenService;
        private INewsService service;
        private DatabaseContext dbContext;
        public NewsController(INewsService service, IAuthenService authenService, DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            this.service = service;
            _authenService = authenService;
        }
        public async Task<IActionResult> Index()
        {
            var news = await service.GetNewsList();
            return View(news);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(News newNews, IFormFile file)
        {
            if (_authenService.IsAdmin() || _authenService.IsSupporter())
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
                    var email = HttpContext.Session.GetString("accEmail") != null ? HttpContext.Session.GetString("accEmail") : "";
                    await service.addNews(newNews, email);
                    TempData["msg"] = "Congratulation !!! Create a news success";
                    return RedirectToAction("Index", "News");
                }
                catch (Exception ex)
                {
                    ViewBag.errormsg = "Create a news fail";
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
                return RedirectToAction("Index", "News");
            }
            return View();
        }

        [HttpGet]
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

        public async Task<IActionResult> News()
        {
            var allNews = await service.GetNewsList();

            return View(allNews);
        }

        public async Task<IActionResult> NewsDetail(int id)
        {
            var comments = service.GetCommentById(id);
            ViewBag.Comments = comments;

            var newsItem = await service.GetNewsById(id);

            if (newsItem == null)
            {
                return NotFound();
            }
            return View(newsItem);
        }

        [HttpPost]
        public IActionResult AddComment(int mewId, string cmt)
        {
            try
            {
                var useremail = HttpContext.Session.GetString("accEmail");
                var user = dbContext.Users.FirstOrDefault(a => a.Email.Equals(useremail));
                Comment comment = new Comment()
                {
                    Text = cmt,
                    Date = DateTime.Now,
                    UserName = user.UserName,
                    NewId = mewId,
                    
                };
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();

                return RedirectToAction("NewsDetail");

            }
            catch (Exception)
            {

                return View("Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Hidden(int id, News news)
        {
            var nws = await service.GetNewsById(id);
            nws.Status = 0;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

