using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryModels;
using WebApp.Database_helper;
using WebApp.Repositories;
using System.Net.Sockets;

namespace WebApp.Controllers
{
    public class PriorityController : Controller
    {
        private readonly DatabaseContext _context;

        private readonly IPriorityServices apriority;
        private readonly IAuthenService aService;

        public PriorityController(DatabaseContext context, IPriorityServices apriority, IAuthenService aService)
        {
            _context = context;
            this.apriority = apriority;
            this.aService = aService;
        }
        public async Task<IActionResult> Index()
        {
            if (!aService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }

            if (!aService.IsAdmin())
            {
                return RedirectToAction("Login", "Authen");
            }
            var priorities = await _context.Priority.ToListAsync();
            return View(priorities);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priority == null)
            {
                return NotFound();
            }

            return View(priority);
        }

        public IActionResult Create()
        {
            if (!aService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }

            if (!aService.IsAdmin())
            {
                return RedirectToAction("Login", "Authen");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Priority priority)
        {
            var existingStatus = await _context.Priority.FirstOrDefaultAsync(ts => ts.Name.ToLower() == priority.Name.ToLower());

            if (existingStatus != null)
            {
                ModelState.AddModelError("Name", "Status already exists.");
                return View(priority);
            }
            try
            {
                _context.Add(priority);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Create new Priority success!";
                TempData["MessageType"] = "success";
            }
            catch (Exception)
            {
                TempData["Message"] = "Create new Priority failed!";
                TempData["MessageType"] = "danger";
            }
            
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority.FindAsync(id);
            if (priority == null)
            {
                return NotFound();
            }
            return View(priority);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Priority priority)
        {
            if (id != priority.Id)
            {
                return NotFound();
            }

            var existingStatus = await _context.Priority.FirstOrDefaultAsync(ts => ts.Name.ToLower() == priority.Name.ToLower());

            if (existingStatus != null && existingStatus.Id != id)
            {
                ModelState.AddModelError("Name", "A state that already exists or overlaps with another state.");
                return View(priority);
            }

            try
            {
                await apriority.editPriority(priority);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Edit Priority success!";
                TempData["MessageType"] = "success";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(priority.Id))
                {
                    return NotFound();
                }
                else
                {
                    TempData["Message"] = "Edit Priority failed!";
                    TempData["MessageType"] = "danger";
                }

            }
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int[] arrList)
        {
            foreach (int item in arrList)
            {
                try
                {
                    var model = await apriority.deletePriority(item);
                    TempData["Message"] = "Remove a topic Priority success!";
                    TempData["MessageType"] = "success";
                    return RedirectToAction("Index", "Priority");

                }
                catch (Exception)
                {
                    TempData["Message"] = "Remove a topic Priority failed!";
                    TempData["MessageType"] = "danger";
                    return RedirectToAction("Index", "Priority");
                }
            }
            return RedirectToAction("Index");
        }

        private bool PriorityExists(int id)
        {
            return _context.Priority.Any(e => e.Id == id);
        }
    }
}