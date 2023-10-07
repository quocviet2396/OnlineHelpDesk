
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;
using System.Linq;
using LibraryModels;
using WebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Database_helper;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using System.Drawing.Printing;
using WebApp.Models.ViewModels;
using Newtonsoft.Json;

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




        public async Task<IActionResult> Index(int? page)
        {

            int pageSize = 10;
            int pageNumber = page ?? 1;

            if (!authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }

            if (authService.IsAdmin())
            {
                ViewData["Layout"] = "_BackendLayout";

                int totalTicketCount = await context.Ticket.CountAsync();
                ViewBag.AccountName = HttpContext.Session.GetString("accEmail");

                var tickets = await context.Ticket
                    .Include(t => t.Creator)
                    .Include(f => f.Category)
                    .Include(ts => ts.TicketStatus)
                    .Include(sp => sp.Supporter)
                    .Include(pr => pr.Priority)
                    .OrderByDescending(t => t.CreateDate)
                    .ToPagedListAsync(pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalItemCount = totalTicketCount;

                return View(tickets);
            }
            else if (authService.IsSupporter())
            {
                ViewData["Layout"] = "_BackendLayout";
                string supporterEmail = HttpContext.Session.GetString("accEmail");

                if (string.IsNullOrEmpty(supporterEmail))
                {
                    return RedirectToAction("Login", "Authen");
                }

                ViewBag.AccountName = supporterEmail;
                int totalTicketCount = await context.Ticket
                    .Where(t => t.Supporter.Email == supporterEmail)
                    .CountAsync();

                var tickets = await context.Ticket
                    .Include(t => t.Creator)
                    .Include(f => f.Category)
                    .Include(ts => ts.TicketStatus)
                    .Include(sp => sp.Supporter)
                    .Include(pr => pr.Priority)
                    .Where(t => t.Supporter.Email == supporterEmail)
                    .OrderByDescending(t => t.CreateDate)
                    .ToPagedListAsync(pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalItemCount = totalTicketCount;

                return View(tickets);
            }
            else
            {
                ViewBag.us = "hidden";
                ViewData["Layout"] = "_Layout";
                string userEmail = HttpContext.Session.GetString("accEmail");

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Login", "Authen");
                }

                ViewBag.AccountName = userEmail;

                int totalTicketCount = await context.Ticket
                    .Where(t => t.Creator.Email == userEmail)
                    .CountAsync();

                var tickets = await context.Ticket
                    .Include(t => t.Creator)
                    .Include(f => f.Category)
                    .Include(ts => ts.TicketStatus)
                    .Include(sp => sp.Supporter)
                    .Include(pr => pr.Priority)
                    .Where(t => t.Creator.Email == userEmail)
                    .OrderByDescending(t => t.CreateDate)
                    .ToPagedListAsync(pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalItemCount = totalTicketCount;

                return View(tickets);
            }
        }







        public async Task<IActionResult> Details(int id)
        {
            if (!authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }
            if (authService.IsAdmin())
            {
                ViewData["Layout"] = "_BackendLayout";
            }
            else if (authService.IsSupporter())
            {
                ViewData["Layout"] = "_BackendLayout";
            }
            else
            {
                ViewData["Layout"] = "_Layout";
            }

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
            if (!authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }
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
            var idUser = context.Users.Where(x => x.Email == test).FirstOrDefault().Id;
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
            if (!authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }
            if (authService.IsAdmin())
            {
                ViewData["Layout"] = "_BackendLayout";
            }
            else if (authService.IsSupporter())
            {
                ViewData["Layout"] = "_BackendLayout";
            }
            else
            {
                ViewData["Layout"] = "_Layout";
            }

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
            if (!authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }
            if (authService.IsAdmin())
            {
                ViewData["Layout"] = "_BackendLayout";
            }
            else if (authService.IsSupporter())
            {
                ViewBag.sp = "hidden";
                ViewData["Layout"] = "_BackendLayout";
            }
            else
            {
                ViewBag.us = "hidden";
                ViewData["Layout"] = "_Layout";
            }
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
            ViewBag.SupporterEmails = suporter;

            var pro = context.Priority.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            pro.Insert(0, new SelectListItem { Value = "", Text = "Select Priority" });
            ViewBag.Pro = pro;
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



            // Kiểm tra xem người dùng có phải là admin không
            if (authService.IsAdmin())
            {
                // Nếu là admin, cho phép cập nhật TicketStatusId và SupporterId
                oldTicket.TicketStatusId = editTicket.TicketStatusId;
                oldTicket.SupporterId = editTicket.SupporterId;
                oldTicket.ModifiedDate = dateTime;
                oldTicket.PriorityId = editTicket.PriorityId;
            }
            else if (authService.IsSupporter())
            {
                // Nếu là Supporter, cho phép cập nhật TicketStatusId
                oldTicket.TicketStatusId = editTicket.TicketStatusId;
                oldTicket.ModifiedDate = dateTime;
                oldTicket.feedback = editTicket.feedback;
            }
            else
            {
                oldTicket.Title = editTicket.Title;
                oldTicket.Description = editTicket.Description;
                oldTicket.CategoryId = editTicket.CategoryId;
            }
            // Lưu thay đổi vào cơ sở dữ liệu
            await ticketService.update(oldTicket);

            TempData["Message"] = "Edit Ticket Success.";
            TempData["MessageType"] = "Success";
            return RedirectToAction("Index", "Ticket");
        }

        //chart by bao
        public string GetTicketStatusData(DateTime? startDate, DateTime? endDate)
        {
            var query = context.Ticket.AsQueryable();

            // Lọc theo ngày bắt đầu nếu có
            if (startDate.HasValue)
            {
                query = query.Where(x => x.CreateDate >= startDate.Value);
            }

            // Lọc theo ngày kết thúc nếu có
            if (endDate.HasValue)
            {
                query = query.Where(x => x.CreateDate <= endDate.Value);
            }

            var statusOpen = query.Count(x => x.TicketStatusId == 1);
            var statustPending = query.Count(x => x.TicketStatusId == 3);
            var statusOnhold = query.Count(x => x.TicketStatusId == 4);
            var statusIn_progress = query.Count(x => x.TicketStatusId == 2);
            var statusRejected = query.Count(x => x.TicketStatusId == 5);
            var statusCompleted = query.Count(x => x.TicketStatusId == 2);
            var statusIn_Close = query.Count(x => x.TicketStatusId == 7);

            var data = new ModelForChart();
            data.Open = statusOpen;
            data.In_progress = statusIn_progress;
            data.Pending = statustPending;
            data.On_hold = statusOnhold;
            data.Rejected = statusRejected;
            data.Closed = statusIn_Close;

            string json = JsonConvert.SerializeObject(data);
            return json;
        }


        public string GetTicketCategoryData(DateTime? startDate, DateTime? endDate)
        {
            var query = context.Ticket.AsQueryable();

            // Lọc theo ngày bắt đầu nếu có
            if (startDate.HasValue)
            {
                query = query.Where(x => x.CreateDate >= startDate.Value);
            }

            // Lọc theo ngày kết thúc nếu có
            if (endDate.HasValue)
            {
                query = query.Where(x => x.CreateDate <= endDate.Value);
            }

            var categories = query
                .GroupBy(t => t.Category.Name)
                .Select(group => new
                {
                    CategoryName = group.Key,
                    Count = group.Count()
                })
                .ToList();
            string json = JsonConvert.SerializeObject(categories);
            return json;
        }



        public string GetTicketCreatorData(DateTime? startDate, DateTime? endDate)
        {
            var query = context.Ticket.AsQueryable();
            if (startDate.HasValue)
            {
                query = query.Where(x => x.CreateDate >= startDate.Value);
            }

            // Lọc theo ngày kết thúc nếu có
            if (endDate.HasValue)
            {
                query = query.Where(x => x.CreateDate <= endDate.Value);
            }
            var creators = query.GroupBy(x => x.Creator.UserName).Select(group => new { GroupName = group.Key, CreatorName = group.Key }).ToList();
            string json = JsonConvert.SerializeObject(creators);
            return json;
        }

        public string GetTicketSupportData(DateTime? startDate, DateTime? endDate)
        {
            var query = context.Ticket.AsQueryable();
            if (startDate.HasValue)
            {
                query = query.Where(x => x.CreateDate >= startDate.Value);
            }

            // Lọc theo ngày kết thúc nếu có
            if (endDate.HasValue)
            {
                query = query.Where(x => x.CreateDate <= endDate.Value);
            }
            var supporter = query.GroupBy(x => x.Supporter.UserName).Select(group => new { GroupName = group.Key, Count = group.Count() }).ToList();

            string json = JsonConvert.SerializeObject(supporter);
            return json;
        }


        [HttpPost]
        public async Task<IActionResult> Filter(int categoryId)
        {
            var filteredTickets = await ticketService.GetTicketById(categoryId);
            return View("Index", filteredTickets);
        }


    }
}
