using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;
using System.Linq;
using LibraryModels;
using WebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Database_helper;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

using WebApp.Authorize;
using System.Collections.Generic;
using WebApp.Ultils;
using Microsoft.AspNetCore.SignalR;
using WebApp.Signal;
using Newtonsoft.Json;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicket ticketService;
        private readonly DatabaseContext context;
        private readonly IAuthenService authService;
        private readonly IHubContext<SignalConfig> _hub;
        private readonly Helper _helper;
        public TicketController(ITicket ticketService, DatabaseContext context, IAuthenService authService, IHubContext<SignalConfig> hub, Helper helper)
        {
            this.ticketService = ticketService;
            this.context = context;
            this.authService = authService;
            _hub = hub;
            _helper = helper;
        }




        public async Task<IActionResult> Index(int pageIndex, int? limit, string? currentSort, string? currentFilter, string? category, DateTime[] CDate, DateTime[] MDate, string? supporter, string? status, string? priority)
        {

            string userEmail = HttpContext.Session.GetString("accEmail");
            var userRole = context.Users.FirstOrDefault(e => e.Email == userEmail);

            if (CDate.Length == 2 && CDate[0] > CDate[1] || MDate.Length == 2 && MDate[0] > MDate[1])
            {
                TempData["Message"] = "from date must less than to date ";
                return RedirectToAction("Index");
            }


            TempData["Layout"] = authService.IsAdmin() || authService.IsSupporter() ? "_BackendLayout" : "_Layout";
            ViewBag.AccountName = userEmail;

            var result = await ticketService.Tickets(userEmail, userRole.Role, pageIndex, limit, currentSort, currentFilter, category, supporter, status, priority, CDate, MDate) as Paginated<Ticket>;
            //sort
            var propertySort = string.IsNullOrEmpty(currentSort) ? null : currentSort.Split("_")[0] == "desc" ? $"asc_{currentSort.Split("_")[1]}" : $"desc_{currentSort.Split("_")[1]}";
            ViewData["propertySort"] = propertySort;
            ViewData["nameSort"] = propertySort?.Split("_")[1];
            //paginate
            ViewData["totalPages"] = result?.TotalPages;
            ViewData["Count"] = result?.Count;
            //name filter
            TempData["currentFilter"] = string.IsNullOrEmpty(currentFilter) ? null : currentFilter;
            TempData["category"] = string.IsNullOrEmpty(category) ? null : category;

            TempData["priority"] = string.IsNullOrEmpty(priority) ? null : priority;

            TempData["supporter"] = string.IsNullOrEmpty(supporter) ? null : supporter;
            TempData["status"] = string.IsNullOrEmpty(status) ? null : status;

            //query filter
            ViewData["Status"] = context.TicketStatus.ToList();
            ViewData["Priority"] = context.Priority.ToList();
            ViewData["Supporter"] = context.Users.Where(a => a.Role == "Supporter").ToList();
            ViewData["Category"] = context.Facilities.ToList();

            return View(result);
        }








        public async Task<IActionResult> Details(int id)
        {
            TempData["Layout"] = authService.IsAdmin() || authService.IsSupporter() ? "_BackendLayout" : "_Layout";
            var ticket = await ticketService.GetTicketById(id);

            var ticketDto = await context.TickdetDTOs.FirstOrDefaultAsync(a => a.TicketId == ticket.Id);

            if (authService.IsAdmin())
            {
                ticketDto.Areaded = true;
                context.SaveChanges();
            }
            else if (authService.IsSupporter())
            {
                ticketDto.Sreaded = true;
                context.SaveChanges();
            }
            else
            {
                ticketDto.Ureaded = true;
                context.SaveChanges();
            }



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
            ticketStatusOptions.Insert(0, new SelectListItem { Value = "", Text = "Select status" });

            // Gán danh sách tùy chọn cho ViewBag.TicketStatusId
            ViewBag.TicketStatusId = ticketStatusOptions;
            var facilities = context.Facilities.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text
                   = f.Name
            }).ToList();
            facilities.Insert(0, new SelectListItem { Value = "", Text = "Select Facilities" });
            ViewBag.CategoryId = facilities;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Ticket NewTicket, IFormFile? file)
        {
            var test = (HttpContext.Session.GetString("accEmail")).ToString();
            var idUser = context.Users.Where(x => x.Email == test).FirstOrDefault().Id;
            var user = context.Users.FirstOrDefault(e => e.Role == Role.Admin);
            var userConn = context.userConn.FirstOrDefault(a => a.UserId == user.Id);
            var userConId = userConn != null ? userConn.ConnectionId : "aa";
            try
            {

                var facilities = context.Facilities.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text
                    = f.Name
                }).ToList();
                facilities.Insert(0, new SelectListItem { Value = "", Text = "Select Facilities" });
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
                    var ticketNonCate = await ticketService.TicketNonCate(user.Email, user.Role);
                    await ticketService.saveTicketDTo(ticketNonCate, "Create", null);
                    _hub.Clients.Client(userConId).SendAsync("SendNotiAdmin", ticketNonCate, "success");
                    return RedirectToAction("Index"); // Chuyển hướng về trang danh sách phiếu sau khi tạo thành công.
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please select a file for attachment.");
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
                TempData["Layout"] = "_BackendLayout";
            }
            else if (authService.IsSupporter())
            {
                TempData["Layout"] = "_BackendLayout";
            }
            else
            {
                TempData["Layout"] = "_Layout";
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
            var ticket = await ticketService.GetTicketById(id);
            var ticketDto = await context.TickdetDTOs.FirstOrDefaultAsync(a => a.TicketId == ticket.Id);
            if (!authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Authen");
            }
            if (authService.IsAdmin())
            {
                TempData["Layout"] = "_BackendLayout";
                ticketDto.Areaded = true;
                context.SaveChanges();
            }
            else if (authService.IsSupporter())
            {
                ViewBag.sp = "hidden";
                TempData["Layout"] = "_BackendLayout";
                ticketDto.Sreaded = true;
                context.SaveChanges();
            }
            else
            {
                ViewBag.us = "hidden";
                TempData["Layout"] = "_Layout";
                ticketDto.Ureaded = true;
                context.SaveChanges();
            }

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
            var userRole = HttpContext.Session.GetString("accRole");
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
            if ((editTicket.TicketStatusId == 5 || editTicket.TicketStatusId == 6) && authService.IsSupporter())
            {
                var user = context.Users.FirstOrDefault(a => a.Id == oldTicket.CreatorId);
                var userConn = context.userConn.FirstOrDefault(a => a.UserId == oldTicket.CreatorId);
                var userConnId = userConn != null && userConn.ConnectionId != null ? userConn.ConnectionId : _helper.randomString(7);
                var ticketNonCate = await ticketService.TicketNonCate(user.Email, user.Role, oldTicket.Id);
               await ticketService.saveTicketDTo(ticketNonCate, "update", userRole);
                _hub.Clients.Client(userConnId).SendAsync("SendNotiAdmin", ticketNonCate, "Suporter");
            }
            else if(authService.IsAdmin())
            {
                var user = context.Users.FirstOrDefault(a => a.Id == editTicket.SupporterId);
                var userConn = context.userConn.FirstOrDefault(a => a.UserId == editTicket.SupporterId);
                var userConnId = userConn != null && userConn.ConnectionId != null ? userConn.ConnectionId : _helper.randomString(7);
                var ticketNonCate = await ticketService.TicketNonCate(user.Email, user.Role, oldTicket.Id);
              await  ticketService.saveTicketDTo(ticketNonCate, "update", userRole);
                _hub.Clients.Client(userConnId).SendAsync("SendNotiAdmin", ticketNonCate, "Admin");
            }
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


      
    }
}