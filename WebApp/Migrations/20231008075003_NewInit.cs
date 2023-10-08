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
                name: "tbNews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNews", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    readed = table.Column<bool>(type: "bit", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    userConnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNotification", x => x.Id);
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
                name: "tbQnA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbQnA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbTicketDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSupporter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameSupporter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTicketDTO", x => x.Id);
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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailToConfirm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    NewsID = table.Column<int>(type: "int", nullable: false),
                    NewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbComments_tbNews_NewsID",
                        column: x => x.NewsID,
                        principalTable: "tbNews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupporterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbFacilities_tbUsers_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "tbUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbUserConn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Connected = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    NotiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserConn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbUserConn_tbNotification_NotiId",
                        column: x => x.NotiId,
                        principalTable: "tbNotification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbUserConn_tbUsers_UserId",
                        column: x => x.UserId,
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
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
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
                columns: new[] { "Id", "Description", "Name", "SupporterId" },
                values: new object[,]
                {
                    { 1, "All problems related to class-rooms", "Class-rooms", null },
                    { 2, "All problems related to labs", "Labs", null },
                    { 3, "All problems related to hostels", "Hostels", null },
                    { 4, "All problems related to mess", "Mess", null },
                    { 5, "All problems related to canteen", "Canteen", null },
                    { 6, "All problems related to gymnasium", "Gymnasium", null },
                    { 7, "All problems related to Computer Centre", "Computer Centre", null },
                    { 8, "All problems related to library", "Library", null },
                    { 9, "All problems related to after-school clubs", "After-school clubs", null },
                    { 10, "Other problems", "Other problems", null }
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
                columns: new[] { "Id", "Code", "Email", "EmailToConfirm", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "sXNojQck", "superadmin@gmail.com", null, "$2a$11$f4NtXkuuho3xD9IQsAWdv.vRjwWDj5yCQTr58XnFLeAv0Ui0gbryW", "Admin", true, "SuperAdmin" },
                    { 2, "XgSDxR5C", "supporter@gmail.com", null, "$2a$11$5O8tiAYHEHjPTeKJKC53nucLxAZdoqZa/tBqN18xhOaSiyF4Xdr9u", "Supporter", true, "Supporter" },
                    { 3, "hInhFW3p", "user@gmail.com", null, "$2a$11$O4MzLmd1m2uyv8edIUivfeDDZvVXyw4rviTrNLIDDyu.PJTe0gmY6", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "74558 Breanne Vista, Rohanside, Monaco", "Wisokyland", new DateTime(2023, 3, 23, 6, 5, 46, 927, DateTimeKind.Local).AddTicks(1122), "onhdexmapletest1991@gmail.com", "Reginald", "Reginald Bogisich", false, "Bogisich", "1-796-779-0061 x89918", "StudentzlcOJFab" },
                    { 3, "84569 Taya Views, Victorside, Belarus", "Labadieside", new DateTime(2023, 4, 21, 1, 2, 15, 771, DateTimeKind.Local).AddTicks(7281), "onhdexmapletest1993@gmail.com", "Dean", "Dean Abernathy", true, "Abernathy", "617-868-5044 x255", "Student1evQbHGE" },
                    { 5, "8954 Mosciski Mall, West Agustina, Ireland", "Paolostad", new DateTime(2023, 1, 3, 18, 7, 50, 152, DateTimeKind.Local).AddTicks(7547), "onhdexmapletest1995@gmail.com", "Kaycee", "Kaycee Becker", false, "Becker", "740.205.1628 x0044", "StudentIaPwzkHt" },
                    { 7, "1198 Kessler Meadows, North Dejahstad, Liechtenstein", "Port Carlee", new DateTime(2023, 7, 21, 17, 41, 52, 232, DateTimeKind.Local).AddTicks(2165), "onhdexmapletest1997@gmail.com", "Federico", "Federico Wisozk", true, "Wisozk", "623.611.0785 x488", "StudentbfhSCkIM" },
                    { 9, "5957 Reichert Circles, Harveyburgh, Bulgaria", "Kaylihaven", new DateTime(2023, 8, 5, 17, 30, 35, 13, DateTimeKind.Local).AddTicks(5744), "onhdexmapletest1999@gmail.com", "Mariam", "Mariam Wilkinson", true, "Wilkinson", "(815) 200-8674", "StudentUZy0UuOQ" },
                    { 11, "61342 D'Amore Shores, Elmerville, Eritrea", "North Erik", new DateTime(2022, 10, 25, 20, 58, 14, 193, DateTimeKind.Local).AddTicks(4424), "onhdexmapletest19911@gmail.com", "Elian", "Elian Casper", true, "Casper", "511-682-6298", "StudentmNXRU12I" },
                    { 13, "13983 Lacy Park, Leolaville, Japan", "Fernfort", new DateTime(2023, 7, 15, 18, 15, 33, 755, DateTimeKind.Local).AddTicks(6163), "onhdexmapletest19913@gmail.com", "Marc", "Marc Stroman", true, "Stroman", "1-640-661-6964 x33235", "StudentvZpLSY2t" },
                    { 15, "890 Rath Plain, Powlowskiport, French Polynesia", "Littelside", new DateTime(2022, 10, 17, 1, 38, 31, 890, DateTimeKind.Local).AddTicks(3562), "onhdexmapletest19915@gmail.com", "Dorothy", "Dorothy Kerluke", true, "Kerluke", "(494) 337-6383", "StudentnONjaitQ" },
                    { 17, "510 Ana Locks, North Tyshawnfurt, Belize", "Lake Emelyville", new DateTime(2023, 8, 11, 16, 21, 11, 36, DateTimeKind.Local).AddTicks(2817), "onhdexmapletest19917@gmail.com", "Maddison", "Maddison Donnelly", true, "Donnelly", "345.998.6311 x92242", "StudentpHMXOra7" },
                    { 19, "410 Kulas Lodge, Orlomouth, Malaysia", "Ramonview", new DateTime(2023, 2, 25, 5, 6, 30, 644, DateTimeKind.Local).AddTicks(505), "onhdexmapletest19919@gmail.com", "Piper", "Piper Jakubowski", false, "Jakubowski", "1-852-469-4820 x5027", "Student4obemsEC" },
                    { 21, "897 Meghan Point, Port Fayechester, United States of America", "Port Kristinashire", new DateTime(2023, 8, 18, 19, 33, 9, 631, DateTimeKind.Local).AddTicks(647), "onhdexmapletest19921@gmail.com", "Giovanny", "Giovanny Rogahn", false, "Rogahn", "559.270.7414", "StudentsAXwh9ke" },
                    { 23, "1456 Little Fork, East Wernerfurt, Holy See (Vatican City State)", "Hahnchester", new DateTime(2023, 6, 9, 20, 50, 7, 38, DateTimeKind.Local).AddTicks(6086), "onhdexmapletest19923@gmail.com", "Bernhard", "Bernhard Feil", true, "Feil", "1-337-323-9286 x58516", "StudentOZZxcfj2" },
                    { 25, "94428 Sadie Mount, West Cedrick, Maldives", "West Ezequiel", new DateTime(2023, 3, 3, 12, 10, 35, 468, DateTimeKind.Local).AddTicks(5277), "onhdexmapletest19925@gmail.com", "Melody", "Melody Morar", true, "Morar", "1-869-922-1914 x9019", "Student3exa0BYY" },
                    { 27, "945 Casper Crest, Rooseveltshire, South Georgia and the South Sandwich Islands", "East Hilarioside", new DateTime(2022, 11, 16, 17, 20, 29, 212, DateTimeKind.Local).AddTicks(118), "onhdexmapletest19927@gmail.com", "Hellen", "Hellen Spencer", false, "Spencer", "(841) 887-3378 x318", "Student2Zh34a3G" },
                    { 29, "4104 Block Falls, Iciefort, Dominican Republic", "West Makenzie", new DateTime(2023, 1, 21, 12, 56, 58, 208, DateTimeKind.Local).AddTicks(326), "onhdexmapletest19929@gmail.com", "May", "May Jacobs", true, "Jacobs", "1-368-633-6783 x1286", "StudentrKT0EViy" },
                    { 31, "717 Terry Hills, Port Isabelle, Trinidad and Tobago", "Nienowfurt", new DateTime(2023, 7, 23, 22, 56, 21, 398, DateTimeKind.Local).AddTicks(9536), "onhdexmapletest19931@gmail.com", "Syble", "Syble Kuhlman", true, "Kuhlman", "290.247.9832", "StudentDGD2U9cS" },
                    { 33, "93859 Gerry Lake, South Anjaliport, Iran", "New Alainahaven", new DateTime(2023, 7, 14, 15, 58, 11, 703, DateTimeKind.Local).AddTicks(4698), "onhdexmapletest19933@gmail.com", "Dejah", "Dejah Rohan", true, "Rohan", "1-589-975-5329", "StudentG2XU4oh0" },
                    { 35, "05341 Steuber Ridges, McGlynnmouth, Haiti", "North Orrinshire", new DateTime(2023, 2, 10, 9, 57, 20, 721, DateTimeKind.Local).AddTicks(1402), "onhdexmapletest19935@gmail.com", "Gabriella", "Gabriella Ferry", true, "Ferry", "489.872.3232", "StudentsVVGRjmI" },
                    { 37, "9545 Cassidy Lodge, Nicolaport, Iraq", "Kayland", new DateTime(2023, 2, 15, 8, 30, 1, 464, DateTimeKind.Local).AddTicks(2851), "onhdexmapletest19937@gmail.com", "Jeromy", "Jeromy Waters", false, "Waters", "479.964.7614", "StudentswIvXZMy" },
                    { 39, "941 Williamson Fall, Glennieburgh, Serbia", "Lake Tessie", new DateTime(2023, 1, 17, 7, 43, 12, 437, DateTimeKind.Local).AddTicks(8519), "onhdexmapletest19939@gmail.com", "Jett", "Jett Tremblay", false, "Tremblay", "673-377-5777 x63626", "Student5f14cGiu" },
                    { 41, "928 Raphael Expressway, Port Agnesstad, El Salvador", "West Donnachester", new DateTime(2023, 1, 28, 16, 34, 17, 189, DateTimeKind.Local).AddTicks(3284), "onhdexmapletest19941@gmail.com", "Arvel", "Arvel Terry", true, "Terry", "1-772-257-9689 x31688", "StudentuDoQGe4O" },
                    { 43, "02594 Arlene Via, Sedrickburgh, South Africa", "North Karsonfort", new DateTime(2022, 10, 11, 22, 55, 16, 141, DateTimeKind.Local).AddTicks(4650), "onhdexmapletest19943@gmail.com", "Celestino", "Celestino Adams", false, "Adams", "238-372-1175 x2620", "Studentmr3RQbT6" },
                    { 45, "10180 Daugherty Curve, Ariellemouth, Nepal", "South Kianastad", new DateTime(2023, 9, 22, 4, 12, 47, 236, DateTimeKind.Local).AddTicks(3400), "onhdexmapletest19945@gmail.com", "Camilla", "Camilla Schmidt", false, "Schmidt", "663.217.9683", "Studentdkh5RA1U" },
                    { 47, "7518 Lennie Wall, Cronaville, Republic of Korea", "Lake Darrenshire", new DateTime(2023, 5, 20, 21, 29, 37, 911, DateTimeKind.Local).AddTicks(6536), "onhdexmapletest19947@gmail.com", "Omer", "Omer Kub", false, "Kub", "536.407.6244 x5071", "Student4k0tpTsS" },
                    { 49, "370 Elroy Forest, Fisherhaven, Faroe Islands", "Narcisofurt", new DateTime(2023, 6, 26, 22, 14, 38, 389, DateTimeKind.Local).AddTicks(5479), "onhdexmapletest19949@gmail.com", "Christy", "Christy Kuvalis", true, "Kuvalis", "596-733-7863", "StudentvgxzOobh" },
                    { 51, "943 Barton Viaduct, Gerholdburgh, Niue", "Windlerville", new DateTime(2023, 2, 5, 15, 35, 55, 661, DateTimeKind.Local).AddTicks(3081), "onhdexmapletest19951@gmail.com", "Ezekiel", "Ezekiel Murazik", true, "Murazik", "733-590-4487", "Student1IxBkYAm" },
                    { 53, "90718 Mayra Spur, North Cheyennetown, Sri Lanka", "Nikolausfort", new DateTime(2023, 6, 1, 1, 52, 10, 740, DateTimeKind.Local).AddTicks(1775), "onhdexmapletest19953@gmail.com", "Joshua", "Joshua McCullough", true, "McCullough", "535.316.3521 x321", "StudentTwEE9A9O" },
                    { 55, "51689 Major Roads, South Easterchester, Slovakia (Slovak Republic)", "Julesstad", new DateTime(2023, 5, 11, 4, 10, 0, 599, DateTimeKind.Local).AddTicks(836), "onhdexmapletest19955@gmail.com", "Desiree", "Desiree Bosco", true, "Bosco", "(417) 765-5310 x94729", "StudentOblLzEW3" },
                    { 57, "60853 Effertz Radial, East Eliezertown, Angola", "West Jerrelltown", new DateTime(2023, 1, 28, 11, 5, 49, 528, DateTimeKind.Local).AddTicks(9688), "onhdexmapletest19957@gmail.com", "Tiffany", "Tiffany King", true, "King", "1-493-683-8381 x8584", "Student7ODxEpqo" },
                    { 59, "1092 Marks Haven, South Bill, Moldova", "Lake Novafort", new DateTime(2023, 5, 23, 17, 24, 5, 935, DateTimeKind.Local).AddTicks(3934), "onhdexmapletest19959@gmail.com", "Marta", "Marta Cormier", true, "Cormier", "396.701.7464 x4829", "StudenthStjcGp6" },
                    { 61, "433 Wiegand Shores, Malachishire, Tanzania", "Vanshire", new DateTime(2023, 1, 5, 0, 38, 54, 637, DateTimeKind.Local).AddTicks(9279), "onhdexmapletest19961@gmail.com", "Colin", "Colin Dicki", true, "Dicki", "(706) 338-3263 x661", "Student0GFl28Rc" },
                    { 63, "192 Forrest Spring, Port Wallace, Yemen", "Cristinaborough", new DateTime(2023, 8, 30, 7, 28, 44, 886, DateTimeKind.Local).AddTicks(3999), "onhdexmapletest19963@gmail.com", "Marilou", "Marilou Rutherford", true, "Rutherford", "1-782-962-6761", "Student8WPGsJAF" },
                    { 65, "809 Vito Greens, O'Keefebury, Japan", "East Aylintown", new DateTime(2023, 7, 28, 22, 29, 20, 360, DateTimeKind.Local).AddTicks(5740), "onhdexmapletest19965@gmail.com", "Jena", "Jena Kreiger", true, "Kreiger", "1-612-822-6970 x15568", "Student7p2mjyrd" },
                    { 67, "64659 Noemi Grove, West Murphymouth, Mongolia", "Alisonstad", new DateTime(2022, 10, 11, 10, 34, 34, 194, DateTimeKind.Local).AddTicks(2675), "onhdexmapletest19967@gmail.com", "Adolphus", "Adolphus Lang", false, "Lang", "1-589-294-6904", "StudentpN8FdJyl" },
                    { 69, "576 Justina Extensions, Laruemouth, Turkey", "Lake Marielle", new DateTime(2023, 2, 18, 7, 49, 52, 422, DateTimeKind.Local).AddTicks(8914), "onhdexmapletest19969@gmail.com", "Kelsie", "Kelsie Blick", false, "Blick", "(430) 383-7004", "StudentbgbMituW" },
                    { 71, "1462 Melyssa Creek, New Stanleymouth, Slovenia", "Lake Benny", new DateTime(2023, 1, 7, 8, 18, 30, 15, DateTimeKind.Local).AddTicks(9811), "onhdexmapletest19971@gmail.com", "Diamond", "Diamond Romaguera", true, "Romaguera", "1-852-854-9469 x1969", "StudentZlHOSatD" },
                    { 73, "2425 Casimer Flat, Conradchester, Liechtenstein", "Levibury", new DateTime(2023, 7, 20, 9, 22, 7, 399, DateTimeKind.Local).AddTicks(1022), "onhdexmapletest19973@gmail.com", "Bailee", "Bailee Kertzmann", true, "Kertzmann", "(771) 415-0148", "Studentk5iyIZqR" },
                    { 75, "549 Alberto Crossing, Fritzton, Luxembourg", "East Valerieberg", new DateTime(2023, 1, 10, 11, 10, 26, 957, DateTimeKind.Local).AddTicks(9239), "onhdexmapletest19975@gmail.com", "Newton", "Newton Lakin", true, "Lakin", "674.258.9245 x724", "StudentFLQXI7bG" },
                    { 77, "330 D'Amore Light, Andersonburgh, Serbia", "Raeganhaven", new DateTime(2023, 4, 26, 9, 29, 48, 177, DateTimeKind.Local).AddTicks(9476), "onhdexmapletest19977@gmail.com", "Vicenta", "Vicenta Jakubowski", true, "Jakubowski", "(249) 507-7535 x392", "Student50sxgRem" },
                    { 79, "48128 Samantha Parkway, West Ewald, Saint Martin", "Libbiebury", new DateTime(2023, 9, 14, 1, 27, 36, 856, DateTimeKind.Local).AddTicks(2448), "onhdexmapletest19979@gmail.com", "Laverna", "Laverna Johnson", true, "Johnson", "333.818.3812 x95303", "StudentLvWkNq7w" },
                    { 81, "825 Rath Loop, West Zion, Cook Islands", "North Ellenfort", new DateTime(2022, 11, 20, 7, 28, 24, 830, DateTimeKind.Local).AddTicks(2470), "onhdexmapletest19981@gmail.com", "Kattie", "Kattie Hickle", false, "Hickle", "303-874-1576 x58668", "StudentCRBDcSuO" },
                    { 83, "153 Tabitha Roads, East Oswald, Republic of Korea", "Emmaleeview", new DateTime(2022, 11, 8, 21, 31, 1, 883, DateTimeKind.Local).AddTicks(8763), "onhdexmapletest19983@gmail.com", "Kitty", "Kitty Homenick", true, "Homenick", "744-305-4628 x73296", "StudentGg5srxkf" },
                    { 85, "972 Kattie Square, Ashlybury, Venezuela", "West Bennettfort", new DateTime(2023, 4, 21, 18, 7, 20, 412, DateTimeKind.Local).AddTicks(4241), "onhdexmapletest19985@gmail.com", "Luna", "Luna Kerluke", false, "Kerluke", "793.492.7760", "StudentbWCoUJ2z" },
                    { 87, "828 Langworth Lane, West Jacinthe, Gabon", "Port Isobel", new DateTime(2023, 2, 17, 9, 35, 5, 639, DateTimeKind.Local).AddTicks(9682), "onhdexmapletest19987@gmail.com", "Michele", "Michele Daniel", true, "Daniel", "257.325.1895", "StudentU0Qp1bno" },
                    { 89, "845 Gerhold Burg, Jeraldmouth, Heard Island and McDonald Islands", "Port Cristal", new DateTime(2023, 5, 17, 9, 14, 16, 235, DateTimeKind.Local).AddTicks(5499), "onhdexmapletest19989@gmail.com", "Moshe", "Moshe Gerhold", false, "Gerhold", "330-224-1489", "StudentQZGbgR5r" },
                    { 91, "47673 O'Connell Points, Laurianefort, Japan", "Lake Granville", new DateTime(2023, 3, 5, 19, 33, 4, 185, DateTimeKind.Local).AddTicks(4799), "onhdexmapletest19991@gmail.com", "Walton", "Walton McGlynn", true, "McGlynn", "856-996-0571", "StudenthWeLoM9s" },
                    { 93, "57342 Herzog Skyway, Bernadetteberg, Ukraine", "North Mabel", new DateTime(2023, 1, 28, 18, 24, 46, 873, DateTimeKind.Local).AddTicks(8343), "onhdexmapletest19993@gmail.com", "Letitia", "Letitia Ullrich", true, "Ullrich", "465-484-3989", "StudentzqiMk2qJ" },
                    { 95, "9368 Grant Harbors, Dooleychester, American Samoa", "South Hoytfurt", new DateTime(2023, 8, 30, 22, 14, 29, 166, DateTimeKind.Local).AddTicks(2534), "onhdexmapletest19995@gmail.com", "Phyllis", "Phyllis Streich", true, "Streich", "1-733-350-8501 x750", "StudentfIcHzFs9" },
                    { 97, "999 Collins Row, Morissetteland, Nepal", "Hattieton", new DateTime(2023, 2, 23, 13, 5, 13, 822, DateTimeKind.Local).AddTicks(4426), "onhdexmapletest19997@gmail.com", "Brandt", "Brandt Carter", false, "Carter", "698-551-3363 x6066", "StudentfACWu3hP" },
                    { 99, "70526 Hayes Park, Danielbury, Bolivia", "Lake Deannachester", new DateTime(2023, 9, 8, 5, 51, 2, 991, DateTimeKind.Local).AddTicks(8957), "onhdexmapletest19999@gmail.com", "Megane", "Megane Torphy", true, "Torphy", "579-292-2057", "Studenta5NIwFZG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbComments_NewsID",
                table: "tbComments",
                column: "NewsID");

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
                name: "IX_tbFacilities_SupporterId",
                table: "tbFacilities",
                column: "SupporterId");

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
                name: "IX_tbUserConn_NotiId",
                table: "tbUserConn",
                column: "NotiId",
                unique: true,
                filter: "[NotiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserConn_UserId",
                table: "tbUserConn",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserInfo_UserId",
                table: "tbUserInfo",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbComments");

            migrationBuilder.DropTable(
                name: "tbDiscussion");

            migrationBuilder.DropTable(
                name: "tbQnA");

            migrationBuilder.DropTable(
                name: "tbTicketDTO");

            migrationBuilder.DropTable(
                name: "tbUserConn");

            migrationBuilder.DropTable(
                name: "tbUserInfo");

            migrationBuilder.DropTable(
                name: "tbUsersInfo");

            migrationBuilder.DropTable(
                name: "tbNews");

            migrationBuilder.DropTable(
                name: "tbTicket");

            migrationBuilder.DropTable(
                name: "tbNotification");

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
