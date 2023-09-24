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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketStatusId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
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
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, null, "superadmin@gmail.com", "123", "Admin", true, "SuperAdmin" },
                    { 2, null, "supporter@gmail.com", "123", "Supporter", true, "Supporter" },
                    { 3, null, "user@gmail.com", "123", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "90829 Monroe Garden, Port Reginaldhaven, Vanuatu", "Joshuaport", new DateTime(2023, 5, 20, 13, 2, 7, 952, DateTimeKind.Local).AddTicks(8764), "Litzy43@hotmail.com", "Litzy", "Litzy Johns", true, "Johns", "(963) 999-3548 x805", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/589.jpg", "Studentso5mOluR" },
                    { 2, "819 Pat Ports, Presleystad, Guyana", "West Eribertostad", new DateTime(2023, 7, 12, 14, 37, 54, 662, DateTimeKind.Local).AddTicks(7588), "Margaret.McGlynn@hotmail.com", "Margaret", "Margaret McGlynn", true, "McGlynn", "705.269.9160 x2270", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/953.jpg", "StudentUxfHDOBF" },
                    { 3, "5746 Enoch Centers, Douglasport, British Indian Ocean Territory (Chagos Archipelago)", "West Nina", new DateTime(2023, 4, 28, 12, 7, 49, 544, DateTimeKind.Local).AddTicks(3333), "Guy55@gmail.com", "Guy", "Guy Monahan", true, "Monahan", "(480) 376-4507 x97829", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/319.jpg", "StudentNcWo5019" },
                    { 4, "44380 Trantow Flat, North Jude, Antigua and Barbuda", "South Dorcasside", new DateTime(2022, 10, 5, 5, 47, 13, 492, DateTimeKind.Local).AddTicks(1942), "Stanford.Morar@gmail.com", "Stanford", "Stanford Morar", true, "Morar", "229-373-2285 x53099", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/659.jpg", "StudentIcpa62Zg" },
                    { 5, "3348 Brionna Isle, Henriettechester, Turkey", "East Viola", new DateTime(2022, 10, 7, 0, 51, 16, 53, DateTimeKind.Local).AddTicks(6736), "Lewis53@hotmail.com", "Lewis", "Lewis Blanda", true, "Blanda", "520-404-0249 x121", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/564.jpg", "StudentZFfDPQjO" },
                    { 6, "02061 Kunze Route, Haskelltown, Pakistan", "Lake Arturo", new DateTime(2023, 6, 27, 22, 29, 11, 63, DateTimeKind.Local).AddTicks(8422), "Consuelo40@hotmail.com", "Consuelo", "Consuelo Kuphal", false, "Kuphal", "1-287-317-8381 x72993", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/20.jpg", "Studentm2nnIKeR" },
                    { 7, "4924 Bill Stream, Lake Mylene, Syrian Arab Republic", "East Adonisview", new DateTime(2023, 5, 11, 9, 10, 25, 359, DateTimeKind.Local).AddTicks(344), "Bradley.Towne24@gmail.com", "Bradley", "Bradley Towne", false, "Towne", "1-320-874-0317 x9463", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/497.jpg", "StudentY2nYLDEM" },
                    { 8, "40408 Tad Loop, East Brent, Algeria", "Lavontown", new DateTime(2023, 5, 8, 13, 33, 52, 89, DateTimeKind.Local).AddTicks(7947), "Camren_Shields87@hotmail.com", "Camren", "Camren Shields", false, "Shields", "1-962-281-4641 x24183", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/188.jpg", "StudentRGpzUF5b" },
                    { 9, "014 Prudence Crossing, Handland, Liberia", "New Hattie", new DateTime(2023, 3, 20, 17, 39, 38, 193, DateTimeKind.Local).AddTicks(171), "Daija.Mante92@hotmail.com", "Daija", "Daija Mante", false, "Mante", "246.354.2000 x2031", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/956.jpg", "StudentxZrouRin" },
                    { 10, "2014 Patsy Island, Schroederview, Sierra Leone", "Hauckville", new DateTime(2023, 6, 1, 11, 12, 13, 254, DateTimeKind.Local).AddTicks(8437), "Eliane_Okuneva58@yahoo.com", "Eliane", "Eliane Okuneva", false, "Okuneva", "(836) 897-1244 x31238", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1018.jpg", "StudentDnaTu5Fk" },
                    { 11, "699 Mayer Parkway, Santinaland, Portugal", "Lake Mariafort", new DateTime(2023, 3, 1, 8, 41, 29, 572, DateTimeKind.Local).AddTicks(8757), "Cecilia.Kihn21@yahoo.com", "Cecilia", "Cecilia Kihn", true, "Kihn", "207-408-9686 x409", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/262.jpg", "StudentOZkgwNpd" },
                    { 12, "26962 Ciara Greens, Rosenbaummouth, Ghana", "North Doughaven", new DateTime(2022, 12, 28, 22, 34, 19, 630, DateTimeKind.Local).AddTicks(2294), "Jesus41@yahoo.com", "Jesus", "Jesus Tromp", true, "Tromp", "1-766-468-2464", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/653.jpg", "Students76ytHA6" },
                    { 13, "0631 Gerhold Forks, Aubreyport, Puerto Rico", "Destineyhaven", new DateTime(2023, 5, 26, 21, 56, 35, 469, DateTimeKind.Local).AddTicks(6455), "Dashawn.Dibbert36@hotmail.com", "Dashawn", "Dashawn Dibbert", true, "Dibbert", "(464) 718-1146 x377", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/408.jpg", "Studentmk9Y6LTN" },
                    { 14, "450 Brandt Pines, Stammshire, Kazakhstan", "West Jarenhaven", new DateTime(2023, 2, 1, 8, 55, 11, 385, DateTimeKind.Local).AddTicks(8173), "Paul_Schoen24@yahoo.com", "Paul", "Paul Schoen", false, "Schoen", "339.531.0373", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/290.jpg", "StudentZKfoAxne" },
                    { 15, "664 Joe Glens, East Barrett, Thailand", "Pfefferstad", new DateTime(2023, 6, 26, 15, 57, 47, 783, DateTimeKind.Local).AddTicks(763), "Vincenzo70@hotmail.com", "Vincenzo", "Vincenzo Bergstrom", false, "Bergstrom", "1-987-814-2168 x52078", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/61.jpg", "StudentUCKsmu3r" },
                    { 16, "76337 Swift Shore, Mariahmouth, Gibraltar", "Volkmanfort", new DateTime(2022, 11, 3, 21, 31, 27, 640, DateTimeKind.Local).AddTicks(6131), "Zoe35@hotmail.com", "Zoe", "Zoe Brakus", true, "Brakus", "(579) 718-1966 x8096", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/398.jpg", "Student0rfqRR7H" },
                    { 17, "0544 Jeffrey Court, West Cordieton, Sweden", "Aufderharmouth", new DateTime(2022, 10, 31, 13, 44, 40, 515, DateTimeKind.Local).AddTicks(8278), "Ewald.Schimmel78@hotmail.com", "Ewald", "Ewald Schimmel", false, "Schimmel", "549.283.3713", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/173.jpg", "StudentMKEniXCw" },
                    { 18, "1014 Alanis Route, Burleyside, Botswana", "Port Elijahport", new DateTime(2023, 7, 8, 22, 16, 36, 6, DateTimeKind.Local).AddTicks(2750), "Reta76@hotmail.com", "Reta", "Reta Schamberger", false, "Schamberger", "878-326-1076", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/280.jpg", "StudentzzRknMuD" },
                    { 19, "5756 Kuhlman Land, South Brigitte, Slovenia", "New Daynefurt", new DateTime(2023, 2, 12, 18, 36, 26, 821, DateTimeKind.Local).AddTicks(7244), "Isaiah_Wintheiser@yahoo.com", "Isaiah", "Isaiah Wintheiser", false, "Wintheiser", "1-774-620-8737 x99526", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/823.jpg", "StudentlTkNtRlN" },
                    { 20, "0466 Fahey Via, West Annabelchester, Uzbekistan", "East Elizabethshire", new DateTime(2023, 9, 10, 21, 17, 57, 769, DateTimeKind.Local).AddTicks(730), "Zack73@yahoo.com", "Zack", "Zack Collier", false, "Collier", "741-618-3458 x5973", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/706.jpg", "Studentmmd4tFhH" },
                    { 21, "277 Turner Corners, Port Gavin, Slovakia (Slovak Republic)", "South Maya", new DateTime(2023, 3, 15, 20, 9, 24, 658, DateTimeKind.Local).AddTicks(1052), "Stevie_Hagenes92@gmail.com", "Stevie", "Stevie Hagenes", true, "Hagenes", "1-492-657-1003 x12594", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/86.jpg", "Studentl4dzBFMW" },
                    { 22, "89486 Noel Gateway, Myrtiemouth, Togo", "Steuberville", new DateTime(2022, 10, 5, 23, 6, 10, 361, DateTimeKind.Local).AddTicks(9797), "Berneice_Waelchi@hotmail.com", "Berneice", "Berneice Waelchi", true, "Waelchi", "655.966.7936", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/36.jpg", "StudentZka6ObzK" },
                    { 23, "81434 Hansen Station, Madelinetown, Republic of Korea", "South Ameliabury", new DateTime(2023, 6, 15, 14, 22, 50, 769, DateTimeKind.Local).AddTicks(841), "Davin_Hansen7@gmail.com", "Davin", "Davin Hansen", true, "Hansen", "1-445-361-4223", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/689.jpg", "StudentUCZq6XGg" },
                    { 24, "57499 Schamberger Route, Krisville, British Indian Ocean Territory (Chagos Archipelago)", "Jacobsonfurt", new DateTime(2023, 2, 18, 18, 40, 59, 580, DateTimeKind.Local).AddTicks(9446), "Quentin88@hotmail.com", "Quentin", "Quentin Bins", true, "Bins", "(764) 314-6210 x3856", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/801.jpg", "StudentxCheelK7" },
                    { 25, "7196 Moore Course, Kurtishaven, Argentina", "Cummerataport", new DateTime(2023, 8, 20, 4, 45, 0, 313, DateTimeKind.Local).AddTicks(586), "Virgie.Howell@gmail.com", "Virgie", "Virgie Howell", true, "Howell", "341.263.7570", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/260.jpg", "StudentXLLnLASr" },
                    { 26, "78960 Senger Estates, West Chaz, Sri Lanka", "North Shad", new DateTime(2022, 11, 7, 18, 23, 0, 683, DateTimeKind.Local).AddTicks(5100), "Kaden_Reinger@yahoo.com", "Kaden", "Kaden Reinger", false, "Reinger", "885-596-2732 x8971", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1025.jpg", "Studenth7Ek61Ye" },
                    { 27, "02851 Novella Overpass, Lake Xavierhaven, Chile", "Croninshire", new DateTime(2023, 1, 17, 4, 3, 56, 862, DateTimeKind.Local).AddTicks(9248), "Harold.Klein@hotmail.com", "Harold", "Harold Klein", false, "Klein", "1-825-242-2063 x77989", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/633.jpg", "StudentJOEErmfj" },
                    { 28, "0407 Leslie Glen, Ortizhaven, United States of America", "Olgaside", new DateTime(2022, 10, 14, 10, 8, 54, 619, DateTimeKind.Local).AddTicks(81), "Ashleigh46@gmail.com", "Ashleigh", "Ashleigh Schuppe", true, "Schuppe", "(888) 971-0258 x768", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/708.jpg", "Studentn7qaerDH" },
                    { 29, "549 Sporer Circle, Cheyennechester, Saint Pierre and Miquelon", "Smithville", new DateTime(2022, 10, 20, 20, 39, 29, 911, DateTimeKind.Local).AddTicks(4479), "Alan.Leffler@hotmail.com", "Alan", "Alan Leffler", true, "Leffler", "823-798-2616", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/541.jpg", "StudentRbJk8G8O" },
                    { 30, "1809 Reichel Port, Port Herminiochester, Niger", "Port Kathlynton", new DateTime(2022, 10, 25, 6, 22, 35, 725, DateTimeKind.Local).AddTicks(4640), "Xavier_Yost7@hotmail.com", "Xavier", "Xavier Yost", true, "Yost", "511-760-5049 x421", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/672.jpg", "Student6BnB02va" },
                    { 31, "1087 Champlin Stravenue, Aglaeshire, Palau", "McCulloughshire", new DateTime(2023, 5, 27, 4, 13, 39, 217, DateTimeKind.Local).AddTicks(6491), "Myron.Strosin@hotmail.com", "Myron", "Myron Strosin", false, "Strosin", "595.957.7263", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/18.jpg", "Studentxj8i8GGP" },
                    { 32, "0154 Brekke Flat, West Burleymouth, Panama", "South Garnett", new DateTime(2023, 6, 1, 15, 55, 2, 561, DateTimeKind.Local).AddTicks(228), "Sydni_Halvorson@yahoo.com", "Sydni", "Sydni Halvorson", false, "Halvorson", "456-941-1177", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1038.jpg", "StudentKgGBxI2K" },
                    { 33, "2652 Alexandre Lodge, Lake Elfrieda, Niue", "Harrisborough", new DateTime(2023, 1, 11, 19, 3, 26, 389, DateTimeKind.Local).AddTicks(3616), "Kennith38@yahoo.com", "Kennith", "Kennith Gerhold", true, "Gerhold", "(703) 997-1928", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/74.jpg", "StudenthlBeukf6" },
                    { 34, "61454 Margaretta Lights, Kreigerfurt, Saudi Arabia", "Kundehaven", new DateTime(2023, 3, 30, 15, 0, 2, 740, DateTimeKind.Local).AddTicks(4158), "Yasmeen_Conn15@hotmail.com", "Yasmeen", "Yasmeen Conn", false, "Conn", "1-721-301-3054 x943", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/932.jpg", "StudentWRPTBi6d" },
                    { 35, "2119 Llewellyn Crossing, Melvinville, Burundi", "Lindsayland", new DateTime(2023, 4, 6, 17, 32, 40, 563, DateTimeKind.Local).AddTicks(219), "Dahlia_Flatley@yahoo.com", "Dahlia", "Dahlia Flatley", true, "Flatley", "1-889-729-3321", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1086.jpg", "StudentfZ4RRYw1" },
                    { 36, "2813 Golden Road, South Jettchester, Pitcairn Islands", "Jennieberg", new DateTime(2023, 8, 11, 3, 4, 21, 773, DateTimeKind.Local).AddTicks(8646), "Keara_Legros@gmail.com", "Keara", "Keara Legros", false, "Legros", "1-735-262-7837 x5379", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/150.jpg", "StudentIhMfUu7Q" },
                    { 37, "5524 Gulgowski Forest, Auerstad, Lao People's Democratic Republic", "West Stephanieville", new DateTime(2023, 8, 14, 23, 10, 4, 240, DateTimeKind.Local).AddTicks(4342), "Myah_Wintheiser57@hotmail.com", "Myah", "Myah Wintheiser", false, "Wintheiser", "1-447-385-3863", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/28.jpg", "Studento50UDZPA" },
                    { 38, "8391 O'Hara Camp, Lake Amanimouth, Thailand", "Lake Dasiabury", new DateTime(2022, 11, 3, 13, 12, 33, 420, DateTimeKind.Local).AddTicks(4242), "Darlene11@gmail.com", "Darlene", "Darlene Kessler", false, "Kessler", "(761) 594-0581 x0269", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/227.jpg", "Student9z9UJQy5" },
                    { 39, "1454 Kay Brook, New Payton, Albania", "South Eribertostad", new DateTime(2023, 3, 20, 18, 1, 48, 749, DateTimeKind.Local).AddTicks(6951), "Kyla.Borer@gmail.com", "Kyla", "Kyla Borer", false, "Borer", "779-560-8226", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/390.jpg", "StudentXLV3OGAB" },
                    { 40, "3003 Schulist Rue, West Ebbatown, Albania", "Port Adolphport", new DateTime(2023, 2, 27, 19, 13, 44, 19, DateTimeKind.Local).AddTicks(6453), "Blanche92@yahoo.com", "Blanche", "Blanche Smith", true, "Smith", "(310) 521-4551", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/445.jpg", "StudentuRTyoLYp" },
                    { 41, "75292 Rutherford Alley, Rodriguezborough, Austria", "East Derick", new DateTime(2022, 11, 2, 5, 50, 52, 474, DateTimeKind.Local).AddTicks(5190), "Broderick_Lebsack90@gmail.com", "Broderick", "Broderick Lebsack", true, "Lebsack", "(714) 294-5067 x0563", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/641.jpg", "StudentWzT0gDj2" },
                    { 42, "72910 Cummerata Parks, Port Americamouth, Puerto Rico", "Wizaview", new DateTime(2022, 11, 6, 18, 19, 25, 973, DateTimeKind.Local).AddTicks(977), "Jerad42@yahoo.com", "Jerad", "Jerad Baumbach", true, "Baumbach", "1-346-364-4417", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/288.jpg", "StudentX1DFUi1Z" },
                    { 43, "9564 Watsica Springs, East Emersonview, Jamaica", "Keshawnshire", new DateTime(2023, 6, 30, 9, 36, 16, 760, DateTimeKind.Local).AddTicks(1478), "Pete_Hauck92@gmail.com", "Pete", "Pete Hauck", true, "Hauck", "695-478-9484 x9069", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/751.jpg", "Student0Arn1nyU" },
                    { 44, "29817 Liana Rest, Stacyfurt, Sri Lanka", "Annabellberg", new DateTime(2023, 4, 20, 13, 38, 21, 719, DateTimeKind.Local).AddTicks(2094), "Nicolette19@gmail.com", "Nicolette", "Nicolette Yundt", false, "Yundt", "(823) 276-9222 x1289", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/980.jpg", "StudentbbTyATEb" },
                    { 45, "36994 Lindsay Road, East Tiffanyhaven, Sierra Leone", "North Robbie", new DateTime(2022, 11, 16, 9, 20, 18, 67, DateTimeKind.Local).AddTicks(9486), "Dangelo_Turner31@yahoo.com", "D'angelo", "D'angelo Turner", false, "Turner", "979.448.0765", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/733.jpg", "StudentHnneGi48" },
                    { 46, "5233 Hintz Mountains, North Rubychester, Liberia", "Haagside", new DateTime(2023, 3, 22, 11, 24, 19, 57, DateTimeKind.Local).AddTicks(4635), "Horacio_Schimmel51@yahoo.com", "Horacio", "Horacio Schimmel", false, "Schimmel", "688-842-9168", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/425.jpg", "StudentypCpMMu6" },
                    { 47, "841 Willms Courts, West Coryburgh, South Africa", "New Feliciaborough", new DateTime(2022, 10, 30, 2, 14, 16, 517, DateTimeKind.Local).AddTicks(9445), "Myles86@yahoo.com", "Myles", "Myles Stokes", false, "Stokes", "279-667-3164 x361", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/956.jpg", "Studenter0ikZWZ" },
                    { 48, "4269 Jessyca Expressway, Jaylanhaven, Samoa", "Rubenport", new DateTime(2023, 3, 24, 23, 11, 10, 575, DateTimeKind.Local).AddTicks(5357), "Sydnie1@gmail.com", "Sydnie", "Sydnie Bayer", false, "Bayer", "1-574-433-3830", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/891.jpg", "StudentzvrLUVDQ" },
                    { 49, "053 Parisian Expressway, Gavinton, Democratic People's Republic of Korea", "West Oran", new DateTime(2023, 7, 25, 15, 54, 4, 734, DateTimeKind.Local).AddTicks(5553), "Keshawn_Stoltenberg69@hotmail.com", "Keshawn", "Keshawn Stoltenberg", true, "Stoltenberg", "726-500-3611 x3387", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/915.jpg", "Student29EKQeUs" },
                    { 50, "0023 Kerluke Extension, Port Aldenburgh, Cook Islands", "Mercedesmouth", new DateTime(2023, 7, 31, 5, 23, 14, 864, DateTimeKind.Local).AddTicks(4925), "Jeromy_Kshlerin71@gmail.com", "Jeromy", "Jeromy Kshlerin", true, "Kshlerin", "781.889.7697 x2486", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/858.jpg", "StudentUWz8mH0l" }
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
                unique: true);
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
