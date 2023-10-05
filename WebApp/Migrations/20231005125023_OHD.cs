using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class OHD : Migration
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
                name: "tbTicketDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSupporter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    TicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNameCreator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNameSupporter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    readed = table.Column<bool>(type: "bit", nullable: true)
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
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_tbNotification_tbUserConn_userConnId",
                        column: x => x.userConnId,
                        principalTable: "tbUserConn",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "Code", "Email", "EmailToConfirm", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "E6wPRoQd", "superadmin@gmail.com", null, "$2a$11$qrG/zVunDOEZ8WRxDtP3SePxxy8jWnIOF4D6e97azF9WhZNR04r2G", "Admin", true, "SuperAdmin" },
                    { 2, "E5sIUBbn", "supporter@gmail.com", null, "$2a$11$z6JErkq8hf22jQJcGs9Uyu4OaAuWMMk6NXpRY2cUQBBK0wVZ15k0W", "Supporter", true, "Supporter" },
                    { 3, "mc8ObVIc", "user@gmail.com", null, "$2a$11$OZcCr2fTEkMXoxFEV0vQzeP/hIB2u8P/5zVyx9kVirvgZKJign74a", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "7039 Roberts Passage, Darwinside, Saint Barthelemy", "Port Bette", new DateTime(2022, 12, 13, 7, 50, 12, 193, DateTimeKind.Local).AddTicks(2574), "onhdexmapletest1991@gmail.com", "Ted", "Ted Walter", true, "Walter", "450.718.8166", "StudentZ1PZaN4I" },
                    { 3, "54244 Casper Branch, West Sherwoodborough, Bahrain", "Lake Taniahaven", new DateTime(2023, 7, 17, 14, 59, 25, 242, DateTimeKind.Local).AddTicks(2829), "onhdexmapletest1993@gmail.com", "Amos", "Amos McGlynn", false, "McGlynn", "(385) 229-9142 x0741", "Student0OhLLDGd" },
                    { 5, "5974 Ernser Circle, Gilbertborough, Falkland Islands (Malvinas)", "West Kellen", new DateTime(2022, 11, 9, 15, 43, 58, 98, DateTimeKind.Local).AddTicks(4165), "onhdexmapletest1995@gmail.com", "Myra", "Myra Oberbrunner", false, "Oberbrunner", "1-340-839-2504 x2662", "StudentGTxJ565r" },
                    { 7, "36249 Kub Trafficway, Port Abbigailburgh, Holy See (Vatican City State)", "Susannaport", new DateTime(2023, 9, 7, 17, 32, 28, 377, DateTimeKind.Local).AddTicks(4183), "onhdexmapletest1997@gmail.com", "Aubree", "Aubree Wintheiser", true, "Wintheiser", "(871) 879-9749", "StudentmFRLj4fE" },
                    { 9, "1791 Orlo Trafficway, Kutchburgh, Australia", "South Belleville", new DateTime(2023, 2, 21, 18, 22, 9, 857, DateTimeKind.Local).AddTicks(2848), "onhdexmapletest1999@gmail.com", "Alanna", "Alanna Kozey", true, "Kozey", "1-925-648-4740", "StudenttTGGr3Jc" },
                    { 11, "6465 Helen Views, Hayliemouth, Netherlands", "Port Gladysville", new DateTime(2023, 2, 12, 3, 33, 23, 97, DateTimeKind.Local).AddTicks(2362), "onhdexmapletest19911@gmail.com", "Fae", "Fae Schmidt", false, "Schmidt", "1-739-969-4451", "Studenthw3uG6m3" },
                    { 13, "59674 Alessandra Haven, Bradtkeburgh, Singapore", "Rosenbaumtown", new DateTime(2023, 9, 6, 19, 15, 35, 64, DateTimeKind.Local).AddTicks(2292), "onhdexmapletest19913@gmail.com", "Myron", "Myron Anderson", false, "Anderson", "258.709.6770 x297", "StudentC2MrJd4m" },
                    { 15, "0906 Tamia Inlet, Lake Celestino, Liechtenstein", "Bertramtown", new DateTime(2023, 5, 1, 11, 34, 10, 244, DateTimeKind.Local).AddTicks(552), "onhdexmapletest19915@gmail.com", "Ola", "Ola Rowe", false, "Rowe", "716.426.3023 x425", "StudentlNG8zkt4" },
                    { 17, "750 Bauch Square, Mosciskifurt, Bahrain", "Breitenbergport", new DateTime(2022, 10, 25, 12, 15, 52, 637, DateTimeKind.Local).AddTicks(2142), "onhdexmapletest19917@gmail.com", "Dale", "Dale Kautzer", true, "Kautzer", "(553) 214-7736", "Student4KSWEgOT" },
                    { 19, "8341 Jayne Villages, Lake Marianburgh, Uzbekistan", "West Murphy", new DateTime(2023, 4, 5, 16, 9, 30, 716, DateTimeKind.Local).AddTicks(8501), "onhdexmapletest19919@gmail.com", "Deon", "Deon Trantow", false, "Trantow", "1-942-388-1707 x11618", "StudentHHjy6WI5" },
                    { 21, "970 Heidenreich Field, McGlynnbury, Brunei Darussalam", "West Helenehaven", new DateTime(2022, 12, 15, 6, 47, 27, 734, DateTimeKind.Local).AddTicks(3733), "onhdexmapletest19921@gmail.com", "Dayton", "Dayton Goodwin", true, "Goodwin", "333.694.3778", "StudentXjWq236C" },
                    { 23, "41918 Herman Courts, West Berta, Georgia", "East Dayna", new DateTime(2023, 8, 10, 8, 14, 19, 504, DateTimeKind.Local).AddTicks(8630), "onhdexmapletest19923@gmail.com", "Margaretta", "Margaretta Daniel", false, "Daniel", "(988) 866-0387", "StudentmHx4kF4h" },
                    { 25, "5186 Buckridge Pine, Goyettechester, Jordan", "West Barneyburgh", new DateTime(2022, 11, 11, 12, 28, 0, 423, DateTimeKind.Local).AddTicks(1038), "onhdexmapletest19925@gmail.com", "Robert", "Robert Swift", true, "Swift", "(906) 448-5711", "StudentiOFB87md" },
                    { 27, "239 Josue River, Lake Rooseveltmouth, Luxembourg", "Lake Myrtle", new DateTime(2023, 8, 3, 23, 58, 45, 940, DateTimeKind.Local).AddTicks(8523), "onhdexmapletest19927@gmail.com", "Alison", "Alison Kuvalis", true, "Kuvalis", "992-957-8483 x64079", "StudentAMrqTA6E" },
                    { 29, "879 O'Connell Land, Franciscaland, Palau", "North Bernard", new DateTime(2022, 12, 15, 17, 28, 21, 337, DateTimeKind.Local).AddTicks(7731), "onhdexmapletest19929@gmail.com", "Kaia", "Kaia Tremblay", false, "Tremblay", "(862) 469-3397 x298", "Student1BJ2Pswp" },
                    { 31, "018 Ryleigh Mission, East Durwardshire, Brazil", "East Bernicestad", new DateTime(2023, 8, 27, 3, 26, 45, 86, DateTimeKind.Local).AddTicks(4636), "onhdexmapletest19931@gmail.com", "Hyman", "Hyman Daugherty", false, "Daugherty", "(922) 812-5047 x346", "StudentVBHFDZzm" },
                    { 33, "362 Dave Island, South Gerardtown, Mozambique", "Isobelstad", new DateTime(2023, 7, 23, 18, 10, 4, 337, DateTimeKind.Local).AddTicks(3682), "onhdexmapletest19933@gmail.com", "Abdul", "Abdul Wisoky", false, "Wisoky", "716-356-2607 x68391", "StudentIR0BMYRt" },
                    { 35, "384 Kunze Alley, North Rico, Norfolk Island", "West Mike", new DateTime(2023, 8, 24, 2, 17, 34, 967, DateTimeKind.Local).AddTicks(9740), "onhdexmapletest19935@gmail.com", "Hardy", "Hardy Huels", true, "Huels", "946-998-2992 x843", "StudentJHNnRPXN" },
                    { 37, "55411 Pagac Junctions, Murphyfurt, Niue", "Port Jadenton", new DateTime(2022, 12, 31, 10, 42, 9, 497, DateTimeKind.Local).AddTicks(3110), "onhdexmapletest19937@gmail.com", "Thea", "Thea Marvin", false, "Marvin", "1-826-378-2211", "StudentpMOQHTtJ" },
                    { 39, "938 Simonis Skyway, New Terrellburgh, Namibia", "North Alainaview", new DateTime(2023, 6, 20, 19, 56, 18, 924, DateTimeKind.Local).AddTicks(2427), "onhdexmapletest19939@gmail.com", "Sanford", "Sanford Collins", true, "Collins", "(454) 806-8631 x109", "Student7yKSVBrp" },
                    { 41, "9188 Alvah Union, Miracleport, Antigua and Barbuda", "Aaliyahchester", new DateTime(2023, 6, 20, 18, 30, 10, 541, DateTimeKind.Local).AddTicks(1248), "onhdexmapletest19941@gmail.com", "Victoria", "Victoria Koepp", false, "Koepp", "927.307.9854 x09456", "StudentDusEFLix" },
                    { 43, "89980 Mallie Tunnel, South Aishafort, Gabon", "Lemkeburgh", new DateTime(2022, 10, 17, 1, 43, 27, 488, DateTimeKind.Local).AddTicks(6414), "onhdexmapletest19943@gmail.com", "Urban", "Urban Bartell", true, "Bartell", "288-451-6428 x534", "StudentfvdzM33Q" },
                    { 45, "523 Sandra Brooks, Lake Zacheryland, Gambia", "West Juliestad", new DateTime(2023, 8, 25, 16, 8, 49, 968, DateTimeKind.Local).AddTicks(8995), "onhdexmapletest19945@gmail.com", "Dayne", "Dayne Jast", false, "Jast", "(739) 970-9813 x298", "StudentKP5WgHhP" },
                    { 47, "741 Bosco Field, Aileenmouth, Maldives", "Adamsbury", new DateTime(2023, 6, 18, 1, 58, 16, 529, DateTimeKind.Local).AddTicks(2957), "onhdexmapletest19947@gmail.com", "Xavier", "Xavier Wolff", false, "Wolff", "564-218-2108", "StudentiC1xmrM9" },
                    { 49, "202 Kenyon Greens, Simonisstad, Montserrat", "Stiedemannmouth", new DateTime(2023, 2, 10, 9, 10, 27, 892, DateTimeKind.Local).AddTicks(2623), "onhdexmapletest19949@gmail.com", "Ashtyn", "Ashtyn Ernser", false, "Ernser", "1-280-667-4404 x7249", "StudentAiATaMns" },
                    { 51, "372 Hand Rest, East Tyshawnfort, Switzerland", "East Ellsworthborough", new DateTime(2023, 7, 11, 1, 48, 52, 634, DateTimeKind.Local).AddTicks(3881), "onhdexmapletest19951@gmail.com", "Joanie", "Joanie Bradtke", true, "Bradtke", "975.650.9558 x81148", "StudentZ2wLrpgT" },
                    { 53, "2859 Judah Island, Mariloufurt, Cayman Islands", "Jasperfort", new DateTime(2023, 7, 1, 17, 26, 17, 547, DateTimeKind.Local).AddTicks(9152), "onhdexmapletest19953@gmail.com", "Emerson", "Emerson Koch", false, "Koch", "514-591-0143 x8879", "Studentl1KypmAv" },
                    { 55, "46763 McDermott Alley, Roweton, Zambia", "Reynoldsside", new DateTime(2023, 5, 4, 5, 23, 33, 580, DateTimeKind.Local).AddTicks(1607), "onhdexmapletest19955@gmail.com", "Jamel", "Jamel Strosin", false, "Strosin", "1-238-353-7417 x99098", "StudentrmtLZvJc" },
                    { 57, "43003 Berge Manor, South Ashleigh, Cook Islands", "Port Conradfort", new DateTime(2023, 4, 25, 12, 36, 38, 172, DateTimeKind.Local).AddTicks(49), "onhdexmapletest19957@gmail.com", "Russel", "Russel Mayer", true, "Mayer", "(307) 634-5826", "Studentay4MJ1BE" },
                    { 59, "4360 Tito Parks, Cullenview, Morocco", "Runtemouth", new DateTime(2023, 5, 27, 3, 27, 38, 644, DateTimeKind.Local).AddTicks(9028), "onhdexmapletest19959@gmail.com", "Melany", "Melany Berge", false, "Berge", "887-908-4464", "StudentyoPbij1M" },
                    { 61, "28927 Jan Expressway, Eliseport, Italy", "Louveniastad", new DateTime(2023, 2, 17, 16, 13, 9, 264, DateTimeKind.Local).AddTicks(8237), "onhdexmapletest19961@gmail.com", "Nora", "Nora Reynolds", false, "Reynolds", "1-693-291-8325", "StudentMuFyzYkc" },
                    { 63, "075 Daryl Ranch, South Maryamborough, Mongolia", "Reynoldbury", new DateTime(2023, 2, 11, 16, 21, 45, 649, DateTimeKind.Local).AddTicks(5899), "onhdexmapletest19963@gmail.com", "Ilene", "Ilene Roberts", false, "Roberts", "341.922.4478 x717", "Student48G3PCo8" },
                    { 65, "3769 Toy Wells, Gaylordville, Mozambique", "Stokesberg", new DateTime(2023, 8, 30, 10, 40, 22, 273, DateTimeKind.Local).AddTicks(139), "onhdexmapletest19965@gmail.com", "Edison", "Edison D'Amore", true, "D'Amore", "(736) 268-5030", "StudentxnDBEd2u" },
                    { 67, "63278 Lang Harbor, South Daxville, Nauru", "North Nya", new DateTime(2023, 8, 12, 2, 11, 22, 432, DateTimeKind.Local).AddTicks(5943), "onhdexmapletest19967@gmail.com", "Annetta", "Annetta Quitzon", false, "Quitzon", "1-203-421-4487", "StudentF66LsXgJ" },
                    { 69, "37212 Sipes Centers, Langworthland, Somalia", "New Miastad", new DateTime(2022, 12, 12, 2, 21, 32, 511, DateTimeKind.Local).AddTicks(9264), "onhdexmapletest19969@gmail.com", "Yessenia", "Yessenia Gleichner", false, "Gleichner", "740-712-5914 x2266", "StudentsWEMjcb0" },
                    { 71, "97800 Rhett Plaza, Port Deltaland, Guyana", "Brownborough", new DateTime(2023, 5, 14, 10, 21, 25, 8, DateTimeKind.Local).AddTicks(2110), "onhdexmapletest19971@gmail.com", "Nathen", "Nathen Mayer", false, "Mayer", "1-779-390-8301", "Studentth5XDpVQ" },
                    { 73, "02124 Kautzer Springs, Mannfort, Poland", "Pollichchester", new DateTime(2023, 1, 13, 0, 4, 46, 975, DateTimeKind.Local).AddTicks(9801), "onhdexmapletest19973@gmail.com", "Darren", "Darren Spencer", false, "Spencer", "(864) 646-1109 x83330", "Student7Gpl7vjA" },
                    { 75, "736 Raynor Street, Gorczanyburgh, Brazil", "Keeblerborough", new DateTime(2023, 4, 15, 20, 19, 42, 108, DateTimeKind.Local).AddTicks(2650), "onhdexmapletest19975@gmail.com", "Emmet", "Emmet Metz", true, "Metz", "413.816.9210 x7469", "StudentITJpgh9H" },
                    { 77, "83060 O'Hara Corner, Dickinsonberg, Australia", "North Arielle", new DateTime(2023, 8, 12, 8, 25, 38, 399, DateTimeKind.Local).AddTicks(2787), "onhdexmapletest19977@gmail.com", "Leland", "Leland Bogan", false, "Bogan", "378-332-6320 x5225", "Studentn7qQ5YKB" },
                    { 79, "78068 Estell Gateway, North Kendrick, Rwanda", "Lake Luzland", new DateTime(2023, 9, 5, 23, 44, 56, 364, DateTimeKind.Local).AddTicks(9874), "onhdexmapletest19979@gmail.com", "Otha", "Otha Flatley", false, "Flatley", "(883) 973-6488 x46922", "StudentzGWwuQ2U" },
                    { 81, "039 Allene Groves, Gutmannborough, Belgium", "Haleymouth", new DateTime(2023, 2, 3, 10, 27, 37, 593, DateTimeKind.Local).AddTicks(2290), "onhdexmapletest19981@gmail.com", "Flavio", "Flavio Wisoky", false, "Wisoky", "510.762.8845", "StudentHmkzcnPh" },
                    { 83, "99868 Abbott Roads, Khalilmouth, Greece", "Toychester", new DateTime(2022, 10, 15, 23, 18, 47, 729, DateTimeKind.Local).AddTicks(2319), "onhdexmapletest19983@gmail.com", "Anais", "Anais Dibbert", true, "Dibbert", "1-705-492-4526", "StudentKaGD923z" },
                    { 85, "2226 Henderson Via, Gulgowskichester, Svalbard & Jan Mayen Islands", "Muellerfort", new DateTime(2023, 1, 3, 1, 11, 47, 974, DateTimeKind.Local).AddTicks(246), "onhdexmapletest19985@gmail.com", "Jayden", "Jayden Hane", true, "Hane", "783-264-1641 x42932", "StudentkAj43HfT" },
                    { 87, "57868 Eleanora Rue, Lake Sageborough, Micronesia", "North Elmer", new DateTime(2022, 12, 2, 17, 28, 40, 429, DateTimeKind.Local).AddTicks(4558), "onhdexmapletest19987@gmail.com", "Nakia", "Nakia Smith", true, "Smith", "246-522-9853", "StudenttDNbQUjp" },
                    { 89, "0933 Block Radial, Kiaraport, Canada", "New Jalynview", new DateTime(2023, 4, 9, 21, 37, 57, 52, DateTimeKind.Local).AddTicks(6758), "onhdexmapletest19989@gmail.com", "Jacquelyn", "Jacquelyn Trantow", true, "Trantow", "574-607-2029 x9855", "StudentDCyMwJbd" },
                    { 91, "659 Moore Valleys, Emilieborough, Nigeria", "East Mossie", new DateTime(2022, 11, 2, 5, 54, 58, 263, DateTimeKind.Local).AddTicks(2231), "onhdexmapletest19991@gmail.com", "Icie", "Icie Hintz", false, "Hintz", "259.419.9875", "StudenttURNrmoM" },
                    { 93, "2571 Maximilian Squares, East Eleazarmouth, Dominican Republic", "Jackieshire", new DateTime(2023, 7, 5, 6, 9, 32, 583, DateTimeKind.Local).AddTicks(7233), "onhdexmapletest19993@gmail.com", "Rose", "Rose Shanahan", false, "Shanahan", "(630) 349-9482 x5251", "StudentBNt8ssM2" },
                    { 95, "43211 Cronin Ports, Port Marastad, Marshall Islands", "Ahmadchester", new DateTime(2023, 5, 28, 21, 50, 14, 896, DateTimeKind.Local).AddTicks(9000), "onhdexmapletest19995@gmail.com", "Dina", "Dina Wehner", false, "Wehner", "640.970.1812", "StudentDHqWA8Z4" },
                    { 97, "74302 Elisa Garden, Farrellton, Guinea", "Gulgowskifurt", new DateTime(2023, 1, 4, 6, 23, 29, 859, DateTimeKind.Local).AddTicks(385), "onhdexmapletest19997@gmail.com", "Tracey", "Tracey Ward", false, "Ward", "1-436-924-8648 x72860", "Student7P3sXX7W" },
                    { 99, "809 Alan Terrace, South Jennyfer, Cameroon", "West Zechariahfurt", new DateTime(2023, 9, 28, 10, 37, 38, 606, DateTimeKind.Local).AddTicks(5265), "onhdexmapletest19999@gmail.com", "Webster", "Webster Funk", false, "Funk", "(401) 847-9946", "Student48CZhNRm" }
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
                name: "IX_tbNotification_userConnId",
                table: "tbNotification",
                column: "userConnId",
                unique: true,
                filter: "[userConnId] IS NOT NULL");

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
                name: "IX_tbUserConn_UserId",
                table: "tbUserConn",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "tbNotification");

            migrationBuilder.DropTable(
                name: "tbTicketDTO");

            migrationBuilder.DropTable(
                name: "tbUserInfo");

            migrationBuilder.DropTable(
                name: "tbUsersInfo");

            migrationBuilder.DropTable(
                name: "tbNews");

            migrationBuilder.DropTable(
                name: "tbTicket");

            migrationBuilder.DropTable(
                name: "tbUserConn");

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
