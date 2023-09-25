using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;
using System.Linq;
using LibraryModels;
using WebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Database_helper;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicket ticketService;
        private readonly DatabaseContext context;
        private readonly IAuthenService authService;
        public TicketController(ITicket ticketService, DatabaseContext context, IAuthenService authService)
        {
            this.ticketService = ticketService;
            this.context = context;
            this.authService = authService;
        }


        public async Task<IActionResult> Index()
        {
            if (!authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }

            if (authService.IsAdmin())
            {
                var tickets = await context.Ticket
                    .Include(t => t.Creator).Include(f => f.Category).Include(ts => ts.TicketStatus).Include(sp=>sp.Supporter)
                    .OrderByDescending(t => t.CreateDate)
                    .ToListAsync();

                return View(tickets);
            }
            else if (authService.IsSupporter())
            {
                string supporterEmail = HttpContext.Session.GetString("accEmail");

                if (string.IsNullOrEmpty(supporterEmail))
                {
                    // Xử lý trường hợp email không hợp lệ.
                    return RedirectToAction("Login", "Authen");
                }

                ViewBag.AccountName = supporterEmail;

                var tickets = await context.Ticket
                    .Include(t => t.Creator).Include(f => f.Category).Include(ts => ts.TicketStatus)
                    .Where(t => t.Supporter.Email == supporterEmail)
                    .OrderByDescending(t => t.CreateDate)
                    .ToListAsync();

                return View(tickets);
            }
            else
            {
                // Nếu người dùng không phải là "admin" hoặc "supporter", chỉ hiển thị danh sách ticket của họ
                string userEmail = HttpContext.Session.GetString("accEmail");

                if (string.IsNullOrEmpty(userEmail))
                {
                    // Xử lý trường hợp email không hợp lệ.
                    return RedirectToAction("Login", "Authen");
                }

                ViewBag.AccountName = userEmail;

                var tickets = await context.Ticket
                    .Include(t => t.Creator).Include(f => f.Category).Include(ts => ts.TicketStatus)
                    .Where(t => t.Creator.Email == userEmail)
                    .OrderByDescending(t => t.CreateDate)
                    .ToListAsync();

                return View(tickets);
            }
        }




        public async Task<IActionResult> Details(int id)
        {
            var ticket = await ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            // Lấy thông tin của TicketStatus cho Ticket
            var ticketStatus = await context.TicketStatus.FirstOrDefaultAsync(ts => ts.Id == ticket.TicketStatusId);

            // Kiểm tra xem có TicketStatus tương ứng hay không
            if (ticketStatus != null)
            {
                // Thêm thông tin TicketStatus.Name vào ViewData để sử dụng trong View
                ViewData["TicketStatusName"] = ticketStatus.Name;
            }
            else
            {
                ViewData["TicketStatusName"] = "Unknown"; // Nếu không tìm thấy TicketStatus
            }

            // Lấy thông tin của Category cho Ticket
            var category = await context.Facilities.FirstOrDefaultAsync(f => f.Id == ticket.CategoryId);

            // Lấy thông tin của Creator cho Ticket
            var creator = await context.Users.FirstOrDefaultAsync(u => u.Id == ticket.CreatorId);

            // Lấy thông tin của Supporter (nếu có) cho Ticket
            var supporter = await context.Users.FirstOrDefaultAsync(u => u.Id == ticket.SupporterId);

            // Đặt thông tin vào ViewBag hoặc ViewData để sử dụng trong View
            ViewBag.Category = category;
            ViewBag.Creator = creator;
            ViewBag.Supporter = supporter;

            return View(ticket);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var ticketStatusOptions = context.TicketStatus
        .Select(ts => new SelectListItem
        {
            Value = ts.Id.ToString(), // Giá trị là Id của trạng thái
            Text = ts.Name // Văn bản là tên của trạng thái
        })
        .ToList();

            // Thêm một tùy chọn mặc định nếu cần
            ticketStatusOptions.Insert(0, new SelectListItem { Value = "", Text = "Chọn trạng thái" });

            // Gán danh sách tùy chọn cho ViewBag.TicketStatusId
            ViewBag.TicketStatusId = ticketStatusOptions;
            var facilities = context.Facilities.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text
                   = f.Name
            }).ToList();
            facilities.Insert(0, new SelectListItem { Value = "", Text = "Select Catagory" });
            ViewBag.CategoryId = facilities;

            return View();
          
        }

        [HttpPost]
        public IActionResult Create(Ticket NewTicket, IFormFile? file)
        {
            var test = (HttpContext.Session.GetString("accEmail")).ToString();
            var idUser = context.Users.Where(x=>x.Email == test).FirstOrDefault().Id;
            try
            {

                var facilities = context.Facilities.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text
                    = f.Name
                }).ToList();
                facilities.Insert(0, new SelectListItem { Value = "", Text = "Select Catagory" });
                ViewBag.CategoryId = facilities;
                var ticketStatusOptions = context.TicketStatus
                    .Select(ts => new SelectListItem
                    {
                        Value = ts.Id.ToString(), // Giá trị là Id của trạng thái
                        Text = ts.Name // Văn bản là tên của trạng thái
                    })
                    .ToList();

                // Thêm một tùy chọn mặc định nếu cần
                ticketStatusOptions.Insert(0, new SelectListItem { Value = "", Text = "Select status" });

                // Gán danh sách tùy chọn cho ViewBag.TicketStatusId
                ViewBag.TicketStatusId = ticketStatusOptions;

                if (ModelState.IsValid)
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/attachment");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        NewTicket.Attachment = uniqueFileName;

                        // Kiểm tra xem ngày tạo đã được cung cấp hay chưa
                        if (NewTicket.CreateDate == null)
                        {
                            NewTicket.CreateDate = DateTime.Now; // Gán giá trị ngày và giờ tạo (ngày hiện tại)
                        }

                        // Lưu phiếu mới vào cơ sở dữ liệu
                        NewTicket.CreatorId = idUser;
                        ticketService.create(NewTicket);

                        return RedirectToAction("Index"); // Chuyển hướng về trang danh sách phiếu sau khi tạo thành công.
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Please select a file for attachment.");
                    }
                
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(NewTicket); // Trả về trang tạo phiếu với dữ liệu phiếu đã nhập và thông báo lỗi (nếu có).
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            // Lấy thông tin của TicketStatus cho Ticket
            var ticketStatus = await context.TicketStatus.FirstOrDefaultAsync(ts => ts.Id == ticket.TicketStatusId);

            // Kiểm tra xem có TicketStatus tương ứng hay không
            if (ticketStatus != null)
            {
                // Thêm thông tin TicketStatus.Name vào ViewData để sử dụng trong View
                ViewData["TicketStatusName"] = ticketStatus.Name;
            }
            else
            {
                ViewData["TicketStatusName"] = "Unknown"; // Nếu không tìm thấy TicketStatus
            }

            return View(ticket);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var isDeleted = await ticketService.delete(id);

            if (!isDeleted)
            {
                // Xử lý lỗi nếu việc xóa không thành công.
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            // Lấy danh sách trạng thái
            var ticketStatusOptions = context.TicketStatus
                .Select(ts => new SelectListItem
                {
                    Value = ts.Id.ToString(),
                    Text = ts.Name
                })
                .ToList();
            var facilities = context.Facilities.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text
                  = f.Name
            }).ToList();
            facilities.Insert(0, new SelectListItem { Value = "", Text = "Select Catagory" });
            ViewBag.CategoryId = facilities;

            ViewBag.TicketStatusId = ticketStatusOptions;
            //       var supporterEmails = await context.Users
            //.Where(u => u.Role == "Supporter") // Lọc theo vai trò Supporter
            //.Select(u => u.Email)
            //.ToListAsync();

            //       var supporterSelectListItems = supporterEmails.Select(email => new SelectListItem
            //       {
            //           Value = email.ToString(),
            //           Text = email
            //       }).ToList();

            //       ViewBag.SupporterEmails = supporterSelectListItems;
            var suporter = context.Users.
                Where(u => u.Role == "Supporter").Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Email
                }).ToList();
            suporter.Insert(0, new SelectListItem { Value = "", Text = "Select Supporter" });
            ViewBag.SupporterEmails=suporter;


            return View(ticket);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ticket editTicket, IFormFile file, DateTime dateTime)
        {
            // Lấy phiếu cũ từ cơ sở dữ liệu
            var oldTicket = await ticketService.GetTicketById(id);
            if (oldTicket == null)
            {
                return NotFound();
            }

            // Xử lý tệp mới nếu có
            if (file != null)
            {
                // Lưu tệp mới vào thư mục
                string path = Path.Combine("wwwroot/images/attachment", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Xóa tệp cũ nếu có
                if (!string.IsNullOrEmpty(oldTicket.Attachment))
                {
                    string oldPath = Path.Combine("wwwroot/images/attachment", oldTicket.Attachment);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                // Cập nhật tên tệp mới cho phiếu
                oldTicket.Attachment = file.FileName;
            }

            // Cập nhật thông tin phiếu từ form chỉnh sửa
            oldTicket.Title = editTicket.Title;
            oldTicket.Description = editTicket.Description;
            oldTicket.CategoryId = editTicket.CategoryId;
            

            // Kiểm tra xem người dùng có phải là admin không
            if (authService.IsAdmin())
            {
                // Nếu là admin, cho phép cập nhật TicketStatusId và SupporterId
                oldTicket.TicketStatusId = editTicket.TicketStatusId;
                oldTicket.SupporterId = editTicket.SupporterId;
                oldTicket.ModifiedDate = dateTime;
            }
            else if (authService.IsSupporter())
            {
                // Nếu là Supporter, cho phép cập nhật TicketStatusId
                oldTicket.TicketStatusId = editTicket.TicketStatusId;
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            await ticketService.update(oldTicket);

            TempData["Message"] = "Edit Ticket Success.";
            TempData["MessageType"] = "Success";
            return RedirectToAction("Index", "Ticket");
        }











        [HttpPost]
        public async Task<IActionResult> Filter(int categoryId)
        {
            var filteredTickets = await ticketService.GetTicketById(categoryId);
            return View("Index", filteredTickets);
        }


    }
}
