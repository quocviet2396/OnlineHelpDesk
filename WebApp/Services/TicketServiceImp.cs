using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using LibraryModels;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Ultils;

namespace WebApp.Services
{
    public class TicketServiceImp : ITicket
    {
        private readonly DatabaseContext db;
        public TicketServiceImp(DatabaseContext db)
        {
            this.db = db;
        }
        public bool create(Ticket newTicket)
        {
            try
            {
                db.Add(newTicket);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                // Ví dụ: Ghi log lỗi
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public async Task<bool> delete(int id)
        {
            var model = db.Ticket.SingleOrDefault(t => t.Id == id);
            if (model != null)
            {
                db.Ticket.Remove(model);
                await db.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await db.Ticket
                .Include(ticket => ticket.TicketStatus)
                .OrderBy(ticket => ticket.CreateDate)
                .ToListAsync();
        }

        public int GetTotalTicketCount()
        {
            return db.Ticket.Count();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await db.Ticket.SingleOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task<bool> update(Ticket newTicket)
        {
            var existingTicket = await db.Ticket.SingleOrDefaultAsync(t => t.Id == newTicket.Id);

            if (existingTicket == null)
            {
                return false; // Ticket with the specified ID not found.
            }

            // Update the properties of the existing ticket with the new values.
            existingTicket.Title = newTicket.Title;
            existingTicket.Description = newTicket.Description;
            existingTicket.ModifiedDate = newTicket.ModifiedDate;
            existingTicket.Attachment = newTicket.Attachment;
            existingTicket.TicketStatusId = newTicket.TicketStatusId;
            existingTicket.CategoryId = newTicket.CategoryId;
            existingTicket.CreatorId = newTicket.CreatorId;
            existingTicket.SupporterId = newTicket.SupporterId;
            existingTicket.PriorityId = newTicket.PriorityId;
            existingTicket.feedback = newTicket.feedback;

            await db.SaveChangesAsync();
            return true; // Ticket updated successfully.
        }


        public async Task<List<Ticket>> Tickets(string email, string role, int pageIndex, int? limit, string? currentSort, string? currentFilter, string? category, string? supporter, string? status, string? priority, DateTime[] CDate, DateTime[] MDate)
        {
            var pageNumber = pageIndex <= 0 ? 1 : pageIndex;

            var Limit = limit ?? 7;

            currentSort = string.IsNullOrEmpty(currentSort) ? "asc_Id" : currentSort;

            var query = await db.Ticket
                    .Include(t => t.Creator).Include(f => f.Category).Include(ts => ts.TicketStatus).Include(sp => sp.Supporter).Include(pr => pr.Priority)
                .OrderByDescending(t => t.CreateDate).ToListAsync();



            if (!string.IsNullOrEmpty(email) && role != Role.Admin)
            {
                query = query.Where(a =>
                        (a.Creator != null && a.Creator.Email.Equals(email)) ||
                        (a.Supporter != null && a.Supporter.Email.Equals(email))).ToList();
            }

            var sort = await Sort<Ticket>.SortAsync(query, currentSort, currentFilter, category: category, status: status, supporter: supporter, priority: priority);


            if (CDate.Length == 2)
            {
                sort = sort.Where(a => a.CreateDate.HasValue && a.CreateDate.Value.Date >= CDate[0].Date && a.CreateDate.Value.Date <= CDate[1].Date);
            }
            if (MDate.Length == 2)
            {
                sort = sort.Where(a => a.ModifiedDate.HasValue && a.ModifiedDate.Value.Date >= MDate[0].Date && a.ModifiedDate.Value.Date <= MDate[1].Date);
            }
            if (MDate.Length >= 1 && MDate[0] != null)
            {
                sort = sort.Where(a => a.ModifiedDate.HasValue && a.ModifiedDate.Value.Date == CDate[0].Date);
            }
            if (CDate.Length >= 1 && CDate[0] != null)
            {
                sort = sort.Where(a => a.CreateDate.HasValue && a.CreateDate.Value.Date == CDate[0].Date);
            }

            var result = await Paginated<Ticket>.CreatePaginate(sort.ToList(), pageNumber, (int)Limit, x => x.CreateDate);

            return result;
        }


        public async Task<TicketDTO> TicketNonCate(string email, string role, int? id = null)
        {
            var user = db.Users.FirstOrDefault(u => u.Email.Equals(email));

            var query = db.Ticket
                    .Include(t => t.Creator)
                    .Include(f => f.Category)
                    .Include(ts => ts.TicketStatus)
                    .Include(sp => sp.Supporter)
                    .Select(c => new TicketDTO()
                    {
                        TicketId = c.Id,
                        Title = c.Title,
                        Decription = c.Description,
                        PhotoPerson = c.Creator.userInfo.Photo,
                        UserNameCreator = c.Creator.UserName,
                        UserNameSupporter = c.Supporter != null ? c.Supporter.UserName : null,
                        EmailCreator = c.Creator.Email,
                        EmailSupporter = c.Supporter != null ? c.Supporter.Email : null,
                        TicketStatus = c.TicketStatus != null ? c.TicketStatus.Name : null,
                        CreateDate = c.CreateDate,
                        ModifiedDate = c.ModifiedDate
                    }).AsEnumerable();
            if (id != null)
            {
                query = query.Where(a => a.TicketId == id);
            }

            if (!string.IsNullOrEmpty(email) && role != Role.Admin)
            {
                if (role == Role.FacilityHead)
                {
                    var notiSupp = query.Where(a =>
                        a.EmailSupporter != null && a.EmailSupporter == email).Where(a => a.TicketStatus == "In progress").Where(a => a.readed == false).OrderBy(a => a.ModifiedDate).LastOrDefault();
                    return notiSupp;
                }
                else
                {
                    var nitoUser = query.Where(a =>
                        a.EmailCreator != null && a.EmailCreator == email).Where(a => a.TicketStatus == "Closed" && a.TicketStatus != "Completed" && a.TicketStatus != "Rejected").Where(a => a.readed == false).OrderBy(a => a.ModifiedDate).LastOrDefault();
                    return nitoUser;
                }
            }
            else
            {
                var notiadmin = query.Where(a => a.TicketStatus == null).OrderBy(a => a.CreateDate).Where(a => a.readed == false).LastOrDefault();
                return notiadmin;
            }

        }

        public async Task<bool> saveTicketDTo(TicketDTO ticketDTO)
        {
            try
            {
                TicketDTO tDto = new TicketDTO()
                {
                    CreateDate = ticketDTO.CreateDate,
                    TicketId = ticketDTO.TicketId,
                    Title = ticketDTO.Title,
                    Decription = ticketDTO.Decription,
                    EmailCreator = ticketDTO.EmailCreator,
                    EmailSupporter = ticketDTO.EmailSupporter,
                    UserNameCreator = ticketDTO.UserNameCreator,
                    UserNameSupporter = ticketDTO.UserNameSupporter,
                    PhotoPerson = ticketDTO.PhotoPerson,
                    readed = ticketDTO.readed,
                    ModifiedDate = ticketDTO.ModifiedDate,
                    TicketStatus = ticketDTO.TicketStatus,
                };
                db.TickdetDTOs.Add(tDto);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
