using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class project : Migration
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "Id", "Description", "Name", "SpId" },
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
                columns: new[] { "Id", "Code", "Email", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "I4xfeCHY", "superadmin@gmail.com", "$2a$11$MEJen6VBOqef3CpAIorALuwbcVRDP1Q2zHAiG76Ktp.JyWIhzvKfe", "Admin", true, "SuperAdmin" },
                    { 2, "WobSeu7q", "supporter@gmail.com", "$2a$11$/vjVehJmvQGQSW1U5V4ph.rcHM.Ohtzrq7rMOELszI9tCbJmv6kqW", "Supporter", true, "Supporter" },
                    { 3, "HD1cfIwo", "user@gmail.com", "$2a$11$pcJ.W3AJ9CyaBWeSJNxeTuQm0lE8Axy6QtWavcFbrhqRPudQUxOrG", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "60773 Deja Forest, Jovannyborough, Bhutan", "Balistrerifurt", new DateTime(2023, 6, 12, 16, 6, 24, 798, DateTimeKind.Local).AddTicks(1929), "onhdexmapletest1991@gmail.com", "Brooke", "Brooke Haag", true, "Haag", "718.365.2502 x27336", "StudentOSepvj4Q" },
                    { 3, "4922 Malachi Haven, New Mauriciostad, Uzbekistan", "Keaganshire", new DateTime(2023, 6, 13, 6, 27, 22, 818, DateTimeKind.Local).AddTicks(585), "onhdexmapletest1993@gmail.com", "Gene", "Gene Kilback", false, "Kilback", "1-319-357-4831 x635", "Student77I2nmA7" },
                    { 5, "00286 Haley Green, Kossbury, Chile", "New Carter", new DateTime(2022, 11, 3, 1, 20, 34, 302, DateTimeKind.Local).AddTicks(8444), "onhdexmapletest1995@gmail.com", "Greg", "Greg Daugherty", true, "Daugherty", "1-505-549-4274", "StudentPftzSS6B" },
                    { 7, "906 Ziemann Key, South Reginaldbury, Antarctica (the territory South of 60 deg S)", "Kulasborough", new DateTime(2023, 3, 4, 11, 30, 48, 110, DateTimeKind.Local).AddTicks(7506), "onhdexmapletest1997@gmail.com", "Palma", "Palma King", true, "King", "1-783-972-4639", "StudentHczbmKnu" },
                    { 9, "7942 Sophie Cliffs, Lottieborough, Nepal", "Quigleyburgh", new DateTime(2023, 8, 16, 11, 38, 7, 14, DateTimeKind.Local).AddTicks(1372), "onhdexmapletest1999@gmail.com", "Gertrude", "Gertrude Ullrich", true, "Ullrich", "865.718.2254 x5179", "StudentI7LGGI4c" },
                    { 11, "5773 Jacobs Route, Jacobsonfurt, Kazakhstan", "North Kobymouth", new DateTime(2023, 6, 15, 10, 33, 28, 254, DateTimeKind.Local).AddTicks(8449), "onhdexmapletest19911@gmail.com", "Maryam", "Maryam Purdy", false, "Purdy", "1-554-308-3019 x694", "StudenttA7Gpn64" },
                    { 13, "952 Eveline Wall, Lake Nathaniel, Kuwait", "Flatleyview", new DateTime(2023, 2, 16, 9, 35, 40, 9, DateTimeKind.Local).AddTicks(5478), "onhdexmapletest19913@gmail.com", "Belle", "Belle Volkman", true, "Volkman", "(701) 618-8347 x4163", "StudentQBShxnHg" },
                    { 15, "8800 Caroline Stravenue, West Jefferey, Spain", "North Liana", new DateTime(2023, 2, 28, 6, 18, 32, 204, DateTimeKind.Local).AddTicks(2388), "onhdexmapletest19915@gmail.com", "Ceasar", "Ceasar Will", false, "Will", "(294) 747-1018", "StudentNxhIFh93" },
                    { 17, "1207 Brendon Manor, South Naomiehaven, Tokelau", "Sandrahaven", new DateTime(2022, 12, 3, 4, 44, 50, 835, DateTimeKind.Local).AddTicks(8800), "onhdexmapletest19917@gmail.com", "Marge", "Marge Emmerich", true, "Emmerich", "1-219-562-1368 x91518", "StudentySTJvVj4" },
                    { 19, "658 Balistreri Cliffs, East Jayneville, Guinea-Bissau", "North Gideonburgh", new DateTime(2023, 8, 9, 7, 31, 2, 368, DateTimeKind.Local).AddTicks(2713), "onhdexmapletest19919@gmail.com", "Dangelo", "Dangelo O'Reilly", false, "O'Reilly", "248-461-3170", "StudentDDS6FG03" },
                    { 21, "5831 Spencer Cliffs, Josephinefort, Swaziland", "East Corinetown", new DateTime(2023, 2, 28, 11, 26, 16, 657, DateTimeKind.Local).AddTicks(2665), "onhdexmapletest19921@gmail.com", "Athena", "Athena Ebert", true, "Ebert", "704-280-7039 x0422", "StudentaLghlM7e" },
                    { 23, "5605 Derrick Prairie, New Pinkie, Guadeloupe", "Langhaven", new DateTime(2023, 4, 30, 4, 4, 58, 206, DateTimeKind.Local).AddTicks(3962), "onhdexmapletest19923@gmail.com", "Maverick", "Maverick Mueller", true, "Mueller", "499-449-6551", "StudentN6btcKpe" },
                    { 25, "4663 Kihn Mills, Kesslerhaven, Madagascar", "Port Abdullahland", new DateTime(2023, 1, 25, 21, 14, 8, 741, DateTimeKind.Local).AddTicks(3961), "onhdexmapletest19925@gmail.com", "Gail", "Gail Boyle", false, "Boyle", "251-937-4702 x1108", "StudentvGoQCxN2" },
                    { 27, "6479 Kyler Lights, Kingborough, Dominican Republic", "Wunschchester", new DateTime(2023, 4, 6, 3, 52, 54, 466, DateTimeKind.Local).AddTicks(727), "onhdexmapletest19927@gmail.com", "Jasmin", "Jasmin Cartwright", true, "Cartwright", "893.576.9663 x96570", "StudentDu0fRhcv" },
                    { 29, "961 Billie Well, West Ashtyn, Libyan Arab Jamahiriya", "North Ally", new DateTime(2023, 3, 7, 21, 28, 0, 955, DateTimeKind.Local).AddTicks(5947), "onhdexmapletest19929@gmail.com", "Marion", "Marion Schowalter", false, "Schowalter", "(838) 235-1145 x8514", "StudentsCeIlsIy" },
                    { 31, "741 Fay Valleys, North Mathew, Isle of Man", "Lake Arlo", new DateTime(2022, 10, 5, 7, 18, 44, 482, DateTimeKind.Local).AddTicks(3064), "onhdexmapletest19931@gmail.com", "Lenore", "Lenore Herzog", false, "Herzog", "923.887.2356 x1482", "StudentLZKRkYDP" },
                    { 33, "5123 Leanne Centers, Dakotaville, Pakistan", "Bartellville", new DateTime(2023, 3, 29, 17, 48, 35, 199, DateTimeKind.Local).AddTicks(2873), "onhdexmapletest19933@gmail.com", "Virginia", "Virginia Hansen", false, "Hansen", "1-644-907-9105 x48930", "StudentbSNH31k3" },
                    { 35, "623 Volkman Ridges, South Alitown, Armenia", "New Carissamouth", new DateTime(2023, 3, 4, 6, 2, 9, 257, DateTimeKind.Local).AddTicks(7726), "onhdexmapletest19935@gmail.com", "Alfonzo", "Alfonzo Skiles", false, "Skiles", "(381) 594-3493 x6879", "StudentZOOov2rK" },
                    { 37, "18477 Ahmad Center, South Bradley, Cambodia", "West Raina", new DateTime(2023, 8, 21, 0, 45, 42, 627, DateTimeKind.Local).AddTicks(4243), "onhdexmapletest19937@gmail.com", "Robb", "Robb Frami", true, "Frami", "1-644-436-4512 x4390", "StudenteZ5riMmO" },
                    { 39, "873 Hobart Ridges, East Saul, Gibraltar", "Mrazmouth", new DateTime(2022, 12, 29, 13, 29, 15, 58, DateTimeKind.Local).AddTicks(1296), "onhdexmapletest19939@gmail.com", "Wyman", "Wyman Haag", true, "Haag", "(713) 237-8808", "Student63LaooCr" },
                    { 41, "0201 Anissa Circle, Wilfridmouth, Tanzania", "South Reinholdland", new DateTime(2023, 3, 20, 5, 59, 36, 977, DateTimeKind.Local).AddTicks(9294), "onhdexmapletest19941@gmail.com", "Marley", "Marley Wunsch", true, "Wunsch", "1-470-644-9247 x74088", "StudentDt5qbBRz" },
                    { 43, "70096 Huels Brooks, Budmouth, Afghanistan", "South Bennie", new DateTime(2023, 9, 6, 0, 25, 57, 914, DateTimeKind.Local).AddTicks(9529), "onhdexmapletest19943@gmail.com", "Kathryne", "Kathryne Harvey", true, "Harvey", "784-669-8304", "StudentIMiWaxQq" },
                    { 45, "775 Queen Highway, New Emily, Saint Barthelemy", "Wavaville", new DateTime(2023, 3, 14, 18, 46, 35, 47, DateTimeKind.Local).AddTicks(4907), "onhdexmapletest19945@gmail.com", "Haylee", "Haylee Auer", true, "Auer", "820.468.3553", "StudentytOJKjhl" },
                    { 47, "0302 Samson Ridge, Lake Scottyville, Zambia", "Pouroshaven", new DateTime(2023, 5, 13, 16, 34, 2, 258, DateTimeKind.Local).AddTicks(9406), "onhdexmapletest19947@gmail.com", "Imogene", "Imogene Jenkins", false, "Jenkins", "1-538-904-9854 x066", "Student5tKdpKET" },
                    { 49, "928 Justen Courts, Port Maynardburgh, Mauritania", "West Kenya", new DateTime(2022, 10, 26, 3, 29, 23, 944, DateTimeKind.Local).AddTicks(7553), "onhdexmapletest19949@gmail.com", "Emil", "Emil Parisian", false, "Parisian", "473-349-1142", "StudentE8v5KQCb" },
                    { 51, "615 Pasquale Orchard, Osbaldostad, Netherlands Antilles", "Isaiberg", new DateTime(2023, 8, 22, 17, 52, 36, 418, DateTimeKind.Local).AddTicks(654), "onhdexmapletest19951@gmail.com", "Zula", "Zula Kautzer", true, "Kautzer", "1-317-542-7375 x45667", "StudentvzWmOm0k" },
                    { 53, "206 Huel Parkways, North Cheyanne, Albania", "Port Maybelletown", new DateTime(2023, 9, 5, 22, 50, 19, 159, DateTimeKind.Local).AddTicks(2573), "onhdexmapletest19953@gmail.com", "Ima", "Ima Wyman", true, "Wyman", "(869) 654-3845 x18160", "StudentzME8L9XM" },
                    { 55, "66378 Eugene Orchard, Runolfsdottirfurt, Moldova", "Jailynfort", new DateTime(2023, 3, 27, 19, 36, 16, 528, DateTimeKind.Local).AddTicks(8507), "onhdexmapletest19955@gmail.com", "Eladio", "Eladio Zulauf", false, "Zulauf", "1-986-458-8789", "Student7K2S632b" },
                    { 57, "7376 Alia Pike, North Jensenport, Bhutan", "Port Nikolas", new DateTime(2022, 12, 27, 16, 59, 10, 709, DateTimeKind.Local).AddTicks(3619), "onhdexmapletest19957@gmail.com", "Roxanne", "Roxanne O'Connell", false, "O'Connell", "698-953-6059 x0533", "StudentiGWLy1cE" },
                    { 59, "5745 Eduardo Junctions, Armstrongstad, Anguilla", "East Luisabury", new DateTime(2023, 4, 7, 16, 35, 43, 929, DateTimeKind.Local).AddTicks(2190), "onhdexmapletest19959@gmail.com", "Rodrick", "Rodrick Price", true, "Price", "809-691-5133", "StudentnboUdIfv" },
                    { 61, "93632 Mayer Well, Port Jennie, Lao People's Democratic Republic", "East Tyson", new DateTime(2022, 11, 19, 23, 38, 27, 4, DateTimeKind.Local).AddTicks(5047), "onhdexmapletest19961@gmail.com", "Gabriel", "Gabriel Koelpin", true, "Koelpin", "844.639.1418", "StudentBuBUYncQ" },
                    { 63, "9277 Palma Way, East Julesville, Belize", "Port Rosie", new DateTime(2023, 3, 3, 22, 44, 41, 43, DateTimeKind.Local).AddTicks(7480), "onhdexmapletest19963@gmail.com", "Monte", "Monte Jerde", true, "Jerde", "1-951-535-0270 x753", "StudentWeVRcfbO" },
                    { 65, "04452 Heathcote Corner, Electaberg, Tokelau", "New Monserrat", new DateTime(2023, 8, 28, 10, 29, 17, 601, DateTimeKind.Local).AddTicks(8805), "onhdexmapletest19965@gmail.com", "Libby", "Libby Fisher", false, "Fisher", "973.360.6363 x41825", "StudentUqr8sysq" },
                    { 67, "357 Stokes Centers, Kaceyhaven, Guam", "Mooreland", new DateTime(2023, 7, 8, 2, 22, 58, 222, DateTimeKind.Local).AddTicks(7094), "onhdexmapletest19967@gmail.com", "Lura", "Lura Wilkinson", true, "Wilkinson", "1-996-359-8870 x8911", "StudentLslARYEn" },
                    { 69, "98987 Jaylen Viaduct, South Zoila, Tajikistan", "Emmieport", new DateTime(2023, 5, 12, 13, 33, 49, 545, DateTimeKind.Local).AddTicks(605), "onhdexmapletest19969@gmail.com", "Haley", "Haley Aufderhar", true, "Aufderhar", "(598) 264-1621 x202", "StudentmHMY1zsy" },
                    { 71, "933 Daniel Summit, New Della, Barbados", "West Erwin", new DateTime(2023, 5, 31, 13, 2, 32, 352, DateTimeKind.Local).AddTicks(9766), "onhdexmapletest19971@gmail.com", "Devonte", "Devonte Jenkins", true, "Jenkins", "1-239-826-7216 x682", "Studenth4l1CGfY" },
                    { 73, "996 Bode Tunnel, Quigleyland, Marshall Islands", "New Golda", new DateTime(2022, 10, 12, 6, 56, 30, 911, DateTimeKind.Local).AddTicks(9917), "onhdexmapletest19973@gmail.com", "Westley", "Westley McDermott", false, "McDermott", "576.619.2673", "StudentMZ863XkA" },
                    { 75, "72500 Donato Prairie, Lake Orlandberg, Slovakia (Slovak Republic)", "Zoeymouth", new DateTime(2023, 2, 9, 1, 49, 10, 201, DateTimeKind.Local).AddTicks(9514), "onhdexmapletest19975@gmail.com", "Sophia", "Sophia Abernathy", false, "Abernathy", "400.671.7250", "StudentCSIkfAFX" },
                    { 77, "70503 Zulauf Camp, West Chadburgh, French Guiana", "North Mauricio", new DateTime(2023, 9, 18, 12, 35, 53, 697, DateTimeKind.Local).AddTicks(8941), "onhdexmapletest19977@gmail.com", "Fabian", "Fabian Zieme", true, "Zieme", "224.880.5956 x988", "StudentNrOF0gc5" },
                    { 79, "889 Leslie Mills, Port Rethabury, Hong Kong", "West D'angelo", new DateTime(2023, 7, 10, 14, 44, 11, 430, DateTimeKind.Local).AddTicks(7540), "onhdexmapletest19979@gmail.com", "Arthur", "Arthur Lemke", true, "Lemke", "(988) 286-2621 x208", "StudentPhANBWuw" },
                    { 81, "707 Spencer Plain, Port Brantview, Romania", "Zulaufview", new DateTime(2023, 1, 12, 6, 20, 56, 66, DateTimeKind.Local).AddTicks(8173), "onhdexmapletest19981@gmail.com", "Owen", "Owen Ward", false, "Ward", "602-354-2787 x72514", "StudentwQ1boHQB" },
                    { 83, "96679 Hauck Pass, Cynthiaburgh, British Indian Ocean Territory (Chagos Archipelago)", "West Veda", new DateTime(2023, 9, 20, 14, 17, 33, 737, DateTimeKind.Local).AddTicks(634), "onhdexmapletest19983@gmail.com", "Tod", "Tod Herman", false, "Herman", "1-585-293-6236", "StudentHFu2UKVR" },
                    { 85, "185 Grayce Lane, New Isidro, Latvia", "Angelicaburgh", new DateTime(2022, 11, 12, 18, 2, 18, 813, DateTimeKind.Local).AddTicks(545), "onhdexmapletest19985@gmail.com", "Aubrey", "Aubrey Langworth", true, "Langworth", "1-301-611-5203 x3945", "StudentlFKvWyEO" },
                    { 87, "701 Elmer Ranch, Port Arno, Wallis and Futuna", "Lake Ravenshire", new DateTime(2023, 6, 11, 8, 50, 12, 924, DateTimeKind.Local).AddTicks(5184), "onhdexmapletest19987@gmail.com", "Zoey", "Zoey Stroman", false, "Stroman", "(564) 921-4909 x69258", "StudentFPM3i7PP" },
                    { 89, "63267 Roberto Motorway, East Joannieshire, Trinidad and Tobago", "West Jaiden", new DateTime(2022, 12, 26, 13, 42, 57, 970, DateTimeKind.Local).AddTicks(4871), "onhdexmapletest19989@gmail.com", "Luciano", "Luciano Schuppe", true, "Schuppe", "563.582.0324 x8740", "StudentW7shYL8Z" },
                    { 91, "8504 Russel Manors, New Jailynville, Venezuela", "North Olgashire", new DateTime(2022, 11, 28, 2, 12, 23, 481, DateTimeKind.Local).AddTicks(1143), "onhdexmapletest19991@gmail.com", "Elisa", "Elisa Upton", false, "Upton", "(450) 776-2040 x39327", "StudentSrbhP12z" },
                    { 93, "423 Brielle Tunnel, Lake Katrina, Malaysia", "Strackebury", new DateTime(2023, 9, 20, 1, 25, 40, 870, DateTimeKind.Local).AddTicks(8250), "onhdexmapletest19993@gmail.com", "Tyson", "Tyson Wilkinson", true, "Wilkinson", "857-847-0356", "StudentEmGO6E8x" },
                    { 95, "410 Williamson Parkways, Port Mariahchester, Equatorial Guinea", "Lake Aiden", new DateTime(2022, 11, 30, 3, 23, 16, 108, DateTimeKind.Local).AddTicks(1579), "onhdexmapletest19995@gmail.com", "Aurelie", "Aurelie Spencer", true, "Spencer", "977-566-7141", "StudentTsYNRmzS" },
                    { 97, "7925 Sonia Isle, New Lavonberg, Peru", "West Vernonborough", new DateTime(2022, 11, 9, 21, 18, 44, 373, DateTimeKind.Local).AddTicks(9354), "onhdexmapletest19997@gmail.com", "Fidel", "Fidel Schowalter", false, "Schowalter", "608-238-8278", "StudentmVhgaaHu" },
                    { 99, "82070 Oberbrunner Mall, New Zander, Pakistan", "West Keshawn", new DateTime(2022, 12, 20, 9, 42, 8, 966, DateTimeKind.Local).AddTicks(4499), "onhdexmapletest19999@gmail.com", "Deshawn", "Deshawn Gusikowski", true, "Gusikowski", "965.389.7580", "StudentzpJdmlvL" }
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
