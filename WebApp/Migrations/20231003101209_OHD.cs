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
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNameCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameSupporter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSupporter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "Id", "Code", "Email", "EmailToConfirm", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "1oGXfw1g", "superadmin@gmail.com", null, "$2a$11$NqtwQPA2e4SmFxyyYgqef.TRNrmhnO98QsDs1z/ZEF64gFg0kEtfW", "Admin", true, "SuperAdmin" },
                    { 2, "rS3TyrsS", "supporter@gmail.com", null, "$2a$11$i7wOz2jDqwWDlLf6H2JALeVX9IuOkJSzb4Xrl0moU8Gvu15CLkHKi", "Supporter", true, "Supporter" },
                    { 3, "psYDeVbO", "user@gmail.com", null, "$2a$11$LHpYHxMrmrJrihDJrm6kkO4tLudEQmtKXCV9o.nMNPj9x8YKfCeN2", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "7307 Hollis Lodge, Norbertbury, Armenia", "New Reannafurt", new DateTime(2023, 9, 25, 5, 7, 7, 378, DateTimeKind.Local).AddTicks(6895), "onhdexmapletest1991@gmail.com", "Andreane", "Andreane Kihn", true, "Kihn", "561.311.5210 x5091", "StudentzWY11aa8" },
                    { 3, "35768 Kunze Court, Port Royal, Sweden", "Loganburgh", new DateTime(2023, 7, 31, 22, 48, 56, 958, DateTimeKind.Local).AddTicks(7752), "onhdexmapletest1993@gmail.com", "Gordon", "Gordon McClure", true, "McClure", "526.411.3359 x34177", "StudentMzxfU00V" },
                    { 5, "9255 Roy Mission, Citlalliport, Turkey", "New Herthachester", new DateTime(2022, 10, 3, 23, 1, 25, 466, DateTimeKind.Local).AddTicks(679), "onhdexmapletest1995@gmail.com", "Ressie", "Ressie Auer", true, "Auer", "716-464-0723", "StudentzjMFRyT2" },
                    { 7, "06440 Herman Trafficway, East Carey, Mauritania", "Larsonborough", new DateTime(2022, 10, 14, 1, 7, 37, 831, DateTimeKind.Local).AddTicks(850), "onhdexmapletest1997@gmail.com", "Arvid", "Arvid Kassulke", false, "Kassulke", "768-948-9944 x9878", "StudentPYdHbZgW" },
                    { 9, "6492 Hills Crescent, Port Dwighttown, Burundi", "Gaylordmouth", new DateTime(2023, 9, 15, 3, 27, 25, 961, DateTimeKind.Local).AddTicks(3389), "onhdexmapletest1999@gmail.com", "Joana", "Joana Douglas", false, "Douglas", "274.556.9551 x850", "StudentVCHdjkuB" },
                    { 11, "96646 Strosin Circle, Angelotown, Djibouti", "Port Victor", new DateTime(2023, 5, 29, 13, 33, 54, 742, DateTimeKind.Local).AddTicks(850), "onhdexmapletest19911@gmail.com", "Magali", "Magali Romaguera", true, "Romaguera", "(952) 258-4915 x55200", "StudentqxYPFzYM" },
                    { 13, "370 Brendon Ranch, Purdymouth, Yemen", "Lake Daniella", new DateTime(2022, 11, 23, 0, 16, 32, 578, DateTimeKind.Local).AddTicks(4170), "onhdexmapletest19913@gmail.com", "Danielle", "Danielle Buckridge", true, "Buckridge", "816-264-6342 x627", "StudentOFZJWXWv" },
                    { 15, "5536 Moen Neck, North Colinberg, Democratic People's Republic of Korea", "New Nellieport", new DateTime(2022, 12, 17, 1, 54, 9, 562, DateTimeKind.Local).AddTicks(8123), "onhdexmapletest19915@gmail.com", "Rowland", "Rowland Glover", false, "Glover", "1-823-857-7162 x3342", "Student9DgEbT3A" },
                    { 17, "02891 Christiansen Land, Tristonburgh, Grenada", "Zemlakport", new DateTime(2023, 5, 23, 0, 0, 53, 543, DateTimeKind.Local).AddTicks(4235), "onhdexmapletest19917@gmail.com", "Ubaldo", "Ubaldo Watsica", true, "Watsica", "840.514.7732 x91568", "StudentSg89U4XA" },
                    { 19, "64237 Chet Spur, Armstrongbury, Finland", "Pollichburgh", new DateTime(2023, 1, 15, 0, 48, 36, 449, DateTimeKind.Local).AddTicks(2573), "onhdexmapletest19919@gmail.com", "Pearl", "Pearl Schneider", true, "Schneider", "(807) 865-6849 x715", "Student4ke1UzvG" },
                    { 21, "74847 Lemke Fords, New Isabellechester, Malawi", "Lake Karlitown", new DateTime(2023, 8, 31, 8, 18, 56, 841, DateTimeKind.Local).AddTicks(5386), "onhdexmapletest19921@gmail.com", "Gabrielle", "Gabrielle Glover", true, "Glover", "671.380.2823", "StudentYQc7XSmU" },
                    { 23, "681 Mills Ridge, Deronton, Bahamas", "Port Marisol", new DateTime(2023, 3, 21, 4, 5, 13, 95, DateTimeKind.Local).AddTicks(4367), "onhdexmapletest19923@gmail.com", "Marielle", "Marielle Goldner", false, "Goldner", "(856) 682-3421", "StudentvtwbwVNH" },
                    { 25, "1661 Jermey Dale, Daneshire, Malta", "Venaburgh", new DateTime(2023, 9, 7, 15, 25, 36, 828, DateTimeKind.Local).AddTicks(9531), "onhdexmapletest19925@gmail.com", "Chanel", "Chanel Mayer", true, "Mayer", "535-496-3491", "Student8WvF7cbI" },
                    { 27, "5447 Mann Falls, Dickensmouth, Turkey", "Pacochatown", new DateTime(2022, 10, 30, 22, 6, 42, 782, DateTimeKind.Local).AddTicks(5136), "onhdexmapletest19927@gmail.com", "Hettie", "Hettie Hermiston", true, "Hermiston", "827-425-5640", "StudentMI89PKv6" },
                    { 29, "537 Keebler Unions, Paolofort, Armenia", "Bartolettiland", new DateTime(2023, 7, 25, 23, 43, 34, 201, DateTimeKind.Local).AddTicks(2050), "onhdexmapletest19929@gmail.com", "Dennis", "Dennis Kihn", true, "Kihn", "(726) 302-5890", "Student6xrq6pOC" },
                    { 31, "98116 Lola Throughway, New Codyborough, Republic of Korea", "Zionhaven", new DateTime(2023, 2, 2, 20, 0, 20, 717, DateTimeKind.Local).AddTicks(349), "onhdexmapletest19931@gmail.com", "Naomie", "Naomie Crist", false, "Crist", "333-663-9783 x274", "StudentaL0KdlPy" },
                    { 33, "07382 Alejandrin Forge, Florenceborough, New Zealand", "East Janie", new DateTime(2023, 4, 28, 18, 19, 7, 152, DateTimeKind.Local).AddTicks(5258), "onhdexmapletest19933@gmail.com", "Burley", "Burley Bins", false, "Bins", "(912) 748-1404 x2410", "StudentVhn7fpR7" },
                    { 35, "246 Rosenbaum Forest, Calihaven, Moldova", "North Suzanne", new DateTime(2023, 8, 16, 11, 46, 9, 486, DateTimeKind.Local).AddTicks(1925), "onhdexmapletest19935@gmail.com", "Arjun", "Arjun Casper", false, "Casper", "(585) 594-0677 x59598", "StudentHpNBv08L" },
                    { 37, "838 Hilll Plaza, West Jessicaside, Peru", "Port Marian", new DateTime(2023, 6, 4, 9, 15, 36, 935, DateTimeKind.Local).AddTicks(9886), "onhdexmapletest19937@gmail.com", "Raphael", "Raphael West", false, "West", "614.481.0964", "StudentrwFzvBgO" },
                    { 39, "75005 Nader Bypass, Hammeschester, Cook Islands", "North Camryn", new DateTime(2023, 3, 26, 19, 23, 28, 76, DateTimeKind.Local).AddTicks(9701), "onhdexmapletest19939@gmail.com", "Eunice", "Eunice Upton", false, "Upton", "1-736-846-4237 x93061", "StudentuaXfVMQG" },
                    { 41, "49782 Brain Keys, Schulistport, Argentina", "West Jaylenport", new DateTime(2023, 6, 12, 13, 22, 54, 517, DateTimeKind.Local).AddTicks(7856), "onhdexmapletest19941@gmail.com", "Agnes", "Agnes Hegmann", false, "Hegmann", "(708) 826-1993", "Studentf68RKayB" },
                    { 43, "133 Billie Islands, Jeraldfort, Northern Mariana Islands", "West Ericachester", new DateTime(2023, 2, 2, 18, 50, 0, 469, DateTimeKind.Local).AddTicks(1315), "onhdexmapletest19943@gmail.com", "Domingo", "Domingo Haley", true, "Haley", "(546) 790-7873", "StudentY1Iqma3W" },
                    { 45, "0613 Chance Island, Elfriedachester, Bahrain", "Heathcotemouth", new DateTime(2023, 7, 28, 7, 2, 46, 863, DateTimeKind.Local).AddTicks(6267), "onhdexmapletest19945@gmail.com", "Myrtle", "Myrtle Tremblay", true, "Tremblay", "1-381-604-3022 x445", "StudentxTi2XaRm" },
                    { 47, "608 Reinger Glens, South Rashawnhaven, Bulgaria", "Stephenchester", new DateTime(2023, 4, 14, 8, 33, 31, 344, DateTimeKind.Local).AddTicks(7394), "onhdexmapletest19947@gmail.com", "Fannie", "Fannie Mante", true, "Mante", "(288) 406-1013 x1525", "StudentTKDZNhKI" },
                    { 49, "74141 Kulas Shore, Strosintown, Mauritius", "Roobstad", new DateTime(2023, 3, 16, 14, 14, 11, 664, DateTimeKind.Local).AddTicks(9346), "onhdexmapletest19949@gmail.com", "Russ", "Russ Erdman", false, "Erdman", "649-346-7951 x284", "StudentRtCh3L7Z" },
                    { 51, "1873 Howell Groves, Marquardtchester, Bouvet Island (Bouvetoya)", "Cormierberg", new DateTime(2023, 3, 26, 12, 47, 44, 527, DateTimeKind.Local).AddTicks(7545), "onhdexmapletest19951@gmail.com", "Providenci", "Providenci Rath", false, "Rath", "1-497-476-1794", "StudentIzuYk6Xj" },
                    { 53, "69824 Cecile Keys, South Anissa, Montserrat", "Fisherhaven", new DateTime(2023, 4, 29, 4, 32, 48, 641, DateTimeKind.Local).AddTicks(1538), "onhdexmapletest19953@gmail.com", "Bertrand", "Bertrand Shields", true, "Shields", "622-558-0897", "Student4B2eESfu" },
                    { 55, "3083 Langosh Prairie, Guymouth, Cameroon", "West Guyport", new DateTime(2023, 9, 29, 16, 42, 45, 135, DateTimeKind.Local).AddTicks(2621), "onhdexmapletest19955@gmail.com", "Dandre", "Dandre Howe", true, "Howe", "526.447.9578 x379", "StudentH06izTLU" },
                    { 57, "2729 Stamm Roads, Jeffreyside, Sri Lanka", "Port Berneicestad", new DateTime(2023, 6, 12, 5, 25, 22, 561, DateTimeKind.Local).AddTicks(4375), "onhdexmapletest19957@gmail.com", "Percival", "Percival Kutch", false, "Kutch", "(333) 791-7398", "StudentiiVyKbeq" },
                    { 59, "24038 Krajcik Vista, Uniqueshire, Micronesia", "East Jillianborough", new DateTime(2023, 6, 22, 10, 39, 0, 293, DateTimeKind.Local).AddTicks(7021), "onhdexmapletest19959@gmail.com", "Ernesto", "Ernesto Mante", true, "Mante", "994-791-4384 x37393", "StudentzORhoUUr" },
                    { 61, "8251 Stiedemann Views, Port Marcosville, Tanzania", "Matildebury", new DateTime(2023, 2, 21, 9, 51, 35, 730, DateTimeKind.Local).AddTicks(1033), "onhdexmapletest19961@gmail.com", "Emerson", "Emerson Koepp", false, "Koepp", "723.948.0217", "Student3ME5Ow1k" },
                    { 63, "387 Lukas Points, Port Lauryshire, Namibia", "East Lesley", new DateTime(2023, 8, 15, 6, 27, 57, 559, DateTimeKind.Local).AddTicks(375), "onhdexmapletest19963@gmail.com", "Janae", "Janae Homenick", true, "Homenick", "1-660-286-3148", "StudentseSqVZYz" },
                    { 65, "268 Christop Parkway, Walterstad, Malaysia", "North Eveline", new DateTime(2023, 5, 26, 19, 59, 20, 663, DateTimeKind.Local).AddTicks(9798), "onhdexmapletest19965@gmail.com", "Izabella", "Izabella MacGyver", true, "MacGyver", "1-531-229-1035 x51093", "StudentNuJIorcj" },
                    { 67, "6513 Shawn Viaduct, Brownview, Lesotho", "North Sandrine", new DateTime(2023, 7, 6, 0, 20, 34, 547, DateTimeKind.Local).AddTicks(6349), "onhdexmapletest19967@gmail.com", "Bettie", "Bettie Fahey", false, "Fahey", "(480) 267-4044", "StudentYgC7GDMR" },
                    { 69, "8998 Keeling Circle, Ludwigshire, Mongolia", "Sporerfurt", new DateTime(2023, 3, 15, 12, 9, 48, 487, DateTimeKind.Local).AddTicks(9828), "onhdexmapletest19969@gmail.com", "Mitchell", "Mitchell Gorczany", false, "Gorczany", "(668) 757-3470 x714", "StudentR6lDtw13" },
                    { 71, "952 Langosh Corner, Lake Joannieside, Bangladesh", "South Dangelo", new DateTime(2023, 8, 30, 17, 43, 45, 888, DateTimeKind.Local).AddTicks(7936), "onhdexmapletest19971@gmail.com", "Krystal", "Krystal Hermiston", true, "Hermiston", "838.978.7661 x10118", "StudentuLhqbJHz" },
                    { 73, "3587 Fausto Square, Sharonfort, Paraguay", "Camrenton", new DateTime(2023, 3, 26, 9, 58, 56, 641, DateTimeKind.Local).AddTicks(9492), "onhdexmapletest19973@gmail.com", "Carolanne", "Carolanne Douglas", false, "Douglas", "725-229-5463 x2594", "Student3AjKwqUZ" },
                    { 75, "61924 Conn Mill, Port Laury, Congo", "Camilleview", new DateTime(2023, 3, 29, 12, 46, 55, 576, DateTimeKind.Local).AddTicks(1696), "onhdexmapletest19975@gmail.com", "Cali", "Cali Cassin", true, "Cassin", "877-982-0928", "StudentFXqQNZ8o" },
                    { 77, "646 Reva Crescent, Corbinchester, Lesotho", "West Melisa", new DateTime(2022, 10, 13, 19, 58, 7, 166, DateTimeKind.Local).AddTicks(266), "onhdexmapletest19977@gmail.com", "Jeffrey", "Jeffrey Bruen", true, "Bruen", "640-406-8093", "StudentpTY8V4ij" },
                    { 79, "7148 Murphy Mountains, New Jace, Netherlands Antilles", "South Mckayla", new DateTime(2023, 4, 18, 0, 50, 27, 572, DateTimeKind.Local).AddTicks(4059), "onhdexmapletest19979@gmail.com", "Jillian", "Jillian Gulgowski", false, "Gulgowski", "(267) 615-0597", "Student0UKI8qRH" },
                    { 81, "9368 Tina Parks, North Antonietta, Thailand", "South Osbaldo", new DateTime(2023, 2, 1, 19, 48, 56, 729, DateTimeKind.Local).AddTicks(1271), "onhdexmapletest19981@gmail.com", "Rosalinda", "Rosalinda Cronin", false, "Cronin", "870-924-5574 x315", "StudentdK9g7Cr5" },
                    { 83, "43684 Ella Fords, Torpton, Faroe Islands", "New Annette", new DateTime(2023, 8, 30, 1, 13, 26, 876, DateTimeKind.Local).AddTicks(7952), "onhdexmapletest19983@gmail.com", "Santina", "Santina Greenfelder", false, "Greenfelder", "1-436-615-4300 x90543", "StudentM5krXl24" },
                    { 85, "52747 Mueller Mount, Mayershire, Taiwan", "Port Syble", new DateTime(2023, 4, 17, 2, 48, 45, 956, DateTimeKind.Local).AddTicks(5038), "onhdexmapletest19985@gmail.com", "Aniyah", "Aniyah Hilll", false, "Hilll", "1-445-542-7426 x4762", "StudentGCsPsF3r" },
                    { 87, "15974 Hillary Island, Bernierburgh, Indonesia", "Lake Beverly", new DateTime(2022, 11, 23, 10, 19, 32, 549, DateTimeKind.Local).AddTicks(1800), "onhdexmapletest19987@gmail.com", "Quinn", "Quinn Weissnat", true, "Weissnat", "1-319-683-9436", "Students9KEiK7R" },
                    { 89, "6634 Hintz Trace, West Lacy, Antigua and Barbuda", "Ernserville", new DateTime(2023, 1, 10, 21, 26, 17, 335, DateTimeKind.Local).AddTicks(9578), "onhdexmapletest19989@gmail.com", "Araceli", "Araceli Purdy", false, "Purdy", "536-633-2862 x39790", "StudentI2SpM05p" },
                    { 91, "28711 Shayne Place, East Heleneburgh, Guernsey", "South Jovanton", new DateTime(2023, 6, 10, 20, 47, 3, 680, DateTimeKind.Local).AddTicks(7295), "onhdexmapletest19991@gmail.com", "Peggie", "Peggie Bailey", false, "Bailey", "907.892.6766 x985", "StudentPJYHprBI" },
                    { 93, "933 Cedrick Greens, North Maxine, Ecuador", "Altenwerthburgh", new DateTime(2023, 1, 1, 23, 37, 36, 91, DateTimeKind.Local).AddTicks(6270), "onhdexmapletest19993@gmail.com", "Jimmy", "Jimmy Denesik", false, "Denesik", "861-361-4758 x563", "StudentEC17j28x" },
                    { 95, "01159 Jacey Heights, Lake Ryannside, Bosnia and Herzegovina", "South Oran", new DateTime(2023, 6, 2, 6, 7, 15, 908, DateTimeKind.Local).AddTicks(8779), "onhdexmapletest19995@gmail.com", "Hassan", "Hassan Lang", false, "Lang", "827.694.9328 x3453", "Studenth0BaSW4y" },
                    { 97, "92025 Daugherty Springs, West Lola, Malaysia", "North Nya", new DateTime(2023, 9, 27, 22, 39, 17, 808, DateTimeKind.Local).AddTicks(8730), "onhdexmapletest19997@gmail.com", "Marcelina", "Marcelina O'Conner", false, "O'Conner", "353.957.9886 x6168", "StudentY6G3DsHK" },
                    { 99, "90671 Casey Mountains, Maggiemouth, Netherlands Antilles", "North Arvel", new DateTime(2022, 12, 16, 11, 53, 23, 567, DateTimeKind.Local).AddTicks(4400), "onhdexmapletest19999@gmail.com", "Chloe", "Chloe Kautzer", true, "Kautzer", "1-588-434-8983 x448", "StudentbhnrYG3n" }
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
