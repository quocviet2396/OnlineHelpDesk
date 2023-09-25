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
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsersInfo", x => x.Id);
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
                    { 1, "ggRaHyI9", "superadmin@gmail.com", "$2a$11$9oNccigKVQ9fXGLJLVjGs.PyA09Y34P6f1k2CEoA65KD1jhiaRat.", "Admin", true, "SuperAdmin" },
                    { 2, "VR30NI2p", "supporter@gmail.com", "$2a$11$xLAojRFZouxKw6R9Zrfv3O2QmRh4Vvq0TS43TQielf7XaEPLUhozm", "Supporter", true, "Supporter" },
                    { 3, "SPlCRvAM", "user@gmail.com", "$2a$11$CFT/aNomljxd534NEIPh7Ort5QU5XMEq1ZgZSpqrkBYVKw2EXPPha", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "346 Ara Gateway, North Sammie, Cayman Islands", "East Nelsonborough", new DateTime(2023, 1, 11, 3, 1, 34, 941, DateTimeKind.Local).AddTicks(1435), "Connor32@gmail.com", "Connor", "Connor Crist", true, "Crist", "1-782-388-3603", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/149.jpg", "StudentsPlSEEBJ" },
                    { 2, "82113 Philip Dale, Lake Lawrence, Marshall Islands", "South Marquise", new DateTime(2022, 9, 27, 9, 39, 44, 606, DateTimeKind.Local).AddTicks(4720), "Jaron.Rogahn@yahoo.com", "Jaron", "Jaron Rogahn", false, "Rogahn", "1-614-553-2141 x161", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1046.jpg", "StudentuvzgVvsF" },
                    { 3, "370 Paucek Plaza, Lake Jarrellshire, Anguilla", "New Philip", new DateTime(2023, 3, 18, 11, 58, 41, 673, DateTimeKind.Local).AddTicks(5111), "Lillian88@yahoo.com", "Lillian", "Lillian Bashirian", false, "Bashirian", "(294) 654-2087", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1219.jpg", "StudenttG9hxr05" },
                    { 4, "686 Muller Mount, Schadenchester, Guinea-Bissau", "North Kaley", new DateTime(2023, 4, 3, 11, 10, 48, 203, DateTimeKind.Local).AddTicks(3843), "Moises_Corkery@yahoo.com", "Moises", "Moises Corkery", true, "Corkery", "888-830-4831 x460", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/615.jpg", "StudentGYK3mevu" },
                    { 5, "588 Einar Locks, Destinchester, Saint Pierre and Miquelon", "East Ambroseton", new DateTime(2023, 6, 26, 1, 38, 25, 708, DateTimeKind.Local).AddTicks(6518), "Riley41@gmail.com", "Riley", "Riley Schowalter", false, "Schowalter", "630-557-8654 x436", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/774.jpg", "Studentg0WojEnA" },
                    { 6, "766 Garland Manors, Port Maximillian, Ethiopia", "Port Kennedi", new DateTime(2023, 2, 14, 4, 54, 19, 530, DateTimeKind.Local).AddTicks(2089), "Braulio79@gmail.com", "Braulio", "Braulio Smith", true, "Smith", "(348) 744-0270", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/21.jpg", "StudentroDu0Dxw" },
                    { 7, "9300 Wisoky Park, Ilianaborough, Egypt", "Gerholdton", new DateTime(2022, 11, 8, 13, 22, 38, 824, DateTimeKind.Local).AddTicks(994), "Mckenna_McKenzie@hotmail.com", "Mckenna", "Mckenna McKenzie", false, "McKenzie", "1-275-774-9516 x75818", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/393.jpg", "Student2tI8KuGE" },
                    { 8, "999 John Views, Halvorsonport, Cook Islands", "Kubland", new DateTime(2023, 3, 10, 19, 19, 13, 40, DateTimeKind.Local).AddTicks(6397), "Anais.King@yahoo.com", "Anais", "Anais King", true, "King", "332-840-7453", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/216.jpg", "Student1WS7AJ8C" },
                    { 9, "6940 Lilliana Walk, Port Derrick, New Caledonia", "East Codyside", new DateTime(2023, 5, 28, 21, 14, 45, 514, DateTimeKind.Local).AddTicks(8465), "Keshaun_Hansen@gmail.com", "Keshaun", "Keshaun Hansen", false, "Hansen", "371-747-8788", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/966.jpg", "StudentB0al0ZaI" },
                    { 10, "019 Kerluke Parkway, Port Carli, Armenia", "Maudeshire", new DateTime(2023, 1, 18, 20, 58, 29, 154, DateTimeKind.Local).AddTicks(9936), "Lafayette_Hettinger@gmail.com", "Lafayette", "Lafayette Hettinger", false, "Hettinger", "870.675.1107 x4201", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1087.jpg", "StudentOVsgd5pj" },
                    { 11, "96585 Mekhi Turnpike, Huldamouth, Equatorial Guinea", "West Raquel", new DateTime(2023, 6, 28, 16, 52, 1, 716, DateTimeKind.Local).AddTicks(934), "Miles.Marquardt@hotmail.com", "Miles", "Miles Marquardt", true, "Marquardt", "(803) 542-6885 x4709", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/311.jpg", "Student29RjRW1d" },
                    { 12, "46086 Ryder Mills, Ernserton, American Samoa", "South Dalechester", new DateTime(2023, 5, 12, 0, 42, 57, 56, DateTimeKind.Local).AddTicks(9131), "Lucas.Hagenes52@hotmail.com", "Lucas", "Lucas Hagenes", true, "Hagenes", "1-827-609-4365 x641", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/823.jpg", "Studentm2yMkCis" },
                    { 13, "3046 Roberts Mill, Geovannyborough, Saint Vincent and the Grenadines", "South Ariane", new DateTime(2022, 10, 22, 18, 6, 40, 959, DateTimeKind.Local).AddTicks(2244), "Johathan_Bauch@gmail.com", "Johathan", "Johathan Bauch", false, "Bauch", "900-723-3900", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/412.jpg", "Student7G3vwXeg" },
                    { 14, "49094 Jermaine Haven, North Beauhaven, Benin", "Eviestad", new DateTime(2023, 3, 31, 1, 30, 13, 121, DateTimeKind.Local).AddTicks(9192), "Astrid37@hotmail.com", "Astrid", "Astrid Willms", true, "Willms", "1-903-509-9098 x676", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/197.jpg", "Studentmu3rb3Ak" },
                    { 15, "8843 Heathcote Station, Port Destanyshire, Bahrain", "Port Orionburgh", new DateTime(2023, 6, 23, 12, 38, 50, 654, DateTimeKind.Local).AddTicks(6639), "Isaias_Aufderhar30@yahoo.com", "Isaias", "Isaias Aufderhar", true, "Aufderhar", "283.960.6286 x1380", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/804.jpg", "StudentrpRdrvtb" },
                    { 16, "63210 Reichel Parks, Bayerfort, Samoa", "Adellaberg", new DateTime(2022, 12, 1, 19, 35, 32, 797, DateTimeKind.Local).AddTicks(9404), "Trey_Smith77@yahoo.com", "Trey", "Trey Smith", false, "Smith", "(241) 518-0419", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/119.jpg", "StudentrsW1M51j" },
                    { 17, "640 Abbott Greens, Christopherbury, San Marino", "East Brodericktown", new DateTime(2023, 7, 14, 8, 25, 43, 454, DateTimeKind.Local).AddTicks(1321), "Elaina.Durgan55@yahoo.com", "Elaina", "Elaina Durgan", false, "Durgan", "324-599-0918 x763", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/412.jpg", "Student2hHtDSMp" },
                    { 18, "58641 McLaughlin Lights, Abbeyside, Swaziland", "Nicklausmouth", new DateTime(2023, 3, 31, 21, 28, 20, 436, DateTimeKind.Local).AddTicks(1744), "Franco77@hotmail.com", "Franco", "Franco Howe", false, "Howe", "(865) 660-5563 x3717", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1016.jpg", "StudentYI43iRaK" },
                    { 19, "675 Heller Junctions, South Einar, Dominica", "New Sandra", new DateTime(2022, 11, 28, 14, 17, 7, 356, DateTimeKind.Local).AddTicks(1580), "Dayton_Bahringer@gmail.com", "Dayton", "Dayton Bahringer", false, "Bahringer", "(385) 453-7839 x4614", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/454.jpg", "StudentUAzb689y" },
                    { 20, "6833 Norene Harbors, Terranceview, Papua New Guinea", "Gradymouth", new DateTime(2022, 10, 8, 7, 58, 56, 107, DateTimeKind.Local).AddTicks(4917), "Reva_Gutmann81@hotmail.com", "Reva", "Reva Gutmann", false, "Gutmann", "876.872.8659 x3079", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1131.jpg", "Student22MtGss0" },
                    { 21, "80802 Rupert Unions, Abbottland, Malawi", "New Yasmeenfurt", new DateTime(2022, 12, 4, 1, 29, 54, 843, DateTimeKind.Local).AddTicks(509), "Hillard_Dicki43@yahoo.com", "Hillard", "Hillard Dicki", true, "Dicki", "726-988-2481 x251", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1096.jpg", "Studentn74wvZt8" },
                    { 22, "6074 Maggio Ways, Lake Josh, Spain", "West Kenstad", new DateTime(2023, 9, 22, 2, 8, 51, 410, DateTimeKind.Local).AddTicks(2743), "Ransom91@hotmail.com", "Ransom", "Ransom Wehner", false, "Wehner", "1-601-983-6542 x26166", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/997.jpg", "StudentFt2DdYlV" },
                    { 23, "2504 Marcus Motorway, Lake Coty, Nigeria", "Port Antonio", new DateTime(2022, 11, 25, 4, 39, 33, 763, DateTimeKind.Local).AddTicks(2839), "Leora_Kshlerin46@gmail.com", "Leora", "Leora Kshlerin", false, "Kshlerin", "1-806-490-3278", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/868.jpg", "Student20AECezX" },
                    { 24, "148 Deckow Course, New Margarita, South Africa", "Conradland", new DateTime(2022, 11, 11, 18, 50, 17, 108, DateTimeKind.Local).AddTicks(5480), "Arjun14@yahoo.com", "Arjun", "Arjun Schoen", false, "Schoen", "830-950-9283 x502", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1112.jpg", "StudentSwjfgC0I" },
                    { 25, "778 Hirthe Flat, Philipfort, Montenegro", "Melynaside", new DateTime(2023, 8, 8, 9, 0, 29, 342, DateTimeKind.Local).AddTicks(5594), "Sherwood37@hotmail.com", "Sherwood", "Sherwood Toy", true, "Toy", "344.968.4498", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/509.jpg", "StudentNjtJT7lq" },
                    { 26, "076 Skiles Alley, Reyesburgh, Bolivia", "Gilbertfurt", new DateTime(2023, 5, 7, 5, 32, 59, 117, DateTimeKind.Local).AddTicks(2043), "Fern_Dickinson69@hotmail.com", "Fern", "Fern Dickinson", false, "Dickinson", "1-955-744-2280", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1070.jpg", "StudentX3NtpHfk" },
                    { 27, "9223 Glover Locks, North Emilio, Guam", "North Brisa", new DateTime(2023, 4, 15, 18, 3, 47, 523, DateTimeKind.Local).AddTicks(7385), "Vicente2@hotmail.com", "Vicente", "Vicente Bins", false, "Bins", "(224) 213-2090 x8218", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/780.jpg", "StudentntBWfBmz" },
                    { 28, "6360 George Via, North Laurianne, Peru", "Sanfordchester", new DateTime(2023, 4, 22, 19, 51, 4, 367, DateTimeKind.Local).AddTicks(5503), "Clair_Bernhard49@yahoo.com", "Clair", "Clair Bernhard", true, "Bernhard", "532.346.3421 x48533", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/754.jpg", "StudentH0HcDN50" },
                    { 29, "688 Joaquin Viaduct, Joshuaport, Niger", "West Abnershire", new DateTime(2023, 1, 5, 0, 38, 4, 618, DateTimeKind.Local).AddTicks(9456), "Giovanna72@gmail.com", "Giovanna", "Giovanna Kuhn", true, "Kuhn", "454.276.0283 x0388", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/58.jpg", "StudentCMwXlJuh" },
                    { 30, "18401 Clint Shores, Kirlinmouth, French Southern Territories", "Port Carlotta", new DateTime(2023, 8, 21, 21, 8, 53, 93, DateTimeKind.Local).AddTicks(2358), "Gregg.Yost@yahoo.com", "Gregg", "Gregg Yost", true, "Yost", "514-350-6912 x774", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/130.jpg", "StudentDn02q6kT" },
                    { 31, "959 Doug Groves, Cruickshankfort, Brazil", "Eliezerborough", new DateTime(2023, 5, 14, 16, 52, 42, 550, DateTimeKind.Local).AddTicks(4617), "Shad_Kertzmann34@gmail.com", "Shad", "Shad Kertzmann", false, "Kertzmann", "1-790-529-3591", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1098.jpg", "StudentP07NW1Ue" },
                    { 32, "34632 Stehr Light, Nolanport, Mexico", "Port Jeraldtown", new DateTime(2023, 7, 26, 19, 18, 7, 742, DateTimeKind.Local).AddTicks(3429), "Maude26@gmail.com", "Maude", "Maude Kerluke", false, "Kerluke", "349-566-6498 x3065", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/967.jpg", "StudentqE7HPqCe" },
                    { 33, "511 Botsford Stream, Lake Esthertown, Timor-Leste", "Gorczanyview", new DateTime(2023, 3, 30, 1, 12, 3, 844, DateTimeKind.Local).AddTicks(5688), "Loma_Cassin@gmail.com", "Loma", "Loma Cassin", true, "Cassin", "275.686.7807 x45182", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/660.jpg", "StudentGsaSlyYg" },
                    { 34, "33757 Rice Stream, South Sisterchester, Iceland", "Lemkeland", new DateTime(2022, 12, 4, 11, 11, 14, 448, DateTimeKind.Local).AddTicks(3873), "Jarret.Goodwin@gmail.com", "Jarret", "Jarret Goodwin", false, "Goodwin", "243-319-6913", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/896.jpg", "Student9x97dLxy" },
                    { 35, "1506 Brakus Corner, New Rodhaven, Virgin Islands, British", "Demetrishaven", new DateTime(2022, 12, 2, 12, 11, 32, 178, DateTimeKind.Local).AddTicks(5566), "Akeem_Koelpin@hotmail.com", "Akeem", "Akeem Koelpin", true, "Koelpin", "658-901-8900", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/76.jpg", "Studentmj1EFsUY" },
                    { 36, "86899 Hintz Land, Torphyville, Turks and Caicos Islands", "Lake Milanshire", new DateTime(2023, 9, 23, 12, 26, 13, 509, DateTimeKind.Local).AddTicks(2935), "Enid48@yahoo.com", "Enid", "Enid Wilkinson", false, "Wilkinson", "655.710.1328", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/316.jpg", "Studentf9szyt5h" },
                    { 37, "475 Zieme Shoals, West Kenberg, United Kingdom", "West Luciennetown", new DateTime(2022, 11, 24, 15, 39, 11, 456, DateTimeKind.Local).AddTicks(9805), "Herbert.Zemlak55@yahoo.com", "Herbert", "Herbert Zemlak", true, "Zemlak", "1-996-738-5742 x514", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/362.jpg", "StudenthUZqIl5J" },
                    { 38, "23832 Yundt Union, Kiehnfort, Lao People's Democratic Republic", "East Zakary", new DateTime(2023, 8, 24, 23, 7, 40, 87, DateTimeKind.Local).AddTicks(3766), "Antonetta.McKenzie91@hotmail.com", "Antonetta", "Antonetta McKenzie", true, "McKenzie", "830.395.5183", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1223.jpg", "StudentgZwrzGNC" },
                    { 39, "0830 Hansen Mill, New Johann, Australia", "Mateoville", new DateTime(2023, 6, 24, 14, 2, 51, 743, DateTimeKind.Local).AddTicks(1567), "Edwin55@hotmail.com", "Edwin", "Edwin Buckridge", false, "Buckridge", "847.665.2234 x466", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/418.jpg", "Student4vXRkEJI" },
                    { 40, "35475 Kihn Circle, New Revaberg, Sri Lanka", "Lake Margarettefurt", new DateTime(2023, 4, 17, 15, 48, 1, 296, DateTimeKind.Local).AddTicks(4643), "Billie18@gmail.com", "Billie", "Billie Harber", false, "Harber", "1-261-959-6205", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/866.jpg", "StudentCudVz9RK" },
                    { 41, "0667 Stroman Park, New Glenna, Saint Helena", "Mustafatown", new DateTime(2023, 3, 29, 10, 11, 8, 710, DateTimeKind.Local).AddTicks(4305), "Annetta.Brown11@yahoo.com", "Annetta", "Annetta Brown", false, "Brown", "1-870-801-1192 x7542", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/532.jpg", "Studentxukw3Tlq" },
                    { 42, "3689 Maya Forge, Osinskiton, Cocos (Keeling) Islands", "Nikkiberg", new DateTime(2023, 3, 31, 2, 55, 27, 866, DateTimeKind.Local).AddTicks(9665), "Amalia_Stoltenberg75@yahoo.com", "Amalia", "Amalia Stoltenberg", false, "Stoltenberg", "(746) 251-7504 x3261", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1218.jpg", "StudentF0PwZbdn" },
                    { 43, "58365 Littel Trace, Guadalupeville, Swaziland", "Schmidtborough", new DateTime(2023, 3, 24, 0, 51, 6, 824, DateTimeKind.Local).AddTicks(1946), "Annamae.Predovic61@yahoo.com", "Annamae", "Annamae Predovic", true, "Predovic", "(817) 347-4564 x69711", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/495.jpg", "StudentcFpdrShM" },
                    { 44, "7063 Myrtle Mission, Lake Ivoryberg, France", "Westborough", new DateTime(2023, 5, 24, 14, 55, 26, 195, DateTimeKind.Local).AddTicks(7872), "Eula.Terry21@yahoo.com", "Eula", "Eula Terry", false, "Terry", "1-932-973-3784 x590", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/710.jpg", "StudentrXh5bqNJ" },
                    { 45, "887 Bartoletti Highway, Uptonstad, Brazil", "Rocioland", new DateTime(2023, 3, 20, 22, 46, 15, 965, DateTimeKind.Local).AddTicks(1671), "Greg_Larson@hotmail.com", "Greg", "Greg Larson", false, "Larson", "1-200-311-3854 x296", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/787.jpg", "StudentLa9INXu9" },
                    { 46, "584 Amie Ways, Bergebury, Burundi", "Sylviashire", new DateTime(2023, 1, 25, 5, 37, 38, 251, DateTimeKind.Local).AddTicks(7738), "Ephraim.Balistreri36@hotmail.com", "Ephraim", "Ephraim Balistreri", false, "Balistreri", "1-812-554-3538", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/195.jpg", "StudentXsOuWzXj" },
                    { 47, "76259 Jast Streets, Rowetown, India", "Ebertchester", new DateTime(2023, 8, 11, 3, 55, 21, 216, DateTimeKind.Local).AddTicks(8629), "Evie.Blick75@yahoo.com", "Evie", "Evie Blick", true, "Blick", "(722) 319-9560 x667", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/218.jpg", "StudentY9tRsWJH" },
                    { 48, "74101 Cormier Streets, Abbigailside, Mali", "O'Reillyberg", new DateTime(2023, 4, 2, 21, 27, 45, 420, DateTimeKind.Local).AddTicks(2759), "Anabel_West@yahoo.com", "Anabel", "Anabel West", false, "West", "467-588-0963", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1059.jpg", "StudentnBhmOL8F" },
                    { 49, "7376 Leanna Haven, East Chad, Slovakia (Slovak Republic)", "Melisaland", new DateTime(2022, 10, 22, 21, 5, 50, 94, DateTimeKind.Local).AddTicks(5260), "Zachary.Mayert23@yahoo.com", "Zachary", "Zachary Mayert", true, "Mayert", "1-313-537-8543 x0427", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/293.jpg", "StudentyEvwLsZB" },
                    { 50, "83835 Wisozk Manors, North Randalburgh, Japan", "Bufordton", new DateTime(2023, 4, 18, 8, 51, 41, 152, DateTimeKind.Local).AddTicks(381), "Reta_Murray@hotmail.com", "Reta", "Reta Murray", false, "Murray", "1-760-452-6983 x074", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/816.jpg", "StudentCC0oKvGL" }
                });

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
                name: "tbDiscussion");

            migrationBuilder.DropTable(
                name: "tbUserInfo");

            migrationBuilder.DropTable(
                name: "tbUsersInfo");

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
