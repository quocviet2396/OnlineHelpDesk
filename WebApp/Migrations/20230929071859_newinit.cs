using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class newinit : Migration
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
                name: "tbNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNews", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "tbComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    NewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbComments_tbNews_NewsId",
                        column: x => x.NewsId,
                        principalTable: "tbNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketStatusId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    SupporterId = table.Column<int>(type: "int", nullable: true),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 1, "oansNlDy", "superadmin@gmail.com", "$2a$11$.HPR9At1R9ZksRGiDslnAOreeA17L1YMPcPQCcTD9NHiltyPNK1SS", "Admin", true, "SuperAdmin" },
                    { 2, "kiAJEJy7", "supporter@gmail.com", "$2a$11$Fs.bZxTa0SJjGRwYOE41gecvyYLL2rXofe3DO1MFG1alwCzfVNSsC", "Supporter", true, "Supporter" },
                    { 3, "WXiltPBD", "user@gmail.com", "$2a$11$pTf1yHGLth6KubIGHj4pEe/DV.m/bHvufiQMt44NQHYrzTVF8mR0C", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "471 Hintz Glen, Lake Jace, Palau", "North Kirsten", new DateTime(2023, 7, 8, 10, 26, 45, 684, DateTimeKind.Local).AddTicks(1074), "Jody.Veum@yahoo.com", "Jody", "Jody Veum", true, "Veum", "1-325-968-8144 x1451", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/944.jpg", "StudentjgQuK9lV" },
                    { 2, "657 Prohaska Gateway, Lake Beryl, Montserrat", "Port Tiaraborough", new DateTime(2022, 11, 13, 10, 49, 2, 614, DateTimeKind.Local).AddTicks(3794), "Zackary_Weber@gmail.com", "Zackary", "Zackary Weber", true, "Weber", "(302) 420-8584 x00741", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/234.jpg", "Student4iwlgPXY" },
                    { 3, "9256 Lucio Station, Jenkinshaven, Nicaragua", "Lake Janyville", new DateTime(2023, 2, 17, 23, 41, 44, 837, DateTimeKind.Local).AddTicks(8923), "Jermey32@yahoo.com", "Jermey", "Jermey Dicki", true, "Dicki", "875-815-5770 x944", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/828.jpg", "StudentIfniNaxe" },
                    { 4, "6642 Anderson Station, East Turner, Guatemala", "Daijashire", new DateTime(2023, 2, 20, 22, 48, 7, 956, DateTimeKind.Local).AddTicks(7580), "Jaron_Macejkovic82@gmail.com", "Jaron", "Jaron Macejkovic", true, "Macejkovic", "578-363-3731 x9665", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/156.jpg", "StudenthS6mo7Hw" },
                    { 5, "6045 Bayer Light, Port Jaylen, Libyan Arab Jamahiriya", "VonRuedenport", new DateTime(2023, 6, 29, 11, 9, 7, 5, DateTimeKind.Local).AddTicks(386), "Damon.Moore78@gmail.com", "Damon", "Damon Moore", false, "Moore", "(569) 920-5991", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1142.jpg", "Studenty219nQ6r" },
                    { 6, "04834 Renner Manor, South Samanta, Wallis and Futuna", "Rodrigoton", new DateTime(2023, 9, 14, 12, 34, 49, 814, DateTimeKind.Local).AddTicks(9338), "Vicente_Gutmann65@yahoo.com", "Vicente", "Vicente Gutmann", true, "Gutmann", "498.954.0536", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/812.jpg", "StudentscqPjjvD" },
                    { 7, "55683 Goyette Gateway, West Garret, Serbia", "Ubaldoburgh", new DateTime(2023, 6, 12, 8, 10, 34, 177, DateTimeKind.Local).AddTicks(548), "Jadyn62@yahoo.com", "Jadyn", "Jadyn Rodriguez", true, "Rodriguez", "761-760-5631 x00902", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/683.jpg", "StudentaZjOK2vy" },
                    { 8, "323 Roxanne Rapid, East Jan, Chile", "Marcosport", new DateTime(2023, 8, 20, 15, 47, 41, 648, DateTimeKind.Local).AddTicks(4803), "Loyal.Feeney54@hotmail.com", "Loyal", "Loyal Feeney", true, "Feeney", "743.477.9628", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1101.jpg", "Studentbb9tEy7L" },
                    { 9, "89360 Etha Fort, West Kaleigh, Lithuania", "Zboncakfurt", new DateTime(2022, 11, 26, 16, 25, 7, 305, DateTimeKind.Local).AddTicks(457), "Keara6@yahoo.com", "Keara", "Keara Rodriguez", false, "Rodriguez", "936-576-9605", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/904.jpg", "StudentsY6SAnsm" },
                    { 10, "794 Schaefer Centers, Murazikmouth, Bosnia and Herzegovina", "Malliefurt", new DateTime(2023, 9, 8, 11, 2, 7, 254, DateTimeKind.Local).AddTicks(6708), "Jessie89@hotmail.com", "Jessie", "Jessie Johnson", true, "Johnson", "403.510.8123", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/598.jpg", "Studentpqlh6UvX" },
                    { 11, "2755 Koepp Rest, West Tamara, Grenada", "East Gina", new DateTime(2023, 5, 22, 6, 33, 47, 255, DateTimeKind.Local).AddTicks(8004), "Serenity.Daniel@hotmail.com", "Serenity", "Serenity Daniel", true, "Daniel", "1-831-246-4314 x8225", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/549.jpg", "Student4qqLS2d2" },
                    { 12, "35574 Towne Skyway, East Gillian, South Africa", "West Shanelleburgh", new DateTime(2023, 3, 3, 18, 25, 5, 274, DateTimeKind.Local).AddTicks(5153), "Elmore.Moore@gmail.com", "Elmore", "Elmore Moore", true, "Moore", "954.872.2368 x40209", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/867.jpg", "StudentmqIsZaAE" },
                    { 13, "508 Rita River, Leannontown, Algeria", "New Bernita", new DateTime(2023, 2, 26, 20, 29, 48, 353, DateTimeKind.Local).AddTicks(9604), "Amir91@yahoo.com", "Amir", "Amir Haag", false, "Haag", "(724) 878-6553 x1121", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/899.jpg", "Student4n3iZcNX" },
                    { 14, "2197 Kling Shore, Jacobibury, Bahrain", "Dorotheaside", new DateTime(2023, 4, 3, 5, 22, 58, 940, DateTimeKind.Local).AddTicks(6657), "Margaret.Reichert84@yahoo.com", "Margaret", "Margaret Reichert", false, "Reichert", "508-770-7711 x78111", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/339.jpg", "StudentM3hhIKDZ" },
                    { 15, "58290 Alisa Rapids, Yundttown, Lithuania", "East Ariel", new DateTime(2023, 7, 9, 2, 55, 13, 15, DateTimeKind.Local).AddTicks(9263), "Freida_Toy@hotmail.com", "Freida", "Freida Toy", true, "Toy", "(250) 297-7939 x032", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1150.jpg", "StudentBqdYMa2p" },
                    { 16, "7671 Bernhard Trail, Simonisview, Bermuda", "North Lorainemouth", new DateTime(2023, 5, 30, 12, 3, 54, 980, DateTimeKind.Local).AddTicks(1234), "Taya94@yahoo.com", "Taya", "Taya Ward", false, "Ward", "302-922-7546", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/309.jpg", "StudentDUUu9Tsf" },
                    { 17, "2461 King Shore, South Abelardo, Gibraltar", "Dooleyborough", new DateTime(2023, 5, 17, 12, 18, 10, 980, DateTimeKind.Local).AddTicks(8087), "Christa.Greenfelder34@yahoo.com", "Christa", "Christa Greenfelder", false, "Greenfelder", "(667) 299-1759 x473", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/858.jpg", "StudentvdnVlZE0" },
                    { 18, "4666 Goldner Stravenue, Karianneport, Saint Kitts and Nevis", "West Luellaville", new DateTime(2023, 1, 8, 8, 41, 51, 130, DateTimeKind.Local).AddTicks(4455), "Ernestine.Walker22@hotmail.com", "Ernestine", "Ernestine Walker", true, "Walker", "759.659.9099 x624", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/221.jpg", "StudentQ2LC00L3" },
                    { 19, "12191 Elisa Keys, Port Teresa, Kenya", "South Vaughn", new DateTime(2023, 3, 15, 6, 39, 56, 34, DateTimeKind.Local).AddTicks(63), "Martina_Rolfson@hotmail.com", "Martina", "Martina Rolfson", true, "Rolfson", "1-439-777-9121 x26378", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/782.jpg", "StudentPy8NlLPO" },
                    { 20, "72459 Larkin Manor, Omafort, Tokelau", "West Elsaton", new DateTime(2023, 6, 1, 11, 30, 58, 951, DateTimeKind.Local).AddTicks(1644), "Afton15@gmail.com", "Afton", "Afton Hickle", true, "Hickle", "1-363-302-6090 x2715", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1086.jpg", "Student4ehJbprl" },
                    { 21, "943 Grant Passage, West Tess, Mauritius", "Simonisfort", new DateTime(2022, 11, 14, 2, 1, 19, 208, DateTimeKind.Local).AddTicks(9203), "Jena.Simonis62@hotmail.com", "Jena", "Jena Simonis", false, "Simonis", "299-528-4721", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1231.jpg", "StudentKO9pR1s1" },
                    { 22, "7750 Royce Viaduct, Francismouth, Mongolia", "Kevonton", new DateTime(2023, 7, 20, 11, 31, 23, 936, DateTimeKind.Local).AddTicks(7600), "Westley71@gmail.com", "Westley", "Westley Crist", false, "Crist", "1-874-643-6757 x4207", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/434.jpg", "StudentrYVAgY4c" },
                    { 23, "8402 Treutel Fall, New Chetside, Pakistan", "East Vince", new DateTime(2023, 4, 3, 8, 47, 57, 748, DateTimeKind.Local).AddTicks(2934), "Alana86@hotmail.com", "Alana", "Alana Kovacek", true, "Kovacek", "426-340-6983", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/877.jpg", "StudentvzDFXFIa" },
                    { 24, "020 Aron Summit, Port Carolina, France", "Millsberg", new DateTime(2022, 11, 11, 17, 11, 45, 188, DateTimeKind.Local).AddTicks(6772), "Nelson67@hotmail.com", "Nelson", "Nelson Luettgen", false, "Luettgen", "1-933-482-6393 x0381", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1135.jpg", "StudentnRQLmETH" },
                    { 25, "712 Mante Spurs, Hellenland, Lithuania", "North Piper", new DateTime(2023, 6, 4, 18, 51, 7, 984, DateTimeKind.Local).AddTicks(2032), "Adalberto43@gmail.com", "Adalberto", "Adalberto Runte", true, "Runte", "328.830.9916", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/496.jpg", "StudentacDGzPNP" },
                    { 26, "566 Kerluke Forest, South Velvashire, Vanuatu", "New Charityhaven", new DateTime(2022, 11, 19, 21, 44, 3, 562, DateTimeKind.Local).AddTicks(4080), "Nya_Mayer@hotmail.com", "Nya", "Nya Mayer", true, "Mayer", "238.859.7850", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/722.jpg", "Student0jWe2v1W" },
                    { 27, "391 Spinka Hill, East Clevefurt, Andorra", "Bauchport", new DateTime(2022, 11, 6, 1, 18, 18, 413, DateTimeKind.Local).AddTicks(4946), "Oliver17@gmail.com", "Oliver", "Oliver Brown", false, "Brown", "1-728-518-3678", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/417.jpg", "Student01kstanQ" },
                    { 28, "71508 Collin Mills, South Sanford, Denmark", "Reichelville", new DateTime(2022, 11, 5, 11, 59, 59, 997, DateTimeKind.Local).AddTicks(3994), "Dillan_Witting@yahoo.com", "Dillan", "Dillan Witting", true, "Witting", "1-906-615-6492", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/356.jpg", "StudentS9hqE7Zv" },
                    { 29, "066 Wiza Gardens, New Jewell, Ukraine", "South Marguerite", new DateTime(2022, 12, 2, 11, 55, 17, 461, DateTimeKind.Local).AddTicks(6641), "Harley_Dickens85@yahoo.com", "Harley", "Harley Dickens", true, "Dickens", "348.948.7487", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/583.jpg", "StudentxQJBZrSQ" },
                    { 30, "053 Myra Lodge, Rosenbaumchester, Moldova", "West Yvonnehaven", new DateTime(2023, 1, 28, 3, 49, 37, 361, DateTimeKind.Local).AddTicks(2879), "Trinity_Hauck9@gmail.com", "Trinity", "Trinity Hauck", true, "Hauck", "1-822-818-3556 x19159", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/265.jpg", "StudentG0u4Mpkh" },
                    { 31, "3973 Rogahn Ferry, South Kyleborough, Mexico", "South Katlyn", new DateTime(2023, 5, 5, 0, 17, 13, 291, DateTimeKind.Local).AddTicks(5656), "Darius23@hotmail.com", "Darius", "Darius Keebler", true, "Keebler", "308-888-7556 x948", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1095.jpg", "Studentd0RMIYeo" },
                    { 32, "18783 Fadel Drives, Langworthmouth, Benin", "East Kareemshire", new DateTime(2022, 11, 17, 20, 31, 30, 78, DateTimeKind.Local).AddTicks(9830), "Moses_Senger@hotmail.com", "Moses", "Moses Senger", true, "Senger", "1-884-711-9281", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/249.jpg", "StudentLFFRul13" },
                    { 33, "854 Carmelo Freeway, North Mauricechester, Mali", "Schaeferland", new DateTime(2023, 3, 28, 13, 8, 54, 432, DateTimeKind.Local).AddTicks(9672), "Colt_Auer88@yahoo.com", "Colt", "Colt Auer", true, "Auer", "386.974.8591 x0260", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/126.jpg", "StudentwpuK18Gt" },
                    { 34, "3173 Kling Turnpike, New Charlenestad, Cuba", "Patsytown", new DateTime(2022, 10, 14, 15, 40, 49, 397, DateTimeKind.Local).AddTicks(9336), "Margarete90@hotmail.com", "Margarete", "Margarete Spinka", true, "Spinka", "1-736-838-2489 x448", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/60.jpg", "Studentcqhdh9EI" },
                    { 35, "284 Williamson Isle, Ocieport, Republic of Korea", "Friesenchester", new DateTime(2023, 4, 10, 2, 52, 53, 473, DateTimeKind.Local).AddTicks(4321), "Alvina.Daniel96@yahoo.com", "Alvina", "Alvina Daniel", true, "Daniel", "1-557-241-2525", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/952.jpg", "StudentuKN49uVa" },
                    { 36, "9120 Haley Pine, Meganemouth, Armenia", "Klockoside", new DateTime(2023, 5, 8, 21, 12, 45, 395, DateTimeKind.Local).AddTicks(3273), "Marilyne_Lehner14@hotmail.com", "Marilyne", "Marilyne Lehner", true, "Lehner", "1-721-733-3830", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/728.jpg", "StudentTCkz37x6" },
                    { 37, "32028 Mayer Walks, Lake Meta, Pakistan", "Jacquesfort", new DateTime(2023, 9, 3, 23, 4, 23, 803, DateTimeKind.Local).AddTicks(7731), "Cordie_Breitenberg@gmail.com", "Cordie", "Cordie Breitenberg", false, "Breitenberg", "1-238-390-6274 x20959", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/243.jpg", "Studentf8NPVrrU" },
                    { 38, "501 Wilkinson Terrace, New Kamren, Tanzania", "West Gilberto", new DateTime(2023, 8, 30, 23, 47, 29, 966, DateTimeKind.Local).AddTicks(2294), "Kian_Runolfsdottir75@yahoo.com", "Kian", "Kian Runolfsdottir", true, "Runolfsdottir", "893-276-3401", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/125.jpg", "Studentd9DcfyMV" },
                    { 39, "58898 Gislason Pass, East Xanderland, Singapore", "Grahambury", new DateTime(2023, 3, 22, 15, 7, 15, 958, DateTimeKind.Local).AddTicks(8579), "Sylvia.Johnston21@yahoo.com", "Sylvia", "Sylvia Johnston", true, "Johnston", "863.473.0127 x50106", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/632.jpg", "Studentn2f8QLRk" },
                    { 40, "1162 King Mills, East Jaydenland, Papua New Guinea", "Willisland", new DateTime(2023, 7, 1, 14, 39, 58, 394, DateTimeKind.Local).AddTicks(9589), "Sadye26@yahoo.com", "Sadye", "Sadye Friesen", false, "Friesen", "787.747.3251", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/557.jpg", "StudenthDuzbe40" },
                    { 41, "25171 Fred Green, South Kielbury, Cameroon", "North Jaquanville", new DateTime(2023, 9, 23, 9, 14, 12, 832, DateTimeKind.Local).AddTicks(3707), "Eryn_Gaylord@hotmail.com", "Eryn", "Eryn Gaylord", true, "Gaylord", "544-334-4802 x5341", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/277.jpg", "StudentAXUCxhhk" },
                    { 42, "9753 Ivy Fall, Claudeville, Bulgaria", "Larsonview", new DateTime(2023, 2, 19, 1, 43, 35, 633, DateTimeKind.Local).AddTicks(1308), "Erik.Grimes92@hotmail.com", "Erik", "Erik Grimes", false, "Grimes", "1-358-507-2700 x6972", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/997.jpg", "Student5k2wGSw6" },
                    { 43, "657 Zulauf Neck, Edaburgh, Somalia", "Port Oswaldmouth", new DateTime(2022, 12, 23, 8, 59, 26, 281, DateTimeKind.Local).AddTicks(3550), "Kylie.Kuhn72@yahoo.com", "Kylie", "Kylie Kuhn", false, "Kuhn", "519-966-6744", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/677.jpg", "Student9dFpddCz" },
                    { 44, "83148 Ardith Viaduct, East Kiphaven, Latvia", "Schadentown", new DateTime(2022, 11, 25, 5, 39, 12, 219, DateTimeKind.Local).AddTicks(5493), "Uriel_Kozey15@yahoo.com", "Uriel", "Uriel Kozey", false, "Kozey", "1-484-355-3719", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1231.jpg", "StudentxO7aofXN" },
                    { 45, "3881 Jerde Alley, New Angieburgh, Qatar", "Lake Buckfurt", new DateTime(2023, 4, 27, 3, 5, 36, 802, DateTimeKind.Local).AddTicks(9473), "Justen_Abbott@yahoo.com", "Justen", "Justen Abbott", false, "Abbott", "646-810-0487 x79460", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/548.jpg", "StudentjOWmRA7j" },
                    { 46, "799 Stark Dam, South Arnulfo, Liechtenstein", "Lake Danteton", new DateTime(2022, 11, 22, 18, 4, 14, 44, DateTimeKind.Local).AddTicks(2196), "Micah75@hotmail.com", "Micah", "Micah Hane", true, "Hane", "(470) 344-2394 x90805", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1172.jpg", "StudentLkHk5KvJ" },
                    { 47, "895 Nitzsche Ways, Kochfort, Andorra", "Dickinsonland", new DateTime(2023, 9, 28, 15, 28, 12, 715, DateTimeKind.Local).AddTicks(6304), "Cydney30@gmail.com", "Cydney", "Cydney Koss", false, "Koss", "1-220-288-6430", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/411.jpg", "Studentqyn1WJS9" },
                    { 48, "3671 Lexus Spring, East Tia, Honduras", "East Camilleville", new DateTime(2023, 1, 14, 15, 7, 24, 615, DateTimeKind.Local).AddTicks(1753), "Stacey13@gmail.com", "Stacey", "Stacey DuBuque", false, "DuBuque", "1-643-209-7126", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/622.jpg", "Studentl6zIN1Re" },
                    { 49, "15571 Ana Radial, West Sheilaberg, Indonesia", "Bahringermouth", new DateTime(2023, 9, 16, 1, 48, 19, 939, DateTimeKind.Local).AddTicks(5152), "Hertha_Ullrich@gmail.com", "Hertha", "Hertha Ullrich", false, "Ullrich", "895.426.8850 x1640", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/268.jpg", "StudentpdZzcmOH" },
                    { 50, "4465 Dooley Views, Breitenbergfurt, Solomon Islands", "Alexysport", new DateTime(2023, 7, 18, 0, 29, 31, 55, DateTimeKind.Local).AddTicks(8620), "Jarrett10@yahoo.com", "Jarrett", "Jarrett Dach", false, "Dach", "1-701-209-6611", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/659.jpg", "StudentKGEysEPs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbComments_NewsId",
                table: "tbComments",
                column: "NewsId");

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
                name: "tbComments");

            migrationBuilder.DropTable(
                name: "tbDiscussion");

            migrationBuilder.DropTable(
                name: "tbUserInfo");

            migrationBuilder.DropTable(
                name: "tbUsersInfo");

            migrationBuilder.DropTable(
                name: "tbNews");

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
