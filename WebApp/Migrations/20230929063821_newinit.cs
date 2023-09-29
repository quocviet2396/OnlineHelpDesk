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
                    { 1, "xTLUYlnM", "superadmin@gmail.com", "$2a$11$XaTWWgoTbylxtG.MBcxtg.3DmZyh8OPhCOoDynuggBck3q/LQldNW", "Admin", true, "SuperAdmin" },
                    { 2, "WDZF2qVd", "supporter@gmail.com", "$2a$11$X1o8fDGXEkyZ2ltQwqAamuQf/uX1C7UafALox061XHadYLORcAE8m", "Supporter", true, "Supporter" },
                    { 3, "Ox766oHg", "user@gmail.com", "$2a$11$V0s6JEys33WBHCoSnLOpUeaDkC/XnbXEaF9jiqwbxH80Tf1o5jATS", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "06822 Jonas Pine, New Adellaland, Falkland Islands (Malvinas)", "West Amiya", new DateTime(2023, 3, 26, 9, 36, 38, 614, DateTimeKind.Local).AddTicks(3885), "Stephen.Hauck@yahoo.com", "Stephen", "Stephen Hauck", false, "Hauck", "1-578-270-2071 x1901", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/269.jpg", "StudentMvXAwnFN" },
                    { 2, "95159 Dino Prairie, Allystad, Peru", "Port Jessy", new DateTime(2023, 4, 14, 6, 32, 44, 127, DateTimeKind.Local).AddTicks(3507), "Jaden.Franecki97@hotmail.com", "Jaden", "Jaden Franecki", true, "Franecki", "(508) 685-8534", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1100.jpg", "Student1bq4zLfa" },
                    { 3, "996 Violette Square, New Einochester, Saint Martin", "Port Mackshire", new DateTime(2023, 7, 21, 21, 12, 23, 2, DateTimeKind.Local).AddTicks(4357), "Jasper_Bartoletti67@gmail.com", "Jasper", "Jasper Bartoletti", true, "Bartoletti", "246-370-3650", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/150.jpg", "StudentdzMTQmiO" },
                    { 4, "96691 Ottis Spurs, Strosinstad, South Georgia and the South Sandwich Islands", "Dietrichville", new DateTime(2023, 2, 14, 7, 21, 43, 514, DateTimeKind.Local).AddTicks(2070), "Torrance.Heaney@gmail.com", "Torrance", "Torrance Heaney", false, "Heaney", "604.551.7267 x47186", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/350.jpg", "StudentuKux74sQ" },
                    { 5, "5514 Champlin Drive, North Kaitlinshire, Kenya", "Oranborough", new DateTime(2023, 8, 16, 19, 24, 20, 753, DateTimeKind.Local).AddTicks(7394), "Tate.Ernser@gmail.com", "Tate", "Tate Ernser", false, "Ernser", "351-953-3132 x875", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/853.jpg", "Student0FLCXelZ" },
                    { 6, "471 Nayeli Mountains, Steuberhaven, Albania", "Lake Jermaineville", new DateTime(2023, 5, 3, 9, 2, 45, 853, DateTimeKind.Local).AddTicks(6102), "Cathy_Gislason0@yahoo.com", "Cathy", "Cathy Gislason", false, "Gislason", "404-840-4419 x08332", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/209.jpg", "StudentUqKCBY5X" },
                    { 7, "5850 Towne Island, Lake Gaylordberg, Pitcairn Islands", "Lake Jada", new DateTime(2023, 5, 21, 15, 22, 43, 958, DateTimeKind.Local).AddTicks(5489), "Randy7@yahoo.com", "Randy", "Randy Medhurst", false, "Medhurst", "(900) 820-7420 x40714", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/632.jpg", "StudentPCOM2gMS" },
                    { 8, "9091 Scottie Tunnel, West Maudie, Timor-Leste", "North Katherine", new DateTime(2023, 8, 8, 22, 25, 19, 676, DateTimeKind.Local).AddTicks(1543), "Braeden66@hotmail.com", "Braeden", "Braeden McDermott", true, "McDermott", "(809) 217-2563", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1171.jpg", "StudentefGTE83y" },
                    { 9, "631 Wisoky Cove, Weissnatfort, Benin", "Lake Monserrat", new DateTime(2022, 12, 10, 19, 36, 37, 116, DateTimeKind.Local).AddTicks(4461), "Kyleigh_Renner56@hotmail.com", "Kyleigh", "Kyleigh Renner", true, "Renner", "(307) 264-9450 x453", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/468.jpg", "Student4sOFSXaA" },
                    { 10, "6642 Adaline Brook, Cronaview, Bulgaria", "Lake Elroy", new DateTime(2022, 11, 5, 16, 32, 32, 987, DateTimeKind.Local).AddTicks(8452), "Jamarcus.Effertz@gmail.com", "Jamarcus", "Jamarcus Effertz", false, "Effertz", "1-651-921-3950", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/207.jpg", "Student0WKPJwor" },
                    { 11, "849 Farrell Park, Kemmerview, Honduras", "New Nicole", new DateTime(2022, 10, 20, 18, 40, 27, 161, DateTimeKind.Local).AddTicks(4691), "Cathrine86@yahoo.com", "Cathrine", "Cathrine Hoppe", true, "Hoppe", "922-720-4299 x94403", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/222.jpg", "StudentMk6SDySq" },
                    { 12, "0509 Maxwell Port, Dickinsonview, Northern Mariana Islands", "West Constantin", new DateTime(2023, 8, 5, 11, 11, 16, 377, DateTimeKind.Local).AddTicks(4631), "Dax_Effertz@gmail.com", "Dax", "Dax Effertz", false, "Effertz", "1-317-250-1023 x8182", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/928.jpg", "StudentrJCj4KL9" },
                    { 13, "99667 Vernie Branch, Guadalupefort, Svalbard & Jan Mayen Islands", "Spencerfort", new DateTime(2023, 5, 24, 9, 51, 15, 574, DateTimeKind.Local).AddTicks(5026), "Lynn.Keebler70@hotmail.com", "Lynn", "Lynn Keebler", false, "Keebler", "1-565-469-8156", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/615.jpg", "StudentDbgQOJ8G" },
                    { 14, "67251 Birdie Hills, Gaylordfurt, Syrian Arab Republic", "Port Hellen", new DateTime(2023, 1, 24, 1, 56, 0, 777, DateTimeKind.Local).AddTicks(5783), "Murphy_Lesch@gmail.com", "Murphy", "Murphy Lesch", true, "Lesch", "308-915-5609 x7877", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/60.jpg", "Student1zKjHAzu" },
                    { 15, "384 Liza Drive, South Maxchester, Cote d'Ivoire", "East Hillardberg", new DateTime(2023, 8, 21, 14, 56, 38, 502, DateTimeKind.Local).AddTicks(7171), "Waino.Cremin@hotmail.com", "Waino", "Waino Cremin", true, "Cremin", "1-716-806-3317 x4460", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/906.jpg", "StudentuxuyVOmY" },
                    { 16, "0100 Boehm Prairie, Okunevafurt, Senegal", "Jacobifurt", new DateTime(2023, 7, 9, 7, 20, 7, 440, DateTimeKind.Local).AddTicks(2233), "Alessandra_Predovic@hotmail.com", "Alessandra", "Alessandra Predovic", true, "Predovic", "1-242-308-1901 x1054", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/934.jpg", "StudentQbWiolVX" },
                    { 17, "42323 Giuseppe Meadow, West Raphael, Portugal", "Croninport", new DateTime(2022, 10, 30, 14, 50, 20, 553, DateTimeKind.Local).AddTicks(6509), "Alisa_Waelchi99@hotmail.com", "Alisa", "Alisa Waelchi", true, "Waelchi", "1-681-513-2538", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1073.jpg", "StudentaZXLqCid" },
                    { 18, "2491 Oswald Courts, Candaceton, United Arab Emirates", "Mayerberg", new DateTime(2023, 2, 8, 16, 48, 24, 801, DateTimeKind.Local).AddTicks(6104), "Deanna_Kunde14@yahoo.com", "Deanna", "Deanna Kunde", true, "Kunde", "(355) 511-1421", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/834.jpg", "Student5dErN6EI" },
                    { 19, "076 Hintz Lodge, East Pedro, Guam", "Adamsberg", new DateTime(2023, 6, 25, 6, 2, 42, 410, DateTimeKind.Local).AddTicks(4556), "Dewitt_Bosco48@gmail.com", "Dewitt", "Dewitt Bosco", false, "Bosco", "845-302-9260", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1196.jpg", "StudentTjdz3oHq" },
                    { 20, "09293 Anderson Roads, Port Amelia, Nepal", "Ravenside", new DateTime(2022, 10, 14, 20, 56, 11, 625, DateTimeKind.Local).AddTicks(9535), "Charlotte.Nikolaus96@yahoo.com", "Charlotte", "Charlotte Nikolaus", true, "Nikolaus", "1-299-557-3313 x4254", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/361.jpg", "Student6oJNlV1L" },
                    { 21, "4607 Nicolas Brook, New Hermina, Israel", "East Keshawn", new DateTime(2023, 3, 12, 3, 1, 54, 568, DateTimeKind.Local).AddTicks(310), "Mollie_Haag@hotmail.com", "Mollie", "Mollie Haag", false, "Haag", "766.428.2957 x77044", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/385.jpg", "StudentQR4ZF3LP" },
                    { 22, "90554 Mckayla Crescent, Spinkachester, Slovenia", "Herzogborough", new DateTime(2023, 8, 11, 6, 34, 57, 98, DateTimeKind.Local).AddTicks(5864), "Kylee97@hotmail.com", "Kylee", "Kylee Ritchie", true, "Ritchie", "453.226.1297 x4783", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/218.jpg", "StudentgzxsZ2n9" },
                    { 23, "7159 Eugenia Curve, East Brent, Bulgaria", "New Pearlieberg", new DateTime(2023, 1, 22, 21, 49, 39, 298, DateTimeKind.Local).AddTicks(550), "Candido51@hotmail.com", "Candido", "Candido Predovic", false, "Predovic", "299.216.7749", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/583.jpg", "Studentwzcsvdhe" },
                    { 24, "372 Ariel Valley, North Mattie, Tajikistan", "Heaneyburgh", new DateTime(2023, 6, 16, 8, 2, 8, 457, DateTimeKind.Local).AddTicks(5439), "Eddie80@hotmail.com", "Eddie", "Eddie Lubowitz", true, "Lubowitz", "1-929-490-0094", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/222.jpg", "Student8iU4xNC5" },
                    { 25, "23186 Fahey Island, East Marley, Saint Barthelemy", "Durganmouth", new DateTime(2023, 7, 16, 10, 31, 7, 602, DateTimeKind.Local).AddTicks(7170), "Evans_Feest@gmail.com", "Evans", "Evans Feest", true, "Feest", "(630) 499-1689", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/950.jpg", "StudentHRJvCVrK" },
                    { 26, "457 Kub Knoll, Rennershire, Ireland", "Millsport", new DateTime(2023, 8, 2, 2, 19, 24, 982, DateTimeKind.Local).AddTicks(5211), "Rosalind80@hotmail.com", "Rosalind", "Rosalind Walter", true, "Walter", "247-251-6925", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/948.jpg", "StudentSIvecUn7" },
                    { 27, "1075 Hettinger Tunnel, Mabelleberg, Slovakia (Slovak Republic)", "Lake Trey", new DateTime(2023, 2, 11, 19, 47, 0, 175, DateTimeKind.Local).AddTicks(6353), "Mabelle4@hotmail.com", "Mabelle", "Mabelle Schmitt", true, "Schmitt", "626-711-2309 x3976", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/124.jpg", "StudentIHqJhRtE" },
                    { 28, "180 Laron Bridge, Myriamfurt, Ecuador", "Mosciskihaven", new DateTime(2023, 4, 3, 21, 46, 35, 587, DateTimeKind.Local).AddTicks(705), "Callie18@yahoo.com", "Callie", "Callie Dicki", false, "Dicki", "1-748-542-9929", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/336.jpg", "StudentGITBAoRK" },
                    { 29, "14422 Fiona Fields, Wardmouth, Honduras", "North Jamarcusburgh", new DateTime(2023, 9, 28, 5, 31, 16, 70, DateTimeKind.Local).AddTicks(6048), "Anita.Lindgren@yahoo.com", "Anita", "Anita Lindgren", true, "Lindgren", "(742) 790-1155 x152", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/266.jpg", "Student2x7bwdbR" },
                    { 30, "98214 Carey Gateway, Kesslerchester, Virgin Islands, British", "Brendanton", new DateTime(2023, 6, 21, 14, 58, 51, 993, DateTimeKind.Local).AddTicks(9494), "Clementine_Auer@hotmail.com", "Clementine", "Clementine Auer", true, "Auer", "514-373-1876", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/655.jpg", "StudentrFu2nSS6" },
                    { 31, "093 Raina Shores, North Deborahville, Moldova", "West Nelsonport", new DateTime(2023, 1, 4, 6, 35, 5, 629, DateTimeKind.Local).AddTicks(3128), "Haley.Kuhlman@yahoo.com", "Haley", "Haley Kuhlman", false, "Kuhlman", "739.503.3133", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/244.jpg", "StudentkGcCZyqa" },
                    { 32, "30935 Sanford Centers, Alfredochester, Bermuda", "South Hosea", new DateTime(2022, 11, 27, 23, 16, 15, 480, DateTimeKind.Local).AddTicks(9065), "Bud70@yahoo.com", "Bud", "Bud Carroll", false, "Carroll", "341-600-9744 x11906", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/131.jpg", "StudentqHXlNcXn" },
                    { 33, "79959 Ziemann Alley, Hodkiewiczborough, Poland", "Joanneborough", new DateTime(2023, 5, 29, 1, 55, 12, 749, DateTimeKind.Local).AddTicks(1375), "Javier_Rempel6@hotmail.com", "Javier", "Javier Rempel", true, "Rempel", "(839) 901-5341", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/20.jpg", "StudentBpIy1kK8" },
                    { 34, "6617 Raleigh Squares, Antoinetteshire, Guinea-Bissau", "O'Reillymouth", new DateTime(2023, 6, 25, 22, 34, 46, 988, DateTimeKind.Local).AddTicks(8510), "Zakary69@yahoo.com", "Zakary", "Zakary Breitenberg", true, "Breitenberg", "(714) 533-7805 x310", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/723.jpg", "StudentwfMZJGCH" },
                    { 35, "4776 Kuhn Square, Carliton, Anguilla", "Port Lyricport", new DateTime(2023, 9, 8, 21, 31, 38, 747, DateTimeKind.Local).AddTicks(2589), "April59@hotmail.com", "April", "April Mills", true, "Mills", "362.955.3370", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/524.jpg", "StudentwW6iOz3W" },
                    { 36, "188 Daniel Estates, New Carolineview, Albania", "New Noel", new DateTime(2023, 8, 6, 19, 56, 2, 651, DateTimeKind.Local).AddTicks(6968), "Billy56@yahoo.com", "Billy", "Billy Walker", false, "Walker", "1-819-808-2248 x8734", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/756.jpg", "StudentiT0p375M" },
                    { 37, "143 Idella Course, Freemanport, Falkland Islands (Malvinas)", "Cronaport", new DateTime(2023, 3, 30, 17, 20, 46, 535, DateTimeKind.Local).AddTicks(1011), "Wilford_Buckridge9@gmail.com", "Wilford", "Wilford Buckridge", true, "Buckridge", "492-882-9798 x071", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/110.jpg", "Student5EruiSNp" },
                    { 38, "75989 Jarred Knoll, Blickborough, Palestinian Territory", "Sanfordton", new DateTime(2023, 1, 26, 18, 15, 3, 460, DateTimeKind.Local).AddTicks(8463), "Eleonore_Ruecker40@gmail.com", "Eleonore", "Eleonore Ruecker", false, "Ruecker", "911-529-2148", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1126.jpg", "StudentyfbJD1vV" },
                    { 39, "213 Hoppe Valleys, Lake Everettefort, Sri Lanka", "New Heathton", new DateTime(2023, 9, 27, 19, 13, 9, 131, DateTimeKind.Local).AddTicks(5539), "Holly_Yundt@hotmail.com", "Holly", "Holly Yundt", false, "Yundt", "392.977.9901 x976", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/640.jpg", "StudentJ25TiGFa" },
                    { 40, "92818 Raymundo Camp, North Bradenland, Guatemala", "New Alessiamouth", new DateTime(2022, 12, 15, 6, 1, 29, 954, DateTimeKind.Local).AddTicks(6726), "Jane_Mraz@hotmail.com", "Jane", "Jane Mraz", false, "Mraz", "1-218-420-4584 x1899", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/130.jpg", "StudentNXzvefl9" },
                    { 41, "9654 Parker Dam, Halvorsonside, Antarctica (the territory South of 60 deg S)", "Tyshawnside", new DateTime(2023, 1, 6, 9, 25, 59, 42, DateTimeKind.Local).AddTicks(1438), "Elinor2@gmail.com", "Elinor", "Elinor Beahan", true, "Beahan", "(483) 396-7258 x4335", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/22.jpg", "StudentTSnT6BKA" },
                    { 42, "5043 Lakin Burgs, Port Lucienneville, Namibia", "Hagenesfurt", new DateTime(2023, 9, 10, 20, 49, 46, 756, DateTimeKind.Local).AddTicks(1288), "Albina_Gutmann67@yahoo.com", "Albina", "Albina Gutmann", false, "Gutmann", "532-212-0389 x7496", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/321.jpg", "StudentaiMN4hdn" },
                    { 43, "22664 White Radial, Joneston, Namibia", "Pricehaven", new DateTime(2023, 5, 30, 14, 36, 20, 707, DateTimeKind.Local).AddTicks(4100), "Eloise_Kertzmann95@hotmail.com", "Eloise", "Eloise Kertzmann", false, "Kertzmann", "304-835-6407 x38655", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/935.jpg", "StudentD9ziICZk" },
                    { 44, "249 Emerson Summit, Mohammedport, Tokelau", "Rhettbury", new DateTime(2023, 3, 1, 3, 24, 37, 486, DateTimeKind.Local).AddTicks(6098), "Halie.Langworth@yahoo.com", "Halie", "Halie Langworth", false, "Langworth", "(397) 991-8720", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/128.jpg", "StudentR6kuwEvj" },
                    { 45, "780 Oberbrunner Spurs, South Micaelamouth, Guyana", "New Richard", new DateTime(2022, 12, 29, 10, 48, 49, 974, DateTimeKind.Local).AddTicks(6577), "Fausto_Turner87@hotmail.com", "Fausto", "Fausto Turner", true, "Turner", "(502) 614-1850 x2318", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1052.jpg", "Student3PWp5pL2" },
                    { 46, "53319 Hallie River, North Chesleyport, Ecuador", "Candacemouth", new DateTime(2023, 9, 25, 3, 16, 53, 167, DateTimeKind.Local).AddTicks(5605), "Pattie_Schuppe@yahoo.com", "Pattie", "Pattie Schuppe", true, "Schuppe", "1-343-428-2356 x635", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/834.jpg", "StudentO9K9vKmh" },
                    { 47, "80166 Kamryn Ways, Garrettmouth, Liechtenstein", "Lindgrenborough", new DateTime(2022, 10, 28, 22, 5, 15, 485, DateTimeKind.Local).AddTicks(8731), "Alford67@hotmail.com", "Alford", "Alford Predovic", true, "Predovic", "(268) 805-6498 x068", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1175.jpg", "Student5bu3az7n" },
                    { 48, "425 Lexus Via, Jaydaview, Bahamas", "Runolfsdottirville", new DateTime(2023, 6, 27, 2, 26, 8, 858, DateTimeKind.Local).AddTicks(6907), "Toy5@yahoo.com", "Toy", "Toy Brakus", false, "Brakus", "(717) 413-5552", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1022.jpg", "StudentuPcysZix" },
                    { 49, "98165 Kamille Camp, South Miguel, Ethiopia", "Guillermoville", new DateTime(2023, 6, 14, 5, 0, 56, 549, DateTimeKind.Local).AddTicks(5468), "Casey84@yahoo.com", "Casey", "Casey Stroman", true, "Stroman", "773-857-7689 x15936", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/379.jpg", "StudentmJ74P7St" },
                    { 50, "395 Beer Views, Millsville, Mauritius", "Bernhardton", new DateTime(2023, 2, 1, 2, 18, 40, 944, DateTimeKind.Local).AddTicks(3348), "Aurelio67@hotmail.com", "Aurelio", "Aurelio Jacobi", false, "Jacobi", "947.429.8923 x251", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1011.jpg", "Student0uc4N1rr" }
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
