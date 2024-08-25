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
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { 10, "Other problems", "Other problems", null });

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
                    { 1, "1PwPNgXJ", "superadmin@gmail.com", null, "$2a$11$DPJEU57ng7sfBiBN/7/sGumA4Errp5wnXPxP0rBnIyUOSdMDL5DmW", "Admin", true, "SuperAdmin" },
                    { 2, "iemEFrsl", "classrooms_supporter@gmail.com", null, "$2a$11$71xIc4g9bgAbxzqG4T9PBOkUjoHr89U9yYHPdXRuzxWQN11ucsewe", "Supporter", true, "ClassRooms-Supporter" },
                    { 3, "t8BFL0jY", "labs_supporter@gmail.com", null, "$2a$11$ryPjBZ5vJ24g38T6uGvoq.dOYCn4YJuIBHQ/H6MfTifQVQ9x6oRI6", "Supporter", true, "Labs-Supporter" },
                    { 4, "TXUFdW2e", "hostels_supporter@gmail.com", null, "$2a$11$Mbp6gQaVODxhwSpY/02zneEZzWCQ0IjEI7.TC9TwPqb/8YDrm3iNW", "Supporter", true, "Hostels-Supporter" },
                    { 5, "SaAEytvL", "financial_supporter@gmail.com", null, "$2a$11$9CSSZPsMvKo456Ee/POFXuBNyYgcf2fmHKQFxFAhBLCng3PS2Io3K", "Supporter", true, "Financial-Supporter" },
                    { 6, "mHj2nje0", "canteen_supporter@gmail.com", null, "$2a$11$w3nt3eloQTDh7qnRf1HHA.RPzH6Xqv5V1YsBzS4bevdu.mbuvmaj2", "Supporter", true, "Canteen-Supporter" },
                    { 7, "Lntt1Q9H", "gymnasium_supporter@gmail.com", null, "$2a$11$kWrhF0a6XxopC.PfXgqSauZTYze8WklVPFOjBhAePS6eHN2WY3uVy", "Supporter", true, "Gymnasium-Supporter" },
                    { 8, "7AVTY4aq", "it_supporter@gmail.com", null, "$2a$11$iKt8CgmJcQzbm7yZT37dnuLrVr3CsiBCZRaaGGYnPiE4q8bZwOT02", "Supporter", true, "IT-Supporter" },
                    { 9, "L2k9W0o5", "library_supporter@gmail.com", null, "$2a$11$PlWjrYbCR5w0F7h/W86fxeSeR2Vkm2fPfnpmgX0HrzvxRUAU8pDHi", "Supporter", true, "Library-Supporter" },
                    { 10, "OqhARCoZ", "clubs_supporter@gmail.com", null, "$2a$11$4hii6VfxZLdI1DcS8ptxDOaZk0fKQr/Ao1TXUY8Q6gvE3fiYaa0Bq", "Supporter", true, "Clubs-Supporter" },
                    { 11, "j21Me5uS", "user@gmail.com", null, "$2a$11$QCpmpEefYOsC6ZFdQorxDeTL8WLAe.X5Wchys6frIM1Dbn8vuymYm", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "1795 Johns Lane, Port Elodyfort, Honduras", "Allanborough", new DateTime(2023, 9, 19, 12, 19, 17, 651, DateTimeKind.Local).AddTicks(6644), "onhdexmapletest1991@gmail.com", "Ashtyn", "Ashtyn Kub", true, "Kub", "403.982.0565 x6726", "StudentiR4JXgAR" },
                    { 3, "51082 Weimann Groves, Keatonburgh, Afghanistan", "Roobhaven", new DateTime(2023, 1, 30, 14, 5, 22, 347, DateTimeKind.Local).AddTicks(2923), "onhdexmapletest1993@gmail.com", "Christopher", "Christopher Oberbrunner", false, "Oberbrunner", "318.808.7112 x746", "Student2BV3YKpx" },
                    { 5, "25117 Erdman Pine, Ziemannfurt, Mexico", "Lake Hollishaven", new DateTime(2023, 3, 31, 12, 27, 1, 981, DateTimeKind.Local).AddTicks(7080), "onhdexmapletest1995@gmail.com", "Chet", "Chet Schiller", false, "Schiller", "723-764-9168", "Studenth9CF1MTV" },
                    { 7, "548 Haley Tunnel, Josephineport, Democratic People's Republic of Korea", "Anaismouth", new DateTime(2022, 11, 28, 11, 16, 43, 304, DateTimeKind.Local).AddTicks(6391), "onhdexmapletest1997@gmail.com", "Osvaldo", "Osvaldo Lockman", true, "Lockman", "801-927-7392 x29483", "Studentijm9AdMe" },
                    { 9, "1702 Walter Brooks, East Mohamed, Togo", "Konopelskihaven", new DateTime(2023, 8, 24, 10, 32, 38, 362, DateTimeKind.Local).AddTicks(4350), "onhdexmapletest1999@gmail.com", "Meghan", "Meghan Hamill", false, "Hamill", "483.474.1329", "StudentOIYdfAkC" },
                    { 11, "34934 Shaina Station, East Archibald, Antarctica (the territory South of 60 deg S)", "West Caroline", new DateTime(2023, 3, 7, 2, 31, 22, 792, DateTimeKind.Local).AddTicks(5585), "onhdexmapletest19911@gmail.com", "Muhammad", "Muhammad Mante", true, "Mante", "(868) 377-2637", "StudentfjGDNpzF" },
                    { 13, "1479 Ward Ways, Estherton, New Zealand", "Juanitastad", new DateTime(2023, 1, 17, 11, 54, 6, 776, DateTimeKind.Local).AddTicks(3704), "onhdexmapletest19913@gmail.com", "Ebba", "Ebba Hilpert", true, "Hilpert", "949-226-3947 x04536", "Student5ZP9RLHc" },
                    { 15, "81739 Tanner Light, East Linnea, Armenia", "Paulinestad", new DateTime(2023, 3, 2, 4, 8, 7, 344, DateTimeKind.Local).AddTicks(4537), "onhdexmapletest19915@gmail.com", "Alejandrin", "Alejandrin Schamberger", true, "Schamberger", "770-244-8102 x903", "StudentMghVemsT" },
                    { 17, "588 Preston Overpass, New Zoietown, Solomon Islands", "Auerside", new DateTime(2023, 1, 23, 6, 51, 24, 697, DateTimeKind.Local).AddTicks(6053), "onhdexmapletest19917@gmail.com", "Leo", "Leo Harvey", false, "Harvey", "(662) 302-1863 x8584", "StudentNuce3qCq" },
                    { 19, "668 Jocelyn Orchard, Port Cameron, Cameroon", "Susannaport", new DateTime(2023, 3, 20, 13, 24, 15, 248, DateTimeKind.Local).AddTicks(8046), "onhdexmapletest19919@gmail.com", "Gina", "Gina Rosenbaum", true, "Rosenbaum", "216-497-2347 x43540", "Student3zYwERKW" },
                    { 21, "7705 MacGyver Fort, Lake Mustafa, Nauru", "Carolyneville", new DateTime(2023, 7, 1, 14, 40, 45, 103, DateTimeKind.Local).AddTicks(2563), "onhdexmapletest19921@gmail.com", "Shyann", "Shyann Carter", false, "Carter", "686.719.5783 x05265", "Student4ZmBwlau" },
                    { 23, "844 Jettie Summit, Lake Jeffrey, Morocco", "North Cindyfort", new DateTime(2022, 11, 4, 3, 46, 52, 605, DateTimeKind.Local).AddTicks(4321), "onhdexmapletest19923@gmail.com", "Miracle", "Miracle Goldner", true, "Goldner", "400-384-6024 x9129", "StudentRewB0UMS" },
                    { 25, "544 Harris Ridges, Jaysontown, Heard Island and McDonald Islands", "South Eladioville", new DateTime(2023, 9, 1, 7, 21, 22, 971, DateTimeKind.Local).AddTicks(9624), "onhdexmapletest19925@gmail.com", "Violette", "Violette Towne", true, "Towne", "470.276.1372", "StudentX9Zju6Oq" },
                    { 27, "75419 Laury Spur, South Daletown, Guinea", "New Addiemouth", new DateTime(2023, 2, 14, 17, 45, 55, 377, DateTimeKind.Local).AddTicks(6689), "onhdexmapletest19927@gmail.com", "Keenan", "Keenan Hintz", false, "Hintz", "1-949-787-3637 x649", "StudentmZ3bcpdQ" },
                    { 29, "5750 Bret Square, Port Louvenia, Vietnam", "Krismouth", new DateTime(2023, 4, 21, 8, 39, 58, 209, DateTimeKind.Local).AddTicks(1102), "onhdexmapletest19929@gmail.com", "Francisca", "Francisca Stoltenberg", true, "Stoltenberg", "532.649.8900", "StudentiIROrtCn" },
                    { 31, "76705 Sporer Way, Hartmannshire, Bangladesh", "Rogelioside", new DateTime(2023, 10, 5, 19, 52, 37, 823, DateTimeKind.Local).AddTicks(5453), "onhdexmapletest19931@gmail.com", "Conner", "Conner O'Kon", true, "O'Kon", "1-814-496-3746 x806", "StudentP8oz5nlm" },
                    { 33, "17529 Heller Burgs, East Nasirfort, Saint Vincent and the Grenadines", "Stiedemannville", new DateTime(2023, 1, 7, 16, 55, 20, 410, DateTimeKind.Local).AddTicks(9985), "onhdexmapletest19933@gmail.com", "Dorian", "Dorian Koelpin", false, "Koelpin", "(346) 544-8584 x145", "StudentfukySe4D" },
                    { 35, "693 McCullough Stravenue, East Sydneyborough, Albania", "Leschville", new DateTime(2023, 8, 26, 10, 45, 37, 762, DateTimeKind.Local).AddTicks(357), "onhdexmapletest19935@gmail.com", "Marty", "Marty Zieme", true, "Zieme", "1-434-251-6656", "StudentcHX5cyab" },
                    { 37, "1130 Hammes Square, Gusikowskibury, Belize", "Port Addison", new DateTime(2023, 10, 4, 16, 53, 30, 363, DateTimeKind.Local).AddTicks(3560), "onhdexmapletest19937@gmail.com", "Katarina", "Katarina Carter", false, "Carter", "252-500-5925 x968", "StudentfKhmuXXo" },
                    { 39, "37974 Jaskolski Wells, South Feliciaside, Honduras", "Gorczanyland", new DateTime(2023, 6, 20, 1, 10, 57, 575, DateTimeKind.Local).AddTicks(1058), "onhdexmapletest19939@gmail.com", "Deron", "Deron Ward", false, "Ward", "835-622-5005", "StudentFG35TM9U" },
                    { 41, "708 Crist Stravenue, New Carliview, Palau", "Hackettmouth", new DateTime(2023, 6, 11, 7, 5, 50, 352, DateTimeKind.Local).AddTicks(6143), "onhdexmapletest19941@gmail.com", "Teresa", "Teresa Wyman", true, "Wyman", "1-733-776-6083", "Student2DQZVakJ" },
                    { 43, "292 Otho Burgs, North Brigitte, United Kingdom", "Port Agustinamouth", new DateTime(2022, 12, 2, 20, 3, 48, 64, DateTimeKind.Local).AddTicks(8136), "onhdexmapletest19943@gmail.com", "Geovanny", "Geovanny Barton", true, "Barton", "939-604-5527", "StudenttQ65rReU" },
                    { 45, "856 Botsford Glen, Zellashire, El Salvador", "New Miracletown", new DateTime(2023, 5, 25, 7, 14, 17, 533, DateTimeKind.Local).AddTicks(3604), "onhdexmapletest19945@gmail.com", "Cristobal", "Cristobal Kling", true, "Kling", "615-551-4395", "StudentBghMnZzS" },
                    { 47, "9788 Freda Skyway, South Lessiebury, Estonia", "North Rosellamouth", new DateTime(2023, 9, 30, 22, 34, 30, 952, DateTimeKind.Local).AddTicks(9522), "onhdexmapletest19947@gmail.com", "Carolyn", "Carolyn DuBuque", true, "DuBuque", "666-971-5393", "Student6pJoemva" },
                    { 49, "599 Hardy Parkway, West Jannie, Sao Tome and Principe", "West Mathias", new DateTime(2023, 6, 19, 7, 24, 56, 29, DateTimeKind.Local).AddTicks(337), "onhdexmapletest19949@gmail.com", "Bridie", "Bridie Koelpin", true, "Koelpin", "(202) 315-4112 x163", "StudentewwmO7Ir" },
                    { 51, "34132 Misty Walk, North Maximilianmouth, Mongolia", "West Toney", new DateTime(2022, 11, 14, 7, 43, 46, 592, DateTimeKind.Local).AddTicks(1210), "onhdexmapletest19951@gmail.com", "Pink", "Pink Boehm", false, "Boehm", "(708) 205-9149 x440", "StudentR56ZG8ag" },
                    { 53, "003 Solon Creek, South Lon, Wallis and Futuna", "Lake Jana", new DateTime(2023, 2, 16, 21, 55, 12, 999, DateTimeKind.Local).AddTicks(6094), "onhdexmapletest19953@gmail.com", "Lesly", "Lesly Kilback", true, "Kilback", "305.748.7693 x57640", "Student8DjoraO1" },
                    { 55, "3836 Hollis Stream, Brannonmouth, Cayman Islands", "North Haskellburgh", new DateTime(2023, 6, 30, 21, 13, 43, 370, DateTimeKind.Local).AddTicks(5074), "onhdexmapletest19955@gmail.com", "Zaria", "Zaria Zemlak", true, "Zemlak", "1-371-453-0300", "StudentAVa4tLTw" },
                    { 57, "7658 Stoltenberg Street, Keshaunfort, France", "South Filomena", new DateTime(2023, 1, 6, 16, 33, 9, 28, DateTimeKind.Local).AddTicks(8042), "onhdexmapletest19957@gmail.com", "Rosie", "Rosie Kunde", true, "Kunde", "(510) 342-5315 x985", "StudentCmevxP5L" },
                    { 59, "65054 Kiehn Ramp, Lake Ellis, Haiti", "Kuhnborough", new DateTime(2023, 8, 12, 15, 33, 25, 578, DateTimeKind.Local).AddTicks(2828), "onhdexmapletest19959@gmail.com", "Gerry", "Gerry Nikolaus", false, "Nikolaus", "453-451-6992 x62518", "StudentHDi6qgeA" },
                    { 61, "59706 Connelly River, Caleighmouth, Somalia", "New Vince", new DateTime(2022, 11, 5, 13, 5, 59, 231, DateTimeKind.Local).AddTicks(8708), "onhdexmapletest19961@gmail.com", "Austen", "Austen Reynolds", true, "Reynolds", "(265) 328-4723", "StudentpzNMWSZ8" },
                    { 63, "226 Raegan Knoll, West Jaron, Saudi Arabia", "Cruickshankberg", new DateTime(2023, 8, 26, 6, 59, 35, 711, DateTimeKind.Local).AddTicks(9204), "onhdexmapletest19963@gmail.com", "Nicholas", "Nicholas Steuber", true, "Steuber", "(968) 758-6869 x8015", "Studentad7XWhIT" },
                    { 65, "4908 Ritchie Forge, Keeblerport, Albania", "Liabury", new DateTime(2023, 5, 10, 15, 48, 49, 378, DateTimeKind.Local).AddTicks(1132), "onhdexmapletest19965@gmail.com", "Toni", "Toni O'Hara", true, "O'Hara", "256.635.0522", "StudentuWF1E7tg" },
                    { 67, "6948 McKenzie Land, Lillieborough, Reunion", "Sporerfort", new DateTime(2023, 2, 15, 8, 10, 39, 240, DateTimeKind.Local).AddTicks(4250), "onhdexmapletest19967@gmail.com", "Daisha", "Daisha Murray", true, "Murray", "266-275-8040 x397", "StudentLBG2dbxw" },
                    { 69, "73267 Arnold Shoals, Granthaven, Colombia", "Framitown", new DateTime(2023, 8, 6, 7, 36, 17, 163, DateTimeKind.Local).AddTicks(6517), "onhdexmapletest19969@gmail.com", "Dillan", "Dillan Cormier", true, "Cormier", "1-979-582-9772 x22732", "StudentVUFQ2ohu" },
                    { 71, "92000 Whitney Isle, North Rashadmouth, Honduras", "Judeshire", new DateTime(2023, 4, 4, 1, 45, 59, 53, DateTimeKind.Local).AddTicks(6137), "onhdexmapletest19971@gmail.com", "Deangelo", "Deangelo Swaniawski", true, "Swaniawski", "909.710.6724", "Student6rBaDgpn" },
                    { 73, "96639 Koepp Islands, Lindton, Suriname", "North Estella", new DateTime(2023, 8, 21, 3, 41, 39, 100, DateTimeKind.Local).AddTicks(2554), "onhdexmapletest19973@gmail.com", "Danielle", "Danielle Buckridge", false, "Buckridge", "403-925-3328 x932", "StudentnFQ5msak" },
                    { 75, "75333 Morton Estate, Greenholtbury, Jordan", "West Camronbury", new DateTime(2023, 7, 10, 8, 55, 55, 388, DateTimeKind.Local).AddTicks(1335), "onhdexmapletest19975@gmail.com", "Justine", "Justine Schaden", false, "Schaden", "(304) 582-6353 x42879", "StudentfXbSyafX" },
                    { 77, "036 Katheryn Pike, Laishaland, Liechtenstein", "Schusterhaven", new DateTime(2023, 7, 25, 9, 22, 12, 105, DateTimeKind.Local).AddTicks(5444), "onhdexmapletest19977@gmail.com", "Emma", "Emma Bergnaum", false, "Bergnaum", "(250) 669-0357 x383", "StudentiKV259Xf" },
                    { 79, "455 Nico Squares, New Ronny, Yemen", "East Diana", new DateTime(2022, 11, 7, 0, 8, 50, 930, DateTimeKind.Local).AddTicks(9978), "onhdexmapletest19979@gmail.com", "Estell", "Estell Upton", false, "Upton", "804.421.1610", "StudentZQu6EpDy" },
                    { 81, "0828 Farrell Knoll, East Watsonville, Cocos (Keeling) Islands", "West Andy", new DateTime(2023, 2, 16, 20, 42, 48, 570, DateTimeKind.Local).AddTicks(2217), "onhdexmapletest19981@gmail.com", "Lula", "Lula Sawayn", true, "Sawayn", "738-707-5200", "StudentnzhZUcXC" },
                    { 83, "330 Richie Coves, Lake Connerborough, Botswana", "Janessaview", new DateTime(2023, 7, 8, 12, 30, 53, 639, DateTimeKind.Local).AddTicks(6185), "onhdexmapletest19983@gmail.com", "Marco", "Marco Dietrich", true, "Dietrich", "755-804-7649", "StudenteO5B2hbm" },
                    { 85, "7489 Irwin Port, Lake Lawrence, Saint Kitts and Nevis", "North Salma", new DateTime(2022, 10, 16, 12, 29, 59, 794, DateTimeKind.Local).AddTicks(693), "onhdexmapletest19985@gmail.com", "Ozella", "Ozella Shields", true, "Shields", "1-286-696-9718 x0686", "StudentQRfW7jVt" },
                    { 87, "636 Keira Shores, Port Lethaville, Bolivia", "Milantown", new DateTime(2023, 2, 19, 5, 39, 15, 938, DateTimeKind.Local).AddTicks(3810), "onhdexmapletest19987@gmail.com", "Herman", "Herman Mayer", true, "Mayer", "(365) 525-3018", "StudentrCx57KQ1" },
                    { 89, "1215 Alessia Drive, East Mellie, Tokelau", "Rosettahaven", new DateTime(2023, 3, 27, 23, 8, 0, 432, DateTimeKind.Local).AddTicks(5120), "onhdexmapletest19989@gmail.com", "Neha", "Neha Prohaska", false, "Prohaska", "294.623.0352 x8923", "StudentqoYBET0R" },
                    { 91, "31533 Cleve Glens, East Garnett, Cambodia", "East Camrynmouth", new DateTime(2023, 9, 6, 3, 10, 18, 225, DateTimeKind.Local).AddTicks(1874), "onhdexmapletest19991@gmail.com", "Emilie", "Emilie Toy", false, "Toy", "750-621-6023 x452", "StudentyquITpnK" },
                    { 93, "807 Mose Run, Lake Brianafurt, Israel", "Edenhaven", new DateTime(2023, 3, 27, 10, 28, 40, 674, DateTimeKind.Local).AddTicks(5092), "onhdexmapletest19993@gmail.com", "Marielle", "Marielle Murazik", false, "Murazik", "(912) 219-4917", "StudentVf7CbbiD" },
                    { 95, "42196 Maci Keys, Schimmelview, Brazil", "Kaiamouth", new DateTime(2023, 2, 3, 8, 30, 49, 173, DateTimeKind.Local).AddTicks(2912), "onhdexmapletest19995@gmail.com", "Scotty", "Scotty Feeney", false, "Feeney", "(640) 841-4207 x50707", "StudentiS4N5QX2" },
                    { 97, "7315 Koss Green, Turnerton, Cuba", "North Jaiden", new DateTime(2022, 12, 1, 14, 37, 55, 511, DateTimeKind.Local).AddTicks(4116), "onhdexmapletest19997@gmail.com", "Jordi", "Jordi Okuneva", false, "Okuneva", "(832) 807-0023", "Studentcg1VPhwS" },
                    { 99, "4160 Beer Parks, Satterfieldville, Cayman Islands", "Lake Fidel", new DateTime(2022, 12, 29, 14, 42, 55, 744, DateTimeKind.Local).AddTicks(880), "onhdexmapletest19999@gmail.com", "Alfonso", "Alfonso Moen", true, "Moen", "(566) 481-4086 x6501", "StudentOusXASdj" }
                });

            migrationBuilder.InsertData(
                table: "tbFacilities",
                columns: new[] { "Id", "Description", "Name", "SupporterId" },
                values: new object[,]
                {
                    { 1, "All problems related to class-rooms", "Class-rooms", 2 },
                    { 2, "All problems related to labs", "Labs", 3 },
                    { 3, "All problems related to hostels", "Hostels", 4 },
                    { 4, "All problems related to financial assistance", "Financial Assistance", 5 },
                    { 5, "All problems related to canteen", "Canteen", 6 },
                    { 6, "All problems related to gymnasium", "Gymnasium", 7 },
                    { 7, "All problems related to Computer Centre", "Computer Centre", 8 },
                    { 8, "All problems related to library", "Library", 9 },
                    { 9, "All problems related to after-school clubs", "After-school clubs", 10 }
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
