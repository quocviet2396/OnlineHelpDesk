using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryModels;
using WebApp.Database_helper;
using WebApp.Repositories;

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TicketStatus ticketStatus)
        {
            
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TicketStatus ticketStatus)
        {
            if (id != ticketStatus.Id)
            {
                return NotFound();
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
                await ticket.deleteTicketStatus(item);
            }
            return RedirectToAction("Index");
        }


        private bool TicketStatusExists(int id)
        {
            return _context.TicketStatus.Any(e => e.Id == id);
        }

    }
}
