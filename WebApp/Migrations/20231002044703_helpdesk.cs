using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class helpdesk : Migration
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
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "Id", "Code", "Email", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "TltlHjo9", "superadmin@gmail.com", "$2a$11$HK4W3uiVhlY0NBpN.OFI2esPu0HhyNZm9Uq0tm.5JgiYiUzbX/Ze2", "Admin", true, "SuperAdmin" },
                    { 2, "LG2wNfRq", "supporter@gmail.com", "$2a$11$JbXs7pQahF/l5Dc0n.H3NO79KgnrBhPR1ryOTJlA15TKDTiQxsEGG", "Supporter", true, "Supporter" },
                    { 3, "5HtjkBPs", "user@gmail.com", "$2a$11$4hUV5qmtJfTTjJB234Tq8e87gPsk2EJ79Mr333VMHkUrNbVum7PvO", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "71853 Kilback Mill, Rasheedborough, Tuvalu", "West Moshe", new DateTime(2022, 11, 6, 22, 4, 21, 838, DateTimeKind.Local).AddTicks(949), "onhdexmapletest1991@gmail.com", "Brittany", "Brittany Blick", true, "Blick", "(441) 357-8217", "StudentunKMULpU" },
                    { 3, "65180 Talia Fall, Lake Annechester, Andorra", "Fayfort", new DateTime(2023, 7, 8, 3, 52, 29, 928, DateTimeKind.Local).AddTicks(6811), "onhdexmapletest1993@gmail.com", "Kamron", "Kamron Kris", true, "Kris", "339.763.7525 x8345", "StudentHuqYW93J" },
                    { 5, "884 Aryanna Falls, Reganville, Antigua and Barbuda", "Port Yvonneville", new DateTime(2023, 1, 7, 12, 51, 19, 390, DateTimeKind.Local).AddTicks(1748), "onhdexmapletest1995@gmail.com", "Trace", "Trace Ledner", true, "Ledner", "(268) 915-2904", "StudentCs1Lbc7C" },
                    { 7, "135 Mattie Walks, West Alberthafurt, Panama", "Port Paul", new DateTime(2023, 4, 28, 8, 11, 31, 452, DateTimeKind.Local).AddTicks(3578), "onhdexmapletest1997@gmail.com", "Johanna", "Johanna Cassin", false, "Cassin", "1-881-597-9379", "StudentBoZvqTte" },
                    { 9, "5572 Ziemann Drive, Baumbachchester, Lao People's Democratic Republic", "Port Marcus", new DateTime(2023, 7, 11, 11, 17, 54, 167, DateTimeKind.Local).AddTicks(8466), "onhdexmapletest1999@gmail.com", "Krystina", "Krystina Buckridge", true, "Buckridge", "460-447-5533", "StudentoYpdphKV" },
                    { 11, "375 Adriel Branch, Eleazarbury, Niger", "West Guadalupe", new DateTime(2023, 3, 15, 7, 14, 19, 523, DateTimeKind.Local).AddTicks(3477), "onhdexmapletest19911@gmail.com", "Jennie", "Jennie Schaefer", true, "Schaefer", "1-413-998-9989 x14951", "StudentAsVyr4De" },
                    { 13, "8330 Altenwerth Trail, Pedroburgh, Argentina", "Haleyberg", new DateTime(2023, 6, 17, 23, 29, 11, 133, DateTimeKind.Local).AddTicks(9222), "onhdexmapletest19913@gmail.com", "Cortez", "Cortez Walker", false, "Walker", "370.447.6102 x3838", "Student4EQU1diW" },
                    { 15, "486 Wisozk Canyon, West Agustin, Saint Martin", "Turcotteburgh", new DateTime(2023, 3, 4, 22, 2, 18, 252, DateTimeKind.Local).AddTicks(2610), "onhdexmapletest19915@gmail.com", "Cade", "Cade Sawayn", false, "Sawayn", "1-516-238-9352", "Studenty3T0lOoA" },
                    { 17, "40014 Wunsch Mill, Brigitteshire, Thailand", "Kylabury", new DateTime(2023, 3, 17, 12, 15, 43, 285, DateTimeKind.Local).AddTicks(6477), "onhdexmapletest19917@gmail.com", "Pierce", "Pierce Gusikowski", true, "Gusikowski", "879.539.4512 x20355", "StudentdRnlyHXK" },
                    { 19, "707 Korey Spring, West Salvadorton, Micronesia", "Cassinmouth", new DateTime(2023, 8, 5, 22, 22, 37, 55, DateTimeKind.Local).AddTicks(9685), "onhdexmapletest19919@gmail.com", "Margaret", "Margaret Considine", true, "Considine", "1-684-446-4258 x283", "StudentB1Q8ibHW" },
                    { 21, "0797 Tavares Spring, North Gilbertoburgh, Gibraltar", "North Vallie", new DateTime(2022, 10, 13, 4, 47, 32, 802, DateTimeKind.Local).AddTicks(659), "onhdexmapletest19921@gmail.com", "Camden", "Camden Langosh", true, "Langosh", "(644) 508-7720 x66592", "Studentij0CIsEK" },
                    { 23, "77317 Nathaniel Union, Jarvisfort, Ecuador", "Edisonborough", new DateTime(2023, 1, 22, 23, 1, 58, 409, DateTimeKind.Local).AddTicks(9952), "onhdexmapletest19923@gmail.com", "Craig", "Craig Wolff", false, "Wolff", "(388) 480-4975 x6619", "StudentExVUJDil" },
                    { 25, "9318 Rudolph Vista, South Abdiel, Saint Kitts and Nevis", "New Goldaton", new DateTime(2023, 2, 24, 10, 29, 38, 472, DateTimeKind.Local).AddTicks(1441), "onhdexmapletest19925@gmail.com", "Mathias", "Mathias Howell", false, "Howell", "362.323.6461", "StudentZx9SWMkH" },
                    { 27, "48322 Rempel Haven, Klockoland, American Samoa", "East Mekhi", new DateTime(2023, 6, 8, 16, 15, 27, 223, DateTimeKind.Local).AddTicks(8863), "onhdexmapletest19927@gmail.com", "Jarrod", "Jarrod Streich", true, "Streich", "981-739-0764 x47920", "StudentMKUo5c0G" },
                    { 29, "9161 Turner Springs, New Josephville, El Salvador", "Haleyside", new DateTime(2023, 4, 12, 19, 20, 2, 287, DateTimeKind.Local).AddTicks(2450), "onhdexmapletest19929@gmail.com", "Cristopher", "Cristopher Batz", false, "Batz", "(860) 954-2018", "StudentO3azwsnJ" },
                    { 31, "07667 Kshlerin Villages, New Obieport, Latvia", "South Nobleside", new DateTime(2022, 12, 9, 14, 33, 52, 387, DateTimeKind.Local).AddTicks(2821), "onhdexmapletest19931@gmail.com", "Madge", "Madge Mann", true, "Mann", "454.808.4914 x364", "StudentwhHl7OVI" },
                    { 33, "77335 Ethel Gardens, West Myaton, Western Sahara", "Lakinshire", new DateTime(2023, 5, 20, 5, 10, 27, 758, DateTimeKind.Local).AddTicks(6479), "onhdexmapletest19933@gmail.com", "Rory", "Rory Dietrich", false, "Dietrich", "338.260.5405 x2425", "StudentS17TxptD" },
                    { 35, "6917 White Summit, Santiagostad, Iran", "Andersonport", new DateTime(2023, 8, 23, 14, 46, 19, 524, DateTimeKind.Local).AddTicks(8730), "onhdexmapletest19935@gmail.com", "Maia", "Maia Davis", false, "Davis", "952-371-6697", "StudentmVNxU84v" },
                    { 37, "17246 Hagenes Harbor, Mariannaton, Brunei Darussalam", "Starkfort", new DateTime(2023, 1, 13, 9, 55, 15, 111, DateTimeKind.Local).AddTicks(7879), "onhdexmapletest19937@gmail.com", "Karlee", "Karlee Beahan", false, "Beahan", "(589) 894-7800 x16357", "StudentGQsyzafp" },
                    { 39, "4867 Prosacco Junctions, Breitenbergville, French Guiana", "Samsonburgh", new DateTime(2022, 10, 25, 15, 25, 11, 432, DateTimeKind.Local).AddTicks(2748), "onhdexmapletest19939@gmail.com", "Agnes", "Agnes Ernser", false, "Ernser", "465.913.2592", "StudentDRCeZZqV" },
                    { 41, "39494 Balistreri Key, Priceside, Sweden", "West Larissa", new DateTime(2023, 3, 5, 21, 42, 17, 653, DateTimeKind.Local).AddTicks(6066), "onhdexmapletest19941@gmail.com", "Erich", "Erich Barton", true, "Barton", "1-623-719-3701", "StudentkDqdN9z7" },
                    { 43, "8853 Blanche Walks, West Jaysonfort, Mayotte", "Lake Margetown", new DateTime(2022, 11, 5, 13, 8, 22, 335, DateTimeKind.Local).AddTicks(9593), "onhdexmapletest19943@gmail.com", "Beth", "Beth Wehner", true, "Wehner", "1-830-661-1523 x2606", "StudentmtMZQ930" },
                    { 45, "76639 Herzog Greens, Lubowitzside, Antigua and Barbuda", "North Dudley", new DateTime(2022, 11, 24, 2, 19, 15, 437, DateTimeKind.Local).AddTicks(427), "onhdexmapletest19945@gmail.com", "Edison", "Edison Klein", true, "Klein", "(951) 710-2207", "StudentQKILcBie" },
                    { 47, "04860 Cole Roads, West Cletaborough, Saint Kitts and Nevis", "Alfredabury", new DateTime(2023, 9, 26, 18, 57, 32, 412, DateTimeKind.Local).AddTicks(9922), "onhdexmapletest19947@gmail.com", "Deangelo", "Deangelo Morissette", true, "Morissette", "(720) 524-9965 x56820", "StudentmcJvAAan" },
                    { 49, "82211 Bechtelar Terrace, Gaylemouth, Qatar", "Julioland", new DateTime(2023, 3, 10, 9, 6, 16, 38, DateTimeKind.Local).AddTicks(2008), "onhdexmapletest19949@gmail.com", "Justice", "Justice Kuvalis", true, "Kuvalis", "742-665-2227 x894", "Studentxnh77OI1" },
                    { 51, "32997 Jacobi Inlet, Kovacekfort, Guinea-Bissau", "Kylermouth", new DateTime(2023, 2, 16, 0, 52, 8, 597, DateTimeKind.Local).AddTicks(5924), "onhdexmapletest19951@gmail.com", "April", "April Cummerata", false, "Cummerata", "463.738.9492", "StudentwSnC3nDs" },
                    { 53, "906 Bayer Avenue, Russelhaven, Benin", "Stiedemannville", new DateTime(2022, 10, 29, 20, 11, 51, 262, DateTimeKind.Local).AddTicks(5044), "onhdexmapletest19953@gmail.com", "Israel", "Israel Bashirian", true, "Bashirian", "734-456-6729 x2892", "Student7unLMrBA" },
                    { 55, "208 Heathcote Expressway, West Tyree, Spain", "New Mikel", new DateTime(2022, 11, 10, 17, 4, 6, 995, DateTimeKind.Local).AddTicks(7192), "onhdexmapletest19955@gmail.com", "Charlene", "Charlene Klocko", false, "Klocko", "(439) 409-0114", "StudentKW27xq6U" },
                    { 57, "7562 Prosacco Pass, New Tiana, Kyrgyz Republic", "Balistrerifort", new DateTime(2023, 7, 26, 13, 54, 33, 403, DateTimeKind.Local).AddTicks(4451), "onhdexmapletest19957@gmail.com", "Leta", "Leta Cruickshank", false, "Cruickshank", "360.601.0012", "StudentsXsPcayR" },
                    { 59, "685 Giovanni Wall, Edythborough, Morocco", "New Terranceland", new DateTime(2023, 6, 30, 17, 1, 45, 742, DateTimeKind.Local).AddTicks(3097), "onhdexmapletest19959@gmail.com", "Katharina", "Katharina Bogisich", true, "Bogisich", "(893) 757-8520 x336", "StudentPZUkaN74" },
                    { 61, "239 Leffler Bypass, New Kayden, Northern Mariana Islands", "North Marilie", new DateTime(2023, 7, 16, 6, 0, 44, 693, DateTimeKind.Local).AddTicks(7123), "onhdexmapletest19961@gmail.com", "Cortez", "Cortez Dickens", true, "Dickens", "1-672-987-5016 x0101", "StudentP2ADve1N" },
                    { 63, "4041 Boyle Walks, North Chelsieview, Mongolia", "Hauckshire", new DateTime(2022, 10, 7, 4, 8, 11, 924, DateTimeKind.Local).AddTicks(3111), "onhdexmapletest19963@gmail.com", "Gabe", "Gabe Dooley", true, "Dooley", "1-471-737-0650 x8450", "StudentqKX0KO6x" },
                    { 65, "762 Jessie Trail, New Erwinview, Lithuania", "Conradmouth", new DateTime(2023, 5, 6, 4, 22, 57, 57, DateTimeKind.Local).AddTicks(8899), "onhdexmapletest19965@gmail.com", "Allan", "Allan Kuhlman", false, "Kuhlman", "1-914-466-2378", "StudentndSgakxU" },
                    { 67, "7405 Pollich Turnpike, Parisianshire, Botswana", "Auerhaven", new DateTime(2023, 9, 16, 21, 11, 34, 151, DateTimeKind.Local).AddTicks(5437), "onhdexmapletest19967@gmail.com", "Sydnie", "Sydnie Stoltenberg", true, "Stoltenberg", "775.500.9424 x78459", "StudentF0eexv4i" },
                    { 69, "89298 Haley Trafficway, New Everette, Barbados", "Schaefermouth", new DateTime(2023, 4, 6, 0, 19, 47, 361, DateTimeKind.Local).AddTicks(103), "onhdexmapletest19969@gmail.com", "Nicolas", "Nicolas Yundt", true, "Yundt", "705.757.7824 x46311", "StudentWuLfRj3G" },
                    { 71, "855 Kelsie Groves, Port Alisonfurt, Maldives", "Augustachester", new DateTime(2023, 1, 19, 13, 9, 57, 293, DateTimeKind.Local).AddTicks(9400), "onhdexmapletest19971@gmail.com", "Alana", "Alana Yundt", false, "Yundt", "290.519.6851 x94915", "Student9Qpw2Eyn" },
                    { 73, "690 Margie Fields, Emmerichborough, Mexico", "West Danielle", new DateTime(2023, 4, 20, 20, 3, 48, 919, DateTimeKind.Local).AddTicks(1343), "onhdexmapletest19973@gmail.com", "Marvin", "Marvin Torp", true, "Torp", "784-610-9979 x172", "StudenthXA8287n" },
                    { 75, "9452 Mable Motorway, South Alfton, Togo", "Lillieshire", new DateTime(2022, 11, 3, 2, 45, 6, 109, DateTimeKind.Local).AddTicks(9691), "onhdexmapletest19975@gmail.com", "Guadalupe", "Guadalupe Cruickshank", false, "Cruickshank", "555-476-0371 x4997", "StudentlUXfLRjl" },
                    { 77, "93419 Felipa Haven, Adrianborough, Benin", "South Sidney", new DateTime(2023, 4, 7, 18, 32, 4, 82, DateTimeKind.Local).AddTicks(8550), "onhdexmapletest19977@gmail.com", "Noah", "Noah Bosco", true, "Bosco", "(563) 590-1880 x742", "StudentXm1QlJVe" },
                    { 79, "849 Kay Parks, Dorcasside, Netherlands", "Hettingerfort", new DateTime(2022, 11, 6, 22, 47, 42, 60, DateTimeKind.Local).AddTicks(2030), "onhdexmapletest19979@gmail.com", "Nikolas", "Nikolas Morar", false, "Morar", "1-305-433-7954 x5046", "StudentbIeO6rrE" },
                    { 81, "599 Tressie Crescent, Lake Rahul, Guinea", "Bernardshire", new DateTime(2023, 3, 24, 21, 10, 57, 380, DateTimeKind.Local).AddTicks(7520), "onhdexmapletest19981@gmail.com", "Zelma", "Zelma Skiles", true, "Skiles", "(668) 659-5163", "StudentVVoZ6u0Q" },
                    { 83, "38516 Vivianne Landing, West Breanneton, Burundi", "South Florence", new DateTime(2023, 9, 22, 9, 0, 45, 989, DateTimeKind.Local).AddTicks(4406), "onhdexmapletest19983@gmail.com", "Dion", "Dion Rolfson", false, "Rolfson", "(734) 420-1648", "Studentf3kLJztb" },
                    { 85, "6758 Kreiger Valley, Wintheiserberg, Bolivia", "Schimmeltown", new DateTime(2023, 5, 3, 2, 47, 41, 346, DateTimeKind.Local).AddTicks(9556), "onhdexmapletest19985@gmail.com", "Dax", "Dax Hermiston", true, "Hermiston", "280.946.0547 x10336", "Studenta2C2K2H7" },
                    { 87, "9120 Courtney Road, Rogahnfurt, Costa Rica", "Stromanshire", new DateTime(2023, 8, 17, 15, 11, 36, 47, DateTimeKind.Local).AddTicks(2729), "onhdexmapletest19987@gmail.com", "Derick", "Derick Gerhold", true, "Gerhold", "(534) 864-3166 x64006", "StudentidYyYA66" },
                    { 89, "91776 Aisha Stravenue, Port Kamille, Cocos (Keeling) Islands", "New Clemensmouth", new DateTime(2023, 8, 25, 22, 13, 43, 391, DateTimeKind.Local).AddTicks(1839), "onhdexmapletest19989@gmail.com", "Dane", "Dane Blanda", true, "Blanda", "905-938-2409 x787", "StudentzZOPgft7" },
                    { 91, "64884 Oberbrunner Station, New Katharinachester, Cayman Islands", "Starkview", new DateTime(2022, 10, 21, 7, 44, 11, 92, DateTimeKind.Local).AddTicks(7837), "onhdexmapletest19991@gmail.com", "Gonzalo", "Gonzalo Prohaska", true, "Prohaska", "787-219-6552", "StudentfwItCaHT" },
                    { 93, "970 Nitzsche Valley, Torpstad, Costa Rica", "Port Marcelinobury", new DateTime(2023, 3, 19, 15, 37, 0, 230, DateTimeKind.Local).AddTicks(4538), "onhdexmapletest19993@gmail.com", "Leland", "Leland Romaguera", false, "Romaguera", "336.203.8817 x2056", "Studentsb6C3X7x" },
                    { 95, "209 Barrows Junction, Lake Leonor, Denmark", "East Buddyton", new DateTime(2023, 3, 19, 13, 38, 40, 341, DateTimeKind.Local).AddTicks(740), "onhdexmapletest19995@gmail.com", "Lyric", "Lyric Gleason", false, "Gleason", "544.643.7914 x34349", "StudentXBfV8ueB" },
                    { 97, "4648 Jon Course, New Efrain, Guinea-Bissau", "Kihnside", new DateTime(2022, 11, 4, 17, 8, 36, 163, DateTimeKind.Local).AddTicks(6952), "onhdexmapletest19997@gmail.com", "Lucile", "Lucile Schuppe", true, "Schuppe", "351-503-7855 x566", "StudentZveLo4X1" },
                    { 99, "594 Armstrong Road, Dickinsonport, Taiwan", "Garnetbury", new DateTime(2023, 9, 7, 14, 28, 18, 718, DateTimeKind.Local).AddTicks(4315), "onhdexmapletest19999@gmail.com", "Willard", "Willard Wiegand", true, "Wiegand", "497-961-8797 x1917", "StudentE6KNMeQJ" }
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
