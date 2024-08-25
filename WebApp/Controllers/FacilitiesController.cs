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

        private readonly IFacilitiesServices afacilities;
        private readonly IAuthenService aService;

        public FacilitiesController(DatabaseContext context, IFacilitiesServices afacilities, IAuthenService aService)
        {
            _context = context;
            this.afacilities = afacilities;
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
            var existingStatus = await _context.Facilities.FirstOrDefaultAsync(ts => ts.Name.ToLower() == facilities.Name.ToLower());

            if (existingStatus != null)
            {
                ModelState.AddModelError("Name", "Status already exists.");
                return View(facilities);
            }
            try
            {
                _context.Add(facilities);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Create new facilities success!";
                TempData["MessageType"] = "success";
            }
            catch (Exception)
            {
                TempData["Message"] = "Create new facilities failed!";
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

            var existingStatus = await _context.Facilities.FirstOrDefaultAsync(ts => ts.Name.ToLower() == facilities.Name.ToLower());

            if (existingStatus != null && existingStatus.Id != id)
            {
                ModelState.AddModelError("Name", "A state that already exists or overlaps with another state.");
                return View(facilities);
            }

            try
            {
                await afacilities.editFacilities(facilities);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Edit a Facilities success!";
                TempData["MessageType"] = "success";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitiesExists(facilities.Id))
                {
                    return NotFound();
                }
                else
                {
                    TempData["Message"] = "Edit Facilities failed!";
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
                    var model = await afacilities.deleteFacilities(item);
                    TempData["Message"] = "Remove a topic Facilities success!";
                    TempData["MessageType"] = "success";
                    return RedirectToAction("Index", "Facilities");

                }
                catch (Exception)
                {
                    TempData["Message"] = "Remove a topic Facilities failed!";
                    TempData["MessageType"] = "danger";
                    return RedirectToAction("Index", "Facilities");
                }
            }
            return RedirectToAction("Index");
        }

        private bool FacilitiesExists(int id)
        {
            return _context.Facilities.Any(e => e.Id == id);
        }
    }
}