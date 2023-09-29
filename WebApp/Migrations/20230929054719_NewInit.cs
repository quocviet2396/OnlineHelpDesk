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
                    { 1, "epLDDoPe", "superadmin@gmail.com", "$2a$11$d3Iyd6zc61MAkgjHpCEJuOQnNuzWAlpUovvu1wBh0RGH8O3EbLjhu", "Admin", true, "SuperAdmin" },
                    { 2, "BavlznID", "supporter@gmail.com", "$2a$11$TcC/V0mKIJQstt3P7n9FWO2dDmozt6iRz3b7ahC.tw5EyHYR9yr1i", "Supporter", true, "Supporter" },
                    { 3, "lcL3l3qC", "user@gmail.com", "$2a$11$f641hV/Jdf.wAzdiQKN3FubWMxIXxP6nxzHBBKAkWkF0MRA2tEYmq", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "6438 Stamm River, North Shanaview, Bulgaria", "Lorenhaven", new DateTime(2023, 5, 24, 14, 9, 18, 850, DateTimeKind.Local).AddTicks(4358), "Eveline29@gmail.com", "Eveline", "Eveline Rath", true, "Rath", "732.440.2109 x766", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/270.jpg", "StudentbplM5eRJ" },
                    { 2, "614 Leannon Village, Darrellfurt, Haiti", "Emeraldland", new DateTime(2022, 11, 29, 3, 3, 8, 446, DateTimeKind.Local).AddTicks(873), "Imogene.Cassin@yahoo.com", "Imogene", "Imogene Cassin", false, "Cassin", "(775) 225-1201 x6151", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1183.jpg", "StudentWQCx9TZO" },
                    { 3, "19401 Izaiah Lake, South Katrina, Guinea-Bissau", "New Kaleighfurt", new DateTime(2023, 1, 16, 21, 18, 30, 346, DateTimeKind.Local).AddTicks(9691), "Emily.Hoppe@yahoo.com", "Emily", "Emily Hoppe", true, "Hoppe", "439.330.3216 x7682", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/673.jpg", "Student7ZDXXSWS" },
                    { 4, "54201 Little Springs, North Antoniaport, Indonesia", "West Hilma", new DateTime(2023, 3, 5, 3, 47, 55, 627, DateTimeKind.Local).AddTicks(2756), "Rocky.Moen@yahoo.com", "Rocky", "Rocky Moen", true, "Moen", "(796) 582-1889", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/687.jpg", "StudentCjAj1rWw" },
                    { 5, "056 Isaac Key, Lizaburgh, Congo", "North Leeview", new DateTime(2022, 11, 11, 19, 6, 38, 690, DateTimeKind.Local).AddTicks(9201), "Julie64@yahoo.com", "Julie", "Julie Wisoky", false, "Wisoky", "507-668-3245 x3610", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1026.jpg", "StudentC8U5r9Oe" },
                    { 6, "20798 Skye Grove, South Ignatius, Georgia", "New Llewellynburgh", new DateTime(2023, 9, 2, 18, 1, 58, 693, DateTimeKind.Local).AddTicks(6493), "Makayla_Beer38@yahoo.com", "Makayla", "Makayla Beer", false, "Beer", "366.587.1474 x542", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1196.jpg", "StudentUij0KHdb" },
                    { 7, "5941 Goldner Dam, Kaseyhaven, Nepal", "East Violetteland", new DateTime(2022, 12, 13, 20, 36, 36, 988, DateTimeKind.Local).AddTicks(7428), "Hollie.Hettinger5@gmail.com", "Hollie", "Hollie Hettinger", false, "Hettinger", "(449) 569-3249", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/272.jpg", "StudentBJiYMPUb" },
                    { 8, "0448 Fahey Meadow, New Asha, Iran", "Port Luella", new DateTime(2023, 8, 23, 16, 44, 9, 574, DateTimeKind.Local).AddTicks(24), "Barry_Runolfsdottir@gmail.com", "Barry", "Barry Runolfsdottir", false, "Runolfsdottir", "(270) 787-4321 x29343", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/314.jpg", "StudentvU8fghIF" },
                    { 9, "054 Yost Underpass, Port Gerardoville, Suriname", "New June", new DateTime(2023, 7, 15, 18, 21, 54, 215, DateTimeKind.Local).AddTicks(1665), "Sally74@gmail.com", "Sally", "Sally Witting", false, "Witting", "(265) 277-1237 x3791", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/891.jpg", "StudentGBL4mrgO" },
                    { 10, "923 Fiona Island, Satterfieldshire, Vietnam", "New Alejandra", new DateTime(2023, 5, 9, 8, 6, 38, 49, DateTimeKind.Local).AddTicks(6988), "Eldora_Wilderman93@yahoo.com", "Eldora", "Eldora Wilderman", true, "Wilderman", "(558) 338-7222", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/280.jpg", "StudentH6dL8Gtw" },
                    { 11, "89099 Carrie Roads, Javonbury, Algeria", "Hintzton", new DateTime(2022, 10, 20, 19, 46, 15, 178, DateTimeKind.Local).AddTicks(937), "Pete.Cormier@yahoo.com", "Pete", "Pete Cormier", true, "Cormier", "371.853.9270", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/816.jpg", "StudentmV9PvxOC" },
                    { 12, "3476 Beatty Drive, North Lloydstad, Luxembourg", "New Antoneport", new DateTime(2023, 9, 18, 12, 13, 17, 422, DateTimeKind.Local).AddTicks(5009), "London14@gmail.com", "London", "London Rowe", true, "Rowe", "1-563-253-6480", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/690.jpg", "StudentgqzO3eFO" },
                    { 13, "33496 Trudie Prairie, New Palmastad, Philippines", "East Kayleeland", new DateTime(2022, 11, 26, 20, 21, 3, 890, DateTimeKind.Local).AddTicks(7995), "Arjun.Morissette58@hotmail.com", "Arjun", "Arjun Morissette", false, "Morissette", "(508) 246-6627", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1158.jpg", "StudentONLb5NAH" },
                    { 14, "70789 Mills Stravenue, Rayshire, Cape Verde", "Harveyville", new DateTime(2023, 6, 6, 17, 41, 37, 911, DateTimeKind.Local).AddTicks(2536), "Gretchen_McKenzie@gmail.com", "Gretchen", "Gretchen McKenzie", true, "McKenzie", "(676) 851-2207 x87701", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/39.jpg", "StudentPneRpQiv" },
                    { 15, "28921 Flatley Avenue, Laceyland, Faroe Islands", "New Winstonfort", new DateTime(2023, 4, 5, 4, 12, 21, 268, DateTimeKind.Local).AddTicks(9074), "Thora40@yahoo.com", "Thora", "Thora Powlowski", false, "Powlowski", "821-969-1888 x725", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/825.jpg", "Studentb0coSFKO" },
                    { 16, "225 Cassin Plain, East Nia, Rwanda", "East Johnnieville", new DateTime(2023, 2, 2, 16, 2, 37, 819, DateTimeKind.Local).AddTicks(9989), "Zora46@hotmail.com", "Zora", "Zora Mayer", false, "Mayer", "1-329-597-8728 x4558", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1163.jpg", "Student6Rs7FVpU" },
                    { 17, "5425 Ebony Terrace, Lake Mohamed, Spain", "West Sammiebury", new DateTime(2023, 9, 18, 19, 24, 55, 348, DateTimeKind.Local).AddTicks(2505), "Johann.Stiedemann36@hotmail.com", "Johann", "Johann Stiedemann", false, "Stiedemann", "1-757-922-8230 x53283", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/420.jpg", "StudentEo1DiFW9" },
                    { 18, "201 Larson Lake, New Gianni, Malaysia", "Flatleyfort", new DateTime(2023, 6, 20, 4, 30, 51, 633, DateTimeKind.Local).AddTicks(451), "Abdiel.Cartwright@gmail.com", "Abdiel", "Abdiel Cartwright", false, "Cartwright", "233.912.6908 x436", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1182.jpg", "Student7WoMUl7U" },
                    { 19, "387 Margaretta Unions, Port Taya, China", "Lake Reidmouth", new DateTime(2023, 1, 31, 4, 58, 57, 563, DateTimeKind.Local).AddTicks(2212), "Arjun.Anderson11@yahoo.com", "Arjun", "Arjun Anderson", false, "Anderson", "457.541.4935 x12052", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/654.jpg", "Student9kA3O2NM" },
                    { 20, "250 Veda Shores, Osvaldofurt, Haiti", "South Karleeville", new DateTime(2023, 8, 22, 14, 40, 39, 888, DateTimeKind.Local).AddTicks(4698), "Rossie.Aufderhar@hotmail.com", "Rossie", "Rossie Aufderhar", false, "Aufderhar", "1-600-200-7741 x748", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/789.jpg", "Student2h4Kth21" },
                    { 21, "4858 Brendon Walk, Kreigerburgh, Sweden", "North Talon", new DateTime(2022, 10, 12, 20, 11, 10, 365, DateTimeKind.Local).AddTicks(2299), "Horace_Christiansen24@gmail.com", "Horace", "Horace Christiansen", true, "Christiansen", "1-862-581-1472 x03475", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/962.jpg", "StudentUndYUfnw" },
                    { 22, "8782 Borer Centers, Port Oliver, Germany", "South Russel", new DateTime(2023, 5, 8, 19, 43, 57, 395, DateTimeKind.Local).AddTicks(1462), "Berta_Wisozk@yahoo.com", "Berta", "Berta Wisozk", false, "Wisozk", "942.501.9557", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/349.jpg", "StudentN0jAghgr" },
                    { 23, "1843 Kessler Ford, Blickside, Bulgaria", "Kriston", new DateTime(2023, 6, 24, 2, 45, 45, 351, DateTimeKind.Local).AddTicks(8690), "Horacio_Watsica77@yahoo.com", "Horacio", "Horacio Watsica", true, "Watsica", "1-617-450-5267 x72598", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/322.jpg", "Studentipxb7gfT" },
                    { 24, "9340 Hadley Path, Lake Hershel, Antarctica (the territory South of 60 deg S)", "North Celestineview", new DateTime(2023, 7, 17, 6, 51, 43, 722, DateTimeKind.Local).AddTicks(8386), "Kimberly.Kihn35@yahoo.com", "Kimberly", "Kimberly Kihn", false, "Kihn", "1-459-982-8773", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1086.jpg", "Studentole5Xur0" },
                    { 25, "4782 Stracke Junctions, West Sagehaven, Angola", "Hintzview", new DateTime(2022, 11, 1, 23, 53, 30, 133, DateTimeKind.Local).AddTicks(8871), "Erna_Rempel70@gmail.com", "Erna", "Erna Rempel", true, "Rempel", "1-455-605-9879", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/71.jpg", "StudentE4l2XkDT" },
                    { 26, "58697 Barrows Manors, Lake Ocieview, Andorra", "Kiehnville", new DateTime(2023, 3, 28, 10, 10, 40, 910, DateTimeKind.Local).AddTicks(6261), "Lavonne99@hotmail.com", "Lavonne", "Lavonne Jakubowski", false, "Jakubowski", "719-536-0263", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/922.jpg", "Student2RsSOgjf" },
                    { 27, "68120 Block Road, East Timmy, Syrian Arab Republic", "Billberg", new DateTime(2023, 6, 30, 15, 16, 20, 137, DateTimeKind.Local).AddTicks(7446), "Audra.Hansen21@yahoo.com", "Audra", "Audra Hansen", false, "Hansen", "1-543-925-0731", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1066.jpg", "Student4LhS2m21" },
                    { 28, "58331 Josiah Drives, North Dashawnburgh, France", "West Darian", new DateTime(2023, 2, 27, 18, 6, 17, 444, DateTimeKind.Local).AddTicks(8613), "Arnulfo99@yahoo.com", "Arnulfo", "Arnulfo Kertzmann", true, "Kertzmann", "994.981.8091", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/952.jpg", "StudentzZwy0hKU" },
                    { 29, "220 Becker Summit, Wittingmouth, Cambodia", "New Raoulburgh", new DateTime(2023, 9, 4, 22, 21, 9, 672, DateTimeKind.Local).AddTicks(3843), "Rachel77@hotmail.com", "Rachel", "Rachel Quitzon", false, "Quitzon", "(498) 621-2957 x169", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1091.jpg", "StudentpMH9uxNY" },
                    { 30, "107 Krajcik Motorway, Connellybury, Gibraltar", "Cronaland", new DateTime(2023, 9, 8, 2, 44, 33, 550, DateTimeKind.Local).AddTicks(9192), "Carmella.Spinka42@yahoo.com", "Carmella", "Carmella Spinka", false, "Spinka", "1-230-502-4378 x31187", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1131.jpg", "Student2boZwdVN" },
                    { 31, "14997 Deion Curve, North Ikemouth, Indonesia", "Israelburgh", new DateTime(2023, 9, 9, 11, 48, 36, 367, DateTimeKind.Local).AddTicks(4165), "Sandra52@gmail.com", "Sandra", "Sandra Christiansen", true, "Christiansen", "356.570.7841", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/38.jpg", "StudentgRNSMXQB" },
                    { 32, "55232 Thad Landing, Creminside, Saint Helena", "South Vancestad", new DateTime(2023, 3, 27, 18, 26, 15, 231, DateTimeKind.Local).AddTicks(8226), "Deondre98@yahoo.com", "Deondre", "Deondre Sanford", false, "Sanford", "(420) 707-5652 x757", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/432.jpg", "Student4ByMEnUb" },
                    { 33, "781 Krajcik Turnpike, Irvingland, Saint Barthelemy", "Stiedemannton", new DateTime(2022, 11, 6, 15, 42, 44, 1, DateTimeKind.Local).AddTicks(5489), "Jack14@hotmail.com", "Jack", "Jack Rogahn", false, "Rogahn", "409.302.6092", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/564.jpg", "StudentvxHbZs4B" },
                    { 34, "067 Carlotta Lake, South Lurlinebury, Argentina", "Bauchmouth", new DateTime(2022, 10, 16, 10, 20, 53, 375, DateTimeKind.Local).AddTicks(5143), "Burnice.Blanda@hotmail.com", "Burnice", "Burnice Blanda", true, "Blanda", "207.309.8040", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/688.jpg", "StudentSKAWbUFh" },
                    { 35, "1006 Reinger Tunnel, Connellyside, Saint Martin", "Lilaport", new DateTime(2022, 12, 25, 14, 42, 49, 215, DateTimeKind.Local).AddTicks(7169), "Leila_Romaguera@hotmail.com", "Leila", "Leila Romaguera", false, "Romaguera", "800-317-1402", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/736.jpg", "StudentMZnLS6Le" },
                    { 36, "48717 Wolff Flats, Rossborough, Tajikistan", "Faheymouth", new DateTime(2022, 10, 22, 20, 31, 17, 111, DateTimeKind.Local).AddTicks(7705), "Ron.Schuster55@yahoo.com", "Ron", "Ron Schuster", false, "Schuster", "570.477.1645 x1705", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/408.jpg", "StudentTz6gqOSk" },
                    { 37, "333 Brisa Haven, Gorczanyton, Cocos (Keeling) Islands", "North Estefaniaport", new DateTime(2022, 12, 17, 2, 47, 35, 364, DateTimeKind.Local).AddTicks(3790), "Amber35@gmail.com", "Amber", "Amber Lynch", true, "Lynch", "265.825.4734 x02018", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/463.jpg", "Student44H0wPmR" },
                    { 38, "53949 Narciso Mills, Jonesmouth, Maldives", "Lake Porter", new DateTime(2022, 11, 9, 11, 7, 41, 374, DateTimeKind.Local).AddTicks(4726), "Mattie_Sporer@hotmail.com", "Mattie", "Mattie Sporer", true, "Sporer", "1-964-699-5117 x2690", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1249.jpg", "StudentccO7L09P" },
                    { 39, "688 Ebert Stream, West Camillamouth, Tuvalu", "Christianborough", new DateTime(2022, 11, 14, 13, 49, 47, 954, DateTimeKind.Local).AddTicks(8524), "Oliver.OConnell62@yahoo.com", "Oliver", "Oliver O'Connell", false, "O'Connell", "960-553-5572 x23703", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/406.jpg", "StudentD8mUNi5A" },
                    { 40, "342 Stanton Terrace, North Casimerside, Marshall Islands", "New Garthmouth", new DateTime(2023, 1, 10, 4, 30, 44, 5, DateTimeKind.Local).AddTicks(2493), "Duncan_Brown44@gmail.com", "Duncan", "Duncan Brown", true, "Brown", "1-484-237-3088", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1243.jpg", "Student4GRmwAUU" },
                    { 41, "8119 Cassin Station, West Ludie, Pitcairn Islands", "South Naomie", new DateTime(2023, 8, 1, 2, 28, 36, 511, DateTimeKind.Local).AddTicks(9531), "Juanita38@gmail.com", "Juanita", "Juanita Gislason", true, "Gislason", "1-958-519-0461 x437", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/909.jpg", "StudentiAm9WueM" },
                    { 42, "0294 Terry Cove, New Letha, Bosnia and Herzegovina", "South Katlynnfort", new DateTime(2022, 12, 20, 6, 10, 37, 625, DateTimeKind.Local).AddTicks(478), "Nelson78@hotmail.com", "Nelson", "Nelson Block", false, "Block", "507-697-5436 x840", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/146.jpg", "StudentyRaUjYtV" },
                    { 43, "32749 Hermiston Lodge, Port Yesseniaport, Indonesia", "New Lydia", new DateTime(2023, 8, 10, 8, 17, 2, 124, DateTimeKind.Local).AddTicks(1293), "Gracie_Wehner21@yahoo.com", "Gracie", "Gracie Wehner", false, "Wehner", "(968) 779-9117", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/517.jpg", "StudentpGIUBJOU" },
                    { 44, "1123 Leo Garden, Wiegandborough, American Samoa", "Marcosbury", new DateTime(2023, 4, 21, 20, 21, 56, 375, DateTimeKind.Local).AddTicks(8881), "Walter_Kuphal@yahoo.com", "Walter", "Walter Kuphal", true, "Kuphal", "1-992-873-5153 x9914", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/952.jpg", "StudentSciuJVcP" },
                    { 45, "109 Prohaska Road, Goyetteborough, Cayman Islands", "Cassieton", new DateTime(2023, 7, 5, 0, 5, 16, 259, DateTimeKind.Local).AddTicks(8787), "Ricardo_Ebert@gmail.com", "Ricardo", "Ricardo Ebert", false, "Ebert", "206-265-3105 x49423", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/405.jpg", "StudentuS7NphLA" },
                    { 46, "37331 Funk Run, Magnoliachester, Faroe Islands", "South Lessie", new DateTime(2022, 10, 16, 1, 52, 37, 17, DateTimeKind.Local).AddTicks(9883), "Clyde_Herzog@hotmail.com", "Clyde", "Clyde Herzog", false, "Herzog", "474.521.6630", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/110.jpg", "Student97LG821e" },
                    { 47, "7430 Koss Motorway, West Kenyonstad, Nigeria", "Kimport", new DateTime(2022, 11, 3, 3, 13, 27, 81, DateTimeKind.Local).AddTicks(5177), "Jada_Klein@gmail.com", "Jada", "Jada Klein", true, "Klein", "902-573-1410", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/576.jpg", "StudentXM4VgZT8" },
                    { 48, "8020 Ramiro Well, Gennaroland, Germany", "Willyfort", new DateTime(2023, 4, 25, 6, 25, 29, 550, DateTimeKind.Local).AddTicks(9013), "Claire45@gmail.com", "Claire", "Claire Feest", true, "Feest", "1-294-933-9287", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1031.jpg", "StudentbyR0vaVf" },
                    { 49, "9392 Casper Ranch, South Guidoland, Saint Kitts and Nevis", "South Harley", new DateTime(2023, 7, 2, 9, 48, 46, 751, DateTimeKind.Local).AddTicks(556), "Janiya.Corwin87@hotmail.com", "Janiya", "Janiya Corwin", true, "Corwin", "327.678.8571", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/379.jpg", "Studenty7RmmfL2" },
                    { 50, "7607 Glen Vista, New Guillermoton, Western Sahara", "Beckerhaven", new DateTime(2023, 3, 23, 12, 11, 41, 96, DateTimeKind.Local).AddTicks(3828), "Ralph95@yahoo.com", "Ralph", "Ralph Considine", true, "Considine", "1-893-910-4218", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/765.jpg", "Student7vpcxQfl" }
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
