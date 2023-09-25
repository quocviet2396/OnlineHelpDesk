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
                    { 1, "cVLqbw56", "superadmin@gmail.com", "$2a$11$Y94j89bcW8v2wuU7JoWNd.pOvUbA3o1ushO4Md3TCOpZcA7zZuIuy", "Admin", true, "SuperAdmin" },
                    { 2, "pvMIq3hA", "supporter@gmail.com", "$2a$11$DJ5454s05LwL.YPQIlWkhu8X1yAOOG6fA/qJHRGfq8FG2i34///Zq", "Supporter", true, "Supporter" },
                    { 3, "Qxz67Dbb", "user@gmail.com", "$2a$11$UxNOFCV0NVDdweT2di.Co.Rt8Dpfpw/1hCdBknjf7bFgUjuwrBx.q", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "2643 Walter Trafficway, North Destin, Iceland", "West Ted", new DateTime(2022, 10, 12, 10, 35, 6, 312, DateTimeKind.Local).AddTicks(781), "Kianna_Strosin@yahoo.com", "Kianna", "Kianna Strosin", false, "Strosin", "615-390-1232 x780", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/481.jpg", "StudentGnMSqHLA" },
                    { 2, "7443 Maci Prairie, North Juanitamouth, Samoa", "East Edwin", new DateTime(2022, 11, 22, 8, 59, 12, 81, DateTimeKind.Local).AddTicks(4156), "Javon31@gmail.com", "Javon", "Javon Gutmann", false, "Gutmann", "(549) 373-0153", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/0.jpg", "StudentC94NHhyL" },
                    { 3, "54990 Vaughn Radial, Port Jorgeland, Cayman Islands", "Lake Dakotastad", new DateTime(2023, 3, 13, 23, 46, 46, 391, DateTimeKind.Local).AddTicks(5648), "Nannie_Miller79@hotmail.com", "Nannie", "Nannie Miller", true, "Miller", "1-677-652-4654 x629", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/457.jpg", "StudentwAxSpIvS" },
                    { 4, "4108 Upton Rest, South Skylar, Ecuador", "O'Haraside", new DateTime(2022, 10, 12, 2, 19, 9, 867, DateTimeKind.Local).AddTicks(6887), "Liliana63@yahoo.com", "Liliana", "Liliana Osinski", true, "Osinski", "1-363-928-8569", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/516.jpg", "Studentj1Ene9W7" },
                    { 5, "4717 Boyd Street, Myrtiefurt, Chile", "Runolfssonmouth", new DateTime(2023, 3, 3, 9, 41, 4, 337, DateTimeKind.Local).AddTicks(557), "Alexis58@yahoo.com", "Alexis", "Alexis Sporer", false, "Sporer", "(672) 227-3824", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1196.jpg", "StudentwImdSC91" },
                    { 6, "136 Keven Hills, New Dollyton, Cook Islands", "East Valentine", new DateTime(2023, 7, 6, 14, 36, 0, 798, DateTimeKind.Local).AddTicks(9706), "Velda.Kub@gmail.com", "Velda", "Velda Kub", false, "Kub", "489.369.3876 x9725", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/588.jpg", "Studentug42rjVJ" },
                    { 7, "6118 Thora Springs, South Arnulfomouth, Marshall Islands", "Clintborough", new DateTime(2023, 9, 11, 7, 40, 10, 256, DateTimeKind.Local).AddTicks(3179), "Ricky_Zboncak@yahoo.com", "Ricky", "Ricky Zboncak", false, "Zboncak", "477.690.8853 x3161", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/529.jpg", "StudentQUYyPCA6" },
                    { 8, "0154 Keebler Center, Deckowfurt, Lesotho", "Rolandoburgh", new DateTime(2023, 7, 28, 4, 31, 16, 921, DateTimeKind.Local).AddTicks(3416), "Alexandra19@hotmail.com", "Alexandra", "Alexandra Cronin", false, "Cronin", "1-558-799-7600 x65299", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/745.jpg", "StudentXBs7C50O" },
                    { 9, "04153 Ernser Circle, Dareberg, Western Sahara", "South Oceane", new DateTime(2022, 10, 24, 18, 45, 16, 578, DateTimeKind.Local).AddTicks(2103), "Jaunita34@gmail.com", "Jaunita", "Jaunita Conn", false, "Conn", "695-839-5946 x47059", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1012.jpg", "StudentCPmbEhCL" },
                    { 10, "413 Orn Fall, Thielton, Sweden", "New Heberland", new DateTime(2022, 10, 10, 19, 22, 56, 451, DateTimeKind.Local).AddTicks(248), "Vance.Ebert@hotmail.com", "Vance", "Vance Ebert", false, "Ebert", "868-984-2207", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1052.jpg", "StudentdMdWPoRz" },
                    { 11, "8837 Bogan Causeway, Johnstonburgh, Tajikistan", "Juwanborough", new DateTime(2023, 6, 25, 15, 50, 2, 188, DateTimeKind.Local).AddTicks(6737), "Louvenia18@hotmail.com", "Louvenia", "Louvenia Bashirian", true, "Bashirian", "728.569.1982", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1020.jpg", "StudentmvupNRAn" },
                    { 12, "936 Maddison Via, South Stanfordport, Egypt", "West Corrinechester", new DateTime(2023, 2, 11, 21, 48, 25, 284, DateTimeKind.Local).AddTicks(8601), "Erna_Collins@hotmail.com", "Erna", "Erna Collins", false, "Collins", "779.562.6436 x5240", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/104.jpg", "StudentcRqUV4cQ" },
                    { 13, "0499 Ferry Unions, Kuhicburgh, Georgia", "Legrosbury", new DateTime(2022, 11, 5, 5, 29, 10, 538, DateTimeKind.Local).AddTicks(8046), "Summer_Dickens@gmail.com", "Summer", "Summer Dickens", false, "Dickens", "254.597.0505", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/399.jpg", "Studentl5gV7Vby" },
                    { 14, "354 Violet Curve, Abdullahfort, Hungary", "South Bernita", new DateTime(2023, 4, 8, 22, 54, 13, 624, DateTimeKind.Local).AddTicks(5022), "Jewell64@yahoo.com", "Jewell", "Jewell Treutel", false, "Treutel", "545-419-8489 x3364", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/739.jpg", "StudentdejBGY7W" },
                    { 15, "4935 Elda Roads, Aldenport, Saint Barthelemy", "Luciustown", new DateTime(2023, 8, 13, 15, 7, 35, 892, DateTimeKind.Local).AddTicks(5673), "Jeff.Cummerata84@yahoo.com", "Jeff", "Jeff Cummerata", true, "Cummerata", "810-765-9669", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/257.jpg", "Student9mo9UeDx" },
                    { 16, "7323 Kieran Springs, New Leila, Papua New Guinea", "Gislasonfort", new DateTime(2023, 2, 3, 13, 4, 18, 205, DateTimeKind.Local).AddTicks(2310), "Eriberto21@gmail.com", "Eriberto", "Eriberto Hoppe", false, "Hoppe", "933-883-9035", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/656.jpg", "StudentVoSLc40P" },
                    { 17, "5424 Rupert Parkways, Luciofort, Macao", "Lake Monserrateborough", new DateTime(2023, 6, 30, 21, 4, 26, 75, DateTimeKind.Local).AddTicks(6936), "Maggie15@hotmail.com", "Maggie", "Maggie Swift", true, "Swift", "807.785.4639", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/451.jpg", "StudentdP3pTK1y" },
                    { 18, "818 Cremin Radial, North Ernestine, Republic of Korea", "West Keshaun", new DateTime(2023, 6, 15, 10, 10, 10, 17, DateTimeKind.Local).AddTicks(1559), "Hayden.Toy95@gmail.com", "Hayden", "Hayden Toy", true, "Toy", "(457) 298-9502", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/129.jpg", "StudentOIPsRGNe" },
                    { 19, "9942 Fay Mews, West Estefania, Georgia", "Beatricebury", new DateTime(2023, 5, 20, 6, 47, 37, 82, DateTimeKind.Local).AddTicks(5929), "Alvah17@hotmail.com", "Alvah", "Alvah Pouros", true, "Pouros", "1-529-608-7070", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/484.jpg", "Studentftssv5Wq" },
                    { 20, "37601 Moen Meadow, North Kane, Isle of Man", "Cristalmouth", new DateTime(2023, 2, 28, 22, 38, 27, 284, DateTimeKind.Local).AddTicks(5364), "Eliseo46@yahoo.com", "Eliseo", "Eliseo Heaney", false, "Heaney", "619-802-5698", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/849.jpg", "StudentzpQoxi0g" },
                    { 21, "1971 Stehr Points, South Hazelside, Kyrgyz Republic", "Dietrichshire", new DateTime(2022, 11, 19, 23, 17, 13, 65, DateTimeKind.Local).AddTicks(4981), "Xzavier.Batz18@yahoo.com", "Xzavier", "Xzavier Batz", false, "Batz", "1-924-973-5278", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/361.jpg", "Student1MNRLESD" },
                    { 22, "59694 Lehner Skyway, Rueckerland, Jersey", "Watersport", new DateTime(2023, 5, 17, 17, 36, 43, 729, DateTimeKind.Local).AddTicks(7956), "Asha.Cruickshank@yahoo.com", "Asha", "Asha Cruickshank", false, "Cruickshank", "(379) 598-5469", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/153.jpg", "StudentiLXyoJf0" },
                    { 23, "0634 Julia Highway, Port Sophieville, Congo", "Hegmannton", new DateTime(2023, 7, 14, 16, 13, 19, 727, DateTimeKind.Local).AddTicks(1691), "Narciso79@yahoo.com", "Narciso", "Narciso Douglas", false, "Douglas", "1-449-536-7705 x4610", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/453.jpg", "StudentbooRCzh7" },
                    { 24, "60240 Leonora Stream, North Millermouth, Marshall Islands", "Port Rylanfurt", new DateTime(2022, 11, 28, 0, 1, 40, 156, DateTimeKind.Local).AddTicks(2629), "Eino78@hotmail.com", "Eino", "Eino Purdy", false, "Purdy", "678.622.5023 x9941", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/331.jpg", "StudentRqe1so3Z" },
                    { 25, "524 Rempel Park, Dellchester, Canada", "South Geoton", new DateTime(2023, 9, 6, 2, 4, 29, 322, DateTimeKind.Local).AddTicks(7386), "Mathilde_Goldner88@yahoo.com", "Mathilde", "Mathilde Goldner", false, "Goldner", "271-498-3826", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/171.jpg", "StudentwA6f2bVx" },
                    { 26, "24414 Bobby Square, Kuvaliston, Germany", "Shanahanton", new DateTime(2022, 12, 5, 18, 12, 21, 670, DateTimeKind.Local).AddTicks(5408), "Karl.Gerlach19@yahoo.com", "Karl", "Karl Gerlach", true, "Gerlach", "(874) 706-1128", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1248.jpg", "Student26FnCU2A" },
                    { 27, "89491 Pfeffer Ridge, East Lemuel, Western Sahara", "Maryammouth", new DateTime(2023, 9, 20, 7, 2, 3, 394, DateTimeKind.Local).AddTicks(2984), "Noemie_Bernhard@gmail.com", "Noemie", "Noemie Bernhard", false, "Bernhard", "1-622-276-9029", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/916.jpg", "StudentlP6BwGTh" },
                    { 28, "678 Velda Knolls, New Meredithburgh, Brazil", "Baronfort", new DateTime(2023, 1, 31, 4, 17, 58, 150, DateTimeKind.Local).AddTicks(4451), "Joshua_Langworth88@hotmail.com", "Joshua", "Joshua Langworth", true, "Langworth", "1-672-498-3578", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/54.jpg", "Student7XF1yPqV" },
                    { 29, "2610 Giovanni Hill, Rosenbaumview, Bahamas", "Micheleberg", new DateTime(2022, 10, 13, 19, 4, 13, 954, DateTimeKind.Local).AddTicks(403), "Polly61@yahoo.com", "Polly", "Polly Ledner", false, "Ledner", "864.595.2052", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/914.jpg", "StudentE7FDrqOs" },
                    { 30, "78209 Schaefer River, New Idellabury, Algeria", "West Logan", new DateTime(2023, 2, 4, 0, 30, 31, 411, DateTimeKind.Local).AddTicks(6564), "Roxane.Ward@yahoo.com", "Roxane", "Roxane Ward", true, "Ward", "749.472.1115 x3670", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1146.jpg", "StudentOAmMFRBd" },
                    { 31, "82432 Myra Isle, Gastontown, Sierra Leone", "Trevorburgh", new DateTime(2023, 7, 24, 2, 50, 10, 894, DateTimeKind.Local).AddTicks(4766), "Lura95@yahoo.com", "Lura", "Lura Rosenbaum", false, "Rosenbaum", "(837) 700-9141 x498", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/68.jpg", "StudentY3WGsfaS" },
                    { 32, "6014 Jodie Throughway, Leschmouth, Virgin Islands, British", "West Kyler", new DateTime(2023, 4, 23, 21, 22, 10, 985, DateTimeKind.Local).AddTicks(6040), "Jacquelyn.Miller@hotmail.com", "Jacquelyn", "Jacquelyn Miller", true, "Miller", "(806) 292-4380", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1038.jpg", "StudentloCP85Qc" },
                    { 33, "6044 Orn Point, Maggiohaven, Bosnia and Herzegovina", "East Zettachester", new DateTime(2023, 8, 11, 21, 40, 53, 71, DateTimeKind.Local).AddTicks(3626), "Lavada.Gislason65@gmail.com", "Lavada", "Lavada Gislason", true, "Gislason", "(257) 736-3862 x96658", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1017.jpg", "StudentPi5nG5Iv" },
                    { 34, "782 Lesch Tunnel, East Dexterville, Greenland", "Euniceside", new DateTime(2022, 11, 30, 1, 5, 24, 18, DateTimeKind.Local).AddTicks(2533), "Levi_Heidenreich@gmail.com", "Levi", "Levi Heidenreich", false, "Heidenreich", "942-219-2955", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/594.jpg", "StudentVZ8MNqAA" },
                    { 35, "2598 Federico Rapid, South Murrayside, Lao People's Democratic Republic", "Tabithaland", new DateTime(2023, 6, 29, 19, 55, 5, 694, DateTimeKind.Local).AddTicks(7237), "Carley_Runolfsdottir@hotmail.com", "Carley", "Carley Runolfsdottir", true, "Runolfsdottir", "1-766-474-2018", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/829.jpg", "Student220M69x0" },
                    { 36, "7243 Kiehn Unions, Mullerton, Cape Verde", "West Russ", new DateTime(2023, 3, 2, 15, 31, 33, 844, DateTimeKind.Local).AddTicks(1736), "Elbert_Tromp@hotmail.com", "Elbert", "Elbert Tromp", false, "Tromp", "847-537-9730 x22138", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/147.jpg", "StudentlxbnFgST" },
                    { 37, "21313 Cronin Pass, Davisville, Egypt", "East Thurman", new DateTime(2022, 10, 11, 9, 18, 49, 209, DateTimeKind.Local).AddTicks(2899), "Reinhold59@hotmail.com", "Reinhold", "Reinhold Ward", true, "Ward", "(736) 366-6041", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/448.jpg", "StudentpElqrYGW" },
                    { 38, "88908 Walter Route, Gideonview, United States of America", "South Eleazarview", new DateTime(2023, 4, 16, 19, 1, 28, 718, DateTimeKind.Local).AddTicks(3580), "Merritt_Thompson@yahoo.com", "Merritt", "Merritt Thompson", false, "Thompson", "1-988-796-6943 x4448", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/745.jpg", "StudentKR3XBbgR" },
                    { 39, "2291 Kyle Flat, Eleonoremouth, Belarus", "New Matilda", new DateTime(2023, 2, 26, 1, 5, 23, 995, DateTimeKind.Local).AddTicks(6300), "Emanuel_Oberbrunner@yahoo.com", "Emanuel", "Emanuel Oberbrunner", false, "Oberbrunner", "695-293-8042 x936", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1151.jpg", "StudentJMSP5sGt" },
                    { 40, "941 Rozella Isle, Salvatoretown, Saudi Arabia", "North Laron", new DateTime(2023, 4, 10, 10, 15, 57, 96, DateTimeKind.Local).AddTicks(2046), "Leila_Johns16@hotmail.com", "Leila", "Leila Johns", true, "Johns", "(513) 962-8850 x73770", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/793.jpg", "StudentsQIlAHL3" },
                    { 41, "084 Ferry Route, Port Zellaland, Luxembourg", "Rosston", new DateTime(2023, 4, 14, 3, 41, 20, 902, DateTimeKind.Local).AddTicks(5533), "Annetta.Grant74@hotmail.com", "Annetta", "Annetta Grant", false, "Grant", "1-833-617-3193 x969", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/182.jpg", "StudentbMby6wDH" },
                    { 42, "41510 Fay Harbor, Janessaborough, San Marino", "New Demondburgh", new DateTime(2022, 12, 4, 7, 4, 54, 925, DateTimeKind.Local).AddTicks(6514), "Eda96@gmail.com", "Eda", "Eda Davis", false, "Davis", "353-996-3161", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/981.jpg", "Studentpz7xqpjD" },
                    { 43, "75768 Kamron River, Haleybury, Canada", "South Melvina", new DateTime(2022, 12, 22, 20, 49, 45, 131, DateTimeKind.Local).AddTicks(5440), "Nathanael.Kautzer@yahoo.com", "Nathanael", "Nathanael Kautzer", false, "Kautzer", "500.989.5514 x521", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/94.jpg", "Student4f0zHLvw" },
                    { 44, "6672 Wyman Greens, Port Abelview, Armenia", "Kuhnburgh", new DateTime(2022, 12, 25, 12, 35, 22, 164, DateTimeKind.Local).AddTicks(6735), "Rosella57@yahoo.com", "Rosella", "Rosella Bechtelar", true, "Bechtelar", "(443) 782-7953", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1158.jpg", "StudentpBqFIxDj" },
                    { 45, "705 Ephraim Orchard, Mullerton, Kenya", "Annettatown", new DateTime(2023, 3, 25, 12, 21, 44, 217, DateTimeKind.Local).AddTicks(3815), "Ryleigh86@gmail.com", "Ryleigh", "Ryleigh Zulauf", true, "Zulauf", "1-678-620-1808", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/686.jpg", "StudentGvxFUm38" },
                    { 46, "592 Aubrey Burg, West Bessie, Palau", "North Price", new DateTime(2023, 6, 22, 18, 20, 48, 159, DateTimeKind.Local).AddTicks(4996), "Jasen_Weber@yahoo.com", "Jasen", "Jasen Weber", false, "Weber", "1-291-970-3115 x65271", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/945.jpg", "Student3SLKot44" },
                    { 47, "81593 Mona Garden, North Augusta, Saint Pierre and Miquelon", "West Jeremieton", new DateTime(2023, 3, 18, 19, 19, 45, 559, DateTimeKind.Local).AddTicks(8142), "Kamron.Gottlieb@hotmail.com", "Kamron", "Kamron Gottlieb", false, "Gottlieb", "604.818.1383 x75103", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1132.jpg", "Studentqr60MDgu" },
                    { 48, "509 Otis Island, Port Lolita, Vanuatu", "Lake Litzytown", new DateTime(2023, 8, 29, 4, 40, 55, 793, DateTimeKind.Local).AddTicks(3396), "Dewayne77@gmail.com", "Dewayne", "Dewayne Ferry", false, "Ferry", "268.553.4945", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/402.jpg", "StudentQM3a4hGD" },
                    { 49, "47689 Purdy Viaduct, Dillonberg, Niue", "East Gabriella", new DateTime(2022, 10, 26, 4, 46, 18, 991, DateTimeKind.Local).AddTicks(9663), "Frances.Conn@yahoo.com", "Frances", "Frances Conn", true, "Conn", "1-440-496-7523", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/796.jpg", "StudentvT5iX127" },
                    { 50, "3701 Pearlie Manor, North Evemouth, Malaysia", "Brennachester", new DateTime(2023, 7, 25, 5, 3, 47, 932, DateTimeKind.Local).AddTicks(3355), "Ruthe_Graham@yahoo.com", "Ruthe", "Ruthe Graham", true, "Graham", "1-863-967-7163 x2102", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/782.jpg", "StudenthJX94iux" }
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
