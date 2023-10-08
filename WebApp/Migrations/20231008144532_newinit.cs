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
                name: "tbNews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailToConfirm = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, "OrOn9vIJ", "superadmin@gmail.com", null, "$2a$11$rxfuJMFdE6xqHIYj/UG1uu702XGPV8vnqIlI2eoDRsaGK/ZcCJnpK", "Admin", true, "SuperAdmin" },
                    { 2, "FFfcdlzt", "supporter@gmail.com", null, "$2a$11$pKR2f34WfgBIGCFEMJUZuuXp9HWzNQlS2SS6cSoEKWCYTwQIxhfhS", "Supporter", true, "Supporter" },
                    { 3, "OkULN53T", "user@gmail.com", null, "$2a$11$vxJprsbJt7/gOEFzaMoLaeXTRSPcCZRqAUgMFFj4G9o3oI1KG8rny", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "63879 Pouros Mountain, Krajcikberg, Montenegro", "Darianafort", new DateTime(2022, 11, 6, 13, 40, 29, 32, DateTimeKind.Local).AddTicks(6861), "onhdexmapletest1991@gmail.com", "Braden", "Braden McCullough", true, "McCullough", "1-228-580-4623 x79166", "StudentETM4KHOY" },
                    { 3, "93956 Milan Views, Port Sydneyfurt, Anguilla", "Lake Quentinmouth", new DateTime(2022, 12, 13, 13, 46, 0, 242, DateTimeKind.Local).AddTicks(9930), "onhdexmapletest1993@gmail.com", "Lucius", "Lucius Torp", true, "Torp", "(772) 681-5585 x4870", "Student2Bzm3DRq" },
                    { 5, "398 Mary Square, South Autumnton, Iraq", "Jailynmouth", new DateTime(2023, 6, 18, 7, 37, 4, 254, DateTimeKind.Local).AddTicks(3051), "onhdexmapletest1995@gmail.com", "Kamryn", "Kamryn Kassulke", true, "Kassulke", "(373) 433-1421", "Student7b66PBbB" },
                    { 7, "57782 Dagmar Spring, Port Ottilie, Yemen", "East Dustyburgh", new DateTime(2023, 7, 26, 7, 54, 24, 222, DateTimeKind.Local).AddTicks(4116), "onhdexmapletest1997@gmail.com", "Emmanuelle", "Emmanuelle West", true, "West", "666.368.1322 x01309", "StudentKqx7a9en" },
                    { 9, "0971 Abshire Rest, Port Alessandraberg, Saint Martin", "Port Gertrude", new DateTime(2023, 9, 3, 7, 23, 14, 880, DateTimeKind.Local).AddTicks(4295), "onhdexmapletest1999@gmail.com", "Tressie", "Tressie McDermott", false, "McDermott", "(727) 848-7550", "StudentljSgwRkL" },
                    { 11, "6449 Cremin Path, North Maeganbury, Bahamas", "Carletonville", new DateTime(2023, 2, 18, 3, 55, 41, 879, DateTimeKind.Local).AddTicks(3643), "onhdexmapletest19911@gmail.com", "Olin", "Olin Halvorson", false, "Halvorson", "836-484-9986", "StudenttxJuVxZb" },
                    { 13, "81521 Lakin Ramp, West Mose, Georgia", "Robertshire", new DateTime(2023, 5, 6, 17, 39, 32, 181, DateTimeKind.Local).AddTicks(5063), "onhdexmapletest19913@gmail.com", "Mable", "Mable Schultz", true, "Schultz", "510.531.6613 x5975", "StudentbaSOykLv" },
                    { 15, "0350 Agustina Extensions, Funkshire, Guernsey", "West Forestport", new DateTime(2023, 6, 5, 20, 36, 44, 993, DateTimeKind.Local).AddTicks(1606), "onhdexmapletest19915@gmail.com", "Vicenta", "Vicenta Kris", true, "Kris", "(680) 935-3679 x14989", "StudentLmi9iqPt" },
                    { 17, "726 Carissa Garden, Favianport, Saint Vincent and the Grenadines", "Berryland", new DateTime(2022, 10, 10, 0, 35, 53, 216, DateTimeKind.Local).AddTicks(3485), "onhdexmapletest19917@gmail.com", "Rogelio", "Rogelio Dickinson", true, "Dickinson", "1-229-798-3235 x971", "Student8Q17JEcO" },
                    { 19, "978 Jerde Curve, South Saigeport, Mozambique", "East Sashatown", new DateTime(2023, 10, 8, 0, 35, 48, 135, DateTimeKind.Local).AddTicks(1494), "onhdexmapletest19919@gmail.com", "Talia", "Talia Will", false, "Will", "1-683-207-9585", "StudentJ7ukzZXJ" },
                    { 21, "2421 DuBuque Coves, Port Jaymeland, Tanzania", "Normaport", new DateTime(2022, 11, 16, 19, 0, 14, 410, DateTimeKind.Local).AddTicks(7276), "onhdexmapletest19921@gmail.com", "Josianne", "Josianne Weimann", false, "Weimann", "950.761.7246 x8853", "StudentgBQhZgOK" },
                    { 23, "43323 Brandon Parkway, Trevorview, Macao", "East Armand", new DateTime(2023, 5, 4, 22, 47, 5, 809, DateTimeKind.Local).AddTicks(4800), "onhdexmapletest19923@gmail.com", "Ruthie", "Ruthie Cummerata", true, "Cummerata", "800-294-8238 x170", "StudentyZMRogUr" },
                    { 25, "5280 Cortney Land, East Josh, Slovakia (Slovak Republic)", "Heaneychester", new DateTime(2023, 3, 12, 2, 8, 23, 202, DateTimeKind.Local).AddTicks(4213), "onhdexmapletest19925@gmail.com", "Marilou", "Marilou Davis", true, "Davis", "(430) 817-9686", "StudentJQQUILvL" },
                    { 27, "077 Stephen Ranch, East Matteotown, Macao", "Port Bethfort", new DateTime(2023, 9, 17, 20, 44, 32, 356, DateTimeKind.Local).AddTicks(6097), "onhdexmapletest19927@gmail.com", "Abbie", "Abbie Kuhn", false, "Kuhn", "(485) 494-7777 x81461", "StudentSuhMWyIw" },
                    { 29, "546 Nicolas Inlet, West Hillardview, Holy See (Vatican City State)", "North Ryley", new DateTime(2023, 5, 4, 17, 58, 56, 351, DateTimeKind.Local).AddTicks(9273), "onhdexmapletest19929@gmail.com", "Brannon", "Brannon Sawayn", true, "Sawayn", "1-343-700-1036", "StudentfxrnGNMw" },
                    { 31, "64338 Sanford Roads, Harveyport, Hungary", "East Georgette", new DateTime(2022, 12, 22, 14, 40, 0, 806, DateTimeKind.Local).AddTicks(7026), "onhdexmapletest19931@gmail.com", "Toby", "Toby Kling", true, "Kling", "578-250-9457", "StudenthkIiUmFt" },
                    { 33, "367 Walker Meadow, Funkview, Norfolk Island", "Sanfordborough", new DateTime(2023, 1, 10, 7, 22, 8, 120, DateTimeKind.Local).AddTicks(7917), "onhdexmapletest19933@gmail.com", "Zakary", "Zakary Erdman", false, "Erdman", "507.677.2950 x1480", "StudentTn7WGqii" },
                    { 35, "157 Yost Road, Reillystad, Zimbabwe", "South Careytown", new DateTime(2023, 10, 7, 15, 38, 23, 307, DateTimeKind.Local).AddTicks(8985), "onhdexmapletest19935@gmail.com", "Kolby", "Kolby Gleichner", false, "Gleichner", "1-922-317-3153", "StudentBl3nJdiM" },
                    { 37, "93972 Erdman Springs, Boydbury, Togo", "Lake Murl", new DateTime(2023, 1, 19, 19, 42, 24, 290, DateTimeKind.Local).AddTicks(5393), "onhdexmapletest19937@gmail.com", "Sally", "Sally Pouros", true, "Pouros", "962-808-5792 x26465", "Studentwd0bwyAz" },
                    { 39, "0529 Ben Viaduct, North Fiona, Republic of Korea", "East Zetta", new DateTime(2023, 3, 7, 13, 2, 39, 963, DateTimeKind.Local).AddTicks(6017), "onhdexmapletest19939@gmail.com", "Sylvester", "Sylvester Marks", true, "Marks", "(956) 567-9901", "StudentB2WaEyBB" },
                    { 41, "923 Nannie Hills, Schillerside, Macedonia", "East Timothybury", new DateTime(2023, 1, 24, 13, 54, 57, 957, DateTimeKind.Local).AddTicks(5382), "onhdexmapletest19941@gmail.com", "Darryl", "Darryl Nicolas", false, "Nicolas", "693.220.7521", "StudentDkB0Y5Hu" },
                    { 43, "01926 King Tunnel, Vandervortland, Latvia", "Lake Mariah", new DateTime(2023, 5, 25, 0, 50, 25, 351, DateTimeKind.Local).AddTicks(7433), "onhdexmapletest19943@gmail.com", "Eli", "Eli Robel", false, "Robel", "(321) 741-0000", "Student3Aalh5nF" },
                    { 45, "8959 McCullough Lock, Jadonville, Albania", "Darleneshire", new DateTime(2023, 2, 19, 16, 10, 23, 409, DateTimeKind.Local).AddTicks(9315), "onhdexmapletest19945@gmail.com", "Benjamin", "Benjamin Smith", true, "Smith", "(445) 585-3983", "Studentch7xEUcm" },
                    { 47, "3494 Faustino Manors, Beahanside, Haiti", "O'Connerchester", new DateTime(2023, 6, 25, 7, 27, 59, 719, DateTimeKind.Local).AddTicks(9075), "onhdexmapletest19947@gmail.com", "Audrey", "Audrey Dare", false, "Dare", "(917) 600-9797 x451", "Studentwf0I6IN1" },
                    { 49, "189 Diana Turnpike, Wymanburgh, Macedonia", "Ednafort", new DateTime(2023, 1, 9, 2, 33, 30, 964, DateTimeKind.Local).AddTicks(4073), "onhdexmapletest19949@gmail.com", "Edna", "Edna Heaney", false, "Heaney", "328.653.0748", "Student8yCa6fit" },
                    { 51, "4192 Dickens Villages, Purdychester, Cote d'Ivoire", "Port Brooklyn", new DateTime(2022, 11, 4, 21, 35, 12, 118, DateTimeKind.Local).AddTicks(6926), "onhdexmapletest19951@gmail.com", "Paula", "Paula Carroll", false, "Carroll", "1-864-276-8714", "Student80umIKhU" },
                    { 53, "44309 Pamela Port, Katlynland, Svalbard & Jan Mayen Islands", "West Ebony", new DateTime(2023, 4, 8, 21, 24, 39, 646, DateTimeKind.Local).AddTicks(9669), "onhdexmapletest19953@gmail.com", "Myrtle", "Myrtle Wiza", true, "Wiza", "(388) 380-7661 x38825", "StudentW9ndOFVn" },
                    { 55, "777 Rempel Locks, East Tillmanside, Serbia", "Destinville", new DateTime(2023, 8, 5, 8, 57, 59, 767, DateTimeKind.Local).AddTicks(2088), "onhdexmapletest19955@gmail.com", "Leonor", "Leonor Kshlerin", true, "Kshlerin", "829-259-8468 x19846", "StudentSkhsWGLA" },
                    { 57, "0235 Sandy Ramp, New Estel, Croatia", "Cheyannefurt", new DateTime(2023, 6, 12, 10, 50, 55, 634, DateTimeKind.Local).AddTicks(724), "onhdexmapletest19957@gmail.com", "Salma", "Salma Heaney", true, "Heaney", "(637) 261-9247", "Student1tbrOhbd" },
                    { 59, "76084 Rose Point, North Angus, Jordan", "West Augustus", new DateTime(2023, 6, 22, 23, 46, 39, 288, DateTimeKind.Local).AddTicks(3434), "onhdexmapletest19959@gmail.com", "Michale", "Michale Schaefer", true, "Schaefer", "1-574-591-8462", "StudentSyWZskVg" },
                    { 61, "67747 Christa Estate, North Gay, Thailand", "Hermannbury", new DateTime(2023, 7, 6, 7, 19, 3, 115, DateTimeKind.Local).AddTicks(2885), "onhdexmapletest19961@gmail.com", "Destinee", "Destinee Buckridge", false, "Buckridge", "1-762-656-0472", "Studentivfzs4kw" },
                    { 63, "2539 Beau Plains, Shanamouth, Mauritania", "Lake Torey", new DateTime(2023, 7, 31, 17, 32, 31, 322, DateTimeKind.Local).AddTicks(1243), "onhdexmapletest19963@gmail.com", "Elaina", "Elaina O'Conner", false, "O'Conner", "(238) 710-2851", "StudentVJfb3Erp" },
                    { 65, "66082 Sonny Forges, West Rosie, Sweden", "Wiegandview", new DateTime(2023, 1, 15, 19, 8, 57, 422, DateTimeKind.Local).AddTicks(3494), "onhdexmapletest19965@gmail.com", "Arlo", "Arlo Zemlak", true, "Zemlak", "243-510-9064", "StudentJDPXwWfH" },
                    { 67, "23078 Morar Grove, Port Angusmouth, Brazil", "East Everettburgh", new DateTime(2023, 2, 7, 12, 35, 22, 383, DateTimeKind.Local).AddTicks(8992), "onhdexmapletest19967@gmail.com", "Guido", "Guido Roberts", false, "Roberts", "894.618.2135 x44845", "StudentG9EKL9zq" },
                    { 69, "220 Dario View, Hesseltown, Colombia", "Vickieton", new DateTime(2023, 5, 30, 11, 39, 5, 701, DateTimeKind.Local).AddTicks(3065), "onhdexmapletest19969@gmail.com", "Nedra", "Nedra Quitzon", true, "Quitzon", "1-795-723-8313", "Student3CKe5aEO" },
                    { 71, "54132 Vladimir Estates, Boyershire, Congo", "West Jewelfort", new DateTime(2023, 2, 27, 7, 48, 23, 583, DateTimeKind.Local).AddTicks(6560), "onhdexmapletest19971@gmail.com", "Macey", "Macey Runte", true, "Runte", "947.535.9349", "StudentHBfRNoka" },
                    { 73, "5531 Maximillia Junctions, McCulloughside, Antigua and Barbuda", "Vivienberg", new DateTime(2023, 9, 22, 20, 1, 12, 262, DateTimeKind.Local).AddTicks(1900), "onhdexmapletest19973@gmail.com", "Armani", "Armani Schroeder", false, "Schroeder", "419.688.8985", "StudentQPHMj8sH" },
                    { 75, "171 Doris Orchard, Deckowstad, Nepal", "South Horacio", new DateTime(2023, 3, 23, 0, 36, 22, 525, DateTimeKind.Local).AddTicks(297), "onhdexmapletest19975@gmail.com", "Stan", "Stan Dare", true, "Dare", "782-924-4109 x39022", "StudentRmsNFShy" },
                    { 77, "23427 Nader Villages, Uptonchester, Montenegro", "Whiteville", new DateTime(2023, 6, 9, 3, 31, 20, 370, DateTimeKind.Local).AddTicks(6935), "onhdexmapletest19977@gmail.com", "Cleve", "Cleve Bergnaum", true, "Bergnaum", "549.785.4591 x6515", "StudentWyhMxFq7" },
                    { 79, "070 Zora Inlet, Keanustad, Pakistan", "Deannachester", new DateTime(2023, 4, 3, 4, 56, 29, 77, DateTimeKind.Local).AddTicks(9714), "onhdexmapletest19979@gmail.com", "Elenor", "Elenor Brekke", true, "Brekke", "794-837-7415", "StudentFk7FsNTJ" },
                    { 81, "59492 Russel Greens, Wizachester, Belarus", "South Angel", new DateTime(2022, 11, 7, 14, 56, 44, 555, DateTimeKind.Local).AddTicks(4276), "onhdexmapletest19981@gmail.com", "Skyla", "Skyla Ritchie", false, "Ritchie", "(358) 971-4282", "StudentvHNxmCd1" },
                    { 83, "05485 Koepp Junctions, East Maxime, Barbados", "Kovacekland", new DateTime(2023, 6, 14, 23, 31, 53, 72, DateTimeKind.Local).AddTicks(7599), "onhdexmapletest19983@gmail.com", "Casper", "Casper Barton", true, "Barton", "(311) 317-0691 x752", "StudentFQeSl9Jp" },
                    { 85, "16076 Auer Knoll, Port Monserratville, Poland", "Dietrichside", new DateTime(2022, 10, 24, 23, 13, 52, 509, DateTimeKind.Local).AddTicks(3652), "onhdexmapletest19985@gmail.com", "Kay", "Kay Hills", true, "Hills", "925-998-4141", "StudentODsMVNkB" },
                    { 87, "48734 Carolanne Cliffs, Madilynton, Bosnia and Herzegovina", "Gusikowskiport", new DateTime(2023, 8, 23, 14, 59, 30, 23, DateTimeKind.Local).AddTicks(8939), "onhdexmapletest19987@gmail.com", "Teresa", "Teresa Kuphal", false, "Kuphal", "1-896-869-3466 x544", "StudentkaxGWZ11" },
                    { 89, "422 Ondricka Shoals, Rowlandburgh, Pakistan", "Gussieton", new DateTime(2023, 8, 12, 7, 2, 44, 182, DateTimeKind.Local).AddTicks(8429), "onhdexmapletest19989@gmail.com", "Abdul", "Abdul Doyle", false, "Doyle", "619.414.2358", "Students0q2nqoU" },
                    { 91, "124 Glover Course, Port Fatima, Mauritania", "Port Ellenhaven", new DateTime(2023, 9, 27, 13, 35, 4, 786, DateTimeKind.Local).AddTicks(5103), "onhdexmapletest19991@gmail.com", "Kirk", "Kirk Lemke", false, "Lemke", "283-539-4828 x6012", "StudentW1XFW3pG" },
                    { 93, "535 Pollich Course, Port Maximo, Martinique", "Port Nikki", new DateTime(2022, 11, 14, 22, 30, 31, 210, DateTimeKind.Local).AddTicks(6126), "onhdexmapletest19993@gmail.com", "America", "America Koch", true, "Koch", "259-704-2556 x2358", "StudentJued2jEr" },
                    { 95, "4213 Rodger Turnpike, Lavonport, Argentina", "Noemieville", new DateTime(2023, 6, 10, 8, 4, 27, 632, DateTimeKind.Local).AddTicks(8103), "onhdexmapletest19995@gmail.com", "Isabelle", "Isabelle Orn", false, "Orn", "(877) 601-1186 x3287", "StudentSH5YonAL" },
                    { 97, "52267 Metz Centers, Port Edmund, Ecuador", "West Nataliahaven", new DateTime(2023, 3, 15, 16, 51, 15, 291, DateTimeKind.Local).AddTicks(258), "onhdexmapletest19997@gmail.com", "Nikki", "Nikki Boyle", false, "Boyle", "(865) 211-8050", "Student7JsuvJZq" },
                    { 99, "388 Marks Valleys, Pearlbury, Puerto Rico", "Merlbury", new DateTime(2023, 2, 19, 14, 26, 46, 81, DateTimeKind.Local).AddTicks(2642), "onhdexmapletest19999@gmail.com", "Bill", "Bill Buckridge", true, "Buckridge", "368.603.1907 x0911", "StudentgXeeeg8x" }
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
