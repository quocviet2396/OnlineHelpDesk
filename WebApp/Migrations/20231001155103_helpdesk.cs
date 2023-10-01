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
                    { 1, "c1efd0kG", "superadmin@gmail.com", "$2a$11$sg4afg.fuHJmIfozqL5jlOocLZrg0lh4WHEnDZQkg0JitlAnQ0Uyi", "Admin", true, "SuperAdmin" },
                    { 2, "1cGz3CAJ", "supporter@gmail.com", "$2a$11$rPGQQh4eyVNfJ5AdYBJm4exOX5V4famxWxtAJEMjWkzkajL//NOEe", "Supporter", true, "Supporter" },
                    { 3, "XOB62qpu", "user@gmail.com", "$2a$11$xqc/YmDdQim7vXiSRbdACeexopnXWxHGPfe20UigfsXWg5fUjZaI2", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "392 Lauretta Neck, North Wendychester, Liberia", "Kennediton", new DateTime(2023, 3, 11, 13, 48, 38, 719, DateTimeKind.Local).AddTicks(9318), "onhdexmapletest1991@gmail.com", "Ansley", "Ansley Bosco", true, "Bosco", "659-414-2810", "Students8Q4BwGc" },
                    { 3, "13993 Padberg Springs, South Tremainestad, Vanuatu", "Port Jadon", new DateTime(2023, 1, 16, 23, 45, 43, 549, DateTimeKind.Local).AddTicks(115), "onhdexmapletest1993@gmail.com", "Velma", "Velma Rodriguez", false, "Rodriguez", "892.364.8643 x6946", "Students9bgHGvz" },
                    { 5, "39265 Lorena Flat, North Opal, Equatorial Guinea", "Johnathonmouth", new DateTime(2023, 8, 28, 4, 55, 46, 759, DateTimeKind.Local).AddTicks(7250), "onhdexmapletest1995@gmail.com", "Vernie", "Vernie Powlowski", false, "Powlowski", "(987) 656-9217", "StudentUDyDymzg" },
                    { 7, "24292 Considine Extensions, Lake Bennettchester, Mongolia", "West Wayne", new DateTime(2023, 5, 27, 1, 2, 38, 255, DateTimeKind.Local).AddTicks(5578), "onhdexmapletest1997@gmail.com", "Scotty", "Scotty Ferry", true, "Ferry", "(212) 851-4442", "StudentNFzWTkAw" },
                    { 9, "8152 Kattie Springs, South Syble, Equatorial Guinea", "East Yvetteland", new DateTime(2023, 7, 31, 3, 48, 21, 123, DateTimeKind.Local).AddTicks(7682), "onhdexmapletest1999@gmail.com", "Scarlett", "Scarlett Stroman", true, "Stroman", "435-900-0039 x086", "StudentCp2ZHx0X" },
                    { 11, "9990 Herbert Valleys, Lake Weldonfurt, Togo", "Ebonyshire", new DateTime(2023, 7, 25, 20, 12, 23, 754, DateTimeKind.Local).AddTicks(7198), "onhdexmapletest19911@gmail.com", "Sonya", "Sonya Dietrich", false, "Dietrich", "586-961-6841 x6465", "Student3WlNkvmj" },
                    { 13, "3927 Glover Canyon, Chadricktown, Afghanistan", "West Leonie", new DateTime(2023, 6, 28, 4, 2, 42, 175, DateTimeKind.Local).AddTicks(6346), "onhdexmapletest19913@gmail.com", "Gerson", "Gerson Runolfsson", true, "Runolfsson", "1-700-230-9214", "StudentwnP2JWC6" },
                    { 15, "2551 Joaquin Walks, New Brandt, Armenia", "Maybury", new DateTime(2022, 11, 25, 15, 48, 19, 285, DateTimeKind.Local).AddTicks(8048), "onhdexmapletest19915@gmail.com", "Adella", "Adella O'Connell", false, "O'Connell", "(208) 380-6223", "StudentEnxjk04r" },
                    { 17, "09499 Jena Parks, East Jacintoburgh, Kyrgyz Republic", "Romagueraland", new DateTime(2023, 4, 7, 0, 39, 28, 343, DateTimeKind.Local).AddTicks(785), "onhdexmapletest19917@gmail.com", "Alessia", "Alessia Klocko", false, "Klocko", "850-969-1417", "StudentIvIkSBE1" },
                    { 19, "3277 Luisa Mission, Heloiseborough, Saint Vincent and the Grenadines", "New Axelmouth", new DateTime(2023, 3, 16, 14, 4, 38, 84, DateTimeKind.Local).AddTicks(7056), "onhdexmapletest19919@gmail.com", "Ivory", "Ivory Zboncak", true, "Zboncak", "(426) 486-9677 x742", "StudentxQ5qzB8Z" },
                    { 21, "3296 Antonetta Way, Ashlynnborough, Monaco", "Javontefurt", new DateTime(2023, 3, 16, 1, 31, 3, 502, DateTimeKind.Local).AddTicks(9246), "onhdexmapletest19921@gmail.com", "Noe", "Noe Harvey", true, "Harvey", "(709) 999-2001", "Student0qxwutkE" },
                    { 23, "5543 Kihn Plaza, East Lester, Holy See (Vatican City State)", "Shanelleport", new DateTime(2023, 2, 9, 11, 20, 42, 210, DateTimeKind.Local).AddTicks(7862), "onhdexmapletest19923@gmail.com", "Sarai", "Sarai Doyle", false, "Doyle", "1-618-907-6763", "StudentRvD1BIkN" },
                    { 25, "9127 Schmeler Walk, Smithside, Russian Federation", "East Daxside", new DateTime(2023, 7, 27, 13, 17, 29, 760, DateTimeKind.Local).AddTicks(1081), "onhdexmapletest19925@gmail.com", "Cali", "Cali Wunsch", false, "Wunsch", "1-888-840-6523", "Student70LJs0Zm" },
                    { 27, "77674 Powlowski Rapid, Port Dimitrichester, Cyprus", "Dejaport", new DateTime(2023, 2, 24, 19, 49, 28, 164, DateTimeKind.Local).AddTicks(9277), "onhdexmapletest19927@gmail.com", "Mona", "Mona Krajcik", true, "Krajcik", "598.205.2483", "StudenthLeDyp22" },
                    { 29, "193 Horace Mews, O'Connellside, Hong Kong", "Hoegermouth", new DateTime(2022, 12, 31, 17, 9, 30, 422, DateTimeKind.Local).AddTicks(5009), "onhdexmapletest19929@gmail.com", "Hattie", "Hattie Bogisich", true, "Bogisich", "(563) 584-7768 x98887", "StudentwDFD4kVx" },
                    { 31, "1526 Swift Court, New Otha, Gabon", "Clayborough", new DateTime(2023, 8, 7, 12, 49, 30, 127, DateTimeKind.Local).AddTicks(7620), "onhdexmapletest19931@gmail.com", "Marcelle", "Marcelle Boehm", false, "Boehm", "561.572.8830 x326", "Studentk872yPhC" },
                    { 33, "66880 Beier Prairie, Adolphusland, Suriname", "New Sigrid", new DateTime(2023, 7, 25, 18, 45, 29, 478, DateTimeKind.Local).AddTicks(5403), "onhdexmapletest19933@gmail.com", "Evan", "Evan Treutel", false, "Treutel", "(530) 546-7051 x0550", "StudentMjxLwNku" },
                    { 35, "0271 Solon Stravenue, Arielleville, Turks and Caicos Islands", "North Stephaniastad", new DateTime(2023, 3, 18, 8, 55, 25, 42, DateTimeKind.Local).AddTicks(9706), "onhdexmapletest19935@gmail.com", "Laila", "Laila Schaefer", true, "Schaefer", "(631) 690-4133 x79215", "StudentkbWBtSMx" },
                    { 37, "52189 Antonina Springs, Solonton, French Guiana", "Langworthville", new DateTime(2022, 10, 17, 13, 33, 29, 863, DateTimeKind.Local).AddTicks(1222), "onhdexmapletest19937@gmail.com", "Lukas", "Lukas Wisoky", true, "Wisoky", "1-451-316-4143", "Studentxf1bHwwb" },
                    { 39, "6270 Kshlerin View, Goldnerview, South Georgia and the South Sandwich Islands", "Norvalfort", new DateTime(2022, 10, 26, 9, 15, 58, 104, DateTimeKind.Local).AddTicks(6577), "onhdexmapletest19939@gmail.com", "Brain", "Brain Fahey", false, "Fahey", "759-932-7248 x057", "StudentzbydPRRQ" },
                    { 41, "1502 Dejah Forest, Port Mauricio, Seychelles", "Port Moisesbury", new DateTime(2023, 1, 22, 2, 54, 58, 61, DateTimeKind.Local).AddTicks(3223), "onhdexmapletest19941@gmail.com", "Kamryn", "Kamryn Littel", true, "Littel", "302.724.1818 x639", "Studentul58Ykld" },
                    { 43, "434 Concepcion Throughway, Bodefort, Swaziland", "Strosinmouth", new DateTime(2023, 6, 22, 8, 19, 8, 14, DateTimeKind.Local).AddTicks(7249), "onhdexmapletest19943@gmail.com", "Trudie", "Trudie Cronin", false, "Cronin", "(683) 789-3379 x8624", "Student4NgXS2FL" },
                    { 45, "1622 Destany Manor, Mozellestad, Dominican Republic", "Minervaview", new DateTime(2022, 11, 29, 22, 52, 29, 667, DateTimeKind.Local).AddTicks(176), "onhdexmapletest19945@gmail.com", "Demarco", "Demarco Reichel", false, "Reichel", "261-325-0000", "StudentQpk7d8dZ" },
                    { 47, "6949 Swift Trafficway, Kennethmouth, Rwanda", "West Calista", new DateTime(2023, 7, 12, 21, 45, 42, 296, DateTimeKind.Local).AddTicks(2082), "onhdexmapletest19947@gmail.com", "Grover", "Grover Zboncak", true, "Zboncak", "280.601.5807 x35801", "Student2rr3tg1w" },
                    { 49, "19942 Quitzon Forges, Port Hulda, Canada", "West Karelle", new DateTime(2023, 9, 15, 18, 47, 21, 595, DateTimeKind.Local).AddTicks(8056), "onhdexmapletest19949@gmail.com", "Jackie", "Jackie Wyman", false, "Wyman", "630-687-6028 x7454", "StudenttI8vDbwW" },
                    { 51, "850 Murray Trail, Lake Marion, Falkland Islands (Malvinas)", "New Lindsey", new DateTime(2023, 2, 27, 10, 14, 53, 430, DateTimeKind.Local).AddTicks(2267), "onhdexmapletest19951@gmail.com", "Clementine", "Clementine Zboncak", false, "Zboncak", "1-610-367-5824", "Studentr8H99mVS" },
                    { 53, "53079 Paxton Mission, Leestad, Georgia", "New Bria", new DateTime(2022, 11, 7, 0, 53, 6, 116, DateTimeKind.Local).AddTicks(2376), "onhdexmapletest19953@gmail.com", "Pearline", "Pearline Kshlerin", true, "Kshlerin", "752.547.6257 x89355", "StudentKOefqxBM" },
                    { 55, "55632 Carleton Grove, South Nannieberg, Madagascar", "South Rickyberg", new DateTime(2023, 5, 27, 11, 10, 33, 376, DateTimeKind.Local).AddTicks(8625), "onhdexmapletest19955@gmail.com", "Maximilian", "Maximilian Dare", false, "Dare", "(718) 867-8947 x2937", "StudentxUmVnx7G" },
                    { 57, "154 Pfannerstill Lodge, New Jenniferchester, Sweden", "Raynorport", new DateTime(2023, 9, 6, 9, 29, 44, 45, DateTimeKind.Local).AddTicks(7167), "onhdexmapletest19957@gmail.com", "Ivah", "Ivah Mante", false, "Mante", "517.845.6467 x239", "Studentue46lcQy" },
                    { 59, "510 Goldner Terrace, Juniusland, Republic of Korea", "Aufderharmouth", new DateTime(2023, 5, 8, 7, 55, 42, 150, DateTimeKind.Local).AddTicks(8702), "onhdexmapletest19959@gmail.com", "Sherman", "Sherman Emard", true, "Emard", "(668) 698-1239 x843", "StudentFMzRYXvn" },
                    { 61, "186 Schultz Hollow, Donatofort, Cuba", "Schummville", new DateTime(2023, 5, 15, 22, 51, 56, 717, DateTimeKind.Local).AddTicks(1167), "onhdexmapletest19961@gmail.com", "Rosario", "Rosario Kautzer", false, "Kautzer", "227.896.4981 x9024", "StudentrvVklggX" },
                    { 63, "893 Kenton Landing, Baileyfurt, Benin", "Hesselberg", new DateTime(2023, 8, 24, 14, 14, 13, 135, DateTimeKind.Local).AddTicks(2897), "onhdexmapletest19963@gmail.com", "Daphnee", "Daphnee Mayert", true, "Mayert", "880-915-5774", "StudentRS2mS3jm" },
                    { 65, "5774 Sigurd Corner, Phoebefurt, Iceland", "North Aaliyah", new DateTime(2023, 2, 16, 18, 23, 51, 511, DateTimeKind.Local).AddTicks(7767), "onhdexmapletest19965@gmail.com", "Jovanny", "Jovanny Balistreri", true, "Balistreri", "222-406-7491", "Student4i3nQows" },
                    { 67, "086 Alba Street, East Gabriel, Falkland Islands (Malvinas)", "Stracketon", new DateTime(2023, 5, 19, 23, 41, 2, 167, DateTimeKind.Local).AddTicks(3312), "onhdexmapletest19967@gmail.com", "Jamir", "Jamir Klein", true, "Klein", "1-603-239-3791", "StudentYUunCBHN" },
                    { 69, "361 Manuela Field, Port Lauren, Turkey", "Judymouth", new DateTime(2023, 3, 6, 3, 22, 26, 685, DateTimeKind.Local).AddTicks(9022), "onhdexmapletest19969@gmail.com", "Danial", "Danial Huels", false, "Huels", "677-613-0097", "StudentWqUqlcpG" },
                    { 71, "591 Osbaldo Plaza, Feilhaven, Sao Tome and Principe", "East Norma", new DateTime(2022, 10, 7, 9, 35, 42, 214, DateTimeKind.Local).AddTicks(3807), "onhdexmapletest19971@gmail.com", "Montana", "Montana Stroman", false, "Stroman", "(230) 696-6047 x04217", "Student8du4ot83" },
                    { 73, "0337 Raven Drive, South Darrick, Niger", "New Eric", new DateTime(2022, 12, 8, 0, 48, 36, 282, DateTimeKind.Local).AddTicks(2611), "onhdexmapletest19973@gmail.com", "Terrell", "Terrell Larson", true, "Larson", "1-636-378-5709 x177", "Student0ewOzezB" },
                    { 75, "2511 Yundt Lane, New Suzannetown, Tunisia", "Darianshire", new DateTime(2023, 3, 11, 22, 47, 47, 713, DateTimeKind.Local).AddTicks(1804), "onhdexmapletest19975@gmail.com", "Cathryn", "Cathryn Adams", true, "Adams", "530.860.0525 x446", "StudentmGhDKK9m" },
                    { 77, "525 Asia Camp, West Venaland, Ecuador", "Lockmanchester", new DateTime(2022, 10, 20, 18, 17, 40, 540, DateTimeKind.Local).AddTicks(3623), "onhdexmapletest19977@gmail.com", "Casper", "Casper Schaefer", true, "Schaefer", "(823) 414-9593 x222", "StudentsUWuk7g1" },
                    { 79, "672 Pat Crest, Connellyburgh, Hong Kong", "East Hankmouth", new DateTime(2022, 10, 5, 21, 30, 22, 336, DateTimeKind.Local).AddTicks(7091), "onhdexmapletest19979@gmail.com", "Ressie", "Ressie Schuster", false, "Schuster", "(232) 858-1454 x42865", "StudentU9QIGayx" },
                    { 81, "346 O'Connell Knolls, Bradville, Malawi", "Raymundoview", new DateTime(2023, 9, 25, 23, 42, 21, 862, DateTimeKind.Local).AddTicks(4593), "onhdexmapletest19981@gmail.com", "Madeline", "Madeline Koss", false, "Koss", "1-941-326-1461 x0579", "Student4TXaVckm" },
                    { 83, "859 Sibyl Ports, Emieview, Tonga", "Lake Bradlyview", new DateTime(2022, 11, 29, 1, 53, 29, 139, DateTimeKind.Local).AddTicks(6414), "onhdexmapletest19983@gmail.com", "Elody", "Elody Rohan", true, "Rohan", "538.638.4709 x8965", "Studenta68tyEMN" },
                    { 85, "87140 Lester Turnpike, South Arjunfurt, Madagascar", "Lake Mathias", new DateTime(2023, 6, 2, 13, 47, 37, 199, DateTimeKind.Local).AddTicks(4895), "onhdexmapletest19985@gmail.com", "Ashton", "Ashton Monahan", false, "Monahan", "404.227.7624 x3103", "Studentxk9cnB09" },
                    { 87, "4341 Gutkowski Rest, Port Bret, Andorra", "Jermainside", new DateTime(2023, 1, 18, 14, 3, 36, 724, DateTimeKind.Local).AddTicks(5705), "onhdexmapletest19987@gmail.com", "Lauretta", "Lauretta Schneider", true, "Schneider", "606-910-6019 x56957", "StudentKGBFpBc3" },
                    { 89, "353 Turcotte Cliff, Marshallburgh, Egypt", "Kyleeshire", new DateTime(2023, 8, 25, 7, 0, 12, 138, DateTimeKind.Local).AddTicks(9479), "onhdexmapletest19989@gmail.com", "Edward", "Edward Feeney", false, "Feeney", "670.859.6515", "StudenttECJkTR2" },
                    { 91, "24880 Rowena Hollow, North Electa, Cayman Islands", "New Wyattport", new DateTime(2023, 7, 21, 10, 37, 35, 71, DateTimeKind.Local).AddTicks(9945), "onhdexmapletest19991@gmail.com", "Elta", "Elta Altenwerth", true, "Altenwerth", "1-230-910-3658", "StudentN9tfoJKx" },
                    { 93, "8441 Gunner Locks, Hillsport, Saudi Arabia", "Carterside", new DateTime(2023, 8, 8, 11, 33, 24, 855, DateTimeKind.Local).AddTicks(9360), "onhdexmapletest19993@gmail.com", "Giovani", "Giovani Graham", true, "Graham", "1-910-592-1042 x491", "StudentjOcJgVRi" },
                    { 95, "716 Hester Junctions, South Catalinachester, Thailand", "Walterbury", new DateTime(2022, 10, 25, 1, 17, 44, 992, DateTimeKind.Local).AddTicks(1906), "onhdexmapletest19995@gmail.com", "Arnulfo", "Arnulfo Murazik", true, "Murazik", "612-460-2367 x1550", "StudentGYaFAHCS" },
                    { 97, "382 Bradtke Field, Medhurstville, Bahrain", "New Zander", new DateTime(2022, 11, 4, 0, 32, 38, 233, DateTimeKind.Local).AddTicks(9638), "onhdexmapletest19997@gmail.com", "Hermina", "Hermina Klein", true, "Klein", "382-471-4849", "StudentmoKDY39n" },
                    { 99, "9943 Runolfsdottir Gardens, Raymundoton, Bahrain", "West Twilaborough", new DateTime(2023, 5, 5, 16, 4, 3, 407, DateTimeKind.Local).AddTicks(2958), "onhdexmapletest19999@gmail.com", "Bettye", "Bettye Kirlin", false, "Kirlin", "(285) 901-4420 x9116", "StudentPNJjJLau" }
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
