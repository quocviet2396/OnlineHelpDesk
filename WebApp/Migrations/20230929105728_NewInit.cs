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
                    { 1, "KsE3CyxC", "superadmin@gmail.com", "$2a$11$.OqZsC7yyyMcZ3vvx5SQjeXHKT3Lc5Q.As4wojoq7IHO.Wvuwxuqa", "Admin", true, "SuperAdmin" },
                    { 2, "XfSkJIta", "supporter@gmail.com", "$2a$11$J6uGzDi9u6pkoDza4dNp/uKG.xm7Qf5fkRsx.BYY5pc0.i0ZUliDC", "Supporter", true, "Supporter" },
                    { 3, "KBfw9669", "user@gmail.com", "$2a$11$xD5wrfjopoV8Lqk1iyCKReBU0QOptw42N6.qtq9ufnwRfWyrX4B6K", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "2964 Kuhlman Circle, Port Jovani, Slovakia (Slovak Republic)", "West Asia", new DateTime(2023, 6, 1, 2, 28, 23, 175, DateTimeKind.Local).AddTicks(2242), "onhdexmapletest1991@gmail.com", "Nyah", "Nyah Sawayn", false, "Sawayn", "1-656-638-4947 x175", "Studentr5Ujk16h" },
                    { 3, "530 Schuster Key, West Kobymouth, Puerto Rico", "Rickiemouth", new DateTime(2023, 3, 27, 11, 45, 17, 546, DateTimeKind.Local).AddTicks(6501), "onhdexmapletest1993@gmail.com", "Antone", "Antone Lind", false, "Lind", "398.658.2278", "StudentQSj3gh71" },
                    { 5, "7775 Dan Fort, Lake Darion, Grenada", "Lake Turnermouth", new DateTime(2022, 10, 18, 2, 53, 54, 322, DateTimeKind.Local).AddTicks(4047), "onhdexmapletest1995@gmail.com", "Alda", "Alda Cruickshank", false, "Cruickshank", "1-305-934-0770 x9322", "StudentdP9WbGtY" },
                    { 7, "61193 Spencer Pass, North Hilma, Maldives", "East Tamiatown", new DateTime(2023, 6, 7, 17, 35, 20, 21, DateTimeKind.Local).AddTicks(3742), "onhdexmapletest1997@gmail.com", "Kenton", "Kenton Nikolaus", false, "Nikolaus", "1-643-458-7130", "Student023aeKqL" },
                    { 9, "65580 Royce Rapid, Kochhaven, Liechtenstein", "Conroymouth", new DateTime(2023, 7, 13, 9, 31, 2, 600, DateTimeKind.Local).AddTicks(4785), "onhdexmapletest1999@gmail.com", "Rickie", "Rickie Gorczany", true, "Gorczany", "355.985.1646", "StudenttsddAifD" },
                    { 11, "8458 Reichert Ford, Torphyport, South Africa", "New Keely", new DateTime(2023, 6, 7, 10, 58, 49, 871, DateTimeKind.Local).AddTicks(9516), "onhdexmapletest19911@gmail.com", "Madeline", "Madeline Erdman", true, "Erdman", "(473) 399-5907 x719", "Student0vhpnSVF" },
                    { 13, "53612 Hackett Track, North Imogeneland, Virgin Islands, U.S.", "Othatown", new DateTime(2022, 10, 9, 1, 28, 5, 102, DateTimeKind.Local).AddTicks(8938), "onhdexmapletest19913@gmail.com", "Durward", "Durward Wolff", false, "Wolff", "1-552-832-7524", "StudentSc9W2Ts1" },
                    { 15, "26718 Maia Spring, New Jackborough, Cayman Islands", "Considinetown", new DateTime(2023, 5, 14, 2, 19, 58, 537, DateTimeKind.Local).AddTicks(2625), "onhdexmapletest19915@gmail.com", "Eliseo", "Eliseo Lemke", false, "Lemke", "596.393.2644", "StudentuKZFP4uI" },
                    { 17, "5191 Cassin Isle, North Joesphland, Netherlands Antilles", "Gayville", new DateTime(2022, 12, 10, 18, 56, 36, 206, DateTimeKind.Local).AddTicks(6152), "onhdexmapletest19917@gmail.com", "Leonard", "Leonard Paucek", false, "Paucek", "884-805-8101 x1017", "StudentHeN4x3sU" },
                    { 19, "939 Schmidt Inlet, Ziemannstad, Sweden", "Lake Theodoratown", new DateTime(2023, 6, 20, 20, 17, 40, 306, DateTimeKind.Local).AddTicks(8650), "onhdexmapletest19919@gmail.com", "Demarco", "Demarco Kreiger", true, "Kreiger", "477.235.9254 x48892", "StudentnHE5GpsX" },
                    { 21, "11595 Hand Bypass, New Bernadetteberg, Cote d'Ivoire", "Mantemouth", new DateTime(2023, 2, 1, 3, 27, 29, 8, DateTimeKind.Local).AddTicks(5354), "onhdexmapletest19921@gmail.com", "Savion", "Savion Krajcik", true, "Krajcik", "1-346-800-7350", "Studentxc8EpLvP" },
                    { 23, "32338 Hyatt Extension, Lake Reed, Belize", "Jessikamouth", new DateTime(2023, 8, 31, 8, 52, 21, 902, DateTimeKind.Local).AddTicks(8123), "onhdexmapletest19923@gmail.com", "Daphne", "Daphne Parisian", true, "Parisian", "1-760-873-2920 x6249", "Student0nMPQsTm" },
                    { 25, "769 Angus Highway, Constanceshire, Serbia", "South Logan", new DateTime(2023, 9, 23, 6, 54, 36, 317, DateTimeKind.Local).AddTicks(8551), "onhdexmapletest19925@gmail.com", "Bianka", "Bianka Cassin", true, "Cassin", "(679) 628-1723", "StudentEXaQotNq" },
                    { 27, "143 Else Port, New Madonna, Taiwan", "Jaquelineville", new DateTime(2023, 1, 23, 17, 34, 36, 730, DateTimeKind.Local).AddTicks(1294), "onhdexmapletest19927@gmail.com", "Lilyan", "Lilyan Legros", true, "Legros", "1-703-520-6156 x1149", "StudentESUCivLS" },
                    { 29, "71590 Kenny Skyway, Port Gerardberg, Mali", "Halvorsonfurt", new DateTime(2022, 10, 5, 11, 12, 16, 185, DateTimeKind.Local).AddTicks(7565), "onhdexmapletest19929@gmail.com", "Bret", "Bret Zboncak", true, "Zboncak", "(941) 283-8142 x00584", "StudentiBozq5sK" },
                    { 31, "1533 Monahan Station, East Jerrodfort, Fiji", "Hanebury", new DateTime(2023, 3, 28, 17, 39, 48, 36, DateTimeKind.Local).AddTicks(6180), "onhdexmapletest19931@gmail.com", "Tyson", "Tyson Smitham", false, "Smitham", "(501) 468-5707 x9046", "StudentyyCpsUFU" },
                    { 33, "68054 Ernser Stream, South Alexander, Djibouti", "Roweberg", new DateTime(2023, 9, 16, 3, 11, 33, 919, DateTimeKind.Local).AddTicks(8617), "onhdexmapletest19933@gmail.com", "Rosario", "Rosario Reilly", false, "Reilly", "918-985-5138 x8748", "Studentao6o0Zdw" },
                    { 35, "26871 Barrows Stream, Adelinemouth, Australia", "Renehaven", new DateTime(2023, 7, 28, 13, 18, 55, 347, DateTimeKind.Local).AddTicks(3106), "onhdexmapletest19935@gmail.com", "Giovanni", "Giovanni Kuhic", true, "Kuhic", "(502) 660-4285", "StudentECzCvkFw" },
                    { 37, "724 Casimer Bridge, Hershelton, Yemen", "Harrisburgh", new DateTime(2023, 7, 26, 12, 9, 51, 686, DateTimeKind.Local).AddTicks(8761), "onhdexmapletest19937@gmail.com", "Jazmin", "Jazmin DuBuque", true, "DuBuque", "366.435.7606", "Studentyet81UV3" },
                    { 39, "6232 Hilma Street, East Rosemary, Heard Island and McDonald Islands", "South Schuylerberg", new DateTime(2023, 5, 13, 23, 46, 21, 717, DateTimeKind.Local).AddTicks(9376), "onhdexmapletest19939@gmail.com", "Halie", "Halie Reichel", true, "Reichel", "887-997-9953", "StudentWlE38AIB" },
                    { 41, "67723 Ward Dam, New Caseymouth, Cote d'Ivoire", "West Enricoland", new DateTime(2023, 6, 20, 2, 5, 8, 122, DateTimeKind.Local).AddTicks(6196), "onhdexmapletest19941@gmail.com", "Loren", "Loren Collier", true, "Collier", "(774) 886-0737", "StudentV4PeZuYT" },
                    { 43, "520 Schiller Shores, Port Marcos, Thailand", "Lake Kamronborough", new DateTime(2023, 4, 29, 23, 0, 42, 566, DateTimeKind.Local).AddTicks(1764), "onhdexmapletest19943@gmail.com", "Remington", "Remington Vandervort", false, "Vandervort", "(453) 854-5491 x056", "StudentDfyjeyb2" },
                    { 45, "50086 Kyra Crossing, Port Aniyahbury, Norfolk Island", "East Carolyn", new DateTime(2023, 2, 16, 20, 5, 38, 296, DateTimeKind.Local).AddTicks(8142), "onhdexmapletest19945@gmail.com", "Erika", "Erika Rohan", true, "Rohan", "1-956-789-2459 x4217", "StudentjKgcfPq6" },
                    { 47, "419 Conn Isle, O'Keefeland, Uzbekistan", "South Daija", new DateTime(2022, 12, 20, 12, 6, 20, 14, DateTimeKind.Local).AddTicks(6460), "onhdexmapletest19947@gmail.com", "Raphaelle", "Raphaelle Strosin", true, "Strosin", "324.330.0665", "Studentw2fRoK6H" },
                    { 49, "459 Hammes Brook, Port Trentonburgh, Guinea-Bissau", "Linneaville", new DateTime(2023, 3, 6, 19, 21, 18, 432, DateTimeKind.Local).AddTicks(3193), "onhdexmapletest19949@gmail.com", "Jaqueline", "Jaqueline Funk", true, "Funk", "879.878.3778 x49525", "Studentyn2073ek" },
                    { 51, "289 Kovacek Port, South Kenton, Zambia", "Gilbertchester", new DateTime(2023, 8, 9, 21, 6, 56, 334, DateTimeKind.Local).AddTicks(3338), "onhdexmapletest19951@gmail.com", "Mariela", "Mariela Jenkins", false, "Jenkins", "1-272-714-6909 x29349", "Studentf8mxPr94" },
                    { 53, "2979 Gutmann Summit, East Annalise, Nepal", "Chelseyside", new DateTime(2022, 10, 3, 6, 36, 5, 322, DateTimeKind.Local).AddTicks(1585), "onhdexmapletest19953@gmail.com", "Wilton", "Wilton Stanton", true, "Stanton", "(924) 391-9182", "StudentZm4rzCEO" },
                    { 55, "420 Grant Flat, Heidiborough, Latvia", "Alvafort", new DateTime(2023, 6, 14, 5, 22, 6, 494, DateTimeKind.Local).AddTicks(4041), "onhdexmapletest19955@gmail.com", "Cydney", "Cydney Windler", false, "Windler", "490.840.5498", "Student68tW87cA" },
                    { 57, "8634 Torphy Causeway, Port Libbieview, Trinidad and Tobago", "West Meaghan", new DateTime(2023, 9, 8, 6, 26, 21, 325, DateTimeKind.Local).AddTicks(7477), "onhdexmapletest19957@gmail.com", "Arnaldo", "Arnaldo Ziemann", true, "Ziemann", "662-237-7350", "StudentkxR0ruEh" },
                    { 59, "19346 Rempel Freeway, Ashleechester, Tajikistan", "West Pamelaburgh", new DateTime(2023, 8, 13, 4, 24, 51, 723, DateTimeKind.Local).AddTicks(1086), "onhdexmapletest19959@gmail.com", "Sigmund", "Sigmund Strosin", false, "Strosin", "1-373-847-9713", "Student10jb7Wq1" },
                    { 61, "097 Emanuel Orchard, Champlinhaven, Cocos (Keeling) Islands", "Reinholdland", new DateTime(2022, 10, 4, 17, 10, 16, 819, DateTimeKind.Local).AddTicks(4864), "onhdexmapletest19961@gmail.com", "Norwood", "Norwood Thiel", true, "Thiel", "(723) 704-6914", "StudentOZJLAdo1" },
                    { 63, "168 Howell Square, North Colemanview, Bangladesh", "Stephaniemouth", new DateTime(2023, 8, 2, 23, 57, 42, 716, DateTimeKind.Local).AddTicks(1732), "onhdexmapletest19963@gmail.com", "Kyla", "Kyla Bosco", true, "Bosco", "398.561.6625 x0474", "Student3cDxQhk7" },
                    { 65, "510 Paucek Viaduct, Stanton, Singapore", "Abdullahfurt", new DateTime(2023, 6, 23, 19, 15, 52, 34, DateTimeKind.Local).AddTicks(3259), "onhdexmapletest19965@gmail.com", "Adrianna", "Adrianna Ferry", true, "Ferry", "688-301-1373", "Studenth5Mjp2Mb" },
                    { 67, "496 Denesik Crossroad, Schneiderport, Saint Pierre and Miquelon", "Cartershire", new DateTime(2023, 4, 19, 1, 40, 39, 686, DateTimeKind.Local).AddTicks(639), "onhdexmapletest19967@gmail.com", "Hailee", "Hailee Nader", false, "Nader", "(500) 602-8737 x3388", "StudentfSXTxEbG" },
                    { 69, "7856 Veronica Glens, Larkinhaven, Niue", "Lake Lillaborough", new DateTime(2023, 9, 8, 6, 36, 24, 288, DateTimeKind.Local).AddTicks(5249), "onhdexmapletest19969@gmail.com", "Marjolaine", "Marjolaine Marks", true, "Marks", "926-423-7085 x0607", "StudentxHY2QCMU" },
                    { 71, "239 Garland Valleys, New Verona, India", "Connellyfurt", new DateTime(2023, 1, 15, 17, 19, 56, 245, DateTimeKind.Local).AddTicks(8413), "onhdexmapletest19971@gmail.com", "Lilliana", "Lilliana Metz", true, "Metz", "(679) 597-3617", "Studente7VPJk5F" },
                    { 73, "54317 Jaeden Brooks, Faheyville, Greenland", "Kuvalisstad", new DateTime(2023, 3, 24, 0, 29, 33, 542, DateTimeKind.Local).AddTicks(2469), "onhdexmapletest19973@gmail.com", "Alvis", "Alvis Hills", true, "Hills", "(754) 887-4586 x733", "StudentbEJ8fgku" },
                    { 75, "70886 Baylee Glens, North Delphiaville, Mali", "Anastacioborough", new DateTime(2022, 11, 3, 4, 48, 18, 568, DateTimeKind.Local).AddTicks(1610), "onhdexmapletest19975@gmail.com", "Clementina", "Clementina Bashirian", false, "Bashirian", "(407) 600-5893", "StudenttAGiRZnT" },
                    { 77, "1164 Ewell Burgs, North Susantown, Venezuela", "Liabury", new DateTime(2022, 10, 19, 22, 20, 47, 598, DateTimeKind.Local).AddTicks(8018), "onhdexmapletest19977@gmail.com", "Rhoda", "Rhoda Kirlin", false, "Kirlin", "414-702-1024 x710", "Studentb9AqAezB" },
                    { 79, "4878 Glennie Fort, South Sylvan, Luxembourg", "Rutherfordfort", new DateTime(2023, 5, 18, 2, 45, 16, 182, DateTimeKind.Local).AddTicks(7428), "onhdexmapletest19979@gmail.com", "Dangelo", "Dangelo Shanahan", false, "Shanahan", "(425) 766-9791 x78484", "StudentgP7Qfu2P" },
                    { 81, "920 Santiago Corner, Rauville, Ethiopia", "New Abel", new DateTime(2023, 6, 9, 11, 59, 19, 286, DateTimeKind.Local).AddTicks(3758), "onhdexmapletest19981@gmail.com", "Suzanne", "Suzanne Predovic", true, "Predovic", "(317) 768-7764", "StudentXMAR8zBt" },
                    { 83, "6279 Ray Mountains, New Tianna, Bermuda", "South D'angelotown", new DateTime(2023, 5, 7, 2, 10, 43, 116, DateTimeKind.Local).AddTicks(1382), "onhdexmapletest19983@gmail.com", "Kade", "Kade Rosenbaum", false, "Rosenbaum", "1-768-500-2780 x9941", "StudentA7ebAtjq" },
                    { 85, "22595 Bode Course, Lake Jasen, Estonia", "North Amaraburgh", new DateTime(2022, 10, 10, 16, 53, 59, 139, DateTimeKind.Local).AddTicks(3144), "onhdexmapletest19985@gmail.com", "Eulalia", "Eulalia Lueilwitz", true, "Lueilwitz", "1-366-845-3573", "StudenthzkUWTZ5" },
                    { 87, "2187 Micah Ramp, Kertzmannstad, Montenegro", "West Audrey", new DateTime(2023, 8, 22, 23, 50, 2, 530, DateTimeKind.Local).AddTicks(1960), "onhdexmapletest19987@gmail.com", "Jorge", "Jorge Blanda", true, "Blanda", "1-858-835-3349 x055", "Student4Gwsd6bY" },
                    { 89, "890 Callie Corners, Kautzerstad, Paraguay", "Thielland", new DateTime(2023, 8, 13, 16, 27, 46, 955, DateTimeKind.Local).AddTicks(2417), "onhdexmapletest19989@gmail.com", "Daphney", "Daphney Graham", false, "Graham", "1-607-999-8293 x26111", "StudentHXzEWFqR" },
                    { 91, "884 Glover Shores, South Hazel, Bahamas", "Dennishaven", new DateTime(2023, 2, 8, 16, 43, 3, 297, DateTimeKind.Local).AddTicks(9082), "onhdexmapletest19991@gmail.com", "Lucienne", "Lucienne Kuhlman", false, "Kuhlman", "1-944-678-2835 x7915", "StudentuaUDWwBV" },
                    { 93, "230 Misty Creek, Russelside, Venezuela", "West Christa", new DateTime(2023, 4, 27, 15, 12, 46, 634, DateTimeKind.Local).AddTicks(7044), "onhdexmapletest19993@gmail.com", "Jordane", "Jordane Paucek", false, "Paucek", "740-623-4634 x57113", "StudentlenqI230" },
                    { 95, "6418 Franecki Court, Rubenberg, Jersey", "Woodrowhaven", new DateTime(2023, 4, 28, 22, 1, 57, 492, DateTimeKind.Local).AddTicks(4387), "onhdexmapletest19995@gmail.com", "Jasmin", "Jasmin Stamm", false, "Stamm", "817-628-3308 x884", "Student8GVTQPtv" },
                    { 97, "629 Cortez Grove, Jaskolskiport, United Arab Emirates", "East Amanistad", new DateTime(2023, 4, 11, 14, 54, 0, 770, DateTimeKind.Local).AddTicks(9166), "onhdexmapletest19997@gmail.com", "Kylie", "Kylie Goyette", true, "Goyette", "573.618.3654", "StudentovLvgyWL" },
                    { 99, "07542 Bogan Rest, West Antonietta, Bangladesh", "Jeramyview", new DateTime(2023, 8, 14, 18, 22, 40, 759, DateTimeKind.Local).AddTicks(607), "onhdexmapletest19999@gmail.com", "Jamar", "Jamar Schmitt", false, "Schmitt", "1-376-411-3750 x7573", "Student6LexJCYb" }
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
