using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;
using LibraryModels;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class FacilitiesController : Controller
    {
        private readonly DatabaseContext _context;

        private readonly IFacilitiesServices facilities;
        private readonly IAuthenService aService;

        public FacilitiesController(DatabaseContext context, IFacilitiesServices facilities, IAuthenService aService)
        {
            _context = context;
            this.facilities = facilities;
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
            var facilities = await _context.Facilities.Include(sp=>sp.Supporter).ToListAsync();
            return View(facilities);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilities = await _context.Facilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facilities == null)
            {
                return NotFound();
            }

            return View(facilities);
        }

        public IActionResult Create()
        {
            var suporter = _context.Users.
                Where(u => u.Role == "Supporter").Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Email
                }).ToList();
            suporter.Insert(0, new SelectListItem { Value = "", Text = "Select Supporter" });
            ViewBag.SupporterEmails = suporter;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Facilities facilities)
        {
            var suporter = _context.Users.
                Where(u => u.Role == "Supporter").Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Email
                }).ToList();
            suporter.Insert(0, new SelectListItem { Value = "", Text = "Select Supporter" });
            ViewBag.SupporterEmails = suporter;
            _context.Add(facilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var suporter = _context.Users.
                Where(u => u.Role == "Supporter").Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Email
                }).ToList();
            suporter.Insert(0, new SelectListItem { Value = "", Text = "Select Supporter" });
            ViewBag.SupporterEmails = suporter;
            var facilities = await _context.Facilities.FindAsync(id);
            if (facilities == null)
            {
                return NotFound();
            }
            return View(facilities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Facilities facilities)
        {
            if (id != facilities.Id)
            {
                return NotFound();
            }

            try
            {
                var suporter = _context.Users.
                Where(u => u.Role == "Supporter").Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Email
                }).ToList();
                suporter.Insert(0, new SelectListItem { Value = "", Text = "Select Supporter" });
                ViewBag.SupporterEmails = suporter;
                _context.Update(facilities);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitiesExists(facilities.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int[] arrList)
        {
            foreach (int item in arrList)
            {
                await facilities.deleteFacilities(item);
            }
            return RedirectToAction("Index");
        }

        private bool FacilitiesExists(int id)
        {
            return _context.Facilities.Any(e => e.Id == id);
        }
    }
}