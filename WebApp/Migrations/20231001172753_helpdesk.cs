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
                    { 1, "FI7K41mI", "superadmin@gmail.com", "$2a$11$jlmPOrPE1zk4QrKhjro0ouudAnl/gSeqz.XAWYACdjE78xB/4JfQy", "Admin", true, "SuperAdmin" },
                    { 2, "8NbT4tR2", "supporter@gmail.com", "$2a$11$uEJKJswxKX2FVJ3NMgSnmeoLD3KdrFFmuGAliFwQo829HobLw.Ol6", "Supporter", true, "Supporter" },
                    { 3, "7n1c3Umq", "user@gmail.com", "$2a$11$LFHspmfTLQLr.EhMpY5lm.t.aJEzEYaCY4A0NujG2Kcv88G3FBp0u", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "34698 Brady Glen, Vivientown, Haiti", "Port Wiltonborough", new DateTime(2022, 11, 27, 22, 27, 45, 127, DateTimeKind.Local).AddTicks(5768), "onhdexmapletest1991@gmail.com", "Zoie", "Zoie Smith", false, "Smith", "930-469-3057 x1540", "StudentOJRAnxGP" },
                    { 3, "0664 Fredrick Pines, Waelchimouth, Switzerland", "West Arlie", new DateTime(2023, 6, 30, 13, 7, 23, 816, DateTimeKind.Local).AddTicks(5444), "onhdexmapletest1993@gmail.com", "Antonia", "Antonia Roberts", false, "Roberts", "601.291.1872 x93761", "Studentd0gS8tGd" },
                    { 5, "552 Lizeth Fords, Kingtown, Sri Lanka", "Alliemouth", new DateTime(2023, 4, 13, 13, 48, 6, 479, DateTimeKind.Local).AddTicks(9114), "onhdexmapletest1995@gmail.com", "Marian", "Marian Mayert", false, "Mayert", "722-942-9659 x7158", "Student3Go3RKG7" },
                    { 7, "000 Larson Junctions, Swiftbury, Eritrea", "Brakusport", new DateTime(2023, 3, 28, 9, 45, 52, 453, DateTimeKind.Local).AddTicks(8213), "onhdexmapletest1997@gmail.com", "Hettie", "Hettie Gutmann", true, "Gutmann", "616.991.7895 x490", "StudentvQ7j1TUO" },
                    { 9, "1946 Clementina Trace, Hildaville, Puerto Rico", "Feliciaberg", new DateTime(2022, 10, 15, 0, 44, 46, 661, DateTimeKind.Local).AddTicks(5251), "onhdexmapletest1999@gmail.com", "Kristian", "Kristian Koch", false, "Koch", "(391) 899-3825 x2502", "StudentkvaOLWnz" },
                    { 11, "4474 Margaretta Vista, Cornellburgh, Germany", "Breitenbergchester", new DateTime(2022, 12, 7, 4, 35, 48, 348, DateTimeKind.Local).AddTicks(2824), "onhdexmapletest19911@gmail.com", "Lauren", "Lauren Bailey", true, "Bailey", "738.887.5934 x186", "StudentxzEAYCNK" },
                    { 13, "4867 Cummerata Meadows, New Geovanni, Netherlands Antilles", "New Ophelia", new DateTime(2022, 11, 22, 17, 40, 2, 382, DateTimeKind.Local).AddTicks(4176), "onhdexmapletest19913@gmail.com", "Mara", "Mara Barton", false, "Barton", "677.536.2797 x8177", "Studentae23iZMu" },
                    { 15, "16268 Shany Passage, East Kennedy, Uganda", "East Brett", new DateTime(2022, 10, 17, 16, 16, 12, 917, DateTimeKind.Local).AddTicks(8511), "onhdexmapletest19915@gmail.com", "Yessenia", "Yessenia Beier", true, "Beier", "(869) 348-5740", "Student5d7bUQvm" },
                    { 17, "91918 O'Kon Place, Port Valeriemouth, United States of America", "Brownmouth", new DateTime(2023, 9, 3, 5, 7, 32, 243, DateTimeKind.Local).AddTicks(389), "onhdexmapletest19917@gmail.com", "Judge", "Judge Jacobs", false, "Jacobs", "367-271-6089", "StudentFvAtO1vL" },
                    { 19, "34587 McCullough View, New Jesus, Mauritius", "West Kaleb", new DateTime(2023, 8, 1, 19, 3, 8, 452, DateTimeKind.Local).AddTicks(7542), "onhdexmapletest19919@gmail.com", "Tyrel", "Tyrel Renner", true, "Renner", "993.652.1794", "Student7Tk5Mo85" },
                    { 21, "64384 Rodrigo Streets, East Erwin, Timor-Leste", "Deeborough", new DateTime(2023, 8, 9, 3, 36, 26, 655, DateTimeKind.Local).AddTicks(4323), "onhdexmapletest19921@gmail.com", "Melyna", "Melyna Rodriguez", false, "Rodriguez", "942.492.7082", "StudentXi96xLon" },
                    { 23, "322 Lemke Center, New Arveltown, Tokelau", "South Uniqueville", new DateTime(2022, 12, 5, 16, 41, 52, 185, DateTimeKind.Local).AddTicks(851), "onhdexmapletest19923@gmail.com", "Mozelle", "Mozelle Pacocha", true, "Pacocha", "1-877-474-2440 x54607", "StudentTBy4ojvm" },
                    { 25, "7199 Caitlyn Underpass, New Ada, Peru", "Leuschkeborough", new DateTime(2023, 4, 16, 1, 45, 1, 776, DateTimeKind.Local).AddTicks(593), "onhdexmapletest19925@gmail.com", "Nash", "Nash O'Connell", false, "O'Connell", "1-961-204-9837 x339", "StudentcGi82RnG" },
                    { 27, "915 Jerde Course, Port Nicolettefurt, Reunion", "East Anderson", new DateTime(2023, 1, 27, 12, 44, 13, 946, DateTimeKind.Local).AddTicks(7078), "onhdexmapletest19927@gmail.com", "Christina", "Christina Yundt", true, "Yundt", "(495) 526-4132 x83820", "StudentsCsUoCf9" },
                    { 29, "9999 Ashlee Neck, Hickleton, Switzerland", "New Lina", new DateTime(2023, 6, 12, 13, 20, 50, 922, DateTimeKind.Local).AddTicks(6025), "onhdexmapletest19929@gmail.com", "Frederick", "Frederick Ernser", true, "Ernser", "386-915-1758", "Students0SFsqiI" },
                    { 31, "67471 Rosie Roads, East Dennis, Bulgaria", "Corineside", new DateTime(2022, 10, 31, 17, 24, 44, 429, DateTimeKind.Local).AddTicks(8278), "onhdexmapletest19931@gmail.com", "Cristian", "Cristian Reichert", false, "Reichert", "353-565-8231 x8447", "StudentR60Kcz1S" },
                    { 33, "5254 Beau Overpass, Port Dovie, Australia", "Chasitymouth", new DateTime(2023, 2, 5, 5, 58, 55, 890, DateTimeKind.Local).AddTicks(9910), "onhdexmapletest19933@gmail.com", "Alaina", "Alaina Ward", false, "Ward", "(999) 369-8580", "Studenttm6c3YLl" },
                    { 35, "282 Marvin Tunnel, West Dejuan, Cambodia", "Lake Lawsonbury", new DateTime(2022, 12, 18, 17, 25, 10, 401, DateTimeKind.Local).AddTicks(7787), "onhdexmapletest19935@gmail.com", "Hailee", "Hailee Hackett", true, "Hackett", "1-714-404-5226 x479", "Studentcg8sj34A" },
                    { 37, "36185 Auer Mill, West Janiya, Finland", "Faheyton", new DateTime(2023, 2, 16, 21, 11, 35, 979, DateTimeKind.Local).AddTicks(9655), "onhdexmapletest19937@gmail.com", "Macy", "Macy Schaden", false, "Schaden", "(297) 309-0223 x425", "StudentHlRQ4oXd" },
                    { 39, "724 Aurelia Stravenue, Rutherfordchester, Equatorial Guinea", "Trentburgh", new DateTime(2022, 11, 27, 10, 43, 29, 89, DateTimeKind.Local).AddTicks(1159), "onhdexmapletest19939@gmail.com", "Ivy", "Ivy Halvorson", true, "Halvorson", "371-343-5095", "Studente7Uw90Uj" },
                    { 41, "79685 Gideon Club, Swiftton, China", "Walterchester", new DateTime(2023, 3, 24, 11, 50, 20, 921, DateTimeKind.Local).AddTicks(7046), "onhdexmapletest19941@gmail.com", "Carolina", "Carolina Rath", true, "Rath", "386.786.5944", "Studentxyn8SQsu" },
                    { 43, "74942 Ron Heights, West Glenberg, Tokelau", "Schaeferstad", new DateTime(2023, 5, 11, 20, 30, 8, 508, DateTimeKind.Local).AddTicks(1784), "onhdexmapletest19943@gmail.com", "Danny", "Danny Fisher", false, "Fisher", "(804) 268-7954", "StudentdWhoJvhI" },
                    { 45, "33391 Hettinger Pines, East Kurtistown, Ethiopia", "Marlinborough", new DateTime(2023, 9, 15, 18, 38, 43, 175, DateTimeKind.Local).AddTicks(681), "onhdexmapletest19945@gmail.com", "Reid", "Reid Flatley", true, "Flatley", "1-662-963-2921 x5108", "StudentxzzS2GrB" },
                    { 47, "04112 Gleason Club, Kirkport, Niger", "Gleichnerchester", new DateTime(2023, 8, 6, 8, 17, 9, 78, DateTimeKind.Local).AddTicks(8863), "onhdexmapletest19947@gmail.com", "Nikolas", "Nikolas Leffler", false, "Leffler", "1-327-959-2569 x8054", "StudentNQREhoc4" },
                    { 49, "93122 Dashawn Cove, New Rubyestad, Venezuela", "Port Marciaburgh", new DateTime(2023, 5, 10, 3, 45, 43, 910, DateTimeKind.Local).AddTicks(1760), "onhdexmapletest19949@gmail.com", "Kaci", "Kaci Koch", false, "Koch", "(815) 386-3760 x781", "StudentOUs4pRuT" },
                    { 51, "75293 Cruickshank Summit, West Jaunitafort, Cape Verde", "New Xavier", new DateTime(2023, 2, 28, 6, 50, 18, 862, DateTimeKind.Local).AddTicks(1204), "onhdexmapletest19951@gmail.com", "Gregorio", "Gregorio McClure", true, "McClure", "985-343-4582", "Studenth9Zzau4z" },
                    { 53, "58980 Braun Greens, Patienceberg, Niue", "Bayertown", new DateTime(2023, 1, 24, 2, 43, 12, 696, DateTimeKind.Local).AddTicks(4051), "onhdexmapletest19953@gmail.com", "Keven", "Keven Rowe", false, "Rowe", "209.812.0344", "Student13J1sKwB" },
                    { 55, "16881 Liana Tunnel, Reichertfurt, Venezuela", "Jedidiahchester", new DateTime(2023, 8, 5, 7, 9, 55, 613, DateTimeKind.Local).AddTicks(2572), "onhdexmapletest19955@gmail.com", "Joany", "Joany Johnston", true, "Johnston", "268.816.8455 x96187", "StudentGeAZ59Lc" },
                    { 57, "0671 Reilly Falls, North Agneshaven, Vanuatu", "Macejkovicmouth", new DateTime(2023, 7, 20, 8, 31, 37, 732, DateTimeKind.Local).AddTicks(4860), "onhdexmapletest19957@gmail.com", "Tyrell", "Tyrell Jenkins", true, "Jenkins", "218-529-1635 x536", "Studenta03at58i" },
                    { 59, "88092 Citlalli Estates, Kamronland, Bahrain", "Robinview", new DateTime(2023, 6, 2, 21, 8, 33, 272, DateTimeKind.Local).AddTicks(4163), "onhdexmapletest19959@gmail.com", "Bettie", "Bettie Hammes", false, "Hammes", "1-652-798-0480", "StudenthFr5dQwz" },
                    { 61, "7884 Conn Neck, Hettingerfort, Maldives", "Bernhardland", new DateTime(2023, 4, 3, 7, 7, 3, 910, DateTimeKind.Local).AddTicks(4090), "onhdexmapletest19961@gmail.com", "Elliott", "Elliott Grady", false, "Grady", "(348) 334-6848", "Student8OAsfPLr" },
                    { 63, "531 Schaefer Road, Greysonberg, Slovakia (Slovak Republic)", "Willowshire", new DateTime(2023, 2, 4, 21, 12, 30, 810, DateTimeKind.Local).AddTicks(3203), "onhdexmapletest19963@gmail.com", "Emmanuelle", "Emmanuelle Lesch", true, "Lesch", "(775) 822-5136 x42213", "StudentRGdiwmiJ" },
                    { 65, "7713 Christiansen Road, South Coy, Maldives", "Lake Kennaland", new DateTime(2023, 2, 27, 10, 31, 20, 418, DateTimeKind.Local).AddTicks(5074), "onhdexmapletest19965@gmail.com", "Jay", "Jay Walsh", false, "Walsh", "(932) 928-7143 x0139", "Student8WJLnfP2" },
                    { 67, "48291 Kuhn Divide, Edgardoshire, Jordan", "Piperfort", new DateTime(2022, 11, 23, 7, 34, 2, 867, DateTimeKind.Local).AddTicks(1929), "onhdexmapletest19967@gmail.com", "Leonor", "Leonor Roob", false, "Roob", "1-655-708-4636", "Student28ia8zy5" },
                    { 69, "998 Kerluke Keys, North Stephen, Micronesia", "New Buford", new DateTime(2023, 6, 8, 5, 55, 51, 935, DateTimeKind.Local).AddTicks(7037), "onhdexmapletest19969@gmail.com", "Maximilian", "Maximilian Herman", true, "Herman", "1-872-557-6310", "StudentBDkWz9H9" },
                    { 71, "5262 Brett Via, Beattyfurt, Sierra Leone", "Reginaldbury", new DateTime(2023, 1, 25, 12, 15, 30, 150, DateTimeKind.Local).AddTicks(3589), "onhdexmapletest19971@gmail.com", "Vincenzo", "Vincenzo Kunze", false, "Kunze", "1-777-997-2472 x8089", "StudentgSIg9l9Q" },
                    { 73, "735 Laurianne Shoal, Dallasland, Bouvet Island (Bouvetoya)", "Watsicastad", new DateTime(2023, 5, 13, 1, 22, 11, 457, DateTimeKind.Local).AddTicks(7607), "onhdexmapletest19973@gmail.com", "Aron", "Aron Braun", false, "Braun", "534.514.4895 x070", "StudentStybnTrc" },
                    { 75, "0886 Joannie Village, South Agnes, Cape Verde", "Kolechester", new DateTime(2023, 4, 25, 7, 10, 7, 852, DateTimeKind.Local).AddTicks(8784), "onhdexmapletest19975@gmail.com", "Jamarcus", "Jamarcus Blick", false, "Blick", "767.908.2745", "StudentjkztyMoz" },
                    { 77, "0331 Wolf Lake, South Chelsie, New Caledonia", "Kearabury", new DateTime(2023, 6, 10, 23, 42, 56, 957, DateTimeKind.Local).AddTicks(732), "onhdexmapletest19977@gmail.com", "Fannie", "Fannie Becker", false, "Becker", "(726) 572-9559", "StudentF7pl0Ko4" },
                    { 79, "975 Nathan Views, Turnerchester, Belarus", "Lake Woodrowton", new DateTime(2023, 8, 2, 2, 52, 50, 608, DateTimeKind.Local).AddTicks(4034), "onhdexmapletest19979@gmail.com", "Ansley", "Ansley White", false, "White", "705-399-0164 x384", "StudentoKpYRwrK" },
                    { 81, "345 Parisian Alley, Demarcusstad, Tajikistan", "Ansleyburgh", new DateTime(2023, 1, 5, 3, 32, 23, 864, DateTimeKind.Local).AddTicks(7598), "onhdexmapletest19981@gmail.com", "Tia", "Tia Williamson", false, "Williamson", "742-414-6897 x2788", "StudentB5e7r6fk" },
                    { 83, "293 Borer Islands, Leonardoland, Sao Tome and Principe", "East Mitchellland", new DateTime(2022, 12, 27, 22, 52, 58, 857, DateTimeKind.Local).AddTicks(9114), "onhdexmapletest19983@gmail.com", "Lottie", "Lottie Bode", true, "Bode", "1-242-534-5451 x29542", "StudentzKYRhVAY" },
                    { 85, "207 Yvette Knoll, Lake Kayceeberg, Oman", "New Jaydeshire", new DateTime(2022, 11, 4, 6, 45, 3, 114, DateTimeKind.Local).AddTicks(9387), "onhdexmapletest19985@gmail.com", "Elliott", "Elliott Sauer", true, "Sauer", "500-669-9021 x51203", "StudentRyjqutry" },
                    { 87, "98052 Brionna Oval, Gregland, Belize", "Kiehnchester", new DateTime(2023, 8, 23, 0, 35, 41, 556, DateTimeKind.Local).AddTicks(8070), "onhdexmapletest19987@gmail.com", "Amos", "Amos Bahringer", false, "Bahringer", "841-617-1628 x83695", "StudentNzdVMX4x" },
                    { 89, "123 Astrid Brooks, Gabrielton, Libyan Arab Jamahiriya", "Genevieveberg", new DateTime(2023, 6, 5, 4, 49, 4, 856, DateTimeKind.Local).AddTicks(124), "onhdexmapletest19989@gmail.com", "Elvis", "Elvis Willms", true, "Willms", "(303) 500-8049 x878", "StudentrWAVW7rl" },
                    { 91, "6532 Kendrick Dam, New Robbieland, Honduras", "North Cedrickstad", new DateTime(2022, 11, 13, 13, 8, 9, 952, DateTimeKind.Local).AddTicks(4930), "onhdexmapletest19991@gmail.com", "Angel", "Angel Strosin", true, "Strosin", "914.447.4101 x9663", "Student6BVu8sYE" },
                    { 93, "479 Zemlak Path, New Brodyton, Colombia", "Oberbrunnertown", new DateTime(2023, 5, 8, 14, 38, 49, 406, DateTimeKind.Local).AddTicks(8433), "onhdexmapletest19993@gmail.com", "Waldo", "Waldo Sporer", false, "Sporer", "(315) 284-0039", "Student6tlF0dbL" },
                    { 95, "136 Brett Turnpike, Goyetteview, Macedonia", "Reynoldborough", new DateTime(2023, 3, 28, 22, 54, 6, 907, DateTimeKind.Local).AddTicks(7847), "onhdexmapletest19995@gmail.com", "Danyka", "Danyka Kertzmann", false, "Kertzmann", "233-968-7840", "StudentxK4TlMT7" },
                    { 97, "2308 Gutmann Squares, Rueckerberg, Holy See (Vatican City State)", "Port Felton", new DateTime(2023, 2, 2, 2, 54, 58, 488, DateTimeKind.Local).AddTicks(8726), "onhdexmapletest19997@gmail.com", "Katelynn", "Katelynn Beer", false, "Beer", "(684) 850-4219 x120", "StudentFyhvBQWd" },
                    { 99, "801 Marianne Corners, Wardstad, San Marino", "South Sanford", new DateTime(2023, 1, 15, 12, 59, 15, 207, DateTimeKind.Local).AddTicks(9866), "onhdexmapletest19999@gmail.com", "Jacinto", "Jacinto Cronin", false, "Cronin", "1-392-221-1556 x12136", "Student2Zvt83ny" }
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
