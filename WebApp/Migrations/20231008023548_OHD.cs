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
                    Areaded = table.Column<bool>(type: "bit", nullable: true),
                    Ureaded = table.Column<bool>(type: "bit", nullable: true),
                    Sreaded = table.Column<bool>(type: "bit", nullable: true)
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
                    { 1, "3rVcn6bc", "superadmin@gmail.com", null, "$2a$11$iRQgzVKbjGgKOPhMNAwipONho3l8sWFQqwDnUici99rLs0wUjZdKa", "Admin", true, "SuperAdmin" },
                    { 2, "YdVR8mSU", "supporter@gmail.com", null, "$2a$11$Svt5s3hKjzhAITPv2z613elEKMO/Qk0ckvouUxkyDIijW7rAO0BJO", "Supporter", true, "Supporter" },
                    { 3, "T4abMLDm", "user@gmail.com", null, "$2a$11$bidgmKV7S9adtUUdwzTxce5OArR1mURaGqomiNf7gaq9Scx224NnS", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "115 Durgan Rue, Stiedemannshire, Burundi", "South Mia", new DateTime(2023, 6, 16, 19, 28, 20, 815, DateTimeKind.Local).AddTicks(4436), "onhdexmapletest1991@gmail.com", "Demond", "Demond Hessel", true, "Hessel", "741-995-2036 x669", "Student8yHpLPZj" },
                    { 3, "988 Nolan Passage, Bodetown, Israel", "Brendonland", new DateTime(2023, 6, 4, 6, 22, 2, 545, DateTimeKind.Local).AddTicks(217), "onhdexmapletest1993@gmail.com", "Reagan", "Reagan Schamberger", true, "Schamberger", "923.976.8790 x44498", "Student6dLMXycu" },
                    { 5, "647 Deon Extension, South Abelardo, Venezuela", "West Elmiratown", new DateTime(2023, 9, 19, 15, 32, 35, 883, DateTimeKind.Local).AddTicks(4884), "onhdexmapletest1995@gmail.com", "Brenda", "Brenda Torphy", false, "Torphy", "1-384-755-1913", "StudentjpGaAt7z" },
                    { 7, "479 Vivian Dale, West Darwin, Slovakia (Slovak Republic)", "East Cordelia", new DateTime(2023, 1, 7, 13, 52, 21, 974, DateTimeKind.Local).AddTicks(2040), "onhdexmapletest1997@gmail.com", "Gerardo", "Gerardo Weimann", true, "Weimann", "272-453-8057 x31469", "StudentylikfVz6" },
                    { 9, "379 Walker Mission, South Sarai, Angola", "Ursulastad", new DateTime(2023, 4, 23, 5, 42, 39, 594, DateTimeKind.Local).AddTicks(2444), "onhdexmapletest1999@gmail.com", "Reinhold", "Reinhold Tremblay", true, "Tremblay", "593-380-7919 x5180", "StudentSNoW7d1m" },
                    { 11, "34710 Stamm Loaf, Port Antoniettaberg, Micronesia", "East Hallie", new DateTime(2022, 11, 25, 7, 55, 52, 55, DateTimeKind.Local).AddTicks(6847), "onhdexmapletest19911@gmail.com", "Dale", "Dale Von", true, "Von", "754-201-4476", "StudenttNf6U7e7" },
                    { 13, "397 Borer Extensions, Port Loraineview, Aruba", "West Sabina", new DateTime(2022, 10, 28, 8, 0, 45, 340, DateTimeKind.Local).AddTicks(3293), "onhdexmapletest19913@gmail.com", "Amie", "Amie Franecki", false, "Franecki", "685.481.0931 x162", "StudentQaCoBfg9" },
                    { 15, "372 Ismael Forges, Davionborough, Bolivia", "Mckenzieborough", new DateTime(2023, 6, 15, 21, 12, 53, 38, DateTimeKind.Local).AddTicks(5296), "onhdexmapletest19915@gmail.com", "Julio", "Julio Champlin", true, "Champlin", "774-503-0850 x06019", "Student32mAfI9z" },
                    { 17, "148 Bailey Lodge, Devantehaven, San Marino", "Darrenhaven", new DateTime(2023, 5, 11, 17, 39, 43, 877, DateTimeKind.Local).AddTicks(2931), "onhdexmapletest19917@gmail.com", "Evie", "Evie Bartell", false, "Bartell", "515.523.5913 x861", "StudentxqyfHgrb" },
                    { 19, "7177 Metz Meadow, New Lexifort, Saint Kitts and Nevis", "North Friedrichfort", new DateTime(2022, 12, 11, 15, 10, 33, 505, DateTimeKind.Local).AddTicks(7502), "onhdexmapletest19919@gmail.com", "Beth", "Beth Goodwin", true, "Goodwin", "717.949.8482 x1923", "StudentvJpmylVx" },
                    { 21, "7345 Rowan Island, New Derrick, Brazil", "East Porterfort", new DateTime(2023, 5, 17, 9, 8, 25, 79, DateTimeKind.Local).AddTicks(563), "onhdexmapletest19921@gmail.com", "Salma", "Salma Langosh", true, "Langosh", "628.926.8490", "StudentRmAgtnPr" },
                    { 23, "822 Kilback Pines, East Halliemouth, Kenya", "Feeneyton", new DateTime(2023, 1, 26, 13, 16, 57, 870, DateTimeKind.Local).AddTicks(3637), "onhdexmapletest19923@gmail.com", "Nelle", "Nelle Luettgen", false, "Luettgen", "821-744-7222 x8971", "StudentUDcRl60P" },
                    { 25, "0626 Blair Harbor, West Amelieborough, Antarctica (the territory South of 60 deg S)", "North Garlandburgh", new DateTime(2022, 10, 25, 23, 38, 43, 768, DateTimeKind.Local).AddTicks(4575), "onhdexmapletest19925@gmail.com", "Kaitlin", "Kaitlin Greenholt", false, "Greenholt", "1-791-990-1736", "Student0QdCudW1" },
                    { 27, "0256 Will Vista, North Patsy, Lebanon", "Lake Ashley", new DateTime(2023, 7, 10, 13, 18, 58, 21, DateTimeKind.Local).AddTicks(9210), "onhdexmapletest19927@gmail.com", "Harmon", "Harmon Cole", false, "Cole", "1-478-506-8607 x337", "Student6BjXfnYO" },
                    { 29, "63110 Nicolas Street, Strackemouth, Togo", "Langchester", new DateTime(2022, 12, 16, 16, 47, 2, 37, DateTimeKind.Local).AddTicks(9302), "onhdexmapletest19929@gmail.com", "Marjory", "Marjory Collins", false, "Collins", "440-231-9415 x88118", "StudentNvawYaXc" },
                    { 31, "374 Jaskolski Key, East Celine, Netherlands", "Kemmerfurt", new DateTime(2022, 10, 13, 22, 26, 11, 377, DateTimeKind.Local).AddTicks(3789), "onhdexmapletest19931@gmail.com", "Rosalee", "Rosalee Murray", false, "Murray", "(479) 932-6734", "Studentd7RzoJOS" },
                    { 33, "618 Hintz Isle, Pollichside, Jersey", "Bartonhaven", new DateTime(2023, 5, 1, 11, 16, 57, 913, DateTimeKind.Local).AddTicks(5728), "onhdexmapletest19933@gmail.com", "Ernestina", "Ernestina Larson", false, "Larson", "298-331-0119 x6691", "StudentvClZ1UH7" },
                    { 35, "7386 Watsica Lights, Merlinview, Thailand", "Koelpinchester", new DateTime(2022, 10, 9, 20, 25, 48, 689, DateTimeKind.Local).AddTicks(5946), "onhdexmapletest19935@gmail.com", "Alejandra", "Alejandra Haag", false, "Haag", "(969) 921-0544 x82800", "StudentQGNBUrji" },
                    { 37, "58385 Terrell Lodge, North Gilda, Albania", "Caesarbury", new DateTime(2022, 12, 9, 15, 26, 52, 419, DateTimeKind.Local).AddTicks(1698), "onhdexmapletest19937@gmail.com", "Curt", "Curt Koepp", false, "Koepp", "475.285.4521", "StudentovCZYoYH" },
                    { 39, "663 Era Overpass, Lake Wallaceview, Austria", "East Camylle", new DateTime(2023, 7, 16, 3, 40, 41, 300, DateTimeKind.Local).AddTicks(3829), "onhdexmapletest19939@gmail.com", "Kirsten", "Kirsten Corkery", false, "Corkery", "(672) 233-8939 x56160", "StudentGGUbWdV8" },
                    { 41, "108 Christopher Cliff, North Generalshire, United States Minor Outlying Islands", "East Faeshire", new DateTime(2022, 11, 20, 5, 48, 45, 821, DateTimeKind.Local).AddTicks(7271), "onhdexmapletest19941@gmail.com", "Sierra", "Sierra Cummings", true, "Cummings", "778-389-9108", "StudentwJ4LqJwj" },
                    { 43, "5444 Ephraim Ridge, North Angelitachester, Germany", "Hermistonfurt", new DateTime(2022, 12, 25, 9, 59, 11, 348, DateTimeKind.Local).AddTicks(1269), "onhdexmapletest19943@gmail.com", "Elwyn", "Elwyn Douglas", true, "Douglas", "(315) 410-0273", "StudentL39lPze0" },
                    { 45, "141 Littel Row, Vonburgh, Fiji", "West Esther", new DateTime(2023, 6, 22, 13, 10, 44, 945, DateTimeKind.Local).AddTicks(9941), "onhdexmapletest19945@gmail.com", "Shaina", "Shaina Bailey", false, "Bailey", "(489) 640-4989 x861", "Studentbz65TrZj" },
                    { 47, "159 Kohler Center, Bogisichmouth, Syrian Arab Republic", "Hilpertton", new DateTime(2023, 6, 29, 17, 53, 2, 257, DateTimeKind.Local).AddTicks(309), "onhdexmapletest19947@gmail.com", "Claire", "Claire Haag", true, "Haag", "(403) 438-8944 x712", "StudentgbaaMOdx" },
                    { 49, "954 Rossie Prairie, Lake Oranstad, Cote d'Ivoire", "Port Generalhaven", new DateTime(2023, 3, 30, 22, 36, 12, 79, DateTimeKind.Local).AddTicks(6988), "onhdexmapletest19949@gmail.com", "Caesar", "Caesar Schmitt", true, "Schmitt", "810-620-1093 x407", "StudentRL0lPiz7" },
                    { 51, "04324 Medhurst Run, West Jacyntheville, Reunion", "Margarettehaven", new DateTime(2023, 7, 20, 4, 40, 45, 451, DateTimeKind.Local).AddTicks(3342), "onhdexmapletest19951@gmail.com", "Cory", "Cory O'Kon", false, "O'Kon", "1-958-530-7466 x90273", "Student0ApjRdMZ" },
                    { 53, "097 Kautzer Shores, North Ressie, South Georgia and the South Sandwich Islands", "South Cullenberg", new DateTime(2023, 4, 4, 17, 47, 10, 432, DateTimeKind.Local).AddTicks(1401), "onhdexmapletest19953@gmail.com", "Victor", "Victor Wolff", true, "Wolff", "404-962-9972", "StudentYTlC3Acb" },
                    { 55, "514 Hahn Grove, Raheemville, Kiribati", "Port Kiraville", new DateTime(2023, 4, 11, 1, 37, 8, 251, DateTimeKind.Local).AddTicks(7034), "onhdexmapletest19955@gmail.com", "Jamel", "Jamel Effertz", false, "Effertz", "880.646.5309 x06785", "StudentRM4gFe1R" },
                    { 57, "3278 Fletcher Route, Cruickshankville, Finland", "Port Camren", new DateTime(2023, 5, 12, 19, 50, 25, 161, DateTimeKind.Local).AddTicks(8321), "onhdexmapletest19957@gmail.com", "Guy", "Guy Rempel", true, "Rempel", "858-453-1838", "Studentamh5dosd" },
                    { 59, "711 Reilly River, Sauermouth, Togo", "South Hilda", new DateTime(2022, 12, 4, 10, 35, 48, 760, DateTimeKind.Local).AddTicks(2770), "onhdexmapletest19959@gmail.com", "Gerard", "Gerard Jacobson", true, "Jacobson", "(903) 938-7069 x222", "StudenttQ0BwTZ1" },
                    { 61, "74148 Christelle Pine, Starkfurt, Yemen", "West Herbert", new DateTime(2022, 12, 14, 23, 31, 49, 121, DateTimeKind.Local).AddTicks(405), "onhdexmapletest19961@gmail.com", "Dion", "Dion Walker", false, "Walker", "(623) 575-4569", "StudentMAJrDZUa" },
                    { 63, "464 Wiza Run, West Llewellynshire, Guinea", "Friesenfort", new DateTime(2023, 7, 9, 17, 15, 27, 846, DateTimeKind.Local).AddTicks(8118), "onhdexmapletest19963@gmail.com", "Rico", "Rico Pouros", false, "Pouros", "(258) 514-5837 x19376", "StudentRdvSnCHO" },
                    { 65, "262 Grimes Hills, Gracielaport, Macedonia", "West Hayleeburgh", new DateTime(2023, 1, 7, 15, 35, 59, 594, DateTimeKind.Local).AddTicks(5504), "onhdexmapletest19965@gmail.com", "Iliana", "Iliana Reynolds", false, "Reynolds", "1-461-356-9232", "StudentyftsnAXG" },
                    { 67, "676 Emmett Greens, New Rashad, Finland", "Lehnerland", new DateTime(2023, 4, 7, 1, 40, 15, 354, DateTimeKind.Local).AddTicks(6125), "onhdexmapletest19967@gmail.com", "Isidro", "Isidro Zemlak", false, "Zemlak", "(728) 993-7101 x08421", "StudentNfecnvHI" },
                    { 69, "18168 Dustin Cliff, Charleston, Mauritius", "New Cristalmouth", new DateTime(2023, 1, 30, 20, 54, 1, 756, DateTimeKind.Local).AddTicks(8623), "onhdexmapletest19969@gmail.com", "Issac", "Issac Bruen", false, "Bruen", "676.993.1594 x65092", "Student98pfjpMY" },
                    { 71, "5934 Jannie Spur, North Anjali, Cocos (Keeling) Islands", "Rogahnview", new DateTime(2023, 9, 25, 17, 28, 5, 159, DateTimeKind.Local).AddTicks(8623), "onhdexmapletest19971@gmail.com", "Maureen", "Maureen Murphy", true, "Murphy", "817.296.8482", "StudentfLcqqCH9" },
                    { 73, "230 Runolfsdottir River, Runolfssonside, Sri Lanka", "West Amelia", new DateTime(2023, 8, 22, 16, 37, 57, 832, DateTimeKind.Local).AddTicks(6923), "onhdexmapletest19973@gmail.com", "Chris", "Chris Shields", false, "Shields", "686.809.2939 x3078", "Student9pJA7t7d" },
                    { 75, "07672 Orlo Cliff, South Lina, New Zealand", "Rowemouth", new DateTime(2022, 10, 22, 20, 55, 2, 769, DateTimeKind.Local).AddTicks(1280), "onhdexmapletest19975@gmail.com", "Rodrick", "Rodrick Rutherford", false, "Rutherford", "(296) 479-0315", "StudentMxR1mDHn" },
                    { 77, "071 Marjory Roads, Clementton, Malawi", "Lake Sydneyside", new DateTime(2022, 10, 11, 1, 30, 26, 742, DateTimeKind.Local).AddTicks(9106), "onhdexmapletest19977@gmail.com", "Judy", "Judy Donnelly", false, "Donnelly", "308.608.4613", "Student4CPz1Ktf" },
                    { 79, "030 Kenny Mills, Lake Karleyfurt, Yemen", "Port Garettmouth", new DateTime(2023, 4, 27, 3, 8, 3, 448, DateTimeKind.Local).AddTicks(3374), "onhdexmapletest19979@gmail.com", "Lukas", "Lukas Daugherty", true, "Daugherty", "1-426-247-5353", "StudentF04Q6y7U" },
                    { 81, "29906 Bailey Crescent, Thielville, Armenia", "Prestonfort", new DateTime(2023, 2, 28, 19, 30, 15, 70, DateTimeKind.Local).AddTicks(6721), "onhdexmapletest19981@gmail.com", "Milford", "Milford Goyette", true, "Goyette", "(277) 591-7120 x9303", "Studented0XPQUv" },
                    { 83, "57177 Kris Skyway, Jarenfurt, Tanzania", "Crooksville", new DateTime(2023, 5, 27, 20, 53, 0, 269, DateTimeKind.Local).AddTicks(8072), "onhdexmapletest19983@gmail.com", "Duane", "Duane Rowe", true, "Rowe", "610.944.7925 x146", "StudentCafdZaHj" },
                    { 85, "765 Carley Throughway, Baileyville, Kazakhstan", "Ulisesport", new DateTime(2023, 9, 9, 5, 36, 46, 264, DateTimeKind.Local).AddTicks(9794), "onhdexmapletest19985@gmail.com", "Kim", "Kim MacGyver", true, "MacGyver", "871-916-5373", "Studentu7a7gCWd" },
                    { 87, "03495 Irwin Radial, Tillmanshire, Turks and Caicos Islands", "South Aletha", new DateTime(2023, 7, 1, 21, 22, 4, 922, DateTimeKind.Local).AddTicks(9585), "onhdexmapletest19987@gmail.com", "Isabella", "Isabella Lebsack", false, "Lebsack", "333.855.5101 x4164", "StudentHhCwA63p" },
                    { 89, "1489 Howe Rest, Harleyberg, Uganda", "West Sethtown", new DateTime(2023, 3, 21, 5, 11, 52, 431, DateTimeKind.Local).AddTicks(6710), "onhdexmapletest19989@gmail.com", "Vada", "Vada Quitzon", true, "Quitzon", "293.390.4885 x789", "Student87ja5rYN" },
                    { 91, "918 Fay Radial, North Reggieborough, Thailand", "West Leoraberg", new DateTime(2022, 11, 18, 23, 6, 28, 129, DateTimeKind.Local).AddTicks(1469), "onhdexmapletest19991@gmail.com", "Zachariah", "Zachariah Nader", true, "Nader", "1-602-695-7478", "Studentw4KwMlaF" },
                    { 93, "15818 Lempi Coves, Elissaburgh, Kuwait", "Waylonmouth", new DateTime(2023, 7, 5, 3, 7, 13, 410, DateTimeKind.Local).AddTicks(7207), "onhdexmapletest19993@gmail.com", "Breana", "Breana Hauck", true, "Hauck", "(885) 721-1587 x054", "StudentXdw48sBd" },
                    { 95, "096 Madaline Park, Port Murphyport, Tokelau", "Funkburgh", new DateTime(2023, 4, 14, 5, 14, 4, 26, DateTimeKind.Local).AddTicks(8571), "onhdexmapletest19995@gmail.com", "Cleve", "Cleve Goodwin", true, "Goodwin", "735.271.6309 x95143", "Studentrcty7syp" },
                    { 97, "61917 Dahlia Bypass, Xavierside, Saint Pierre and Miquelon", "West Pietro", new DateTime(2023, 5, 4, 18, 10, 44, 427, DateTimeKind.Local).AddTicks(4839), "onhdexmapletest19997@gmail.com", "Helen", "Helen Hoeger", false, "Hoeger", "385-260-0180 x5266", "StudentoG8NxKOR" },
                    { 99, "96914 Kessler Key, Arneport, Saint Lucia", "Hellenview", new DateTime(2023, 8, 18, 17, 22, 16, 886, DateTimeKind.Local).AddTicks(784), "onhdexmapletest19999@gmail.com", "Imani", "Imani Wilkinson", false, "Wilkinson", "816.778.9375 x539", "Student8VMATlqv" }
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
