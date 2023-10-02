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
                    { 1, "Ee8NzHgp", "superadmin@gmail.com", "$2a$11$UR.eYlk.SjFNA3v5Yre0EOjZl/re9hatl1MgsNIdPnzTlfbbA3nmK", "Admin", true, "SuperAdmin" },
                    { 2, "msAhoshF", "supporter@gmail.com", "$2a$11$G/bvWREEVLjJr3ud0VfZ6uZ5Fad6SDXXOBr2ZucmHYl3cqP3wqkUm", "Supporter", true, "Supporter" },
                    { 3, "fmiZVyls", "user@gmail.com", "$2a$11$qrQA3GZKTJ6ubJqN4/ocY.cyakMBUSU1otiY5R6.Otc23IAAwFr4W", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "611 Bayer Pike, Magnusshire, Bulgaria", "Betsystad", new DateTime(2022, 11, 26, 19, 59, 30, 223, DateTimeKind.Local).AddTicks(8144), "onhdexmapletest1991@gmail.com", "Delphia", "Delphia Beier", true, "Beier", "773-301-7584 x475", "StudentL5wY7TvH" },
                    { 3, "289 King Flats, Mooreview, Jersey", "New Noel", new DateTime(2023, 9, 19, 20, 21, 59, 864, DateTimeKind.Local).AddTicks(8719), "onhdexmapletest1993@gmail.com", "Verda", "Verda Considine", true, "Considine", "792.591.7927 x969", "StudentIc33ysM7" },
                    { 5, "1918 Taurean Path, Fayeberg, Solomon Islands", "Napoleonfurt", new DateTime(2023, 2, 24, 20, 39, 20, 493, DateTimeKind.Local).AddTicks(1583), "onhdexmapletest1995@gmail.com", "Providenci", "Providenci Lindgren", true, "Lindgren", "(250) 244-2168 x197", "Student2rq7zSSF" },
                    { 7, "243 Calista Vista, Rowehaven, Isle of Man", "Rogertown", new DateTime(2022, 11, 21, 15, 53, 6, 508, DateTimeKind.Local).AddTicks(4716), "onhdexmapletest1997@gmail.com", "Rebeka", "Rebeka Turner", true, "Turner", "(458) 631-8202 x9164", "Student20biFZ3C" },
                    { 9, "71332 Lonie Roads, Spinkabury, Virgin Islands, British", "East Andrewchester", new DateTime(2023, 9, 6, 14, 3, 0, 328, DateTimeKind.Local).AddTicks(8675), "onhdexmapletest1999@gmail.com", "Evie", "Evie Emmerich", false, "Emmerich", "1-730-296-5268 x497", "Studentxyqe9Il6" },
                    { 11, "15847 Bertrand Village, Metzstad, Kyrgyz Republic", "Port Davionfurt", new DateTime(2022, 10, 16, 20, 35, 25, 981, DateTimeKind.Local).AddTicks(3342), "onhdexmapletest19911@gmail.com", "Seamus", "Seamus Torp", true, "Torp", "(707) 758-3418 x07142", "StudentlsqdKKFp" },
                    { 13, "47624 Kylie Overpass, Johnsberg, Tanzania", "West Letitia", new DateTime(2023, 8, 19, 0, 7, 58, 92, DateTimeKind.Local).AddTicks(9941), "onhdexmapletest19913@gmail.com", "Sabina", "Sabina Treutel", false, "Treutel", "1-613-823-7010 x944", "StudentQ2pu5MDt" },
                    { 15, "5308 Gottlieb Haven, New Nicholausfurt, Malta", "Gunnarburgh", new DateTime(2023, 3, 17, 3, 19, 32, 239, DateTimeKind.Local).AddTicks(4648), "onhdexmapletest19915@gmail.com", "Dawson", "Dawson Haley", true, "Haley", "465-367-8014", "StudentEGmI4RCi" },
                    { 17, "17087 Kristy Vista, Keeblerton, Cote d'Ivoire", "Keaganhaven", new DateTime(2022, 11, 30, 14, 52, 51, 621, DateTimeKind.Local).AddTicks(8212), "onhdexmapletest19917@gmail.com", "Ferne", "Ferne Murphy", false, "Murphy", "460.262.6862 x8328", "StudentqM2yttJs" },
                    { 19, "530 Jarod Mission, Kielhaven, Tanzania", "Jarenbury", new DateTime(2023, 9, 24, 1, 8, 28, 715, DateTimeKind.Local).AddTicks(4619), "onhdexmapletest19919@gmail.com", "Tania", "Tania Russel", true, "Russel", "1-441-689-4558 x58473", "Studento1lvvnFl" },
                    { 21, "42640 Gerda Court, South Hilma, Virgin Islands, British", "Port Eladioland", new DateTime(2023, 9, 5, 4, 7, 58, 146, DateTimeKind.Local).AddTicks(8310), "onhdexmapletest19921@gmail.com", "Andre", "Andre Kilback", false, "Kilback", "(816) 574-7735 x8488", "Student6ZCDiouu" },
                    { 23, "609 Kilback Highway, East Lisette, Lebanon", "Breitenbergmouth", new DateTime(2023, 1, 12, 22, 28, 54, 352, DateTimeKind.Local).AddTicks(4953), "onhdexmapletest19923@gmail.com", "Lorenz", "Lorenz Beier", true, "Beier", "(889) 919-0705 x07733", "StudentmmsCjiEH" },
                    { 25, "8524 Ferry Drive, East Dereckborough, Saudi Arabia", "East Rahsaan", new DateTime(2023, 4, 6, 12, 10, 23, 915, DateTimeKind.Local).AddTicks(9777), "onhdexmapletest19925@gmail.com", "Susana", "Susana Walsh", true, "Walsh", "(642) 871-0748 x7569", "Student1ABe8cmL" },
                    { 27, "55444 Elwin Motorway, Gleichnerside, Jersey", "South Anselhaven", new DateTime(2023, 9, 7, 6, 11, 10, 179, DateTimeKind.Local).AddTicks(9181), "onhdexmapletest19927@gmail.com", "Nolan", "Nolan Kunde", false, "Kunde", "(327) 406-6894 x993", "StudentW0Ur38lI" },
                    { 29, "939 Douglas Junction, South Euna, Lao People's Democratic Republic", "West Fatimaburgh", new DateTime(2023, 2, 17, 6, 33, 15, 8, DateTimeKind.Local).AddTicks(5189), "onhdexmapletest19929@gmail.com", "Pinkie", "Pinkie Zemlak", false, "Zemlak", "796-761-7649", "StudentDOcKNE20" },
                    { 31, "404 Kessler Spring, Paucekburgh, Albania", "Biankaview", new DateTime(2023, 7, 14, 5, 48, 33, 291, DateTimeKind.Local).AddTicks(6491), "onhdexmapletest19931@gmail.com", "Alice", "Alice Ritchie", true, "Ritchie", "987.530.4589 x474", "StudentdrHLyvbv" },
                    { 33, "232 Terry Mission, Ludieland, Marshall Islands", "West Freddiemouth", new DateTime(2023, 2, 8, 1, 40, 8, 122, DateTimeKind.Local).AddTicks(1285), "onhdexmapletest19933@gmail.com", "Carolina", "Carolina Botsford", false, "Botsford", "1-591-726-1609 x73087", "StudentxKosgpUU" },
                    { 35, "79046 McDermott Stravenue, West Dorris, Equatorial Guinea", "Casimirbury", new DateTime(2023, 2, 13, 1, 24, 20, 627, DateTimeKind.Local).AddTicks(3090), "onhdexmapletest19935@gmail.com", "Josephine", "Josephine Wisozk", true, "Wisozk", "(245) 277-9918", "Studentc1RSOzHB" },
                    { 37, "3012 Imelda Forest, New Andersonstad, Djibouti", "East Noemiport", new DateTime(2023, 7, 23, 20, 24, 42, 544, DateTimeKind.Local).AddTicks(4660), "onhdexmapletest19937@gmail.com", "Casimer", "Casimer Donnelly", false, "Donnelly", "1-685-542-7252 x51972", "StudentXrwhv33O" },
                    { 39, "64222 Lowe Mountains, Maximillianside, Azerbaijan", "Sengermouth", new DateTime(2023, 9, 2, 21, 0, 32, 220, DateTimeKind.Local).AddTicks(9039), "onhdexmapletest19939@gmail.com", "Viva", "Viva Harvey", true, "Harvey", "224.231.0088 x4793", "Studentglx9yORw" },
                    { 41, "4785 Frederic Plaza, Marksbury, Tokelau", "Hilllhaven", new DateTime(2023, 8, 26, 22, 22, 32, 944, DateTimeKind.Local).AddTicks(3608), "onhdexmapletest19941@gmail.com", "Juwan", "Juwan Rogahn", false, "Rogahn", "874.426.5755 x26628", "Student4lW3kZ31" },
                    { 43, "39067 Parker Station, Clovismouth, Cook Islands", "Napoleonland", new DateTime(2022, 12, 12, 16, 39, 1, 465, DateTimeKind.Local).AddTicks(5423), "onhdexmapletest19943@gmail.com", "Dora", "Dora Lindgren", false, "Lindgren", "1-997-671-3739", "StudentukgTDV5U" },
                    { 45, "3593 Dawson Views, Port Myrl, South Africa", "North Randallmouth", new DateTime(2023, 4, 4, 15, 57, 53, 142, DateTimeKind.Local).AddTicks(4361), "onhdexmapletest19945@gmail.com", "Westley", "Westley Schroeder", false, "Schroeder", "(819) 415-9001", "StudentIlO5Cawo" },
                    { 47, "1169 Wiegand Forges, East Shane, United States Minor Outlying Islands", "Syblemouth", new DateTime(2022, 11, 3, 17, 49, 47, 127, DateTimeKind.Local).AddTicks(4217), "onhdexmapletest19947@gmail.com", "Mariane", "Mariane Blanda", true, "Blanda", "465.720.2454", "StudenthUoecrfJ" },
                    { 49, "6598 Schmeler Points, West Tedton, Tanzania", "New Raulstad", new DateTime(2023, 5, 10, 19, 23, 15, 9, DateTimeKind.Local).AddTicks(7442), "onhdexmapletest19949@gmail.com", "Ibrahim", "Ibrahim Kiehn", false, "Kiehn", "300.830.3979 x004", "StudentM4roq9ZV" },
                    { 51, "49565 Jany Street, Herzogmouth, Brunei Darussalam", "Blancheville", new DateTime(2022, 10, 16, 4, 54, 20, 658, DateTimeKind.Local).AddTicks(9517), "onhdexmapletest19951@gmail.com", "Pedro", "Pedro Abernathy", true, "Abernathy", "1-919-837-3432 x07965", "StudentVvdDcPvl" },
                    { 53, "041 Favian Run, North Darianport, Iceland", "Lake Queenfurt", new DateTime(2023, 5, 27, 12, 54, 6, 917, DateTimeKind.Local).AddTicks(6728), "onhdexmapletest19953@gmail.com", "Guido", "Guido Satterfield", true, "Satterfield", "871-815-7447", "Student9zvAGI5l" },
                    { 55, "4351 Pacocha Plaza, Port Kaseyview, Brazil", "North Kyla", new DateTime(2023, 8, 7, 18, 18, 23, 477, DateTimeKind.Local).AddTicks(2175), "onhdexmapletest19955@gmail.com", "May", "May Heaney", true, "Heaney", "401.605.7375", "StudentqJiCJdXf" },
                    { 57, "25341 Dejah Loaf, South Reyborough, Ireland", "East Geoland", new DateTime(2023, 2, 11, 4, 38, 17, 924, DateTimeKind.Local).AddTicks(5406), "onhdexmapletest19957@gmail.com", "Saul", "Saul Friesen", true, "Friesen", "988-413-6060", "Studentx13fYNLK" },
                    { 59, "45153 Cassin Pines, Port Wilfordborough, Spain", "Cummerataside", new DateTime(2023, 1, 29, 23, 30, 44, 929, DateTimeKind.Local).AddTicks(6081), "onhdexmapletest19959@gmail.com", "Faye", "Faye Goldner", false, "Goldner", "(241) 215-0266", "StudentB5iQEvTO" },
                    { 61, "04413 Dewitt Summit, Keltonfort, Denmark", "Soledadbury", new DateTime(2022, 11, 4, 3, 49, 46, 435, DateTimeKind.Local).AddTicks(6679), "onhdexmapletest19961@gmail.com", "Theo", "Theo Adams", true, "Adams", "627.438.3996 x021", "StudentBJbp08Ne" },
                    { 63, "60519 Morissette Bypass, North Maude, Guadeloupe", "Clayport", new DateTime(2023, 6, 15, 13, 18, 18, 79, DateTimeKind.Local).AddTicks(8245), "onhdexmapletest19963@gmail.com", "Filomena", "Filomena Koch", false, "Koch", "337.763.1445 x872", "StudentlJ7fQ3Nu" },
                    { 65, "289 Osinski Islands, North Hildegard, Canada", "Brodyberg", new DateTime(2023, 7, 11, 21, 46, 42, 91, DateTimeKind.Local).AddTicks(133), "onhdexmapletest19965@gmail.com", "Germaine", "Germaine Mills", false, "Mills", "435.742.4403", "StudentwztVhwlF" },
                    { 67, "7130 Rowan Springs, Orieland, Sao Tome and Principe", "West Waylon", new DateTime(2023, 2, 11, 6, 1, 30, 16, DateTimeKind.Local).AddTicks(7534), "onhdexmapletest19967@gmail.com", "Jonathan", "Jonathan Maggio", true, "Maggio", "1-319-341-9572 x147", "StudentrLiOGHAU" },
                    { 69, "78238 Katelynn Plain, East Alanland, Cook Islands", "West Derrickmouth", new DateTime(2022, 10, 27, 3, 54, 48, 261, DateTimeKind.Local).AddTicks(3258), "onhdexmapletest19969@gmail.com", "Issac", "Issac Dach", false, "Dach", "(587) 553-2930 x7129", "StudentYXP5WCjD" },
                    { 71, "098 Runolfsdottir Hills, Grimesburgh, Iran", "Lake Eliezer", new DateTime(2022, 10, 11, 17, 57, 14, 7, DateTimeKind.Local).AddTicks(260), "onhdexmapletest19971@gmail.com", "Kirsten", "Kirsten Jast", false, "Jast", "908.545.0593 x690", "Student24CwzyAR" },
                    { 73, "9951 Wilhelm Ridges, Port Reuben, Moldova", "Croninstad", new DateTime(2023, 8, 2, 11, 22, 11, 410, DateTimeKind.Local).AddTicks(2844), "onhdexmapletest19973@gmail.com", "Camille", "Camille Hilll", false, "Hilll", "1-427-692-3556 x32810", "StudentpPyg68bI" },
                    { 75, "3446 Jaquan Valley, Franzton, Central African Republic", "Bergnaumview", new DateTime(2023, 8, 18, 7, 10, 56, 669, DateTimeKind.Local).AddTicks(5575), "onhdexmapletest19975@gmail.com", "Freddie", "Freddie Renner", false, "Renner", "582.939.0470", "StudentE7RigY6B" },
                    { 77, "712 Braun Ways, MacGyverside, French Polynesia", "Langborough", new DateTime(2023, 1, 26, 13, 16, 18, 674, DateTimeKind.Local).AddTicks(3264), "onhdexmapletest19977@gmail.com", "Kenyatta", "Kenyatta Heidenreich", false, "Heidenreich", "(246) 983-9674 x28282", "StudentQllw5k99" },
                    { 79, "1346 Kub Club, Port Jaunita, Bulgaria", "Mauricioside", new DateTime(2023, 8, 20, 15, 27, 36, 988, DateTimeKind.Local).AddTicks(2960), "onhdexmapletest19979@gmail.com", "Keyshawn", "Keyshawn Collier", true, "Collier", "(590) 848-7715 x027", "Studentwl6Ei2iO" },
                    { 81, "8368 Swift Mount, Moisesbury, Denmark", "West Raleigh", new DateTime(2023, 6, 11, 12, 25, 2, 258, DateTimeKind.Local).AddTicks(727), "onhdexmapletest19981@gmail.com", "Kira", "Kira Paucek", true, "Paucek", "554.253.5411", "StudentiOU4hHP3" },
                    { 83, "0644 Ruth Square, O'Harahaven, Armenia", "Myrnahaven", new DateTime(2022, 11, 2, 15, 11, 21, 337, DateTimeKind.Local).AddTicks(1662), "onhdexmapletest19983@gmail.com", "Adriel", "Adriel Kutch", true, "Kutch", "395.449.2198 x305", "Student06u1IVJG" },
                    { 85, "3640 Houston Lock, Eldredton, Antarctica (the territory South of 60 deg S)", "Danielport", new DateTime(2023, 3, 14, 8, 52, 30, 488, DateTimeKind.Local).AddTicks(6828), "onhdexmapletest19985@gmail.com", "Monique", "Monique Lesch", true, "Lesch", "277.743.6909", "Studentwo0bWEc3" },
                    { 87, "921 Destany Port, Port Jabariberg, Norway", "Vadaside", new DateTime(2023, 4, 25, 4, 59, 52, 800, DateTimeKind.Local).AddTicks(7815), "onhdexmapletest19987@gmail.com", "Berenice", "Berenice Jacobi", true, "Jacobi", "986.979.3690 x42444", "Studentvo7kh7j3" },
                    { 89, "8039 Mable Square, South Elenamouth, Romania", "East Judson", new DateTime(2023, 9, 10, 22, 35, 21, 213, DateTimeKind.Local).AddTicks(497), "onhdexmapletest19989@gmail.com", "Sofia", "Sofia Feil", true, "Feil", "(639) 857-4054 x6296", "Student7fg3l60u" },
                    { 91, "90731 Schulist Corner, East Deshawnburgh, Hong Kong", "Lake Reva", new DateTime(2022, 12, 3, 21, 13, 5, 19, DateTimeKind.Local).AddTicks(5639), "onhdexmapletest19991@gmail.com", "Miles", "Miles Wyman", true, "Wyman", "1-870-365-7934", "StudentIOpzIneK" },
                    { 93, "042 Pagac Flats, O'Keefeton, Argentina", "Zellaland", new DateTime(2023, 6, 29, 17, 29, 0, 693, DateTimeKind.Local).AddTicks(5892), "onhdexmapletest19993@gmail.com", "Eleonore", "Eleonore Bechtelar", false, "Bechtelar", "1-680-589-7577 x113", "StudentZhvdBaNH" },
                    { 95, "26458 Tressie Heights, Uptonton, Saint Vincent and the Grenadines", "North Ezrachester", new DateTime(2023, 9, 7, 13, 15, 1, 587, DateTimeKind.Local).AddTicks(1048), "onhdexmapletest19995@gmail.com", "Darian", "Darian McDermott", false, "McDermott", "806-214-1808 x857", "Studentn7I60EUs" },
                    { 97, "594 Chaya Pike, Dibbertmouth, Saint Helena", "Lake Catharine", new DateTime(2023, 9, 13, 6, 20, 0, 521, DateTimeKind.Local).AddTicks(9013), "onhdexmapletest19997@gmail.com", "Keely", "Keely Haag", false, "Haag", "915.819.1523", "Student7u5GR70i" },
                    { 99, "928 Purdy Street, Keelingville, Namibia", "Katelinberg", new DateTime(2022, 12, 23, 8, 42, 1, 721, DateTimeKind.Local).AddTicks(8737), "onhdexmapletest19999@gmail.com", "Kirsten", "Kirsten Pollich", true, "Pollich", "214.348.1525 x6884", "Studentk5FpGdYQ" }
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
