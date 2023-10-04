using Bogus;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using WebApp.Ultils;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApp.Database_helper
{
    public class DatabaseContext : DbContext
    {
        private readonly Helper _helper;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, Helper helper) : base(options) { _helper = helper; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersInfo> UsersInfo { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Discussion> Discussion { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<News> News { get; set; }
<<<<<<< HEAD
=======
        public DbSet<UserConn> userConn { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<TicketDTO> TickdetDTOs { get; set; }
>>>>>>> Viet


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string url = "server=localhost;database=OHDDb;uid=sa; pwd=123456aA@$;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(url);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                 .HasOne(t => t.Creator)
                 .WithMany()
                 .HasForeignKey(t => t.CreatorId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ticket>()
                 .HasOne(t => t.Supporter)
                 .WithMany()
                 .HasForeignKey(t => t.SupporterId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Facilities>()
                 .HasOne(t => t.Supporter)
                 .WithMany()
                 .HasForeignKey(t => t.SupporterId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Discussion>()
                 .HasOne(d => d.Ticket)
                 .WithMany()
                 .HasForeignKey(d => d.TicketId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Users>().HasOne(_ => _.userInfo).WithOne(a => a.users).HasForeignKey<UserInfo>(a => a.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Users>().HasOne(_ => _.userConn).WithOne(a => a.Users).HasForeignKey<UserConn>(a => a.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notifications>().HasOne(_ => _.userConn).WithOne(a => a.Notifications).HasForeignKey<UserConn>(a => a.NotiId).OnDelete(DeleteBehavior.NoAction);


            // Định nghĩa các thông tin mô hình hóa cho bảng "tbUsers"
            modelBuilder.Entity<Users>().HasData(
                new Users { Id = 1, Email = "superadmin@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Role = "Admin", Status = true, UserName = "SuperAdmin", Code = _helper.randomString(8), EmailToConfirm = null },
                new Users { Id = 2, Email = "supporter@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Role = "Supporter", Status = true, UserName = "Supporter", Code = _helper.randomString(8), EmailToConfirm = null },
                new Users { Id = 3, Email = "user@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Role = "User", Status = true, UserName = "User", Code = _helper.randomString(8), EmailToConfirm = null }
            );

            // Định nghĩa các thông tin mô hình hóa cho bảng "tbPriority"
            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, Name = "Critical" },
                new Priority { Id = 2, Name = "High" },
                new Priority { Id = 3, Name = "Medium" },
                new Priority { Id = 4, Name = "Low" },
                new Priority { Id = 5, Name = "Urgent" },
                new Priority { Id = 6, Name = "Escalation" }
            );


            // Định nghĩa các thông tin mô hình hóa cho bảng "tbFacilities"
            modelBuilder.Entity<Facilities>().HasData(
                new Facilities { Id = 1, Name = "Class-rooms", Description = "All problems related to class-rooms" },
                new Facilities { Id = 2, Name = "Labs", Description = "All problems related to labs" },
                new Facilities { Id = 3, Name = "Hostels", Description = "All problems related to hostels" },
                new Facilities { Id = 4, Name = "Mess", Description = "All problems related to mess" },
                new Facilities { Id = 5, Name = "Canteen", Description = "All problems related to canteen" },
                new Facilities { Id = 6, Name = "Gymnasium", Description = "All problems related to gymnasium" },
                new Facilities { Id = 7, Name = "Computer Centre", Description = "All problems related to Computer Centre" },
                new Facilities { Id = 8, Name = "Library", Description = "All problems related to library" },
                new Facilities { Id = 9, Name = "After-school clubs", Description = "All problems related to after-school clubs" },
                new Facilities { Id = 10, Name = "Other problems", Description = "Other problems" }
            );

            // Định nghĩa các thông tin mô hình hóa cho bảng "tbTicketStatus"
            modelBuilder.Entity<TicketStatus>().HasData(
                new TicketStatus { Id = 1, Name = "Open" },
                new TicketStatus { Id = 2, Name = "In progress" },
                new TicketStatus { Id = 3, Name = "Pending" },
                new TicketStatus { Id = 4, Name = "On hold" },
                new TicketStatus { Id = 5, Name = "Rejected" },
                new TicketStatus { Id = 6, Name = "Completed" },
                new TicketStatus { Id = 7, Name = "Closed" }
            );

            var ids = 0;

            var usersInfo = new Faker<UsersInfo>()
                            .RuleFor(u => u.Gender, f => f.Random.Bool())
                            .RuleFor(u => u.Id, f => ++ids)
                            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                            .RuleFor(u => u.FullName, (f, u) => u.FirstName + " " + u.LastName)
                            .RuleFor(u => u.Email, (f, u) => $"onhdexmapletest199{ids++}@gmail.com")
                            .RuleFor(u => u.Student_code, f => $"Student{_helper.randomString(8)}")
                            .RuleFor(u => u.DateOfBirth, f => f.Date.Past())
                            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                            .RuleFor(u => u.Address, f => f.Address.FullAddress())
                            .RuleFor(u => u.City, f => f.Address.City());

            modelBuilder.Entity<UsersInfo>().HasData(usersInfo.GenerateBetween(50, 50));
        }
    }
}