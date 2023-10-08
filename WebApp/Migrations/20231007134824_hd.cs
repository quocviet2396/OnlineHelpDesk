using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class hd : Migration
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
                    { 1, "d5ia4aqP", "superadmin@gmail.com", null, "$2a$11$SRDOfviKH4JxBVUD3I8xKO0VV8QLffun/txk2bC381UOiQ0FU928u", "Admin", true, "SuperAdmin" },
                    { 2, "7OsQSEec", "supporter@gmail.com", null, "$2a$11$KUrz0KsYyft0yZJ99ukSq.tHYDkZQEqyJe3PHx1GhxFYBtH3JVA0a", "Supporter", true, "Supporter" },
                    { 3, "HntL7Rcy", "user@gmail.com", null, "$2a$11$Ydgwcuwil.MEnnXKfCh40.FhgL5Fe54jlnd6p2qFiDpk/ej7nqSs.", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "9316 Christa Rue, Jaydonland, Cape Verde", "North Brycenton", new DateTime(2023, 7, 2, 16, 47, 30, 462, DateTimeKind.Local).AddTicks(2890), "onhdexmapletest1991@gmail.com", "Sidney", "Sidney Terry", true, "Terry", "317-621-0063 x5938", "StudentBeOFkvb5" },
                    { 3, "013 Luisa Highway, Ratkeville, Croatia", "South Soledadberg", new DateTime(2023, 8, 18, 14, 2, 31, 182, DateTimeKind.Local).AddTicks(7282), "onhdexmapletest1993@gmail.com", "Eloise", "Eloise Funk", true, "Funk", "387-944-0606 x694", "StudentQ1f0vO1h" },
                    { 5, "5274 Stark Wells, West Unaport, Philippines", "North Marlen", new DateTime(2023, 2, 3, 22, 40, 16, 489, DateTimeKind.Local).AddTicks(4798), "onhdexmapletest1995@gmail.com", "Joana", "Joana Kihn", true, "Kihn", "(873) 919-2757 x8552", "StudentREenIPGK" },
                    { 7, "436 Deckow Light, New Alliehaven, Albania", "Colleenside", new DateTime(2023, 2, 22, 2, 39, 40, 888, DateTimeKind.Local).AddTicks(5597), "onhdexmapletest1997@gmail.com", "Jaren", "Jaren Schumm", false, "Schumm", "803.560.8112", "Student7amqoIu3" },
                    { 9, "593 Khalil Locks, East Carterchester, Puerto Rico", "Claudinestad", new DateTime(2023, 4, 12, 8, 3, 15, 861, DateTimeKind.Local).AddTicks(6532), "onhdexmapletest1999@gmail.com", "Tierra", "Tierra Jacobi", true, "Jacobi", "736.694.7172", "StudentM1eIsbcL" },
                    { 11, "00466 Rosie Branch, Deeberg, Iraq", "North Barryfort", new DateTime(2022, 10, 28, 14, 22, 37, 25, DateTimeKind.Local).AddTicks(8312), "onhdexmapletest19911@gmail.com", "Lulu", "Lulu McCullough", false, "McCullough", "646.950.4378 x595", "StudenteDeRDchL" },
                    { 13, "346 Jessika Manor, Amandaton, Switzerland", "Marjoriefurt", new DateTime(2023, 2, 3, 17, 21, 1, 85, DateTimeKind.Local).AddTicks(3621), "onhdexmapletest19913@gmail.com", "Herminia", "Herminia Spinka", false, "Spinka", "894.391.9355", "Student1jTl3Zlw" },
                    { 15, "6959 Turner Flats, Wildermanburgh, Afghanistan", "New Astrid", new DateTime(2023, 8, 26, 13, 1, 19, 351, DateTimeKind.Local).AddTicks(2948), "onhdexmapletest19915@gmail.com", "Fermin", "Fermin Emmerich", false, "Emmerich", "(327) 627-7266 x179", "StudentXPTb1ebo" },
                    { 17, "12815 Zemlak Drive, Port Jarvis, Greece", "Fernton", new DateTime(2023, 3, 18, 5, 44, 33, 543, DateTimeKind.Local).AddTicks(7925), "onhdexmapletest19917@gmail.com", "Zetta", "Zetta Rempel", false, "Rempel", "(358) 528-8289", "Student8ZtdY6IL" },
                    { 19, "7421 Stokes Shore, West Daxbury, Mauritius", "Marquardtfurt", new DateTime(2022, 11, 25, 20, 41, 55, 821, DateTimeKind.Local).AddTicks(6155), "onhdexmapletest19919@gmail.com", "Josephine", "Josephine Smith", true, "Smith", "1-520-250-5156", "StudentQ6D5ddIa" },
                    { 21, "10559 Curt Hill, Rennermouth, Antarctica (the territory South of 60 deg S)", "New Rosiehaven", new DateTime(2023, 7, 17, 2, 17, 15, 97, DateTimeKind.Local).AddTicks(4732), "onhdexmapletest19921@gmail.com", "Kory", "Kory Pacocha", false, "Pacocha", "(280) 745-5403", "StudentiOwuNqGj" },
                    { 23, "24030 Denesik Expressway, South Elsa, Myanmar", "East Donnell", new DateTime(2023, 1, 6, 17, 52, 3, 617, DateTimeKind.Local).AddTicks(3599), "onhdexmapletest19923@gmail.com", "Asa", "Asa Swift", true, "Swift", "793-487-3333 x458", "Studentslc84u0A" },
                    { 25, "744 Beaulah Wall, Robertoshire, Pakistan", "New Greggfort", new DateTime(2023, 7, 19, 16, 48, 59, 278, DateTimeKind.Local).AddTicks(3259), "onhdexmapletest19925@gmail.com", "Jaren", "Jaren Conn", true, "Conn", "847-714-1769", "StudentS4UiS6GG" },
                    { 27, "046 Schumm Tunnel, South Tessie, Gibraltar", "East Rutheside", new DateTime(2023, 5, 25, 10, 7, 10, 259, DateTimeKind.Local).AddTicks(5774), "onhdexmapletest19927@gmail.com", "Xavier", "Xavier Fay", true, "Fay", "(919) 413-9082 x108", "StudentLwq1VuGM" },
                    { 29, "0668 Hyatt Light, East Garnet, Cook Islands", "Cristmouth", new DateTime(2023, 9, 6, 10, 14, 53, 185, DateTimeKind.Local).AddTicks(6340), "onhdexmapletest19929@gmail.com", "Hermann", "Hermann Adams", true, "Adams", "677.752.5106 x205", "StudentTV98TnuM" },
                    { 31, "550 Ophelia Cove, Elsemouth, Turkey", "Caspershire", new DateTime(2022, 12, 12, 3, 35, 4, 290, DateTimeKind.Local).AddTicks(5287), "onhdexmapletest19931@gmail.com", "Dawn", "Dawn Bayer", true, "Bayer", "815.895.2056 x5835", "Student1AH2NnON" },
                    { 33, "843 Gladyce Mountain, Francescoport, Comoros", "East Caitlyn", new DateTime(2023, 9, 26, 16, 37, 31, 296, DateTimeKind.Local).AddTicks(7914), "onhdexmapletest19933@gmail.com", "Johanna", "Johanna Sawayn", true, "Sawayn", "1-901-672-7733 x6703", "StudentHIoa85c5" },
                    { 35, "97486 Kuphal Roads, Vonmouth, Zimbabwe", "Trantowchester", new DateTime(2023, 8, 21, 8, 12, 29, 807, DateTimeKind.Local).AddTicks(5758), "onhdexmapletest19935@gmail.com", "Faustino", "Faustino Mayert", false, "Mayert", "219.438.2246", "StudentPrnWbzBm" },
                    { 37, "4252 Eugenia Trafficway, Pollichmouth, Malaysia", "Rickport", new DateTime(2022, 11, 11, 9, 33, 19, 297, DateTimeKind.Local).AddTicks(6657), "onhdexmapletest19937@gmail.com", "Bert", "Bert Johnson", true, "Johnson", "944.237.1343 x856", "Studente23zQmYA" },
                    { 39, "5778 Kacie Parkways, East Marleemouth, Qatar", "Gerholdbury", new DateTime(2023, 4, 26, 4, 2, 20, 366, DateTimeKind.Local).AddTicks(6115), "onhdexmapletest19939@gmail.com", "Rowland", "Rowland Turner", true, "Turner", "200-959-8683", "StudentYFby9wLs" },
                    { 41, "424 Reginald Circles, New Laney, Palestinian Territory", "North Fatima", new DateTime(2023, 7, 17, 10, 24, 16, 525, DateTimeKind.Local).AddTicks(4648), "onhdexmapletest19941@gmail.com", "Greyson", "Greyson Osinski", true, "Osinski", "1-554-350-5790 x004", "StudentTrI8x3I3" },
                    { 43, "8132 Merlin Pass, Gerhardtown, China", "Cordiechester", new DateTime(2022, 11, 25, 22, 5, 38, 133, DateTimeKind.Local).AddTicks(5510), "onhdexmapletest19943@gmail.com", "Alvena", "Alvena Boyer", false, "Boyer", "1-800-697-1951 x85406", "StudentmCr5GlP1" },
                    { 45, "68135 Lebsack Center, Hilllburgh, Malaysia", "Port Lyda", new DateTime(2023, 5, 13, 4, 40, 9, 148, DateTimeKind.Local).AddTicks(6453), "onhdexmapletest19945@gmail.com", "Melyna", "Melyna Hahn", false, "Hahn", "560-738-7849", "Studentrddmux5e" },
                    { 47, "61939 Meda Canyon, D'Amoreshire, Sierra Leone", "North Abdullahhaven", new DateTime(2023, 1, 4, 12, 48, 22, 611, DateTimeKind.Local).AddTicks(9450), "onhdexmapletest19947@gmail.com", "Flavie", "Flavie Goldner", false, "Goldner", "(505) 571-0276", "StudentpQnENKBD" },
                    { 49, "46820 Franz Drive, New Mikeside, Monaco", "South Marcosborough", new DateTime(2023, 7, 13, 4, 34, 14, 195, DateTimeKind.Local).AddTicks(6850), "onhdexmapletest19949@gmail.com", "Magnolia", "Magnolia Kuhic", false, "Kuhic", "694.274.6331 x58147", "Students6iz5Y74" },
                    { 51, "5060 Jordane Unions, Arnaldostad, Lebanon", "East Graceburgh", new DateTime(2022, 12, 30, 5, 43, 35, 389, DateTimeKind.Local).AddTicks(9175), "onhdexmapletest19951@gmail.com", "Gracie", "Gracie Brakus", false, "Brakus", "(980) 314-9674 x12368", "StudentcYTqr410" },
                    { 53, "57006 Loma Fort, Jennyferbury, Ireland", "West Esmeraldaborough", new DateTime(2022, 10, 24, 22, 42, 41, 839, DateTimeKind.Local).AddTicks(1299), "onhdexmapletest19953@gmail.com", "German", "German Labadie", true, "Labadie", "589-818-9022", "StudentHCOyTGsg" },
                    { 55, "1238 Schultz Ford, Okunevachester, Greece", "New Lomaborough", new DateTime(2023, 7, 6, 18, 20, 21, 489, DateTimeKind.Local).AddTicks(5437), "onhdexmapletest19955@gmail.com", "Josiane", "Josiane Wilderman", true, "Wilderman", "(284) 271-5274", "StudenttkppByNT" },
                    { 57, "397 Liliane Bridge, East Crawford, Saint Martin", "Yostmouth", new DateTime(2023, 1, 9, 2, 15, 8, 74, DateTimeKind.Local).AddTicks(6496), "onhdexmapletest19957@gmail.com", "Theresia", "Theresia Jacobi", false, "Jacobi", "1-660-526-6517 x979", "StudentbYgxl54O" },
                    { 59, "6875 Borer Canyon, Pagacborough, Isle of Man", "Port Tessie", new DateTime(2023, 2, 5, 9, 32, 17, 861, DateTimeKind.Local).AddTicks(7500), "onhdexmapletest19959@gmail.com", "Vesta", "Vesta Mayer", false, "Mayer", "1-460-863-6063 x01454", "StudentCTTdl2sB" },
                    { 61, "916 Jonathan Forge, Lake Koreybury, Rwanda", "O'Keefeside", new DateTime(2023, 7, 2, 12, 24, 45, 923, DateTimeKind.Local).AddTicks(8527), "onhdexmapletest19961@gmail.com", "Shakira", "Shakira Kihn", true, "Kihn", "419.663.7997", "StudentxDFiVQSq" },
                    { 63, "857 Judd Square, New Vergiemouth, El Salvador", "Pansybury", new DateTime(2022, 10, 24, 13, 7, 14, 882, DateTimeKind.Local).AddTicks(6340), "onhdexmapletest19963@gmail.com", "Cleveland", "Cleveland Hirthe", true, "Hirthe", "1-417-524-5854", "StudentieyNyvMp" },
                    { 65, "7415 Theodora Unions, Gislasonbury, New Caledonia", "Jovaniborough", new DateTime(2023, 3, 26, 1, 3, 43, 986, DateTimeKind.Local).AddTicks(8311), "onhdexmapletest19965@gmail.com", "Leopoldo", "Leopoldo Lakin", false, "Lakin", "1-253-962-8927 x805", "StudentPvrfv5Al" },
                    { 67, "557 Sawayn Forge, East Davontemouth, Lao People's Democratic Republic", "Lake Patriciaton", new DateTime(2023, 2, 21, 12, 50, 49, 870, DateTimeKind.Local).AddTicks(1115), "onhdexmapletest19967@gmail.com", "Sanford", "Sanford Aufderhar", false, "Aufderhar", "325-300-8910", "StudentFGXFO6mS" },
                    { 69, "449 Luettgen Burg, Sonyaborough, Barbados", "Katrinaside", new DateTime(2023, 6, 25, 4, 29, 46, 91, DateTimeKind.Local).AddTicks(9073), "onhdexmapletest19969@gmail.com", "Neil", "Neil Schaefer", false, "Schaefer", "1-357-255-9374 x53583", "StudentLmCOXSCJ" },
                    { 71, "5700 Beatty Junctions, Robertsshire, Virgin Islands, U.S.", "New Jaden", new DateTime(2023, 2, 10, 0, 27, 5, 606, DateTimeKind.Local).AddTicks(9043), "onhdexmapletest19971@gmail.com", "Asha", "Asha Schumm", false, "Schumm", "(406) 319-8315 x11202", "StudentYsaOVnvY" },
                    { 73, "50624 Raegan Plaza, New Sheridan, Antarctica (the territory South of 60 deg S)", "South Erin", new DateTime(2022, 10, 14, 13, 1, 1, 615, DateTimeKind.Local).AddTicks(8232), "onhdexmapletest19973@gmail.com", "Henri", "Henri Hansen", false, "Hansen", "478-280-8502", "StudentAbAPdY0M" },
                    { 75, "3480 Connelly Light, Chelsieland, Peru", "Port Alexaneberg", new DateTime(2023, 9, 27, 23, 37, 13, 528, DateTimeKind.Local).AddTicks(6053), "onhdexmapletest19975@gmail.com", "Jana", "Jana Kuvalis", true, "Kuvalis", "391-890-3129", "StudentffyfISKl" },
                    { 77, "62728 Shane Junction, New Margarettaburgh, Colombia", "Greenberg", new DateTime(2022, 10, 21, 17, 57, 27, 719, DateTimeKind.Local).AddTicks(5619), "onhdexmapletest19977@gmail.com", "Liza", "Liza Lynch", false, "Lynch", "1-910-447-6029", "StudentNIuPULYR" },
                    { 79, "880 Shakira Tunnel, Lake Paulside, Indonesia", "Mohamedland", new DateTime(2023, 4, 30, 2, 40, 22, 521, DateTimeKind.Local).AddTicks(2982), "onhdexmapletest19979@gmail.com", "Burnice", "Burnice Schultz", true, "Schultz", "(450) 786-8348", "StudentLSEAFWhV" },
                    { 81, "62974 Sim Wall, East Otha, Lebanon", "South Eliasport", new DateTime(2023, 6, 21, 4, 26, 2, 994, DateTimeKind.Local).AddTicks(644), "onhdexmapletest19981@gmail.com", "Rylan", "Rylan Orn", false, "Orn", "353.520.2360 x1727", "StudentGv3l3gqm" },
                    { 83, "91984 Kuphal Alley, Odessahaven, Iceland", "East Violettechester", new DateTime(2022, 11, 23, 11, 33, 11, 833, DateTimeKind.Local).AddTicks(7762), "onhdexmapletest19983@gmail.com", "Aubrey", "Aubrey Considine", true, "Considine", "970-625-1564", "Studentbn39CNaG" },
                    { 85, "14200 Goldner Island, West Johannfort, Saint Martin", "South Preston", new DateTime(2023, 9, 15, 18, 59, 29, 279, DateTimeKind.Local).AddTicks(4065), "onhdexmapletest19985@gmail.com", "Justine", "Justine Okuneva", false, "Okuneva", "1-466-732-1705 x1920", "StudentfkiuJYov" },
                    { 87, "56550 Lucie Ridges, Olinborough, Austria", "Mayeton", new DateTime(2023, 6, 8, 8, 46, 44, 82, DateTimeKind.Local).AddTicks(5475), "onhdexmapletest19987@gmail.com", "Drew", "Drew Frami", false, "Frami", "479.903.8363", "StudentPIhMaGfE" },
                    { 89, "0130 Michaela Mountain, Kihnside, Kazakhstan", "Nyaton", new DateTime(2022, 11, 20, 8, 52, 36, 503, DateTimeKind.Local).AddTicks(4), "onhdexmapletest19989@gmail.com", "Amanda", "Amanda Rice", false, "Rice", "348.724.4753 x90975", "StudentjyBD6RSZ" },
                    { 91, "47643 Alexander Estates, Yazminborough, Bulgaria", "West Vitaport", new DateTime(2023, 3, 9, 4, 39, 52, 857, DateTimeKind.Local).AddTicks(6071), "onhdexmapletest19991@gmail.com", "Jaylin", "Jaylin Cremin", false, "Cremin", "(236) 218-7653", "StudentdYm94Zbs" },
                    { 93, "35020 Caesar Way, New Hazelbury, Nepal", "North Kaylin", new DateTime(2022, 10, 24, 22, 21, 43, 200, DateTimeKind.Local).AddTicks(7630), "onhdexmapletest19993@gmail.com", "Makenna", "Makenna Mayer", true, "Mayer", "953-730-9616 x345", "Studentx2YxdI4x" },
                    { 95, "2488 Caitlyn Divide, West Brooks, Maldives", "West Darren", new DateTime(2023, 6, 28, 11, 45, 4, 452, DateTimeKind.Local).AddTicks(2883), "onhdexmapletest19995@gmail.com", "Maiya", "Maiya Metz", false, "Metz", "1-253-709-5423 x99332", "StudentkwJAHVvV" },
                    { 97, "552 Shanahan Island, West Tatyanaville, Bouvet Island (Bouvetoya)", "Padbergland", new DateTime(2023, 1, 29, 16, 43, 31, 351, DateTimeKind.Local).AddTicks(402), "onhdexmapletest19997@gmail.com", "Domenick", "Domenick Runte", false, "Runte", "1-700-664-3255", "Studentc6151fLc" },
                    { 99, "521 Eden Ridge, North Leone, Sweden", "Lake Adriel", new DateTime(2023, 7, 27, 14, 37, 13, 459, DateTimeKind.Local).AddTicks(2147), "onhdexmapletest19999@gmail.com", "Dandre", "Dandre Walsh", true, "Walsh", "542.778.8975 x3999", "Student0tHuIvou" }
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
