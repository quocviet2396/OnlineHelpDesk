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
                columns: new[] { "Id", "Code", "Email", "EmailToConfirm", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "2hXDzNyV", "superadmin@gmail.com", null, "$2a$11$XwtbfDoe4tHGYgIs5FRHPOJ5lvVBuqczp.3JkBZKh0gMHyOf6TIPi", "Admin", true, "SuperAdmin" },
                    { 2, "BIQLjC7P", "supporter@gmail.com", null, "$2a$11$.IN5OEK2A0uj3xbjsMiQOuewMds0dOEeoAAKiQCPu8i69FYQ2EXay", "Supporter", true, "Supporter" },
                    { 3, "fAe05WiL", "user@gmail.com", null, "$2a$11$ubnNOLel94.39eNjI0ZvOe/8wN3ySKLVTpvd1TFrz8B.lLx3W/wqW", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "18211 Hilpert Meadows, Littleville, Japan", "West Aldentown", new DateTime(2023, 9, 17, 8, 45, 10, 46, DateTimeKind.Local).AddTicks(892), "onhdexmapletest1991@gmail.com", "Everett", "Everett Rempel", true, "Rempel", "1-386-320-5665 x9442", "StudentX2cE66ai" },
                    { 3, "339 Samanta Run, Koeppport, Spain", "Cristtown", new DateTime(2023, 5, 7, 9, 13, 58, 140, DateTimeKind.Local).AddTicks(5940), "onhdexmapletest1993@gmail.com", "Berry", "Berry Buckridge", false, "Buckridge", "(676) 328-6177", "Student0ATNCYzy" },
                    { 5, "1359 Russel Loop, Port Torrance, Belgium", "Spencerberg", new DateTime(2023, 8, 13, 15, 5, 27, 67, DateTimeKind.Local).AddTicks(4223), "onhdexmapletest1995@gmail.com", "Javier", "Javier Ratke", true, "Ratke", "435.945.0726", "StudentKbRF4jON" },
                    { 7, "3877 Baumbach Rue, Schmidtton, Antarctica (the territory South of 60 deg S)", "West Arnulfo", new DateTime(2023, 5, 9, 8, 10, 24, 458, DateTimeKind.Local).AddTicks(2919), "onhdexmapletest1997@gmail.com", "Lina", "Lina Rowe", false, "Rowe", "(857) 944-4107 x85922", "StudentwN9Vie9J" },
                    { 9, "23774 Eloise Brook, Mayertview, Argentina", "Loweshire", new DateTime(2022, 11, 17, 4, 59, 50, 787, DateTimeKind.Local).AddTicks(9505), "onhdexmapletest1999@gmail.com", "Austen", "Austen Feil", true, "Feil", "662.717.1844 x13493", "StudentHIZyiiBZ" },
                    { 11, "741 King Road, Bartolettiside, Norfolk Island", "Zulauftown", new DateTime(2023, 3, 1, 4, 3, 5, 292, DateTimeKind.Local).AddTicks(2220), "onhdexmapletest19911@gmail.com", "Theo", "Theo Rolfson", true, "Rolfson", "1-894-218-3880 x328", "Student4XQemNLa" },
                    { 13, "4483 Ford Extensions, West Carlifurt, Equatorial Guinea", "Veldaborough", new DateTime(2023, 4, 24, 7, 22, 0, 445, DateTimeKind.Local).AddTicks(5375), "onhdexmapletest19913@gmail.com", "Granville", "Granville Mraz", true, "Mraz", "871.970.4364 x8887", "StudentzLYLa4EC" },
                    { 15, "255 Tessie Mews, South Alverta, United Arab Emirates", "East Alphonso", new DateTime(2023, 2, 20, 18, 2, 35, 141, DateTimeKind.Local).AddTicks(8752), "onhdexmapletest19915@gmail.com", "Lavada", "Lavada Schiller", false, "Schiller", "998.374.6552", "StudentY9MGPW1F" },
                    { 17, "9303 Arden Heights, West Lola, Iceland", "New Michaelville", new DateTime(2023, 7, 20, 21, 53, 52, 858, DateTimeKind.Local).AddTicks(3851), "onhdexmapletest19917@gmail.com", "Jackeline", "Jackeline Haley", true, "Haley", "687-447-1417", "StudentCwSc7oug" },
                    { 19, "1160 Rau Walks, Archibaldland, Azerbaijan", "Sauerborough", new DateTime(2022, 12, 20, 9, 14, 38, 783, DateTimeKind.Local).AddTicks(9109), "onhdexmapletest19919@gmail.com", "Helmer", "Helmer Bogisich", true, "Bogisich", "1-779-785-0089", "StudentUNjMSb60" },
                    { 21, "5777 Legros Rapids, Jaydaside, Burundi", "Port Johnnieview", new DateTime(2023, 2, 12, 16, 40, 23, 978, DateTimeKind.Local).AddTicks(5071), "onhdexmapletest19921@gmail.com", "Jarod", "Jarod Bruen", false, "Bruen", "741.244.6988 x122", "Student87pVkQr9" },
                    { 23, "8666 Boyer Gardens, South Nelleview, Tanzania", "Kertzmannchester", new DateTime(2023, 7, 9, 15, 29, 14, 543, DateTimeKind.Local).AddTicks(1551), "onhdexmapletest19923@gmail.com", "Anahi", "Anahi Rohan", true, "Rohan", "272-863-8633 x4463", "StudentGb4kOgMb" },
                    { 25, "663 Addie Burg, Port Tyrastad, Cape Verde", "Lake Garfieldborough", new DateTime(2022, 10, 14, 0, 20, 59, 573, DateTimeKind.Local).AddTicks(3761), "onhdexmapletest19925@gmail.com", "Luna", "Luna Beatty", true, "Beatty", "1-352-249-1853", "Studentl9Nb7JoR" },
                    { 27, "59042 Walter Hollow, Carolineshire, Uganda", "East Keltonchester", new DateTime(2023, 5, 5, 4, 56, 29, 578, DateTimeKind.Local).AddTicks(2725), "onhdexmapletest19927@gmail.com", "Kiley", "Kiley Skiles", false, "Skiles", "1-927-456-6808", "StudentfIp3g07f" },
                    { 29, "55984 Jaylin Stream, Cameronland, Myanmar", "Bennytown", new DateTime(2023, 9, 9, 22, 47, 48, 583, DateTimeKind.Local).AddTicks(5699), "onhdexmapletest19929@gmail.com", "Ashley", "Ashley Stokes", false, "Stokes", "555-798-9526", "StudentW0PRQjez" },
                    { 31, "260 Mossie Views, Gonzaloborough, Tajikistan", "Zitaborough", new DateTime(2023, 4, 12, 4, 41, 15, 234, DateTimeKind.Local).AddTicks(8222), "onhdexmapletest19931@gmail.com", "Etha", "Etha Murray", false, "Murray", "1-288-752-5673", "StudentbZE26DFn" },
                    { 33, "2154 Rico Points, Donnellyberg, Ghana", "South Daron", new DateTime(2023, 3, 23, 10, 28, 55, 911, DateTimeKind.Local).AddTicks(8771), "onhdexmapletest19933@gmail.com", "Minerva", "Minerva Mitchell", true, "Mitchell", "(726) 973-1810", "StudentUqAEH0zs" },
                    { 35, "5389 Schiller Orchard, Spinkamouth, Guinea-Bissau", "Cicerohaven", new DateTime(2023, 10, 1, 16, 33, 39, 778, DateTimeKind.Local).AddTicks(3465), "onhdexmapletest19935@gmail.com", "Corrine", "Corrine Streich", true, "Streich", "977-404-5506 x6292", "StudentQsYb525V" },
                    { 37, "6271 Stoltenberg Walks, South Antone, Bouvet Island (Bouvetoya)", "New Bria", new DateTime(2023, 6, 17, 21, 59, 7, 754, DateTimeKind.Local).AddTicks(6791), "onhdexmapletest19937@gmail.com", "Jaime", "Jaime Fisher", false, "Fisher", "(878) 207-2641", "StudentTSta8h4H" },
                    { 39, "489 Jerry Track, West Eldon, Kuwait", "West Kennedi", new DateTime(2022, 10, 27, 7, 25, 16, 477, DateTimeKind.Local).AddTicks(4490), "onhdexmapletest19939@gmail.com", "Domenick", "Domenick Green", true, "Green", "(830) 821-8504", "StudentIkMJfQMG" },
                    { 41, "042 Lorna Alley, South Kamryntown, Zimbabwe", "North Michel", new DateTime(2023, 7, 14, 15, 41, 16, 474, DateTimeKind.Local).AddTicks(2480), "onhdexmapletest19941@gmail.com", "Hilton", "Hilton Little", true, "Little", "925-224-1286", "StudentCtrlny8B" },
                    { 43, "136 Cedrick Hill, Pricebury, Gabon", "Lake Hannah", new DateTime(2022, 11, 8, 9, 38, 29, 718, DateTimeKind.Local).AddTicks(8999), "onhdexmapletest19943@gmail.com", "Rusty", "Rusty Feeney", true, "Feeney", "(502) 237-2503 x6055", "StudentMwJKFSBT" },
                    { 45, "74714 Titus Trafficway, Lisetteville, Estonia", "Volkmanshire", new DateTime(2023, 6, 14, 14, 50, 24, 104, DateTimeKind.Local).AddTicks(7284), "onhdexmapletest19945@gmail.com", "Zander", "Zander Stokes", true, "Stokes", "997-317-2881 x5879", "StudentSjIUGrWY" },
                    { 47, "854 Delpha Canyon, Lake Lottie, Reunion", "Elissaland", new DateTime(2023, 3, 3, 9, 16, 23, 767, DateTimeKind.Local).AddTicks(7194), "onhdexmapletest19947@gmail.com", "Carson", "Carson Haag", true, "Haag", "1-399-310-9376 x613", "StudentKbvrPF8l" },
                    { 49, "9954 Rey Plaza, Tiabury, Bosnia and Herzegovina", "South Cameron", new DateTime(2023, 9, 11, 5, 15, 3, 394, DateTimeKind.Local).AddTicks(6279), "onhdexmapletest19949@gmail.com", "Rhiannon", "Rhiannon Runolfsson", true, "Runolfsson", "927-808-5903 x14452", "StudentHbDdbmPR" },
                    { 51, "05520 Ova Port, Braunmouth, Poland", "Guidoburgh", new DateTime(2023, 7, 13, 22, 54, 3, 872, DateTimeKind.Local).AddTicks(4477), "onhdexmapletest19951@gmail.com", "Tanya", "Tanya Larson", true, "Larson", "(978) 292-4939 x5127", "StudentxCweH6ss" },
                    { 53, "067 Ezequiel Pike, South Robertview, Colombia", "East Fanny", new DateTime(2023, 6, 28, 22, 35, 46, 218, DateTimeKind.Local).AddTicks(4427), "onhdexmapletest19953@gmail.com", "Wyman", "Wyman Torphy", true, "Torphy", "902-438-9295 x841", "Studentw4QoDw0c" },
                    { 55, "866 Edwin Court, West Luciousfort, Madagascar", "Armandport", new DateTime(2022, 11, 13, 11, 41, 55, 752, DateTimeKind.Local).AddTicks(7131), "onhdexmapletest19955@gmail.com", "Katlyn", "Katlyn Haag", false, "Haag", "(543) 446-0884 x490", "StudentZ6EKNNSp" },
                    { 57, "0874 Armstrong Points, Port Alessandrastad, Ghana", "Collinsland", new DateTime(2023, 6, 8, 20, 47, 33, 505, DateTimeKind.Local).AddTicks(3684), "onhdexmapletest19957@gmail.com", "Denis", "Denis Gottlieb", false, "Gottlieb", "560-556-2365", "StudentC1Yi10jK" },
                    { 59, "7026 Nicolas Mountain, Port Meta, Sweden", "East Jerod", new DateTime(2023, 3, 25, 19, 6, 10, 707, DateTimeKind.Local).AddTicks(5528), "onhdexmapletest19959@gmail.com", "Marjorie", "Marjorie Paucek", false, "Paucek", "(224) 699-1214 x48825", "Studenti6bF97u4" },
                    { 61, "7714 Hiram Ville, Missourishire, Namibia", "Weberburgh", new DateTime(2022, 11, 1, 1, 3, 58, 393, DateTimeKind.Local).AddTicks(1331), "onhdexmapletest19961@gmail.com", "Alicia", "Alicia Auer", false, "Auer", "802.204.3379", "StudentUJ5fvvDt" },
                    { 63, "59347 Greyson Plaza, Herthafurt, Tokelau", "North Karina", new DateTime(2022, 12, 8, 14, 5, 42, 315, DateTimeKind.Local).AddTicks(9447), "onhdexmapletest19963@gmail.com", "River", "River Labadie", true, "Labadie", "238-543-3134 x307", "Student8byvxPLU" },
                    { 65, "114 Morton Grove, Dooleyhaven, Senegal", "New Judy", new DateTime(2023, 1, 13, 6, 29, 34, 476, DateTimeKind.Local).AddTicks(8251), "onhdexmapletest19965@gmail.com", "Dorcas", "Dorcas Jerde", true, "Jerde", "(353) 472-4643", "Studentt4wAds8i" },
                    { 67, "3865 Cierra Harbors, Ivafurt, Uruguay", "Port Shania", new DateTime(2022, 10, 10, 22, 0, 38, 651, DateTimeKind.Local).AddTicks(2845), "onhdexmapletest19967@gmail.com", "Justyn", "Justyn Feest", true, "Feest", "(827) 911-3907", "StudentmPUzqqxj" },
                    { 69, "441 Greenholt Courts, Elsachester, Lithuania", "Port Erinbury", new DateTime(2022, 10, 27, 13, 53, 14, 839, DateTimeKind.Local).AddTicks(882), "onhdexmapletest19969@gmail.com", "Carroll", "Carroll Spinka", true, "Spinka", "1-468-867-9069", "StudentuvxeVnKK" },
                    { 71, "92273 Emmerich Oval, Johnstonberg, Grenada", "West Ricardo", new DateTime(2023, 2, 9, 18, 49, 51, 361, DateTimeKind.Local).AddTicks(4136), "onhdexmapletest19971@gmail.com", "Jacky", "Jacky Predovic", true, "Predovic", "(319) 227-8579 x70591", "StudentPlZNjRQc" },
                    { 73, "9131 Bruen Bridge, New Travon, Latvia", "East Ryanview", new DateTime(2022, 12, 24, 9, 43, 25, 92, DateTimeKind.Local).AddTicks(1907), "onhdexmapletest19973@gmail.com", "Gladys", "Gladys Jacobson", false, "Jacobson", "1-268-936-7807 x0431", "Studentbnpj1jfM" },
                    { 75, "73391 Abernathy Islands, Robertsside, Antarctica (the territory South of 60 deg S)", "Braunmouth", new DateTime(2023, 9, 3, 20, 44, 42, 77, DateTimeKind.Local).AddTicks(26), "onhdexmapletest19975@gmail.com", "Alice", "Alice Johnson", true, "Johnson", "(203) 895-0714 x2276", "StudentlQt22yOQ" },
                    { 77, "9062 Schimmel Neck, Heidenreichfurt, Lesotho", "East Dannyland", new DateTime(2023, 3, 20, 20, 14, 26, 622, DateTimeKind.Local).AddTicks(9496), "onhdexmapletest19977@gmail.com", "Clemens", "Clemens Welch", true, "Welch", "630-508-8511 x56248", "Studentk2mFHzrK" },
                    { 79, "98311 Lenore Divide, Mauriciostad, Slovenia", "Langtown", new DateTime(2023, 2, 4, 4, 8, 35, 222, DateTimeKind.Local).AddTicks(3489), "onhdexmapletest19979@gmail.com", "Timothy", "Timothy Armstrong", false, "Armstrong", "(716) 583-5297", "StudentuV6uNeaL" },
                    { 81, "3982 Aditya Drive, Lake Jeffrey, Afghanistan", "Port Ayla", new DateTime(2023, 7, 8, 5, 12, 52, 235, DateTimeKind.Local).AddTicks(8994), "onhdexmapletest19981@gmail.com", "Vernie", "Vernie Christiansen", false, "Christiansen", "(464) 563-4076", "Student38eYL3En" },
                    { 83, "7977 Reilly Burg, New Tomas, Slovenia", "New Jeffreyfurt", new DateTime(2023, 2, 2, 20, 14, 9, 231, DateTimeKind.Local).AddTicks(7964), "onhdexmapletest19983@gmail.com", "Caesar", "Caesar Sawayn", true, "Sawayn", "(885) 543-6971 x6618", "Studentd2X0Odwg" },
                    { 85, "03642 Johnson Roads, Friesenchester, Finland", "Stanleychester", new DateTime(2023, 4, 30, 3, 26, 4, 743, DateTimeKind.Local).AddTicks(6376), "onhdexmapletest19985@gmail.com", "Verner", "Verner Trantow", false, "Trantow", "(697) 322-8915 x3231", "Student0yNg4RRd" },
                    { 87, "206 Emard Ways, East Maribelberg, Burkina Faso", "Lake Karinastad", new DateTime(2023, 5, 23, 0, 39, 7, 358, DateTimeKind.Local).AddTicks(3102), "onhdexmapletest19987@gmail.com", "Carlo", "Carlo Marquardt", false, "Marquardt", "1-522-544-8287 x026", "Student7DZidKCh" },
                    { 89, "6662 Macey Street, Shirleyberg, Slovakia (Slovak Republic)", "Port Damianborough", new DateTime(2023, 5, 5, 12, 40, 49, 468, DateTimeKind.Local).AddTicks(576), "onhdexmapletest19989@gmail.com", "Reyna", "Reyna Waters", true, "Waters", "(333) 236-9946", "Studentfmp1O3hM" },
                    { 91, "09793 Jewel Avenue, Tianamouth, United Kingdom", "East Jordane", new DateTime(2023, 7, 12, 7, 50, 39, 270, DateTimeKind.Local).AddTicks(5699), "onhdexmapletest19991@gmail.com", "Theron", "Theron Zboncak", false, "Zboncak", "(960) 526-6163 x8197", "StudentfEyHubFO" },
                    { 93, "2997 Ila Haven, Lynchhaven, Solomon Islands", "Davefort", new DateTime(2022, 10, 17, 12, 32, 55, 937, DateTimeKind.Local).AddTicks(888), "onhdexmapletest19993@gmail.com", "Lue", "Lue Kovacek", true, "Kovacek", "(938) 380-5578 x48901", "Student1OpkCkgY" },
                    { 95, "6643 Arvid Avenue, South Christineshire, Mali", "New Ron", new DateTime(2022, 12, 17, 9, 5, 19, 544, DateTimeKind.Local).AddTicks(6614), "onhdexmapletest19995@gmail.com", "Eli", "Eli Hirthe", true, "Hirthe", "741-581-3891 x69047", "StudentNePrJrmY" },
                    { 97, "60702 Jeremie Lights, South Enamouth, Palau", "North Orvillefurt", new DateTime(2023, 4, 18, 16, 18, 16, 208, DateTimeKind.Local).AddTicks(8715), "onhdexmapletest19997@gmail.com", "Edward", "Edward Morar", false, "Morar", "(360) 498-1491", "StudentET2JzsFj" },
                    { 99, "96681 Solon Branch, North Everettmouth, Guadeloupe", "Lake Kennethfort", new DateTime(2022, 10, 7, 17, 21, 31, 821, DateTimeKind.Local).AddTicks(3530), "onhdexmapletest19999@gmail.com", "Rosetta", "Rosetta Rice", false, "Rice", "(515) 914-4007", "Student5DpQWBB6" }
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
