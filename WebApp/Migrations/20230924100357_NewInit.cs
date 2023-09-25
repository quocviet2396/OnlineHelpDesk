using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbPriority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTicketStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTicketStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbUsersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketStatusId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    SupporterId = table.Column<int>(type: "int", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbTicket_tbFacilities_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tbFacilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbTicket_tbPriority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "tbPriority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbTicket_tbTicketStatus_TicketStatusId",
                        column: x => x.TicketStatusId,
                        principalTable: "tbTicketStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbTicket_tbUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "tbUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbTicket_tbUsers_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "tbUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbTicket_tbUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tbUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbUserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbUserInfo_tbUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbDiscussion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    FacilitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDiscussion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbDiscussion_tbFacilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "tbFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbDiscussion_tbTicket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "tbTicket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbDiscussion_tbUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbFacilities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "All problems related to class-rooms", "Class-rooms" },
                    { 2, "All problems related to labs", "Labs" },
                    { 3, "All problems related to hostels", "Hostels" },
                    { 4, "All problems related to mess", "Mess" },
                    { 5, "All problems related to canteen", "Canteen" },
                    { 6, "All problems related to gymnasium", "Gymnasium" },
                    { 7, "All problems related to Computer Centre", "Computer Centre" },
                    { 8, "All problems related to library", "Library" },
                    { 9, "All problems related to after-school clubs", "After-school clubs" },
                    { 10, "Other problems", "Other problems" }
                });

            migrationBuilder.InsertData(
                table: "tbPriority",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Critical" },
                    { 2, "High" },
                    { 3, "Medium" },
                    { 4, "Low" },
                    { 5, "Urgent" },
                    { 6, "Escalation" }
                });

            migrationBuilder.InsertData(
                table: "tbTicketStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In progress" },
                    { 3, "Pending" },
                    { 4, "On hold" },
                    { 5, "Rejected" },
                    { 6, "Completed" },
                    { 7, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "tbUsers",
                columns: new[] { "Id", "Code", "Email", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "8jLWYeRf", "superadmin@gmail.com", "$2a$11$nDTCmHzltYL.H6cyu0o.JORMweVjPqPdAQW3xreMdRaJgcy.LDDfe", "Admin", true, "SuperAdmin" },
                    { 2, "qBFy3tZs", "supporter@gmail.com", "$2a$11$juBbHAaxXZfCYtGxlw.1Ruo8GlDJpJ5GUwP4jmQYYbZYXw.5O78qm", "Supporter", true, "Supporter" },
                    { 3, "rHdcF3Gq", "user@gmail.com", "$2a$11$jz.O8dtzBrJVOM0pj4eUf.Vhsn/uaCN1vWxgVhGYzk2qciBqE9GuW", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "49812 Lamar Ridge, East Arimouth, Chile", "Lowellfort", new DateTime(2022, 11, 20, 5, 25, 28, 926, DateTimeKind.Local).AddTicks(523), "Augustus.Littel@gmail.com", "Augustus", "Augustus Littel", false, "Littel", "611.937.8337 x0584", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1160.jpg", "Student7yNIrxuA" },
                    { 2, "40832 Ole Centers, Port Gracieview, American Samoa", "Luraville", new DateTime(2023, 1, 26, 6, 37, 0, 307, DateTimeKind.Local).AddTicks(9731), "Jada.Cruickshank@hotmail.com", "Jada", "Jada Cruickshank", false, "Cruickshank", "676.578.2903", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/125.jpg", "Studentqk7JY1mZ" },
                    { 3, "39980 Emmerich Ridges, Port Hazelberg, Reunion", "Port Vella", new DateTime(2022, 11, 22, 2, 6, 11, 86, DateTimeKind.Local).AddTicks(65), "Lori_Metz56@gmail.com", "Lori", "Lori Metz", true, "Metz", "847.771.2939 x0019", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/997.jpg", "Student2lucBh13" },
                    { 4, "41359 Gorczany Club, Lebsackmouth, Isle of Man", "Wileyfort", new DateTime(2022, 12, 31, 12, 5, 3, 19, DateTimeKind.Local).AddTicks(2230), "Adrain51@yahoo.com", "Adrain", "Adrain Botsford", true, "Botsford", "230-428-3491 x8341", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/573.jpg", "StudentCC4FNRZW" },
                    { 5, "703 Eli Forest, South Grahamfort, Suriname", "East Rickshire", new DateTime(2023, 4, 1, 12, 50, 57, 915, DateTimeKind.Local).AddTicks(5738), "Bernita_Herzog@gmail.com", "Bernita", "Bernita Herzog", false, "Herzog", "759-703-3107 x296", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/137.jpg", "StudentHLXjmMTo" },
                    { 6, "9788 Jasen Fork, West Laury, Madagascar", "West Lenna", new DateTime(2023, 3, 25, 1, 59, 8, 412, DateTimeKind.Local).AddTicks(9288), "Bulah_Fay@yahoo.com", "Bulah", "Bulah Fay", false, "Fay", "374-314-9887", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/242.jpg", "Student1e3EhtIb" },
                    { 7, "246 Gideon Valleys, Katlynmouth, United States of America", "Boyermouth", new DateTime(2023, 6, 23, 2, 18, 1, 59, DateTimeKind.Local).AddTicks(5156), "Reece.Fritsch@hotmail.com", "Reece", "Reece Fritsch", true, "Fritsch", "853.915.1712", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/426.jpg", "StudentEz4a9gTh" },
                    { 8, "808 Shields Trail, Lake Rickie, Montserrat", "West Esther", new DateTime(2023, 2, 14, 17, 11, 36, 251, DateTimeKind.Local).AddTicks(3513), "Jairo.Harber0@gmail.com", "Jairo", "Jairo Harber", true, "Harber", "715.615.2617", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/794.jpg", "StudentllD7AAx6" },
                    { 9, "718 Jerde Village, Vandervortview, El Salvador", "Lake Athena", new DateTime(2023, 4, 1, 22, 40, 23, 129, DateTimeKind.Local).AddTicks(5469), "Pasquale55@gmail.com", "Pasquale", "Pasquale Brekke", true, "Brekke", "855-840-0923 x083", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/503.jpg", "StudentcOCYYXZT" },
                    { 10, "09732 Julio Trail, Dickimouth, Romania", "Naderstad", new DateTime(2023, 7, 24, 13, 4, 24, 97, DateTimeKind.Local).AddTicks(2024), "Floyd_Sipes@hotmail.com", "Floyd", "Floyd Sipes", false, "Sipes", "1-589-964-5903", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/590.jpg", "Student9fPrJhOD" },
                    { 11, "91270 Landen Via, New Palma, Timor-Leste", "Andychester", new DateTime(2023, 5, 20, 8, 49, 9, 790, DateTimeKind.Local).AddTicks(2594), "Sienna_Pollich@yahoo.com", "Sienna", "Sienna Pollich", false, "Pollich", "242-908-1115 x2356", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/78.jpg", "StudentwtTibIKL" },
                    { 12, "137 Daniel Shoal, Lake Colten, New Caledonia", "Willberg", new DateTime(2022, 10, 25, 22, 5, 53, 951, DateTimeKind.Local).AddTicks(535), "Keeley_Koss@gmail.com", "Keeley", "Keeley Koss", false, "Koss", "854.517.6689 x66423", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/57.jpg", "StudentMR60bs0f" },
                    { 13, "321 Quigley Mall, Sammyfort, Ghana", "Lake Gordon", new DateTime(2023, 2, 15, 4, 54, 21, 618, DateTimeKind.Local).AddTicks(8762), "Tania83@gmail.com", "Tania", "Tania Pfeffer", true, "Pfeffer", "(421) 516-4134", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/981.jpg", "Student2aMCTtL4" },
                    { 14, "739 Raul Mountains, Nellieport, Mali", "New Dasia", new DateTime(2022, 11, 14, 19, 16, 54, 186, DateTimeKind.Local).AddTicks(2438), "Luisa13@hotmail.com", "Luisa", "Luisa Barton", false, "Barton", "(457) 832-4419 x94153", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/772.jpg", "StudentVmQrHeeq" },
                    { 15, "58479 Feil Canyon, West Wernerport, Ghana", "New Dayne", new DateTime(2023, 2, 26, 14, 2, 41, 636, DateTimeKind.Local).AddTicks(6408), "Aaron52@yahoo.com", "Aaron", "Aaron Cassin", true, "Cassin", "(529) 997-0650", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/951.jpg", "StudentGgBAFQJD" },
                    { 16, "36381 Sauer Vista, East Orland, India", "Rosahaven", new DateTime(2023, 6, 4, 9, 56, 7, 33, DateTimeKind.Local).AddTicks(6262), "Carolanne_Abernathy14@hotmail.com", "Carolanne", "Carolanne Abernathy", true, "Abernathy", "(826) 875-8195 x775", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/885.jpg", "StudentUgKlrMy5" },
                    { 17, "85858 Josefa Street, Wolfstad, Oman", "Morissetteborough", new DateTime(2023, 3, 8, 22, 39, 29, 495, DateTimeKind.Local).AddTicks(6629), "Toby.Cruickshank7@yahoo.com", "Toby", "Toby Cruickshank", false, "Cruickshank", "(251) 428-9287", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1057.jpg", "Student7ro5CYST" },
                    { 18, "893 Ernie Freeway, Rodriguezburgh, British Indian Ocean Territory (Chagos Archipelago)", "Carahaven", new DateTime(2023, 7, 27, 6, 22, 1, 775, DateTimeKind.Local).AddTicks(8771), "Candace.Morar36@hotmail.com", "Candace", "Candace Morar", false, "Morar", "283.321.5989 x45390", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1213.jpg", "Student3YdqFwvA" },
                    { 19, "26026 Nicola Rest, South Maritzaton, Timor-Leste", "Mullerland", new DateTime(2023, 1, 25, 13, 43, 12, 484, DateTimeKind.Local).AddTicks(9451), "Destany.Schimmel@hotmail.com", "Destany", "Destany Schimmel", false, "Schimmel", "1-975-943-9576 x9501", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1156.jpg", "StudentWTruIh5v" },
                    { 20, "31046 Sarai Unions, Schuylerfort, Sri Lanka", "East Serenityside", new DateTime(2022, 10, 22, 13, 14, 51, 168, DateTimeKind.Local).AddTicks(862), "Darrion.Crist@gmail.com", "Darrion", "Darrion Crist", false, "Crist", "942-661-8726 x404", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/936.jpg", "Student2ULKnoQQ" },
                    { 21, "353 Stroman Lake, West Xzavier, Cuba", "Macejkovicville", new DateTime(2022, 11, 11, 4, 36, 47, 402, DateTimeKind.Local).AddTicks(3096), "Robb5@hotmail.com", "Robb", "Robb Jast", false, "Jast", "703-761-5727", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/814.jpg", "StudentwjGsAXn9" },
                    { 22, "6917 Halvorson Place, Klingland, Solomon Islands", "Lake Nash", new DateTime(2023, 1, 8, 19, 4, 34, 827, DateTimeKind.Local).AddTicks(3708), "Dejuan.Kuvalis@yahoo.com", "Dejuan", "Dejuan Kuvalis", false, "Kuvalis", "(513) 846-1710 x46819", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/281.jpg", "StudentlCbDUMYL" },
                    { 23, "7731 Jacobson Brooks, Marciafort, Bosnia and Herzegovina", "Durganville", new DateTime(2023, 3, 16, 22, 35, 57, 437, DateTimeKind.Local).AddTicks(9286), "Alden_Brakus65@yahoo.com", "Alden", "Alden Brakus", true, "Brakus", "(704) 629-0005", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/709.jpg", "StudentOUhhZpXO" },
                    { 24, "03605 Travis Cliffs, Boehmbury, Latvia", "East Lucioborough", new DateTime(2023, 3, 19, 20, 16, 43, 10, DateTimeKind.Local).AddTicks(4037), "Austyn_Wilkinson2@gmail.com", "Austyn", "Austyn Wilkinson", false, "Wilkinson", "1-298-941-8216 x34570", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/857.jpg", "StudenthDZRdfwc" },
                    { 25, "760 Berniece Plains, South Cletusport, Kyrgyz Republic", "Kaylaborough", new DateTime(2022, 10, 3, 16, 2, 12, 949, DateTimeKind.Local).AddTicks(4080), "Carlie.Predovic@hotmail.com", "Carlie", "Carlie Predovic", false, "Predovic", "281.444.4588 x9537", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/685.jpg", "Student0Fszla7k" },
                    { 26, "684 Otto Gardens, Lake Andersonhaven, Saint Martin", "Veumland", new DateTime(2023, 9, 19, 3, 52, 39, 574, DateTimeKind.Local).AddTicks(8452), "Earl_Hilpert78@hotmail.com", "Earl", "Earl Hilpert", true, "Hilpert", "483-613-3104 x823", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/4.jpg", "StudentYdGSwueC" },
                    { 27, "3680 Leilani Circles, West Ezra, Macedonia", "South Jacklynfort", new DateTime(2023, 3, 17, 12, 12, 45, 276, DateTimeKind.Local).AddTicks(3987), "Abbigail91@gmail.com", "Abbigail", "Abbigail Dicki", true, "Dicki", "363-753-3461", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1064.jpg", "StudentF6LgkACK" },
                    { 28, "19948 Herminio Parkway, New Kyliefurt, New Zealand", "Borerville", new DateTime(2023, 9, 7, 12, 17, 42, 549, DateTimeKind.Local).AddTicks(9855), "Malcolm.Huel@hotmail.com", "Malcolm", "Malcolm Huel", false, "Huel", "1-978-337-0189", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1216.jpg", "StudentVkHV9qPF" },
                    { 29, "7972 Nella Harbors, Jordynberg, United States Minor Outlying Islands", "Lake Justusland", new DateTime(2022, 11, 23, 0, 37, 24, 491, DateTimeKind.Local).AddTicks(7735), "Jabari27@yahoo.com", "Jabari", "Jabari Feil", false, "Feil", "1-746-255-4450 x956", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/245.jpg", "StudenthurJNt39" },
                    { 30, "92768 Rosanna View, Lake Alice, Antigua and Barbuda", "South Nellieland", new DateTime(2023, 4, 19, 14, 27, 28, 84, DateTimeKind.Local).AddTicks(5393), "Kole.Wilkinson68@gmail.com", "Kole", "Kole Wilkinson", true, "Wilkinson", "813-713-5430 x03182", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/787.jpg", "StudentdQN3rPmz" },
                    { 31, "8835 Block Cliff, Wardmouth, Iraq", "Watsonhaven", new DateTime(2023, 7, 5, 23, 40, 7, 890, DateTimeKind.Local).AddTicks(832), "Bailee_Ziemann@yahoo.com", "Bailee", "Bailee Ziemann", false, "Ziemann", "(533) 768-3306 x597", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/394.jpg", "StudentRLoiJpmD" },
                    { 32, "976 Smith Highway, Caspermouth, Serbia", "West Mylesberg", new DateTime(2023, 4, 6, 8, 30, 16, 831, DateTimeKind.Local).AddTicks(6949), "Verlie19@gmail.com", "Verlie", "Verlie Welch", false, "Welch", "1-941-751-7183 x221", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/595.jpg", "StudentgcWxsOsF" },
                    { 33, "319 Shields Island, Lake Valentine, Norfolk Island", "East Cruz", new DateTime(2023, 3, 27, 18, 40, 24, 190, DateTimeKind.Local).AddTicks(407), "Ned52@yahoo.com", "Ned", "Ned Harber", false, "Harber", "839-405-2156", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/737.jpg", "StudentAkQqhWf5" },
                    { 34, "43698 Easton Terrace, South Xander, Samoa", "Summerhaven", new DateTime(2023, 3, 27, 21, 49, 27, 170, DateTimeKind.Local).AddTicks(1757), "Brionna.Schuster60@hotmail.com", "Brionna", "Brionna Schuster", false, "Schuster", "1-840-695-4448 x840", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1209.jpg", "Student35XjbuGs" },
                    { 35, "25284 Cruickshank Locks, East Jamirstad, Colombia", "Kohlertown", new DateTime(2022, 12, 28, 2, 27, 52, 297, DateTimeKind.Local).AddTicks(7188), "Autumn_DuBuque@gmail.com", "Autumn", "Autumn DuBuque", true, "DuBuque", "575-798-2862 x332", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/529.jpg", "StudentglLsZhar" },
                    { 36, "2980 Adams Wall, New Twilaside, Moldova", "East Carafort", new DateTime(2022, 11, 6, 1, 39, 55, 622, DateTimeKind.Local).AddTicks(1984), "Flavie28@gmail.com", "Flavie", "Flavie Moen", true, "Moen", "488-576-9254", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/897.jpg", "StudentBaf0et8V" },
                    { 37, "33588 Shields Ford, Port Guadalupe, Tajikistan", "West Elfriedaborough", new DateTime(2023, 6, 16, 10, 12, 59, 782, DateTimeKind.Local).AddTicks(4352), "Felipe_Treutel@gmail.com", "Felipe", "Felipe Treutel", false, "Treutel", "(224) 755-5367", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1098.jpg", "StudentyNvHwNlh" },
                    { 38, "0489 Lemke Lights, Lilianaside, Sri Lanka", "Kuphalberg", new DateTime(2023, 2, 3, 8, 20, 16, 127, DateTimeKind.Local).AddTicks(5370), "Dell.Mayert97@gmail.com", "Dell", "Dell Mayert", false, "Mayert", "753.505.7213", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1038.jpg", "StudentbC1wQah1" },
                    { 39, "6352 Hand Divide, West Granville, Mongolia", "South Odessa", new DateTime(2023, 3, 28, 13, 45, 54, 526, DateTimeKind.Local).AddTicks(9189), "Allene_Maggio46@hotmail.com", "Allene", "Allene Maggio", true, "Maggio", "427.942.1546", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/818.jpg", "StudenthKgsHiZH" },
                    { 40, "405 Nienow Lake, South Marta, Virgin Islands, British", "North Lavern", new DateTime(2022, 11, 26, 7, 47, 48, 174, DateTimeKind.Local).AddTicks(9680), "Kole_Ruecker@yahoo.com", "Kole", "Kole Ruecker", false, "Ruecker", "507.404.9350", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/419.jpg", "StudentsPlrg2VP" },
                    { 41, "23710 Felicia Streets, North May, Malaysia", "Trinitymouth", new DateTime(2022, 10, 17, 6, 42, 30, 576, DateTimeKind.Local).AddTicks(8207), "Arlo48@gmail.com", "Arlo", "Arlo Metz", true, "Metz", "1-495-245-6976 x90634", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/941.jpg", "StudentYm28L1H4" },
                    { 42, "01644 Huel Village, South Bonita, Zambia", "Robelshire", new DateTime(2022, 11, 22, 19, 50, 47, 701, DateTimeKind.Local).AddTicks(3403), "Carmine_Christiansen@gmail.com", "Carmine", "Carmine Christiansen", true, "Christiansen", "1-544-716-0524", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1176.jpg", "Student766y8Imx" },
                    { 43, "961 Brekke Vista, New Americaburgh, Liechtenstein", "Murazikfurt", new DateTime(2023, 1, 29, 6, 10, 8, 735, DateTimeKind.Local).AddTicks(502), "Unique_Williamson@yahoo.com", "Unique", "Unique Williamson", true, "Williamson", "641.819.8736 x472", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1223.jpg", "StudentYZ6dRM5n" },
                    { 44, "026 Beahan Row, Elianchester, Saint Pierre and Miquelon", "Monserratmouth", new DateTime(2023, 1, 7, 23, 59, 2, 906, DateTimeKind.Local).AddTicks(4195), "Randal38@gmail.com", "Randal", "Randal Johnston", false, "Johnston", "(973) 628-5467 x2880", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/25.jpg", "StudentqNzZyAmB" },
                    { 45, "535 Gussie Turnpike, New Gonzalo, Fiji", "Leonorahaven", new DateTime(2023, 4, 15, 0, 57, 5, 70, DateTimeKind.Local).AddTicks(2853), "Alexane_Harris91@hotmail.com", "Alexane", "Alexane Harris", true, "Harris", "1-341-981-6445", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/339.jpg", "Studentv6DOXdFb" },
                    { 46, "2860 Sawayn Valleys, East Jude, Tanzania", "East Chelsea", new DateTime(2023, 7, 26, 10, 39, 45, 65, DateTimeKind.Local).AddTicks(7537), "Chanelle.Feil54@gmail.com", "Chanelle", "Chanelle Feil", false, "Feil", "1-608-488-4760 x70733", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/767.jpg", "StudentPzFhLNmD" },
                    { 47, "1730 Schuppe Path, Audreannemouth, United Arab Emirates", "Loyalville", new DateTime(2023, 9, 15, 13, 1, 51, 607, DateTimeKind.Local).AddTicks(2919), "Liliana_Von@yahoo.com", "Liliana", "Liliana Von", true, "Von", "(693) 857-9103", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/916.jpg", "StudentxdypcOMF" },
                    { 48, "728 Wunsch Center, South Euniceborough, Bermuda", "Pourosmouth", new DateTime(2022, 11, 19, 17, 55, 34, 371, DateTimeKind.Local).AddTicks(1649), "Karolann_Kreiger@gmail.com", "Karolann", "Karolann Kreiger", true, "Kreiger", "(611) 493-9225 x0869", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/880.jpg", "StudentfuCApjrz" },
                    { 49, "8099 Maureen Station, Hirthefort, Netherlands", "West Jaden", new DateTime(2022, 10, 21, 20, 31, 23, 218, DateTimeKind.Local).AddTicks(9473), "Theron_Schultz@yahoo.com", "Theron", "Theron Schultz", false, "Schultz", "(392) 313-8722 x7273", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/892.jpg", "StudentSl128O7V" },
                    { 50, "0357 Lew Skyway, North Kyleeberg, Tanzania", "West Lazaro", new DateTime(2022, 11, 13, 15, 21, 29, 474, DateTimeKind.Local).AddTicks(6237), "Kasey73@gmail.com", "Kasey", "Kasey Gerlach", true, "Gerlach", "(317) 272-1736", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/208.jpg", "StudentNyu8vkh0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbDiscussion_FacilitiesId",
                table: "tbDiscussion",
                column: "FacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_tbDiscussion_TicketId",
                table: "tbDiscussion",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_tbDiscussion_UsersId",
                table: "tbDiscussion",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTicket_CategoryId",
                table: "tbTicket",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTicket_CreatorId",
                table: "tbTicket",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTicket_PriorityId",
                table: "tbTicket",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTicket_SupporterId",
                table: "tbTicket",
                column: "SupporterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTicket_TicketStatusId",
                table: "tbTicket",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTicket_UsersId",
                table: "tbTicket",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserInfo_UserId",
                table: "tbUserInfo",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbDiscussion");

            migrationBuilder.DropTable(
                name: "tbUserInfo");

            migrationBuilder.DropTable(
                name: "tbUsersInfo");

            migrationBuilder.DropTable(
                name: "tbTicket");

            migrationBuilder.DropTable(
                name: "tbFacilities");

            migrationBuilder.DropTable(
                name: "tbPriority");

            migrationBuilder.DropTable(
                name: "tbTicketStatus");

            migrationBuilder.DropTable(
                name: "tbUsers");
        }
    }
}
