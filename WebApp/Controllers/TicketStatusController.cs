using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryModels;
using WebApp.Database_helper;
using WebApp.Repositories;
using System.Linq;
using System.Net.Sockets;


namespace WebApp.Controllers
{
    public class TicketStatusController : Controller
    {
        private readonly DatabaseContext _context;

        private readonly ITicketStatusServices ticket;
        private readonly IAuthenService aService;

        public TicketStatusController(DatabaseContext context, ITicketStatusServices ticket, IAuthenService aService)
        {
            _context = context;
            this.ticket = ticket;
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
            var ticketStatuses = await _context.TicketStatus.ToListAsync();
            return View(ticketStatuses);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketStatus = await _context.TicketStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketStatus == null)
            {
                return NotFound();
            }

            return View(ticketStatus);
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
        public async Task<IActionResult> Create(TicketStatus ticketStatus)
        {
            var existingStatus = await _context.TicketStatus.FirstOrDefaultAsync(ts => ts.Name.ToLower() == ticketStatus.Name.ToLower());

            if (existingStatus != null)
            {
                ModelState.AddModelError("Name", "Status already exists.");
                return View(ticketStatus);
            }

            _context.Add(ticketStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketStatus = await _context.TicketStatus.FindAsync(id);
            if (ticketStatus == null)
            {
                return NotFound();
            }
            return View(ticketStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketStatus ticketStatus)
        {
            if (id != ticketStatus.Id)
            {
                return NotFound();
            }

            var existingStatus = await _context.TicketStatus.FirstOrDefaultAsync(ts => ts.Name.ToLower() == ticketStatus.Name.ToLower());

            if (existingStatus != null && existingStatus.Id != id)
            {
                ModelState.AddModelError("Name", "A state that already exists or overlaps with another state.");
                return View(ticketStatus);
            }

            try
            {
                _context.Update(ticketStatus);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketStatusExists(ticketStatus.Id))
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
                try
                {
                    var model = await ticket.deleteTicketStatus(item);
                    TempData["Message"] = "Remove a topic TicketStatus success!";
                    TempData["MessageType"] = "success";
                    return RedirectToAction("Index", "TicketStatus");

                }
                catch (Exception)
                {
                    TempData["Message"] = "Remove a topic TicketStatus failed!";
                    TempData["MessageType"] = "danger";
                    return RedirectToAction("Index", "TicketStatus");
                }
            }
            return RedirectToAction("Index");
        }


        private bool TicketStatusExists(int id)
        {
            return _context.TicketStatus.Any(e => e.Id == id);
        }

    }
}
