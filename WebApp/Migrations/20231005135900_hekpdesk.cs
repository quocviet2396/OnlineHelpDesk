using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class hekpdesk : Migration
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
                    { 1, "qvwdN58I", "superadmin@gmail.com", "$2a$11$YwokxByOb8K6D3Zxeh3Q.uYeVI2y5NZy.isx/eQWZGn0NSw332dRG", "Admin", true, "SuperAdmin" },
                    { 2, "tR0RmLPV", "supporter@gmail.com", "$2a$11$J7ktN4YWgIFDJm6HFCxky.zSuyPf6.Qs0FcGIhnZkdcafLn5RcxBW", "Supporter", true, "Supporter" },
                    { 3, "91UBfWES", "user@gmail.com", "$2a$11$HQbib9hUn.QVLtmRit78MOvKI68FrHGvTXn4w5spSqQzPV6e4vdpa", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "8401 Leilani Streets, South Raheemberg, Seychelles", "North Alexamouth", new DateTime(2022, 11, 9, 17, 2, 8, 490, DateTimeKind.Local).AddTicks(5449), "onhdexmapletest1991@gmail.com", "Myrtie", "Myrtie Walker", true, "Walker", "858-245-2440", "Student70q8dHAZ" },
                    { 3, "066 Lemke Mews, East Alfordville, Heard Island and McDonald Islands", "North Annabelle", new DateTime(2023, 8, 28, 11, 10, 29, 130, DateTimeKind.Local).AddTicks(1338), "onhdexmapletest1993@gmail.com", "Daija", "Daija Gleason", true, "Gleason", "378-428-4464 x90629", "StudentUrasKYMK" },
                    { 5, "4390 Gislason Mews, Terrillburgh, Uruguay", "Lake Arlo", new DateTime(2023, 7, 8, 13, 1, 36, 992, DateTimeKind.Local).AddTicks(8580), "onhdexmapletest1995@gmail.com", "Zaria", "Zaria Windler", true, "Windler", "(339) 679-8163", "StudentNFbLUbF1" },
                    { 7, "2784 Ova Ports, Lake Joanie, Sri Lanka", "Lake Jalonmouth", new DateTime(2023, 7, 22, 6, 22, 56, 934, DateTimeKind.Local).AddTicks(602), "onhdexmapletest1997@gmail.com", "Julius", "Julius Heaney", true, "Heaney", "208.666.8067 x203", "StudentW1Ae9Viv" },
                    { 9, "6433 Runte Lodge, East Cydneybury, British Indian Ocean Territory (Chagos Archipelago)", "Port Hillarymouth", new DateTime(2022, 10, 24, 5, 11, 15, 963, DateTimeKind.Local).AddTicks(1470), "onhdexmapletest1999@gmail.com", "Eugene", "Eugene Maggio", false, "Maggio", "1-715-941-4988 x1526", "StudentU6va2kFL" },
                    { 11, "298 Llewellyn Orchard, Kurtisburgh, Palau", "Port Naomieshire", new DateTime(2023, 4, 17, 6, 1, 20, 633, DateTimeKind.Local).AddTicks(4116), "onhdexmapletest19911@gmail.com", "Hillary", "Hillary Hessel", false, "Hessel", "1-520-635-6693 x18226", "Studentr0J2Jn7S" },
                    { 13, "71015 Dereck Junction, Port Lucinda, Georgia", "New Maximus", new DateTime(2023, 1, 27, 15, 12, 13, 993, DateTimeKind.Local).AddTicks(4272), "onhdexmapletest19913@gmail.com", "Eryn", "Eryn Brown", true, "Brown", "1-483-393-2080 x3862", "StudentOh4R9d7l" },
                    { 15, "89643 Rafael Ville, West Tom, Hungary", "Lake Justinestad", new DateTime(2023, 7, 7, 15, 19, 29, 456, DateTimeKind.Local).AddTicks(3835), "onhdexmapletest19915@gmail.com", "Jensen", "Jensen Little", false, "Little", "295-792-8880 x00029", "StudentR7rC8smm" },
                    { 17, "92147 Kassandra Club, Jacyntheshire, Lao People's Democratic Republic", "Reillyberg", new DateTime(2022, 11, 25, 11, 14, 21, 798, DateTimeKind.Local).AddTicks(9088), "onhdexmapletest19917@gmail.com", "Alba", "Alba Conn", true, "Conn", "(265) 861-1812 x66903", "StudentmVmSr8VU" },
                    { 19, "8196 Filiberto Port, West Chelsea, Palau", "Deborahborough", new DateTime(2023, 1, 20, 8, 20, 55, 656, DateTimeKind.Local).AddTicks(9011), "onhdexmapletest19919@gmail.com", "Krystina", "Krystina Cummerata", false, "Cummerata", "271-270-0355", "StudentCbdMVSz0" },
                    { 21, "690 Anjali Lights, East Turner, Paraguay", "East Malika", new DateTime(2023, 7, 30, 9, 38, 2, 513, DateTimeKind.Local).AddTicks(5517), "onhdexmapletest19921@gmail.com", "Verla", "Verla Kris", false, "Kris", "324.790.1105", "StudentblQc1Keq" },
                    { 23, "1766 Dach Club, Leonieberg, Macao", "Ritchieton", new DateTime(2023, 3, 22, 2, 21, 31, 61, DateTimeKind.Local).AddTicks(7959), "onhdexmapletest19923@gmail.com", "Theresa", "Theresa Tremblay", false, "Tremblay", "1-441-239-8950 x201", "StudentqXp11Ule" },
                    { 25, "5665 Milton Turnpike, Hickletown, Vanuatu", "Port Hillarymouth", new DateTime(2022, 10, 15, 18, 45, 22, 65, DateTimeKind.Local).AddTicks(5532), "onhdexmapletest19925@gmail.com", "Thora", "Thora Littel", true, "Littel", "587-945-8974 x81373", "Studentxa9ZaGrz" },
                    { 27, "35255 Meagan Squares, North Shanel, Bahrain", "South Jon", new DateTime(2022, 12, 19, 0, 33, 50, 360, DateTimeKind.Local).AddTicks(2477), "onhdexmapletest19927@gmail.com", "Kacey", "Kacey Crooks", true, "Crooks", "272.541.0897 x61129", "Studenta4Uxj9rK" },
                    { 29, "43403 Kreiger Fork, Niaport, Tokelau", "Anastacioton", new DateTime(2023, 8, 30, 1, 22, 26, 420, DateTimeKind.Local).AddTicks(3269), "onhdexmapletest19929@gmail.com", "Shaniya", "Shaniya Okuneva", true, "Okuneva", "536.594.3495 x858", "StudentFjdUFu1f" },
                    { 31, "952 Flatley Ridges, New Daltonland, Cayman Islands", "Port Mohammedstad", new DateTime(2023, 8, 18, 20, 15, 31, 634, DateTimeKind.Local).AddTicks(9405), "onhdexmapletest19931@gmail.com", "August", "August Turner", false, "Turner", "1-438-849-9264 x1025", "Student1hwBldAi" },
                    { 33, "42591 West Keys, Lake Cortneyton, Gabon", "Meghanshire", new DateTime(2023, 5, 5, 12, 44, 20, 983, DateTimeKind.Local).AddTicks(5999), "onhdexmapletest19933@gmail.com", "Zakary", "Zakary Littel", false, "Littel", "1-482-589-1628", "StudentI8pLzCwa" },
                    { 35, "48711 Lakin Junction, Lake Lenorastad, Trinidad and Tobago", "New Clarabelle", new DateTime(2022, 10, 15, 3, 6, 1, 654, DateTimeKind.Local).AddTicks(7059), "onhdexmapletest19935@gmail.com", "Lafayette", "Lafayette Hahn", true, "Hahn", "1-406-328-6960", "StudentiJ6jJvzj" },
                    { 37, "41522 Marcella Plaza, West Rhoda, Moldova", "Bellaville", new DateTime(2023, 8, 16, 10, 47, 55, 859, DateTimeKind.Local).AddTicks(9009), "onhdexmapletest19937@gmail.com", "Ally", "Ally Kerluke", true, "Kerluke", "1-958-681-3685 x1050", "StudentgnQPZxZj" },
                    { 39, "9736 Jacobson Mall, Ashlynnburgh, Croatia", "Lake Stellachester", new DateTime(2023, 7, 5, 19, 23, 15, 72, DateTimeKind.Local).AddTicks(5591), "onhdexmapletest19939@gmail.com", "Dwight", "Dwight Ziemann", false, "Ziemann", "648-652-9782 x70941", "StudentistSe0Yd" },
                    { 41, "111 Gibson Track, Ovafort, American Samoa", "Lake Emmalee", new DateTime(2022, 11, 7, 10, 0, 58, 861, DateTimeKind.Local).AddTicks(9543), "onhdexmapletest19941@gmail.com", "Rahul", "Rahul Medhurst", false, "Medhurst", "823.316.7080", "StudentHThIRvRA" },
                    { 43, "64460 Zulauf Courts, Robertsbury, Turkey", "Port Beauland", new DateTime(2022, 11, 4, 19, 47, 54, 904, DateTimeKind.Local).AddTicks(5360), "onhdexmapletest19943@gmail.com", "Andre", "Andre Heller", false, "Heller", "1-727-732-9047 x4920", "StudentGvphuIYK" },
                    { 45, "481 Abshire Inlet, Hermannburgh, Turks and Caicos Islands", "Lake Courtney", new DateTime(2023, 8, 26, 12, 49, 23, 403, DateTimeKind.Local).AddTicks(7478), "onhdexmapletest19945@gmail.com", "Ariane", "Ariane Lockman", true, "Lockman", "1-778-333-4931", "StudentpYNbhAG2" },
                    { 47, "872 Bertrand Fork, Paulborough, Christmas Island", "West Pascaleborough", new DateTime(2023, 5, 4, 22, 51, 6, 277, DateTimeKind.Local).AddTicks(3375), "onhdexmapletest19947@gmail.com", "Julianne", "Julianne Gorczany", true, "Gorczany", "1-342-554-8331", "Studentwd0ha4A2" },
                    { 49, "0488 Bartholome Extension, Cyrilfurt, Ghana", "East Theron", new DateTime(2023, 1, 29, 13, 2, 14, 764, DateTimeKind.Local).AddTicks(1507), "onhdexmapletest19949@gmail.com", "Rosario", "Rosario Beer", true, "Beer", "(533) 545-3670 x6930", "StudentDPqAe0et" },
                    { 51, "960 Daugherty Passage, Port Yessenia, Christmas Island", "Phyllisborough", new DateTime(2023, 9, 14, 14, 32, 53, 459, DateTimeKind.Local).AddTicks(3699), "onhdexmapletest19951@gmail.com", "Joshuah", "Joshuah Sauer", true, "Sauer", "(784) 399-3170 x605", "StudentQIXqndnH" },
                    { 53, "4106 Medhurst Canyon, Davinside, Djibouti", "North Lemuelview", new DateTime(2022, 12, 2, 10, 19, 32, 290, DateTimeKind.Local).AddTicks(2074), "onhdexmapletest19953@gmail.com", "Tyrell", "Tyrell Pfannerstill", false, "Pfannerstill", "(496) 742-6426", "StudentOr15LLQY" },
                    { 55, "05280 Rogahn Drive, New Marisol, Cayman Islands", "Larkinshire", new DateTime(2023, 8, 15, 21, 31, 34, 229, DateTimeKind.Local).AddTicks(9817), "onhdexmapletest19955@gmail.com", "Jasen", "Jasen Kiehn", false, "Kiehn", "1-427-922-0827", "StudentcWItK6t2" },
                    { 57, "9055 Margot Bypass, O'Konport, Ecuador", "Lake Serenity", new DateTime(2023, 6, 30, 20, 43, 39, 850, DateTimeKind.Local).AddTicks(6999), "onhdexmapletest19957@gmail.com", "Toney", "Toney Grimes", false, "Grimes", "432.245.7466", "StudentOVPxtu71" },
                    { 59, "891 Avery Land, Port Maria, Northern Mariana Islands", "East Consueloborough", new DateTime(2023, 1, 13, 3, 17, 32, 749, DateTimeKind.Local).AddTicks(8632), "onhdexmapletest19959@gmail.com", "Ezequiel", "Ezequiel Hauck", true, "Hauck", "803-962-2771 x51591", "StudentpWOkprUz" },
                    { 61, "486 Koelpin Avenue, Schmidthaven, Romania", "Wymanchester", new DateTime(2023, 6, 16, 16, 13, 4, 62, DateTimeKind.Local).AddTicks(7565), "onhdexmapletest19961@gmail.com", "Vernice", "Vernice McClure", false, "McClure", "1-331-868-0908 x18204", "StudentMgw2bTxv" },
                    { 63, "2659 Cierra Via, North Anastad, Guatemala", "Emieberg", new DateTime(2023, 2, 19, 11, 27, 43, 92, DateTimeKind.Local).AddTicks(7413), "onhdexmapletest19963@gmail.com", "Sam", "Sam Ferry", true, "Ferry", "835-844-5813", "StudentnqIIRGSo" },
                    { 65, "038 Daniel Branch, Hansenchester, Philippines", "New Hans", new DateTime(2023, 8, 3, 3, 39, 41, 778, DateTimeKind.Local).AddTicks(6902), "onhdexmapletest19965@gmail.com", "Darren", "Darren MacGyver", false, "MacGyver", "1-992-752-8135", "StudentbjNP02Bb" },
                    { 67, "7302 Carter Parkways, Pfannerstillton, Gambia", "Gulgowskiport", new DateTime(2023, 3, 19, 21, 28, 54, 263, DateTimeKind.Local).AddTicks(5283), "onhdexmapletest19967@gmail.com", "Jewel", "Jewel Hessel", false, "Hessel", "(650) 454-4370 x08694", "StudentlIeyv2H5" },
                    { 69, "716 Taya Oval, Port Kennith, Zimbabwe", "Grantmouth", new DateTime(2023, 5, 22, 22, 6, 7, 411, DateTimeKind.Local).AddTicks(277), "onhdexmapletest19969@gmail.com", "Marisa", "Marisa Oberbrunner", true, "Oberbrunner", "(620) 795-3776", "Student2uBSxZWh" },
                    { 71, "2702 Consuelo Pines, West Seth, Mali", "Lake Jackyfurt", new DateTime(2023, 4, 15, 19, 2, 37, 572, DateTimeKind.Local).AddTicks(3828), "onhdexmapletest19971@gmail.com", "Chyna", "Chyna Brown", false, "Brown", "293-906-9458", "StudenteOBnrd1U" },
                    { 73, "7638 Jo Station, North Cassie, Slovakia (Slovak Republic)", "New Stefan", new DateTime(2023, 9, 24, 15, 1, 0, 942, DateTimeKind.Local).AddTicks(2518), "onhdexmapletest19973@gmail.com", "Ila", "Ila Barton", true, "Barton", "949.838.4119 x549", "Student3dek43to" },
                    { 75, "6296 Hartmann Stravenue, Schmelerport, Iran", "Lake Bryceshire", new DateTime(2023, 2, 15, 6, 37, 55, 267, DateTimeKind.Local).AddTicks(283), "onhdexmapletest19975@gmail.com", "Florian", "Florian Collins", false, "Collins", "891.580.6628", "StudentKLARbbCp" },
                    { 77, "28796 Connelly Cliff, Pacochachester, Lao People's Democratic Republic", "Hackettmouth", new DateTime(2023, 5, 12, 11, 1, 41, 424, DateTimeKind.Local).AddTicks(4697), "onhdexmapletest19977@gmail.com", "Adolfo", "Adolfo Leannon", false, "Leannon", "671.937.8615 x6064", "StudentYG5N0eu8" },
                    { 79, "43841 Golda Ranch, New Elfriedahaven, Lesotho", "McKenziestad", new DateTime(2023, 2, 17, 22, 16, 14, 313, DateTimeKind.Local).AddTicks(2306), "onhdexmapletest19979@gmail.com", "Karley", "Karley Collier", true, "Collier", "(256) 553-2181", "Student48UAqEJk" },
                    { 81, "250 Kailyn Gardens, Wuckertside, Ethiopia", "Lake Erick", new DateTime(2023, 2, 21, 5, 26, 22, 722, DateTimeKind.Local).AddTicks(7142), "onhdexmapletest19981@gmail.com", "Dewayne", "Dewayne Kuvalis", false, "Kuvalis", "737.674.6586", "StudentzkX8SFAk" },
                    { 83, "9685 Perry Spurs, Schoenburgh, Pakistan", "Port Tessie", new DateTime(2023, 7, 18, 13, 15, 17, 787, DateTimeKind.Local).AddTicks(6351), "onhdexmapletest19983@gmail.com", "Anika", "Anika Leffler", true, "Leffler", "261-825-9249", "StudentDJuvSKm0" },
                    { 85, "0060 Devin Extension, West Aidan, New Caledonia", "East Madelyn", new DateTime(2023, 8, 14, 2, 46, 38, 132, DateTimeKind.Local).AddTicks(4888), "onhdexmapletest19985@gmail.com", "Karlie", "Karlie Shanahan", true, "Shanahan", "1-776-264-8894", "StudentTkcW8cQx" },
                    { 87, "08573 Zemlak Stravenue, Faheybury, Slovakia (Slovak Republic)", "Mabelland", new DateTime(2022, 12, 24, 4, 25, 58, 713, DateTimeKind.Local).AddTicks(1224), "onhdexmapletest19987@gmail.com", "Freddie", "Freddie Jacobs", true, "Jacobs", "1-306-962-2178 x86593", "StudentOoH2su69" },
                    { 89, "758 Mossie Lodge, Charityshire, Malawi", "D'Amoreport", new DateTime(2022, 10, 23, 5, 23, 16, 802, DateTimeKind.Local).AddTicks(1554), "onhdexmapletest19989@gmail.com", "Raymond", "Raymond Luettgen", true, "Luettgen", "315.593.9581", "Student4WlGnXrJ" },
                    { 91, "1279 Ebert Ranch, Bartellville, New Zealand", "East Leora", new DateTime(2022, 12, 3, 0, 13, 52, 978, DateTimeKind.Local).AddTicks(684), "onhdexmapletest19991@gmail.com", "Webster", "Webster Dickinson", true, "Dickinson", "926-890-5922", "StudentzCpN5yPK" },
                    { 93, "479 Verona Neck, South Owenburgh, Thailand", "Ziemannton", new DateTime(2023, 3, 27, 13, 14, 37, 723, DateTimeKind.Local).AddTicks(3208), "onhdexmapletest19993@gmail.com", "Christy", "Christy Jenkins", true, "Jenkins", "966.597.9039", "StudentDoqdlcOE" },
                    { 95, "6032 Thad Cove, Port Erikaport, Macao", "Lake Arnoldmouth", new DateTime(2023, 6, 16, 9, 57, 25, 958, DateTimeKind.Local).AddTicks(6095), "onhdexmapletest19995@gmail.com", "Josiah", "Josiah Hoppe", false, "Hoppe", "711-433-8726 x9609", "Student0r32xSyI" },
                    { 97, "104 Dusty Keys, Howellchester, Chad", "Schmelerland", new DateTime(2023, 4, 24, 2, 59, 6, 115, DateTimeKind.Local).AddTicks(4126), "onhdexmapletest19997@gmail.com", "Austyn", "Austyn Ankunding", false, "Ankunding", "(966) 229-8319", "StudentELqpsMy1" },
                    { 99, "38772 Betty Meadow, Port Edwardside, Germany", "Pagacborough", new DateTime(2023, 8, 22, 14, 57, 44, 7, DateTimeKind.Local).AddTicks(5249), "onhdexmapletest19999@gmail.com", "Janae", "Janae Paucek", false, "Paucek", "676.883.1733 x010", "StudentGTe8A0ov" }
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
