using LibraryModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApp.Database_helper
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersInfo> UsersInfo { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Discussion> Discussion { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<Priority> Priority { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string str = "server=DESKTOP-F4OHHB4\\MSSQLSERVER01; database=OHDDb; Trusted_Connection=true; TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(str);
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

            modelBuilder.Entity<Discussion>()
                 .HasOne(d => d.Ticket)
                 .WithMany()
                 .HasForeignKey(d => d.TicketId)
                 .OnDelete(DeleteBehavior.NoAction);


            // Định nghĩa các thông tin mô hình hóa cho bảng "tbUsers"
            modelBuilder.Entity<Users>().HasData(
                new Users { Id = 1, Email = "superadmin@gmail.com", Password = "123", Role = "Admin", Status = true},
                new Users { Id = 2, Email = "supporter@gmail.com", Password = "123", Role = "Supporter", Status = true},
                new Users { Id = 3, Email = "user@gmail.com", Password = "123", Role = "User", Status = true}
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
                new Facilities { Id = 1, Name = "Class-rooms", Description = "All problems related to class-rooms"},
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
                new TicketStatus { Id = 7, Name = "Closed"}
            );
        }
    }
}
