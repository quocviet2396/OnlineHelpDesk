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
                    readed = table.Column<bool>(type: "bit", nullable: true),
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
                    UserId = table.Column<int>(type: "int", nullable: true)
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
                    { 1, "6l4PsLO9", "superadmin@gmail.com", "$2a$11$mY1Y4zw7tzAwNL7r9I.VpeBZWS4HFbNiRSE/6ChixFS6.QRXHcSf2", "Admin", true, "SuperAdmin" },
                    { 2, "XqpjXeS7", "supporter@gmail.com", "$2a$11$/adGVdej8MhiH8AinHAVaOEIM7Hp7yYPNlXb34.XbdYfWn6IuqRwy", "Supporter", true, "Supporter" },
                    { 3, "NEc9cFYV", "user@gmail.com", "$2a$11$waI/NsxwY55oeqCKaqCAWOHKTh9ZyJB2hitCTtXlbbi8HjoIF5Z.2", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "02372 Yost Trace, Manteberg, Saint Helena", "Port Chynamouth", new DateTime(2023, 2, 2, 20, 3, 26, 222, DateTimeKind.Local).AddTicks(3703), "onhdexmapletest1991@gmail.com", "Electa", "Electa O'Reilly", false, "O'Reilly", "1-694-822-2022 x91779", "StudentmkkMS9Ii" },
                    { 3, "0276 Howell Crossroad, Scotland, United Kingdom", "Marlonberg", new DateTime(2023, 9, 22, 2, 37, 30, 859, DateTimeKind.Local).AddTicks(5844), "onhdexmapletest1993@gmail.com", "Santos", "Santos Hagenes", false, "Hagenes", "(569) 240-7507 x1183", "Studentb4f9SBsn" },
                    { 5, "273 Aaliyah Turnpike, Lake Sebastianhaven, Svalbard & Jan Mayen Islands", "Schaeferstad", new DateTime(2023, 9, 2, 8, 46, 19, 441, DateTimeKind.Local).AddTicks(5458), "onhdexmapletest1995@gmail.com", "Nestor", "Nestor Huels", false, "Huels", "599-841-2757 x44244", "Studentn9muw4S7" },
                    { 7, "0320 Madie Prairie, Ninaburgh, Isle of Man", "East Odessashire", new DateTime(2022, 12, 4, 23, 40, 42, 88, DateTimeKind.Local).AddTicks(9724), "onhdexmapletest1997@gmail.com", "Ceasar", "Ceasar Thiel", false, "Thiel", "(335) 733-7735 x1141", "Studentn4GotfCW" },
                    { 9, "975 Wilson Isle, Bartonburgh, Tuvalu", "East Leilani", new DateTime(2022, 10, 19, 4, 4, 8, 699, DateTimeKind.Local).AddTicks(8822), "onhdexmapletest1999@gmail.com", "Anjali", "Anjali Marks", false, "Marks", "(310) 612-1157 x50283", "Studentsbx9si7i" },
                    { 11, "750 Dorothea Place, New Deion, Estonia", "Lefflerhaven", new DateTime(2022, 11, 11, 20, 46, 55, 641, DateTimeKind.Local).AddTicks(6550), "onhdexmapletest19911@gmail.com", "Clemens", "Clemens Kozey", false, "Kozey", "345.797.1232 x8640", "StudentBEK6sOia" },
                    { 13, "502 Keeling Shores, Wittingville, Solomon Islands", "Lehnerland", new DateTime(2023, 9, 19, 11, 29, 3, 223, DateTimeKind.Local).AddTicks(1349), "onhdexmapletest19913@gmail.com", "Adah", "Adah Kshlerin", true, "Kshlerin", "(302) 513-9301 x18047", "StudentIIQt3jxh" },
                    { 15, "0219 Lindsey Village, Coltonview, Bahrain", "New Wilson", new DateTime(2023, 7, 22, 20, 2, 1, 362, DateTimeKind.Local).AddTicks(4402), "onhdexmapletest19915@gmail.com", "Cristian", "Cristian Price", true, "Price", "(879) 608-0128", "StudentbNtyIWKn" },
                    { 17, "39476 Everardo Drive, West Dominicfort, Cyprus", "Strosinborough", new DateTime(2023, 7, 11, 20, 5, 50, 709, DateTimeKind.Local).AddTicks(8307), "onhdexmapletest19917@gmail.com", "Russell", "Russell Braun", false, "Braun", "1-420-622-5172", "StudentfWveyI89" },
                    { 19, "307 Wehner Views, Leanneshire, Costa Rica", "Rhiannonmouth", new DateTime(2023, 5, 17, 17, 48, 7, 39, DateTimeKind.Local).AddTicks(9871), "onhdexmapletest19919@gmail.com", "Kaelyn", "Kaelyn Gleason", false, "Gleason", "(373) 218-3236", "StudentGqugi9Td" },
                    { 21, "8673 Halvorson Course, Padbergfort, Ecuador", "Lednerburgh", new DateTime(2023, 3, 28, 11, 29, 31, 453, DateTimeKind.Local).AddTicks(1243), "onhdexmapletest19921@gmail.com", "Earnestine", "Earnestine Collins", false, "Collins", "460.965.5419 x27756", "StudentBNjKKFqw" },
                    { 23, "98614 Abshire Turnpike, Lake Moseland, United Arab Emirates", "West Jaclynchester", new DateTime(2022, 11, 22, 8, 45, 33, 184, DateTimeKind.Local).AddTicks(2026), "onhdexmapletest19923@gmail.com", "Jaiden", "Jaiden Dach", false, "Dach", "622-358-6510", "StudentRjPoacsW" },
                    { 25, "68246 Boyle Station, Lake Denis, Republic of Korea", "North Myra", new DateTime(2023, 6, 1, 22, 52, 39, 806, DateTimeKind.Local).AddTicks(1747), "onhdexmapletest19925@gmail.com", "Jimmy", "Jimmy Mertz", false, "Mertz", "397-562-2345", "StudentdsOfU3oR" },
                    { 27, "46165 Leuschke Oval, Whitefort, Mauritania", "West Davonte", new DateTime(2023, 6, 24, 13, 1, 48, 825, DateTimeKind.Local).AddTicks(4015), "onhdexmapletest19927@gmail.com", "Leonel", "Leonel Cruickshank", false, "Cruickshank", "372-208-2468", "StudentyMudMhVM" },
                    { 29, "89124 Diego Road, Lake Donavon, Martinique", "Port Craigland", new DateTime(2022, 12, 30, 6, 24, 53, 118, DateTimeKind.Local).AddTicks(8182), "onhdexmapletest19929@gmail.com", "Al", "Al Weimann", false, "Weimann", "(818) 281-1228", "StudentUWO2LeUJ" },
                    { 31, "0811 Spencer Hill, North Antwantown, Oman", "Urbanmouth", new DateTime(2023, 5, 23, 3, 47, 24, 599, DateTimeKind.Local).AddTicks(7438), "onhdexmapletest19931@gmail.com", "Judah", "Judah Brown", false, "Brown", "1-319-555-7882 x838", "StudentJu0rJbyu" },
                    { 33, "10988 Catalina Turnpike, Sipesmouth, Micronesia", "Grahamville", new DateTime(2023, 6, 14, 5, 28, 13, 676, DateTimeKind.Local).AddTicks(1875), "onhdexmapletest19933@gmail.com", "Jaquelin", "Jaquelin Schoen", false, "Schoen", "793.288.4098", "StudentmtqiE298" },
                    { 35, "06513 Shanna Green, West Destanyfurt, Cyprus", "South Tonistad", new DateTime(2023, 5, 18, 11, 59, 46, 659, DateTimeKind.Local).AddTicks(6816), "onhdexmapletest19935@gmail.com", "Bo", "Bo Tremblay", false, "Tremblay", "443.449.2300 x9355", "StudentnongdMTf" },
                    { 37, "993 Aaron Mills, Dibbertview, New Zealand", "Metzview", new DateTime(2023, 8, 11, 12, 22, 25, 554, DateTimeKind.Local).AddTicks(6552), "onhdexmapletest19937@gmail.com", "Rose", "Rose McCullough", true, "McCullough", "(395) 565-3762", "StudentwxvFDXCJ" },
                    { 39, "287 Ebony Square, New Lennie, Samoa", "Torpbury", new DateTime(2023, 6, 6, 13, 36, 24, 808, DateTimeKind.Local).AddTicks(7047), "onhdexmapletest19939@gmail.com", "Antonina", "Antonina Mills", true, "Mills", "1-634-652-8747", "StudentmTl3QvW1" },
                    { 41, "7333 Sabina Union, East Elinor, Mozambique", "Johnsonland", new DateTime(2022, 11, 12, 7, 53, 23, 650, DateTimeKind.Local).AddTicks(2132), "onhdexmapletest19941@gmail.com", "Kendra", "Kendra Botsford", true, "Botsford", "1-401-774-3529", "Student40EwlI9K" },
                    { 43, "0674 Kautzer Port, New Karine, Virgin Islands, U.S.", "East Maud", new DateTime(2023, 9, 14, 7, 12, 28, 602, DateTimeKind.Local).AddTicks(7376), "onhdexmapletest19943@gmail.com", "Wendell", "Wendell Abshire", true, "Abshire", "394-776-7867 x51067", "StudentcpkLg4rt" },
                    { 45, "824 Jakob Keys, North Clair, Netherlands Antilles", "Lake Douglas", new DateTime(2023, 5, 17, 3, 52, 50, 797, DateTimeKind.Local).AddTicks(5827), "onhdexmapletest19945@gmail.com", "Kayla", "Kayla Fritsch", true, "Fritsch", "364-436-8668", "StudentIQKPjx36" },
                    { 47, "345 Clair Parkway, Zakaryton, Mayotte", "North Hermina", new DateTime(2023, 6, 23, 9, 8, 55, 859, DateTimeKind.Local).AddTicks(7148), "onhdexmapletest19947@gmail.com", "Owen", "Owen Legros", false, "Legros", "328-918-6022 x024", "StudentqFomIqCs" },
                    { 49, "938 Aubree Springs, North Rosemary, Armenia", "Beierton", new DateTime(2023, 9, 16, 4, 36, 30, 608, DateTimeKind.Local).AddTicks(7041), "onhdexmapletest19949@gmail.com", "Gerry", "Gerry Bogan", true, "Bogan", "573.448.0097 x737", "StudentMYIWTkAO" },
                    { 51, "83943 Ritchie Well, Schummmouth, Chile", "Weissnatville", new DateTime(2023, 9, 21, 9, 56, 31, 181, DateTimeKind.Local).AddTicks(7682), "onhdexmapletest19951@gmail.com", "Benny", "Benny Kulas", true, "Kulas", "1-363-965-2644", "Studenta6bOFFVN" },
                    { 53, "11607 Reichel Parkway, Port Damian, El Salvador", "Hagenesmouth", new DateTime(2023, 1, 25, 22, 51, 52, 736, DateTimeKind.Local).AddTicks(1915), "onhdexmapletest19953@gmail.com", "Audreanne", "Audreanne Von", true, "Von", "341.573.5309", "StudentMf4JHxPV" },
                    { 55, "5980 Hoppe Flat, Morissetteland, Afghanistan", "Lake Pasqualeside", new DateTime(2022, 10, 29, 6, 34, 14, 122, DateTimeKind.Local).AddTicks(6178), "onhdexmapletest19955@gmail.com", "Kenna", "Kenna Wolf", true, "Wolf", "(710) 814-3666 x2075", "Student6HFmmFT5" },
                    { 57, "87751 Maximus Curve, Fannyberg, Liechtenstein", "Lake Scottyside", new DateTime(2023, 6, 26, 17, 37, 37, 707, DateTimeKind.Local).AddTicks(5002), "onhdexmapletest19957@gmail.com", "Christa", "Christa Satterfield", false, "Satterfield", "350.447.3685 x1768", "StudentiOH5o7CY" },
                    { 59, "89846 Elna Trace, North Justinaport, Mongolia", "Humbertostad", new DateTime(2022, 11, 13, 17, 7, 16, 384, DateTimeKind.Local).AddTicks(7279), "onhdexmapletest19959@gmail.com", "Jefferey", "Jefferey Koch", true, "Koch", "344-680-0098 x35694", "StudentUWxhaf9D" },
                    { 61, "9937 Wuckert Pine, Dickinsonview, Czech Republic", "New Zita", new DateTime(2023, 6, 27, 18, 0, 29, 766, DateTimeKind.Local).AddTicks(812), "onhdexmapletest19961@gmail.com", "Jett", "Jett Braun", true, "Braun", "1-765-471-2156 x00754", "StudentGYJFUbiB" },
                    { 63, "02795 Durgan Mountains, East Citlallihaven, Qatar", "New Lesley", new DateTime(2023, 2, 19, 9, 28, 17, 915, DateTimeKind.Local).AddTicks(8665), "onhdexmapletest19963@gmail.com", "Eva", "Eva Carroll", false, "Carroll", "1-407-964-9423 x9616", "StudentO7D1aDmh" },
                    { 65, "4785 Marcellus Rapids, Leschland, Austria", "Port Ninaside", new DateTime(2022, 10, 16, 15, 0, 35, 627, DateTimeKind.Local).AddTicks(1432), "onhdexmapletest19965@gmail.com", "Hoyt", "Hoyt Pfannerstill", true, "Pfannerstill", "1-813-552-2157 x3186", "StudentowhNCfvo" },
                    { 67, "18738 Connelly Plaza, Durganland, Bermuda", "Uliseston", new DateTime(2022, 10, 8, 7, 20, 19, 701, DateTimeKind.Local).AddTicks(4257), "onhdexmapletest19967@gmail.com", "Sigrid", "Sigrid Quigley", true, "Quigley", "972-844-7674 x65552", "Studentgams0sb3" },
                    { 69, "96161 Collier Manor, Ethatown, Brunei Darussalam", "Maximoside", new DateTime(2023, 6, 25, 0, 39, 58, 769, DateTimeKind.Local).AddTicks(2039), "onhdexmapletest19969@gmail.com", "Gillian", "Gillian Pfannerstill", true, "Pfannerstill", "390-947-9046 x4962", "StudentXZVEGLgP" },
                    { 71, "744 Kozey Row, Anabelmouth, Panama", "Emilechester", new DateTime(2022, 11, 10, 8, 33, 21, 562, DateTimeKind.Local).AddTicks(4461), "onhdexmapletest19971@gmail.com", "Mona", "Mona Little", false, "Little", "654-520-8418 x3297", "StudentZ2NeUP9h" },
                    { 73, "599 Hallie Hill, Sawaynmouth, Sri Lanka", "Lake Alan", new DateTime(2023, 1, 20, 0, 15, 15, 412, DateTimeKind.Local).AddTicks(4761), "onhdexmapletest19973@gmail.com", "Amie", "Amie Bode", false, "Bode", "(544) 595-1867", "StudenthLNOpzzy" },
                    { 75, "7350 Maximus Plaza, Asiastad, Guam", "Marlenberg", new DateTime(2022, 10, 10, 1, 34, 12, 800, DateTimeKind.Local).AddTicks(3804), "onhdexmapletest19975@gmail.com", "Darrel", "Darrel Herzog", false, "Herzog", "589-293-9522", "StudentIMF1EEXL" },
                    { 77, "7979 Turcotte Vista, Beahanport, Finland", "Port Garnettburgh", new DateTime(2023, 8, 1, 17, 46, 31, 119, DateTimeKind.Local).AddTicks(292), "onhdexmapletest19977@gmail.com", "Carlos", "Carlos Schulist", false, "Schulist", "(453) 389-3380 x6389", "StudentC5N6D5AD" },
                    { 79, "75896 Christophe Rapids, Hyattside, South Georgia and the South Sandwich Islands", "Traceyburgh", new DateTime(2023, 6, 20, 20, 31, 3, 664, DateTimeKind.Local).AddTicks(3473), "onhdexmapletest19979@gmail.com", "Kristofer", "Kristofer Dickinson", false, "Dickinson", "685.867.6750", "StudentODSgpaO7" },
                    { 81, "6998 Jacobs Forges, North Ellie, Nepal", "Whiteland", new DateTime(2023, 9, 7, 14, 4, 3, 297, DateTimeKind.Local).AddTicks(3372), "onhdexmapletest19981@gmail.com", "Ahmad", "Ahmad Rogahn", true, "Rogahn", "(718) 717-1042", "StudentzfDAU0uQ" },
                    { 83, "4938 Lubowitz Road, North Rahul, Lesotho", "Port Ellisland", new DateTime(2022, 12, 29, 22, 23, 9, 369, DateTimeKind.Local).AddTicks(9190), "onhdexmapletest19983@gmail.com", "Syble", "Syble Johns", false, "Johns", "1-728-437-0131", "StudentBxbtmWIM" },
                    { 85, "38786 Schimmel Falls, O'Konfurt, Greece", "Isaacshire", new DateTime(2023, 7, 17, 21, 26, 55, 127, DateTimeKind.Local).AddTicks(7035), "onhdexmapletest19985@gmail.com", "Lilian", "Lilian Franecki", true, "Franecki", "289.641.9464 x389", "StudentdO9QcQ5D" },
                    { 87, "5169 Michel Avenue, New Lutherchester, Taiwan", "East Kelsi", new DateTime(2022, 11, 3, 0, 37, 37, 189, DateTimeKind.Local).AddTicks(4977), "onhdexmapletest19987@gmail.com", "Rubie", "Rubie McDermott", false, "McDermott", "1-353-506-7122 x5915", "Student5BZYyv0M" },
                    { 89, "8315 Domenick Throughway, New Devante, Malta", "Binsbury", new DateTime(2023, 7, 10, 8, 30, 58, 249, DateTimeKind.Local).AddTicks(7034), "onhdexmapletest19989@gmail.com", "Kayla", "Kayla Towne", false, "Towne", "960.382.0173 x8049", "StudentOIdbEYnr" },
                    { 91, "750 Funk Streets, Erichchester, Madagascar", "East Saul", new DateTime(2023, 2, 1, 22, 19, 51, 258, DateTimeKind.Local).AddTicks(3049), "onhdexmapletest19991@gmail.com", "Jena", "Jena Quigley", true, "Quigley", "557.796.6865", "StudenteF5eru2p" },
                    { 93, "967 Eldora Field, Lake Patsychester, Bolivia", "North Kevinton", new DateTime(2023, 6, 2, 8, 44, 17, 444, DateTimeKind.Local).AddTicks(2417), "onhdexmapletest19993@gmail.com", "Missouri", "Missouri Willms", false, "Willms", "378-947-5781", "StudentA8G4wBqb" },
                    { 95, "5883 Roberta Via, Theronport, Saint Helena", "South Alfonso", new DateTime(2022, 12, 21, 10, 35, 54, 576, DateTimeKind.Local).AddTicks(2907), "onhdexmapletest19995@gmail.com", "Marianna", "Marianna Cremin", true, "Cremin", "768-322-2932 x583", "StudentLa6mkBCF" },
                    { 97, "050 Altenwerth Stravenue, New Elijahtown, Solomon Islands", "East Oleta", new DateTime(2023, 8, 21, 1, 52, 21, 817, DateTimeKind.Local).AddTicks(3031), "onhdexmapletest19997@gmail.com", "Austen", "Austen Mueller", true, "Mueller", "(396) 642-5397 x163", "StudentesBxBDk6" },
                    { 99, "79219 Adams Trail, South Emilie, Somalia", "Medhursthaven", new DateTime(2023, 7, 11, 6, 56, 28, 186, DateTimeKind.Local).AddTicks(2703), "onhdexmapletest19999@gmail.com", "Alene", "Alene Rohan", true, "Rohan", "(337) 771-8938 x1687", "Studentw5FuDSwI" }
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
