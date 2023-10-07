using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class fekjpp : Migration
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
                    NewId = table.Column<int>(type: "int", nullable: false),
                    NewsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbComments_tbNews_NewId",
                        column: x => x.NewId,
                        principalTable: "tbNews",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tbComments_tbNews_NewsID",
                        column: x => x.NewsID,
                        principalTable: "tbNews",
                        principalColumn: "ID");
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
                    { 1, "hqhYYkZK", "superadmin@gmail.com", "$2a$11$iSPo/sV6TuEBSC.VO8apBOYp.cxT7hIgHtXt4dYdSBYkHeN8IA5Pi", "Admin", true, "SuperAdmin" },
                    { 2, "zV3YEkRr", "supporter@gmail.com", "$2a$11$SV97t9cQaOme0sYoOGO15eP35TRWPAcK28pgzW0xVDhQ0QpxdXk9.", "Supporter", true, "Supporter" },
                    { 3, "peBz2vLf", "user@gmail.com", "$2a$11$YvbVMkiOyvJAb4YU/rvYeOAgyLngCeBBRKimj0y5P5cf0uGHvylg2", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "376 Solon Point, Hollyberg, Taiwan", "Legrosfurt", new DateTime(2023, 2, 7, 21, 9, 46, 224, DateTimeKind.Local).AddTicks(4598), "onhdexmapletest1991@gmail.com", "Modesta", "Modesta Frami", true, "Frami", "463-272-1101 x343", "Student8IIdwbhw" },
                    { 3, "9792 Mohr Common, Emardtown, Netherlands Antilles", "Mitchellport", new DateTime(2023, 5, 29, 16, 39, 51, 983, DateTimeKind.Local).AddTicks(2899), "onhdexmapletest1993@gmail.com", "Annette", "Annette Okuneva", true, "Okuneva", "815-809-5836 x184", "Student8PoEUj1j" },
                    { 5, "70210 Muller Stravenue, Aufderharburgh, Sweden", "New Carmelborough", new DateTime(2023, 3, 20, 12, 47, 15, 470, DateTimeKind.Local).AddTicks(2355), "onhdexmapletest1995@gmail.com", "Katharina", "Katharina Cummings", true, "Cummings", "1-439-680-6590 x2864", "Student9x3UpVxM" },
                    { 7, "009 Kub Villages, New Heidi, Mexico", "Port Margaret", new DateTime(2023, 1, 9, 7, 25, 7, 346, DateTimeKind.Local).AddTicks(3217), "onhdexmapletest1997@gmail.com", "Noe", "Noe Erdman", false, "Erdman", "514.561.0536 x488", "StudenttksP30fd" },
                    { 9, "3701 Greyson Motorway, Donnellyland, Sudan", "Lake Ofelia", new DateTime(2023, 4, 29, 15, 24, 53, 587, DateTimeKind.Local).AddTicks(8740), "onhdexmapletest1999@gmail.com", "Layla", "Layla Schmidt", false, "Schmidt", "426.517.6708", "StudentlT5Uavop" },
                    { 11, "2632 Bruen Curve, Lake Shaylee, Monaco", "South Einohaven", new DateTime(2023, 4, 30, 20, 0, 35, 718, DateTimeKind.Local).AddTicks(9564), "onhdexmapletest19911@gmail.com", "Jaiden", "Jaiden Waters", true, "Waters", "328.523.4153", "StudentVB3nuloY" },
                    { 13, "839 Kenyatta Cliff, North Shaneland, Israel", "Rexstad", new DateTime(2022, 11, 9, 13, 47, 25, 661, DateTimeKind.Local).AddTicks(5080), "onhdexmapletest19913@gmail.com", "Eulalia", "Eulalia Tremblay", false, "Tremblay", "1-496-602-8783 x1458", "StudentJkjSdPj6" },
                    { 15, "492 Vivianne Locks, Virgiemouth, Christmas Island", "New Vito", new DateTime(2023, 6, 17, 3, 12, 11, 708, DateTimeKind.Local).AddTicks(3584), "onhdexmapletest19915@gmail.com", "Johnpaul", "Johnpaul Mitchell", false, "Mitchell", "989.272.0920", "StudentaNw0DZCB" },
                    { 17, "13110 Mueller Valleys, Port Norwoodtown, Iceland", "Port Mauriceton", new DateTime(2023, 9, 12, 3, 33, 39, 231, DateTimeKind.Local).AddTicks(9789), "onhdexmapletest19917@gmail.com", "Mylene", "Mylene Jones", false, "Jones", "(715) 554-1201 x03524", "StudentSPDKQG1Q" },
                    { 19, "6099 Hyatt Loop, East Bridieville, Romania", "Aleenland", new DateTime(2022, 10, 24, 0, 49, 35, 958, DateTimeKind.Local).AddTicks(7140), "onhdexmapletest19919@gmail.com", "Oscar", "Oscar Hahn", false, "Hahn", "548.277.9358 x36819", "StudentaJqce3VK" },
                    { 21, "939 Torp Greens, East Ardellaside, United States of America", "Maramouth", new DateTime(2023, 9, 7, 17, 3, 14, 124, DateTimeKind.Local).AddTicks(8000), "onhdexmapletest19921@gmail.com", "Nyah", "Nyah Torphy", true, "Torphy", "(590) 592-4146 x2538", "StudentEXYPGkQu" },
                    { 23, "838 Bahringer Route, West Dallasview, Malta", "South Angela", new DateTime(2023, 1, 6, 7, 49, 55, 924, DateTimeKind.Local).AddTicks(8897), "onhdexmapletest19923@gmail.com", "Armand", "Armand Wunsch", false, "Wunsch", "461-689-7638 x179", "StudentYmxges6W" },
                    { 25, "3691 Nikolaus Fort, Hamillside, Isle of Man", "Violaton", new DateTime(2023, 7, 8, 17, 24, 58, 488, DateTimeKind.Local).AddTicks(2769), "onhdexmapletest19925@gmail.com", "Lois", "Lois Kassulke", true, "Kassulke", "586-709-7926 x752", "Student5QzbGgj5" },
                    { 27, "701 Gorczany Freeway, Dimitriview, Burkina Faso", "Aronfort", new DateTime(2023, 3, 27, 19, 46, 41, 751, DateTimeKind.Local).AddTicks(8223), "onhdexmapletest19927@gmail.com", "Adele", "Adele Emard", false, "Emard", "295.950.8314", "StudentTvOmgPFS" },
                    { 29, "07130 Jerde Motorway, East Lyda, Vanuatu", "Lake Marta", new DateTime(2023, 1, 17, 5, 34, 1, 87, DateTimeKind.Local).AddTicks(5841), "onhdexmapletest19929@gmail.com", "Margarette", "Margarette Padberg", true, "Padberg", "(537) 383-9892", "StudentfxKASh22" },
                    { 31, "7444 Madison Meadow, Ottiliemouth, Saint Vincent and the Grenadines", "Bergnaumburgh", new DateTime(2023, 7, 14, 17, 0, 6, 122, DateTimeKind.Local).AddTicks(5251), "onhdexmapletest19931@gmail.com", "Imogene", "Imogene Keeling", true, "Keeling", "398.437.8677 x10653", "StudentTewVmytb" },
                    { 33, "3682 Jennifer Key, North Arianeberg, Papua New Guinea", "Port Angelo", new DateTime(2023, 5, 20, 1, 9, 50, 39, DateTimeKind.Local).AddTicks(7886), "onhdexmapletest19933@gmail.com", "Kaylie", "Kaylie Parker", true, "Parker", "343.561.4655", "StudentvL43SDPM" },
                    { 35, "021 Osinski Inlet, Mosciskiborough, El Salvador", "Gislasonhaven", new DateTime(2022, 12, 5, 8, 11, 13, 600, DateTimeKind.Local).AddTicks(4568), "onhdexmapletest19935@gmail.com", "Eric", "Eric Kozey", false, "Kozey", "1-646-460-4724", "StudentV05xAqfh" },
                    { 37, "653 Stoltenberg Ridges, Karianemouth, Zambia", "South Hobartburgh", new DateTime(2022, 11, 15, 0, 14, 27, 557, DateTimeKind.Local).AddTicks(8365), "onhdexmapletest19937@gmail.com", "Aubrey", "Aubrey Quitzon", true, "Quitzon", "246-788-7221 x5337", "Student08tRAhEC" },
                    { 39, "499 Delpha Hollow, New Ophelia, American Samoa", "Generalton", new DateTime(2023, 4, 27, 22, 22, 53, 10, DateTimeKind.Local).AddTicks(5609), "onhdexmapletest19939@gmail.com", "Estella", "Estella Lehner", true, "Lehner", "271-439-2405", "StudentsqPOyGfh" },
                    { 41, "2628 Reymundo Extension, Beattyfurt, United States of America", "Tillmanchester", new DateTime(2023, 4, 27, 13, 4, 31, 451, DateTimeKind.Local).AddTicks(3260), "onhdexmapletest19941@gmail.com", "Tiara", "Tiara Dickens", true, "Dickens", "1-526-220-6786", "Studentsuluql1f" },
                    { 43, "876 Tyree Motorway, Klingland, Kazakhstan", "Joannyhaven", new DateTime(2023, 4, 5, 18, 8, 24, 966, DateTimeKind.Local).AddTicks(8814), "onhdexmapletest19943@gmail.com", "Baron", "Baron Bogisich", false, "Bogisich", "741-801-4745 x6860", "Student2pbnQ4gD" },
                    { 45, "9682 Hoyt Mount, East Glennieburgh, Mali", "South Ulices", new DateTime(2023, 3, 20, 17, 4, 4, 366, DateTimeKind.Local).AddTicks(2717), "onhdexmapletest19945@gmail.com", "Marianne", "Marianne Collins", false, "Collins", "211.923.4175", "StudentpARVIRtF" },
                    { 47, "2209 Arturo Creek, Cassinville, Liberia", "Tracebury", new DateTime(2023, 1, 9, 7, 49, 36, 751, DateTimeKind.Local).AddTicks(6893), "onhdexmapletest19947@gmail.com", "Kareem", "Kareem Collins", false, "Collins", "1-500-473-6430", "StudentEql0tnww" },
                    { 49, "6050 Will Streets, East Jaunitahaven, Heard Island and McDonald Islands", "Quintenville", new DateTime(2023, 6, 14, 7, 23, 39, 849, DateTimeKind.Local).AddTicks(5175), "onhdexmapletest19949@gmail.com", "Coy", "Coy Miller", true, "Miller", "253.609.9847", "StudentB6ihdq3v" },
                    { 51, "0616 Ebony Harbors, South Amelia, Ghana", "East Stefaniechester", new DateTime(2022, 10, 25, 16, 59, 4, 88, DateTimeKind.Local).AddTicks(2104), "onhdexmapletest19951@gmail.com", "Shanelle", "Shanelle Goldner", false, "Goldner", "453-902-2938", "StudenttrCxexwF" },
                    { 53, "6565 Rath Highway, North Eldred, Botswana", "Xanderbury", new DateTime(2023, 3, 16, 0, 24, 49, 443, DateTimeKind.Local).AddTicks(5380), "onhdexmapletest19953@gmail.com", "Savannah", "Savannah Hilpert", false, "Hilpert", "1-315-688-1924 x080", "Studentig0RuMV3" },
                    { 55, "4869 Ziemann Gateway, North Emory, Guinea-Bissau", "Moenstad", new DateTime(2022, 10, 25, 23, 40, 1, 619, DateTimeKind.Local).AddTicks(8284), "onhdexmapletest19955@gmail.com", "Llewellyn", "Llewellyn Schinner", false, "Schinner", "413-491-0738 x868", "StudentV5MikbNw" },
                    { 57, "596 Rosendo Forge, Cummerataland, Niue", "Vitoview", new DateTime(2023, 4, 4, 7, 24, 23, 34, DateTimeKind.Local).AddTicks(6285), "onhdexmapletest19957@gmail.com", "Kadin", "Kadin Lemke", false, "Lemke", "1-628-763-2670 x333", "StudentqkBHQISt" },
                    { 59, "322 Johns Mews, Port Dejaburgh, Singapore", "Donatoland", new DateTime(2023, 4, 5, 9, 39, 55, 425, DateTimeKind.Local).AddTicks(4633), "onhdexmapletest19959@gmail.com", "Sonia", "Sonia Dooley", false, "Dooley", "1-252-687-1162", "Student4Wp2LbXw" },
                    { 61, "609 Kuvalis Extension, West Mervin, Russian Federation", "Leeport", new DateTime(2023, 9, 4, 23, 9, 23, 688, DateTimeKind.Local).AddTicks(5576), "onhdexmapletest19961@gmail.com", "Elyse", "Elyse Cassin", true, "Cassin", "997-480-1477 x49020", "StudentAElUqmoA" },
                    { 63, "792 Abshire Hills, New Prudenceberg, Cocos (Keeling) Islands", "Katelynnhaven", new DateTime(2023, 2, 26, 2, 1, 26, 256, DateTimeKind.Local).AddTicks(5860), "onhdexmapletest19963@gmail.com", "Leola", "Leola Swift", false, "Swift", "1-945-776-1468 x752", "StudentZi3XivVN" },
                    { 65, "810 McClure Street, Ibrahimhaven, Lao People's Democratic Republic", "Dickensstad", new DateTime(2023, 2, 10, 13, 57, 28, 291, DateTimeKind.Local).AddTicks(502), "onhdexmapletest19965@gmail.com", "Bryana", "Bryana Gutmann", false, "Gutmann", "(427) 582-4478 x927", "StudentNSwxNAHY" },
                    { 67, "6423 Reynolds Stream, MacGyverview, Vanuatu", "Port Macyfurt", new DateTime(2023, 5, 21, 19, 19, 58, 302, DateTimeKind.Local).AddTicks(752), "onhdexmapletest19967@gmail.com", "Grady", "Grady Gleason", true, "Gleason", "760-643-8578", "Studentg0ZTHVrp" },
                    { 69, "0108 Rick Freeway, East Thurman, Tokelau", "New Rowena", new DateTime(2022, 10, 21, 1, 41, 30, 254, DateTimeKind.Local).AddTicks(8974), "onhdexmapletest19969@gmail.com", "Stanton", "Stanton Renner", false, "Renner", "283.283.9832 x41384", "Student7FkYj6S9" },
                    { 71, "22393 Jenkins Shore, North Jaden, Gambia", "North Scarlettton", new DateTime(2023, 7, 21, 19, 14, 33, 762, DateTimeKind.Local).AddTicks(5593), "onhdexmapletest19971@gmail.com", "Buck", "Buck Jacobs", true, "Jacobs", "(676) 861-9047 x66572", "StudentJmXpDO1f" },
                    { 73, "238 Luettgen Gateway, West Gabrielville, Thailand", "Port Luis", new DateTime(2022, 10, 14, 5, 56, 16, 943, DateTimeKind.Local).AddTicks(2601), "onhdexmapletest19973@gmail.com", "Mireille", "Mireille Durgan", true, "Durgan", "(464) 206-7695 x302", "StudentxFi31aDU" },
                    { 75, "723 Aryanna Expressway, Hermannport, Antigua and Barbuda", "Johnsonland", new DateTime(2023, 2, 22, 10, 38, 25, 137, DateTimeKind.Local).AddTicks(1412), "onhdexmapletest19975@gmail.com", "Elody", "Elody Kautzer", true, "Kautzer", "1-545-651-7717 x278", "StudentvJze4L3V" },
                    { 77, "890 Casper Estate, Salmatown, Tunisia", "Port Emmaleeside", new DateTime(2022, 12, 19, 22, 35, 45, 597, DateTimeKind.Local).AddTicks(5569), "onhdexmapletest19977@gmail.com", "Adonis", "Adonis DuBuque", false, "DuBuque", "383.700.8550 x27096", "Student86vAPC15" },
                    { 79, "64154 Ziemann Place, North Alexys, Libyan Arab Jamahiriya", "Gusikowskiberg", new DateTime(2023, 6, 2, 8, 50, 18, 138, DateTimeKind.Local).AddTicks(6794), "onhdexmapletest19979@gmail.com", "Marjorie", "Marjorie Skiles", true, "Skiles", "771.225.4020", "StudentgnDuF57u" },
                    { 81, "86929 Shayna Mall, Lake Alf, Macedonia", "Lake Boydtown", new DateTime(2022, 12, 27, 1, 32, 8, 171, DateTimeKind.Local).AddTicks(9854), "onhdexmapletest19981@gmail.com", "Mireya", "Mireya Thiel", false, "Thiel", "792.963.2899", "StudentyVJuIahd" },
                    { 83, "267 Tillman Keys, Port Fritzmouth, Georgia", "Port Cory", new DateTime(2023, 10, 4, 1, 48, 20, 371, DateTimeKind.Local).AddTicks(1746), "onhdexmapletest19983@gmail.com", "Gregorio", "Gregorio Terry", false, "Terry", "1-462-906-1315 x33616", "StudentY7njEQzO" },
                    { 85, "054 Lowe Shore, South Teresa, Thailand", "West Lora", new DateTime(2023, 2, 12, 10, 38, 48, 247, DateTimeKind.Local).AddTicks(745), "onhdexmapletest19985@gmail.com", "Kameron", "Kameron Moen", false, "Moen", "544-516-2602 x8292", "StudentbWsM4Au6" },
                    { 87, "4365 Leannon Springs, East Yvette, Guernsey", "East Macey", new DateTime(2023, 8, 17, 1, 24, 15, 242, DateTimeKind.Local).AddTicks(3722), "onhdexmapletest19987@gmail.com", "Hassan", "Hassan Stracke", false, "Stracke", "477.802.9142 x21743", "Student1EeveqoW" },
                    { 89, "139 Schamberger Turnpike, Lake Ansleyland, Tonga", "Haroldland", new DateTime(2022, 10, 30, 0, 43, 31, 17, DateTimeKind.Local).AddTicks(9863), "onhdexmapletest19989@gmail.com", "Everett", "Everett Dicki", false, "Dicki", "740.842.4217 x14212", "StudentLZ1N9mQc" },
                    { 91, "688 Freda Turnpike, Bruenstad, Cuba", "New Muriel", new DateTime(2023, 6, 22, 11, 42, 33, 445, DateTimeKind.Local).AddTicks(9724), "onhdexmapletest19991@gmail.com", "Jaylon", "Jaylon Borer", false, "Borer", "(603) 523-0236 x74946", "StudentBaz2lQna" },
                    { 93, "2900 Jones Street, Lake Dee, Uruguay", "Abdultown", new DateTime(2023, 3, 6, 6, 26, 47, 687, DateTimeKind.Local).AddTicks(1184), "onhdexmapletest19993@gmail.com", "Juvenal", "Juvenal Koss", true, "Koss", "1-750-787-7497 x3126", "StudentyatBQklu" },
                    { 95, "809 Marlene Street, South Skylarborough, Tokelau", "Lucieshire", new DateTime(2022, 10, 31, 0, 35, 15, 62, DateTimeKind.Local).AddTicks(4513), "onhdexmapletest19995@gmail.com", "Brook", "Brook Von", false, "Von", "(209) 528-5786 x22126", "StudentzODP1ses" },
                    { 97, "99944 Conn Island, Volkmanside, Holy See (Vatican City State)", "Roxaneton", new DateTime(2023, 4, 17, 15, 23, 0, 734, DateTimeKind.Local).AddTicks(494), "onhdexmapletest19997@gmail.com", "Jazmyn", "Jazmyn Hegmann", true, "Hegmann", "811-722-1399 x851", "StudentwrnQKe8c" },
                    { 99, "01354 Bogan Street, Ryanport, Zambia", "Port Carole", new DateTime(2023, 9, 12, 4, 37, 5, 325, DateTimeKind.Local).AddTicks(5345), "onhdexmapletest19999@gmail.com", "Isaiah", "Isaiah Cassin", false, "Cassin", "(717) 770-9399", "StudentrTQ6wMXx" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbComments_NewId",
                table: "tbComments",
                column: "NewId");

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
