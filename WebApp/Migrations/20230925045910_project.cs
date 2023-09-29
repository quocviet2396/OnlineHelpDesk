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
                    { 1, "wqglypHd", "superadmin@gmail.com", "$2a$11$wWgTO0PUiU3DkV6AhwWTS.Q5rqjUp/jjKvP6th9o0t4d7k.W/PEr6", "Admin", true, "SuperAdmin" },
                    { 2, "2rHDfT2p", "supporter@gmail.com", "$2a$11$NpqwIosyCJuTuIMsyrn4seePHSFjfjLIh4DMZOfHYMbDW2beEhdxq", "Supporter", true, "Supporter" },
                    { 3, "n8nEEFPg", "user@gmail.com", "$2a$11$609mX9JtnAOzPJu.28ymFOvxSMNuhT7g.wBbvQyI5DPIOGry/1PC6", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "40182 Swift Coves, New Odiemouth, Taiwan", "New Gailshire", new DateTime(2023, 5, 9, 13, 48, 16, 593, DateTimeKind.Local).AddTicks(5734), "Ashton99@yahoo.com", "Ashton", "Ashton Balistreri", true, "Balistreri", "1-757-631-7905 x14990", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/132.jpg", "StudentHK7iRIdB" },
                    { 2, "4339 Pollich Mountain, Rosemarieville, Zambia", "Loymouth", new DateTime(2022, 12, 11, 6, 28, 2, 304, DateTimeKind.Local).AddTicks(5697), "Bonnie_Kiehn@gmail.com", "Bonnie", "Bonnie Kiehn", true, "Kiehn", "1-771-952-1087 x6877", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1141.jpg", "StudentGfDk2UkI" },
                    { 3, "42849 Adelbert Bridge, Veldachester, Myanmar", "Jaylinberg", new DateTime(2023, 7, 11, 5, 56, 8, 85, DateTimeKind.Local).AddTicks(3813), "Assunta_Hintz@yahoo.com", "Assunta", "Assunta Hintz", false, "Hintz", "768-500-3829", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/60.jpg", "StudentpE7xeP2y" },
                    { 4, "6455 Flatley Lodge, Johnsonstad, Costa Rica", "South John", new DateTime(2022, 12, 17, 23, 54, 45, 826, DateTimeKind.Local).AddTicks(7949), "Lucio55@hotmail.com", "Lucio", "Lucio Reichel", false, "Reichel", "1-911-715-3480 x7121", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/319.jpg", "StudentnpSevO9e" },
                    { 5, "192 Kaylin Branch, East Jarrod, Uruguay", "Hillsfurt", new DateTime(2023, 5, 19, 11, 20, 22, 694, DateTimeKind.Local).AddTicks(2890), "Danielle_Kshlerin94@hotmail.com", "Danielle", "Danielle Kshlerin", false, "Kshlerin", "829.787.3362", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1112.jpg", "StudentxKfxUsIo" },
                    { 6, "25863 Wallace Courts, North Sterling, Pakistan", "West Thaddeusview", new DateTime(2023, 6, 16, 11, 40, 26, 19, DateTimeKind.Local).AddTicks(9453), "Lorenza61@yahoo.com", "Lorenza", "Lorenza O'Kon", true, "O'Kon", "449.406.4572 x667", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/155.jpg", "StudentoUAiRhll" },
                    { 7, "601 Wilhelmine Way, West Raleigh, Tonga", "Garlandmouth", new DateTime(2022, 12, 20, 10, 46, 40, 402, DateTimeKind.Local).AddTicks(6455), "Carley4@yahoo.com", "Carley", "Carley Gislason", true, "Gislason", "904.706.0416", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/939.jpg", "StudentInO7WNre" },
                    { 8, "08787 Pacocha Glen, Port Eliezer, Sao Tome and Principe", "Geovanyberg", new DateTime(2022, 11, 18, 17, 34, 18, 930, DateTimeKind.Local).AddTicks(4918), "Kasey66@hotmail.com", "Kasey", "Kasey Johnson", false, "Johnson", "(229) 213-3467 x7590", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/442.jpg", "Student9eZbatuc" },
                    { 9, "044 Selena Summit, Cristville, Liechtenstein", "New Busterview", new DateTime(2023, 3, 24, 23, 38, 15, 988, DateTimeKind.Local).AddTicks(8276), "Jerry_Becker@hotmail.com", "Jerry", "Jerry Becker", false, "Becker", "(816) 721-3679 x3916", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/119.jpg", "StudentsGJllX5R" },
                    { 10, "584 Lacy Trace, Florinetown, Bosnia and Herzegovina", "Heathcoteburgh", new DateTime(2022, 10, 7, 4, 13, 28, 52, DateTimeKind.Local).AddTicks(1004), "Raymundo.OHara@yahoo.com", "Raymundo", "Raymundo O'Hara", true, "O'Hara", "468.598.1053", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/85.jpg", "StudentVqD8t9bU" },
                    { 11, "693 Von Mission, Rohanchester, Dominican Republic", "Lake Ilamouth", new DateTime(2023, 8, 11, 11, 58, 30, 280, DateTimeKind.Local).AddTicks(7930), "Bernard_Rosenbaum@hotmail.com", "Bernard", "Bernard Rosenbaum", false, "Rosenbaum", "930.970.7556", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/494.jpg", "Student0xaBuGhM" },
                    { 12, "4551 Tierra Overpass, Chloemouth, Nauru", "South Keventon", new DateTime(2022, 10, 6, 5, 40, 3, 903, DateTimeKind.Local).AddTicks(1892), "Brennon60@yahoo.com", "Brennon", "Brennon Cole", false, "Cole", "1-355-350-1480 x30023", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/353.jpg", "StudentLMmHpkBQ" },
                    { 13, "167 Muriel Square, Jakubowskiland, Fiji", "Cormierland", new DateTime(2023, 8, 24, 8, 53, 14, 675, DateTimeKind.Local).AddTicks(4431), "Shanel.Hoppe@yahoo.com", "Shanel", "Shanel Hoppe", true, "Hoppe", "943-547-5710 x87611", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/575.jpg", "StudentDEqD8QWV" },
                    { 14, "95742 West Trail, Kariside, Faroe Islands", "Kathleenton", new DateTime(2023, 5, 19, 5, 6, 40, 609, DateTimeKind.Local).AddTicks(643), "Fannie_Pacocha30@hotmail.com", "Fannie", "Fannie Pacocha", true, "Pacocha", "(421) 258-1060 x3370", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/486.jpg", "StudentvOumULPZ" },
                    { 15, "81718 Clyde Greens, Veummouth, Belgium", "South Salmamouth", new DateTime(2022, 10, 21, 9, 28, 9, 592, DateTimeKind.Local).AddTicks(5777), "Tatum57@gmail.com", "Tatum", "Tatum Cruickshank", true, "Cruickshank", "556.282.7057", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1181.jpg", "StudentGtobTDuC" },
                    { 16, "8790 Stamm Summit, Jarrodville, Tajikistan", "Lake Erich", new DateTime(2022, 11, 20, 6, 33, 13, 492, DateTimeKind.Local).AddTicks(355), "Helena.Powlowski@yahoo.com", "Helena", "Helena Powlowski", true, "Powlowski", "(979) 267-1298 x63505", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/159.jpg", "StudentlnPbR6TO" },
                    { 17, "176 Larson Mission, Port Lucy, Brunei Darussalam", "Port Catharine", new DateTime(2023, 1, 20, 3, 25, 36, 179, DateTimeKind.Local).AddTicks(7502), "Ericka61@yahoo.com", "Ericka", "Ericka Hintz", true, "Hintz", "869-279-6613", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/958.jpg", "StudentqwjbEqoN" },
                    { 18, "77348 Bernadette Prairie, West Sadye, Sweden", "Langburgh", new DateTime(2023, 8, 28, 17, 23, 6, 898, DateTimeKind.Local).AddTicks(6324), "Kamren_Bechtelar4@yahoo.com", "Kamren", "Kamren Bechtelar", false, "Bechtelar", "702-887-7336 x79037", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/131.jpg", "StudentR1RR1AKS" },
                    { 19, "028 Murphy Pines, Hirthechester, Venezuela", "Alexandreberg", new DateTime(2023, 3, 26, 18, 11, 0, 467, DateTimeKind.Local).AddTicks(5268), "Geovany78@gmail.com", "Geovany", "Geovany Mayer", true, "Mayer", "(499) 931-4259", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/308.jpg", "StudentUNKM4i38" },
                    { 20, "94841 Stoltenberg Forks, South Anderson, Sao Tome and Principe", "Eldonchester", new DateTime(2022, 12, 13, 20, 8, 51, 625, DateTimeKind.Local).AddTicks(1644), "Asia.Marquardt@hotmail.com", "Asia", "Asia Marquardt", true, "Marquardt", "342-746-3432 x89641", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/171.jpg", "StudentMHCTwM5I" },
                    { 21, "00856 Conn Shoals, Garrisonshire, Macedonia", "Jacobiview", new DateTime(2022, 10, 11, 16, 39, 55, 322, DateTimeKind.Local).AddTicks(455), "Willard76@yahoo.com", "Willard", "Willard Kemmer", false, "Kemmer", "630-286-5753", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/88.jpg", "Student4HYFyNlu" },
                    { 22, "9759 Myra Ridges, Port Brice, British Indian Ocean Territory (Chagos Archipelago)", "Bayerfurt", new DateTime(2023, 9, 10, 7, 10, 44, 625, DateTimeKind.Local).AddTicks(5338), "Lamont.Hoeger65@hotmail.com", "Lamont", "Lamont Hoeger", false, "Hoeger", "710-202-0760", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/13.jpg", "StudenttnkuyL3L" },
                    { 23, "50101 Bins Keys, Beckerport, Austria", "South Ethel", new DateTime(2022, 11, 3, 15, 58, 14, 70, DateTimeKind.Local).AddTicks(8368), "Herbert.Huels@yahoo.com", "Herbert", "Herbert Huels", true, "Huels", "568-377-9203", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/673.jpg", "Student4ayAEiNf" },
                    { 24, "9189 Flatley View, Wittington, Palestinian Territory", "Port Altatown", new DateTime(2022, 12, 16, 8, 20, 0, 33, DateTimeKind.Local).AddTicks(6546), "Aniyah_Nader@hotmail.com", "Aniyah", "Aniyah Nader", true, "Nader", "375-712-7050", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/852.jpg", "StudentfkRtcCE2" },
                    { 25, "53958 Gerhard Wall, Lake Rylanfurt, Mali", "North Marcoberg", new DateTime(2023, 4, 24, 22, 30, 33, 585, DateTimeKind.Local).AddTicks(2806), "Immanuel.Hegmann26@hotmail.com", "Immanuel", "Immanuel Hegmann", true, "Hegmann", "782.869.2327", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1174.jpg", "Student3xE7TGd4" },
                    { 26, "7326 Alaina Club, West Allieberg, Madagascar", "Gulgowskihaven", new DateTime(2023, 3, 6, 21, 32, 37, 464, DateTimeKind.Local).AddTicks(4464), "Bernardo_Larson@gmail.com", "Bernardo", "Bernardo Larson", false, "Larson", "(290) 608-4745", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/608.jpg", "StudentWCrFyAtx" },
                    { 27, "5123 Ethel Pine, Rutherfordtown, Mali", "Candelarioville", new DateTime(2022, 10, 30, 20, 35, 58, 460, DateTimeKind.Local).AddTicks(7624), "Lenora21@gmail.com", "Lenora", "Lenora Christiansen", true, "Christiansen", "280-949-4571 x485", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/250.jpg", "StudentoB1NkdM9" },
                    { 28, "488 West Junction, Haleyburgh, Belgium", "Beattyville", new DateTime(2023, 1, 22, 19, 50, 4, 514, DateTimeKind.Local).AddTicks(9442), "Betsy55@yahoo.com", "Betsy", "Betsy Hamill", false, "Hamill", "529.284.4916 x8939", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/686.jpg", "Student08g4mSc3" },
                    { 29, "584 Shanahan Cove, East Marguerite, Samoa", "Erinport", new DateTime(2022, 9, 30, 23, 0, 40, 455, DateTimeKind.Local).AddTicks(8379), "Fletcher.Koss@gmail.com", "Fletcher", "Fletcher Koss", true, "Koss", "285-769-8905", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1161.jpg", "StudentgeqfKXJH" },
                    { 30, "4578 Buckridge Valleys, South Enidhaven, Congo", "Sadyebury", new DateTime(2022, 12, 1, 19, 50, 40, 916, DateTimeKind.Local).AddTicks(5205), "Burdette33@yahoo.com", "Burdette", "Burdette Ruecker", true, "Ruecker", "(587) 334-7546", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/108.jpg", "StudentMzEvPS2I" },
                    { 31, "6262 Porter Mountains, North Samanthaside, Portugal", "West Donaldmouth", new DateTime(2022, 12, 1, 4, 48, 40, 11, DateTimeKind.Local).AddTicks(9775), "Amina.Bins27@yahoo.com", "Amina", "Amina Bins", true, "Bins", "1-340-683-1589 x4698", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/880.jpg", "StudentQblGmKlf" },
                    { 32, "3000 Esmeralda Drive, South Margeport, Liberia", "West Marshall", new DateTime(2022, 12, 21, 18, 46, 59, 57, DateTimeKind.Local).AddTicks(6688), "Wallace_Sauer48@gmail.com", "Wallace", "Wallace Sauer", true, "Sauer", "922-640-4126", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/61.jpg", "StudenteqysmO0p" },
                    { 33, "45874 Legros Mill, Mossieberg, Togo", "Balistrerimouth", new DateTime(2023, 4, 25, 10, 56, 9, 180, DateTimeKind.Local).AddTicks(6206), "Mustafa72@gmail.com", "Mustafa", "Mustafa Boyer", true, "Boyer", "1-370-755-9732", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/292.jpg", "StudentGMcFdCNh" },
                    { 34, "2650 Spinka Brook, Diegoville, France", "Cruickshankburgh", new DateTime(2023, 8, 20, 9, 49, 11, 209, DateTimeKind.Local).AddTicks(9597), "Aric_Hickle78@hotmail.com", "Aric", "Aric Hickle", true, "Hickle", "1-317-653-4860", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/789.jpg", "Student6NKL6ksK" },
                    { 35, "74435 Dawson Drive, North Jenifer, Ethiopia", "Pollichburgh", new DateTime(2022, 12, 1, 16, 31, 21, 61, DateTimeKind.Local).AddTicks(1730), "Tre_Durgan54@hotmail.com", "Tre", "Tre Durgan", true, "Durgan", "1-355-387-2360", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/720.jpg", "StudentvexibZjz" },
                    { 36, "0355 Leuschke Spur, Purdychester, Congo", "East Carmelmouth", new DateTime(2023, 4, 7, 3, 57, 44, 481, DateTimeKind.Local).AddTicks(845), "Krista.Hegmann@yahoo.com", "Krista", "Krista Hegmann", true, "Hegmann", "393-939-6840", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/589.jpg", "StudentD6k7EbB8" },
                    { 37, "506 Vita Forest, West Laurineshire, Gabon", "Alfredafurt", new DateTime(2023, 4, 22, 15, 6, 33, 937, DateTimeKind.Local).AddTicks(1850), "Ruthe_Quitzon66@yahoo.com", "Ruthe", "Ruthe Quitzon", true, "Quitzon", "449-236-0255 x32144", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/997.jpg", "StudentAvXTjtFA" },
                    { 38, "610 Ankunding View, North Micah, New Caledonia", "Lueilwitzborough", new DateTime(2022, 10, 25, 13, 53, 45, 280, DateTimeKind.Local).AddTicks(9881), "Aileen_Klocko@gmail.com", "Aileen", "Aileen Klocko", true, "Klocko", "963.294.0247 x669", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/614.jpg", "StudenttMDa7qj7" },
                    { 39, "13921 Krystina Road, Port Edythe, Virgin Islands, British", "Port Lilyan", new DateTime(2023, 2, 1, 11, 1, 20, 557, DateTimeKind.Local).AddTicks(5127), "Napoleon.Treutel0@gmail.com", "Napoleon", "Napoleon Treutel", true, "Treutel", "1-656-645-0933 x384", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/922.jpg", "Student2cCCl5Kl" },
                    { 40, "116 Lilyan Falls, Stammton, Lebanon", "East Ansley", new DateTime(2023, 5, 19, 14, 1, 2, 827, DateTimeKind.Local).AddTicks(2669), "Percival64@yahoo.com", "Percival", "Percival Bernhard", false, "Bernhard", "1-884-697-8693", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/36.jpg", "StudentKn8ECrA7" },
                    { 41, "59133 Benjamin Circles, Mantemouth, Botswana", "Prosaccoside", new DateTime(2023, 7, 2, 11, 36, 34, 500, DateTimeKind.Local).AddTicks(5583), "Raina_Collier@gmail.com", "Raina", "Raina Collier", true, "Collier", "1-776-795-8994 x12375", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/122.jpg", "StudentObFn8q12" },
                    { 42, "123 Trudie Trace, Bashirianfurt, Bosnia and Herzegovina", "Kleinstad", new DateTime(2023, 3, 25, 22, 14, 11, 929, DateTimeKind.Local).AddTicks(6422), "Henri_Fisher@gmail.com", "Henri", "Henri Fisher", false, "Fisher", "(499) 667-2161 x562", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/609.jpg", "StudenttnlC4ZnF" },
                    { 43, "166 Anne Groves, North Cassieshire, Virgin Islands, U.S.", "New Fionafurt", new DateTime(2023, 7, 20, 13, 21, 8, 405, DateTimeKind.Local).AddTicks(8188), "Missouri_Quitzon99@gmail.com", "Missouri", "Missouri Quitzon", false, "Quitzon", "843.419.7177", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/191.jpg", "StudentDyQPBOYi" },
                    { 44, "835 Beatty Rue, Lake Octaviaport, Iraq", "Kathrynburgh", new DateTime(2022, 11, 4, 0, 6, 50, 25, DateTimeKind.Local).AddTicks(3143), "Tremayne.VonRueden5@hotmail.com", "Tremayne", "Tremayne VonRueden", true, "VonRueden", "324-241-8737", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/259.jpg", "StudentKIyDdZYR" },
                    { 45, "9637 Prosacco Track, East Bricemouth, Hungary", "Mrazborough", new DateTime(2023, 2, 28, 18, 27, 28, 641, DateTimeKind.Local).AddTicks(6947), "Junior.Nicolas28@hotmail.com", "Junior", "Junior Nicolas", true, "Nicolas", "248.830.6446 x2214", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/475.jpg", "Student310bOM2o" },
                    { 46, "6042 Wehner Manors, Jaylenville, Czech Republic", "East Gennarochester", new DateTime(2023, 1, 12, 23, 53, 54, 342, DateTimeKind.Local).AddTicks(3629), "Gardner63@hotmail.com", "Gardner", "Gardner Lubowitz", true, "Lubowitz", "576-305-2946", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/187.jpg", "Studenth8XmFc4Q" },
                    { 47, "95600 Benjamin Field, North Filibertohaven, India", "North Itzelberg", new DateTime(2022, 12, 4, 15, 52, 59, 975, DateTimeKind.Local).AddTicks(8671), "Manuela.Pollich@hotmail.com", "Manuela", "Manuela Pollich", false, "Pollich", "1-359-954-7432 x556", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/16.jpg", "StudentfFUfU6GF" },
                    { 48, "63248 Dandre Burg, New Lorainemouth, French Southern Territories", "Zemlakfurt", new DateTime(2023, 9, 24, 11, 9, 8, 900, DateTimeKind.Local).AddTicks(2060), "Magali32@gmail.com", "Magali", "Magali Waelchi", true, "Waelchi", "1-350-791-8355", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/632.jpg", "StudentLSRTxAmH" },
                    { 49, "61731 Daugherty Gateway, Kiehntown, Czech Republic", "East Andystad", new DateTime(2023, 3, 22, 6, 7, 35, 498, DateTimeKind.Local).AddTicks(1547), "Dino.Batz@hotmail.com", "Dino", "Dino Batz", false, "Batz", "357.496.2427 x87877", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/477.jpg", "StudentxbDvmqlC" },
                    { 50, "8225 Elna Way, Cydneybury, Mali", "Gaylordburgh", new DateTime(2023, 4, 6, 13, 16, 51, 427, DateTimeKind.Local).AddTicks(2342), "Ella.Kling66@gmail.com", "Ella", "Ella Kling", true, "Kling", "677.975.8053 x29038", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/560.jpg", "StudentdbgMnFNF" }
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
