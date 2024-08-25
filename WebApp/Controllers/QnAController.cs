using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class QnAController : Controller
    {
        private readonly DatabaseContext db;
        private readonly IQnAService qnAService;
        private readonly IAuthenService authenService;
        public QnAController(DatabaseContext db, IAuthenService authenService, IQnAService qnAService)
        {
            this.db = db;
            this.authenService = authenService;
            this.qnAService = qnAService;
        }
        public async Task<IActionResult> Index()
        {
            if (!authenService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }

            if (!authenService.IsAdmin())
            {
                return RedirectToAction("Login", "Authen");
            }
            var qna = await db.QnA.ToListAsync();
            return View(qna);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (!authenService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }

            if (!authenService.IsAdmin())
            {
                return RedirectToAction("Login", "Authen");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QnA newQnA)
        {
            var existTitile = await db.QnA.FirstOrDefaultAsync(q => q.Title.ToLower() == newQnA.Title.ToLower());
            if (existTitile != null)
            {
                TempData["Message"] = "The Title already exists!!";
                TempData["MessageType"] = "danger";
                return View(newQnA);
            }    
            try
            {
                db.Add(newQnA);
                await db.SaveChangesAsync();
                TempData["Message"] = "Create a new topic QnA success!";
                TempData["MessageType"] = "success";
                return RedirectToAction("Index", "QnA");
            }
            catch (Exception)
            {
                TempData["Message"] = "Create failed!!";
                TempData["MessageType"] = "danger";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await qnAService.removeQnA(id);
                TempData["Message"] = "Remove a topic QnA success!";
                TempData["MessageType"] = "success";
                return RedirectToAction("Index", "QnA");

            }
            catch (Exception)
            {
                TempData["Message"] = "Remove a topic QnA failed!";
                TempData["MessageType"] = "danger";
                return RedirectToAction("Index", "QnA");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!authenService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }

            if (!authenService.IsAdmin())
            {
                return RedirectToAction("Login", "Authen");
            }
            var model = await qnAService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(QnA editQnA)
        {
            var existTitile = await db.QnA.FirstOrDefaultAsync(q => q.Title.ToLower() == editQnA.Title.ToLower());
            if (existTitile != null && existTitile.Id != editQnA.Id)
            {
                TempData["Message"] = "The Title already exists!!";
                TempData["MessageType"] = "danger";
                return View(editQnA);
            }
            try
            {
                await qnAService.updateQnA(editQnA);
                TempData["Message"] = "Update a topic QnA success!";
                TempData["MessageType"] = "success";
                return RedirectToAction("Index", "QnA");
            }
            catch (Exception)
            {
                TempData["Message"] = "Update a topic QnA failed!";
                TempData["MessageType"] = "danger";
            }
            return View();
        }
    }
}
