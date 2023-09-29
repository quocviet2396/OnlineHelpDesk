using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class hd : Migration
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
                    { 1, "lpi1FgZj", "superadmin@gmail.com", "$2a$11$37PHRU.vX9JKlr0SBU4/fegj7nG48.L6FVV0MCidCNmLGKDPAu5SW", "Admin", true, "SuperAdmin" },
                    { 2, "qnTlmhwp", "supporter@gmail.com", "$2a$11$afntE.x99L0xQK4i77uyf.VVq2dkvpFtWrMQekv28n6sAJoNhIeqm", "Supporter", true, "Supporter" },
                    { 3, "74lJHAty", "user@gmail.com", "$2a$11$WgxFZcWZKL3iRsAkZEFnl.9yzWA61m.4WJj5p8GYgwJxsdFtRFdJS", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "470 Kessler Highway, Omermouth, Belarus", "Bayershire", new DateTime(2022, 10, 4, 5, 19, 54, 880, DateTimeKind.Local).AddTicks(5581), "Sebastian.Koch31@yahoo.com", "Sebastian", "Sebastian Koch", true, "Koch", "646.253.9415 x050", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/688.jpg", "StudentcPZnm78Y" },
                    { 2, "84009 Boyd Stream, O'Konland, Canada", "Lake Ayden", new DateTime(2022, 12, 28, 1, 9, 42, 776, DateTimeKind.Local).AddTicks(2505), "Adrianna_Gutmann15@hotmail.com", "Adrianna", "Adrianna Gutmann", false, "Gutmann", "(311) 339-7882", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/364.jpg", "Studentxi4rHXto" },
                    { 3, "1835 Bauch Rapids, Terrencefurt, Trinidad and Tobago", "West Darwinton", new DateTime(2022, 11, 2, 9, 51, 5, 596, DateTimeKind.Local).AddTicks(7737), "Bernice_Fahey@gmail.com", "Bernice", "Bernice Fahey", false, "Fahey", "352-843-1851 x48696", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1221.jpg", "Studentuu99mCav" },
                    { 4, "1988 Betty Walk, Caitlynberg, Nicaragua", "Schambergertown", new DateTime(2022, 11, 25, 2, 59, 37, 15, DateTimeKind.Local).AddTicks(4865), "Pearl_Ledner@hotmail.com", "Pearl", "Pearl Ledner", true, "Ledner", "595-622-5987 x0804", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/917.jpg", "Studentei9UXxUD" },
                    { 5, "0374 Mikel Club, Armstrongbury, Honduras", "Christiansenborough", new DateTime(2023, 8, 6, 9, 10, 55, 662, DateTimeKind.Local).AddTicks(9236), "Josianne.Turcotte@gmail.com", "Josianne", "Josianne Turcotte", false, "Turcotte", "260.770.6345 x294", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1017.jpg", "StudentFNCUkCXT" },
                    { 6, "7320 Ciara Groves, South Andreane, Micronesia", "Lake Alizaton", new DateTime(2022, 11, 29, 6, 43, 16, 572, DateTimeKind.Local).AddTicks(9022), "Pete11@gmail.com", "Pete", "Pete West", true, "West", "1-282-702-1274 x21671", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1245.jpg", "Studentk0ChBNGM" },
                    { 7, "69466 Owen Springs, South Antonina, Trinidad and Tobago", "Yazminstad", new DateTime(2023, 8, 18, 15, 21, 14, 272, DateTimeKind.Local).AddTicks(6602), "Larue_Orn79@yahoo.com", "Larue", "Larue Orn", true, "Orn", "896.574.5644 x70882", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1119.jpg", "StudentUYs39lB6" },
                    { 8, "77273 Kunze Wall, Jorgeberg, Spain", "Oswaldofurt", new DateTime(2023, 5, 24, 6, 56, 51, 576, DateTimeKind.Local).AddTicks(3598), "Nickolas.Feil@yahoo.com", "Nickolas", "Nickolas Feil", false, "Feil", "1-803-207-0837", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/405.jpg", "StudentSI66HEx1" },
                    { 9, "79557 Jarod Lake, Adamshaven, Algeria", "Mattshire", new DateTime(2023, 3, 20, 10, 54, 19, 548, DateTimeKind.Local).AddTicks(5363), "Camron_Labadie@gmail.com", "Camron", "Camron Labadie", false, "Labadie", "925.768.6347 x9227", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/520.jpg", "Student14KinbLz" },
                    { 10, "9669 Lind Course, Traceyhaven, Ukraine", "North Louvenia", new DateTime(2023, 5, 27, 17, 20, 37, 347, DateTimeKind.Local).AddTicks(7798), "Holden_Luettgen19@yahoo.com", "Holden", "Holden Luettgen", false, "Luettgen", "1-787-729-0505", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/405.jpg", "StudentVDRzoYqy" },
                    { 11, "339 Jamil Inlet, Willmsmouth, Tanzania", "Heidenreichchester", new DateTime(2023, 2, 13, 7, 4, 5, 111, DateTimeKind.Local).AddTicks(1867), "Lavon64@gmail.com", "Lavon", "Lavon Armstrong", true, "Armstrong", "455-412-4131", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/587.jpg", "Student1JzOo8Cr" },
                    { 12, "6519 Oberbrunner Spurs, Lindgrenmouth, Faroe Islands", "Jaclynland", new DateTime(2023, 5, 5, 22, 2, 27, 780, DateTimeKind.Local).AddTicks(4801), "Marisol15@gmail.com", "Marisol", "Marisol Raynor", true, "Raynor", "518-246-4415 x353", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/501.jpg", "Student1D9zCh3D" },
                    { 13, "723 Eugenia Groves, Watersland, Ghana", "West Leannabury", new DateTime(2023, 2, 23, 3, 44, 16, 233, DateTimeKind.Local).AddTicks(4832), "Jamal.McLaughlin@gmail.com", "Jamal", "Jamal McLaughlin", false, "McLaughlin", "(922) 951-1896 x6338", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/50.jpg", "StudentJJKFBTni" },
                    { 14, "3335 Morar Tunnel, New Letitia, Cuba", "Vincenzotown", new DateTime(2023, 6, 1, 11, 17, 58, 56, DateTimeKind.Local).AddTicks(956), "Pearlie_Watsica59@gmail.com", "Pearlie", "Pearlie Watsica", false, "Watsica", "674-525-9636 x533", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/759.jpg", "StudentO89l6U3T" },
                    { 15, "8516 Aileen Prairie, Hoppechester, Jordan", "North Camylleburgh", new DateTime(2023, 1, 19, 19, 18, 33, 817, DateTimeKind.Local).AddTicks(5692), "Prince.Gerhold@gmail.com", "Prince", "Prince Gerhold", true, "Gerhold", "996-472-6762 x2764", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/946.jpg", "StudentDHJ61CQE" },
                    { 16, "0789 Kuhic Lodge, Port Allen, Greece", "Cieloview", new DateTime(2022, 10, 5, 18, 12, 48, 90, DateTimeKind.Local).AddTicks(8542), "Reid.Hahn@hotmail.com", "Reid", "Reid Hahn", true, "Hahn", "987-935-5086", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/733.jpg", "StudentJ5g5xBw9" },
                    { 17, "18216 Ratke Parks, North Jeromy, France", "Erdmanfurt", new DateTime(2023, 7, 26, 7, 20, 33, 183, DateTimeKind.Local).AddTicks(2866), "Marcel11@hotmail.com", "Marcel", "Marcel Homenick", true, "Homenick", "320-610-1967 x5135", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/424.jpg", "StudentulQldN7S" },
                    { 18, "70264 Katharina Ports, Aaronside, Belgium", "Abigayleborough", new DateTime(2022, 10, 9, 4, 35, 52, 408, DateTimeKind.Local).AddTicks(6026), "Annabell_Rau@gmail.com", "Annabell", "Annabell Rau", true, "Rau", "460.753.2627 x483", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/622.jpg", "StudentIDTpzrB1" },
                    { 19, "19017 Adams Falls, New Napoleon, Albania", "Isaiasburgh", new DateTime(2022, 10, 29, 8, 39, 44, 362, DateTimeKind.Local).AddTicks(3528), "Kavon.Hickle@gmail.com", "Kavon", "Kavon Hickle", true, "Hickle", "(908) 708-4079", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/96.jpg", "Studentgi8Vsydm" },
                    { 20, "22684 Pearlie Island, West Erickaview, Tanzania", "Guidofurt", new DateTime(2022, 10, 22, 14, 53, 12, 394, DateTimeKind.Local).AddTicks(3874), "Erica.Corkery@gmail.com", "Erica", "Erica Corkery", false, "Corkery", "348.880.8828 x885", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/125.jpg", "Student8c40d46Y" },
                    { 21, "47835 Rice Burg, Cristalberg, Anguilla", "Myrtieberg", new DateTime(2022, 9, 30, 17, 37, 31, 685, DateTimeKind.Local).AddTicks(6439), "Joey.Zboncak86@yahoo.com", "Joey", "Joey Zboncak", false, "Zboncak", "764-734-7712 x2495", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/196.jpg", "Student5NUbgXH0" },
                    { 22, "88057 Richie Stravenue, Millsbury, Morocco", "New Verniceland", new DateTime(2023, 2, 25, 17, 12, 29, 662, DateTimeKind.Local).AddTicks(373), "Maye88@hotmail.com", "Maye", "Maye Paucek", true, "Paucek", "1-677-910-9405 x6989", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1249.jpg", "StudentwQfDELaI" },
                    { 23, "4001 Oswaldo Course, Leeborough, Republic of Korea", "Williamsonfurt", new DateTime(2023, 8, 22, 5, 58, 11, 379, DateTimeKind.Local).AddTicks(5119), "Nichole.Hane25@gmail.com", "Nichole", "Nichole Hane", false, "Hane", "458.436.8173 x335", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/983.jpg", "StudentoVeM3udt" },
                    { 24, "303 Pagac Views, Lake Raul, Cayman Islands", "Micaelaborough", new DateTime(2022, 11, 14, 5, 36, 28, 780, DateTimeKind.Local).AddTicks(4081), "Nelson45@gmail.com", "Nelson", "Nelson Fritsch", false, "Fritsch", "328-676-3978 x895", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/807.jpg", "Student12GCcUil" },
                    { 25, "732 Alphonso Club, East Domenicamouth, American Samoa", "Fernandotown", new DateTime(2023, 3, 30, 5, 44, 36, 286, DateTimeKind.Local).AddTicks(5696), "Shyann10@gmail.com", "Shyann", "Shyann Gislason", true, "Gislason", "1-683-505-5196 x725", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/702.jpg", "Student7vdL64OD" },
                    { 26, "7686 Luettgen Squares, South Shanonburgh, Spain", "Prohaskaland", new DateTime(2023, 8, 22, 20, 34, 31, 305, DateTimeKind.Local).AddTicks(6834), "Gudrun.Miller9@gmail.com", "Gudrun", "Gudrun Miller", true, "Miller", "488-283-9942 x90496", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1052.jpg", "StudentvrehRNGS" },
                    { 27, "9592 Lisandro Square, South Victoriaborough, Venezuela", "West Woodrow", new DateTime(2023, 8, 16, 16, 11, 43, 802, DateTimeKind.Local).AddTicks(5857), "Creola.Waters39@yahoo.com", "Creola", "Creola Waters", true, "Waters", "497.372.4142 x661", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/310.jpg", "StudenttG8aHUDg" },
                    { 28, "69992 Green Burg, Mackenzieborough, Paraguay", "Ziemannport", new DateTime(2023, 4, 28, 13, 53, 6, 499, DateTimeKind.Local).AddTicks(9449), "Ellis.Buckridge@gmail.com", "Ellis", "Ellis Buckridge", false, "Buckridge", "1-235-531-8916 x031", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/905.jpg", "Student5ESqu6ef" },
                    { 29, "9966 Herman Points, Pfannerstillside, Tonga", "Hodkiewiczchester", new DateTime(2023, 9, 24, 19, 26, 8, 392, DateTimeKind.Local).AddTicks(2), "Rick21@hotmail.com", "Rick", "Rick Krajcik", false, "Krajcik", "442-480-3314", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/175.jpg", "Student9KJKah4U" },
                    { 30, "23188 Mueller Meadow, Port Diana, Brunei Darussalam", "South Armaniland", new DateTime(2022, 10, 28, 4, 48, 7, 686, DateTimeKind.Local).AddTicks(5534), "Orville_Senger@gmail.com", "Orville", "Orville Senger", false, "Senger", "725.685.5691", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1205.jpg", "StudentltHigqbc" },
                    { 31, "075 Hudson Plains, East Johantown, Cape Verde", "Amandaburgh", new DateTime(2023, 5, 28, 20, 29, 24, 113, DateTimeKind.Local).AddTicks(7711), "Jacinthe83@hotmail.com", "Jacinthe", "Jacinthe Brown", false, "Brown", "884.581.4656", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/340.jpg", "StudentqVYkwRrH" },
                    { 32, "65067 Lucio Fork, Kossland, Lesotho", "New Dangelo", new DateTime(2023, 5, 19, 21, 47, 42, 114, DateTimeKind.Local).AddTicks(3538), "Adolfo.Crist@hotmail.com", "Adolfo", "Adolfo Crist", false, "Crist", "(841) 319-4610 x295", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/24.jpg", "Student1xBNjqZR" },
                    { 33, "5279 Jacquelyn Keys, New Javon, Djibouti", "New Jaydaburgh", new DateTime(2023, 8, 31, 5, 17, 3, 17, DateTimeKind.Local).AddTicks(1050), "Jackeline.Herzog57@yahoo.com", "Jackeline", "Jackeline Herzog", true, "Herzog", "(894) 935-0120 x3739", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/997.jpg", "StudentBxkrYTEi" },
                    { 34, "79072 Wiza Throughway, Dibbertborough, Mauritius", "West Amelieborough", new DateTime(2023, 7, 20, 10, 38, 57, 348, DateTimeKind.Local).AddTicks(5729), "Elvie55@hotmail.com", "Elvie", "Elvie Prosacco", false, "Prosacco", "1-365-762-5593 x6546", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/166.jpg", "StudentFBNesaLE" },
                    { 35, "145 Raynor Drives, Augustusstad, Philippines", "North Zettaview", new DateTime(2023, 4, 25, 17, 57, 19, 57, DateTimeKind.Local).AddTicks(5932), "Ivy_OKeefe99@hotmail.com", "Ivy", "Ivy O'Keefe", false, "O'Keefe", "904.656.8631", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/469.jpg", "StudentZ9X3BlPZ" },
                    { 36, "40178 Schaefer Cliffs, Port Rachellechester, Libyan Arab Jamahiriya", "Reinholdville", new DateTime(2023, 3, 11, 20, 47, 44, 911, DateTimeKind.Local).AddTicks(7914), "Doyle_Reynolds36@gmail.com", "Doyle", "Doyle Reynolds", true, "Reynolds", "(278) 535-6248 x9445", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/873.jpg", "Student48dpp3qN" },
                    { 37, "814 Gerard Rapids, West Benedictborough, Uruguay", "Tryciaport", new DateTime(2023, 5, 29, 1, 5, 49, 842, DateTimeKind.Local).AddTicks(4018), "Vada_Larson@yahoo.com", "Vada", "Vada Larson", true, "Larson", "(401) 651-3108 x30432", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/728.jpg", "StudentmVwcQH9O" },
                    { 38, "1211 Erwin Knolls, Helmerton, Japan", "Rheamouth", new DateTime(2023, 6, 24, 0, 42, 6, 940, DateTimeKind.Local).AddTicks(5393), "Zackary_Barrows77@gmail.com", "Zackary", "Zackary Barrows", true, "Barrows", "1-454-683-7239", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1249.jpg", "StudentYX7ag6Ow" },
                    { 39, "622 Gutkowski Well, South Winfieldberg, Northern Mariana Islands", "New Opheliaview", new DateTime(2022, 10, 1, 7, 28, 10, 330, DateTimeKind.Local).AddTicks(9249), "Alessandra.Moen66@yahoo.com", "Alessandra", "Alessandra Moen", true, "Moen", "604.666.2986 x49609", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/253.jpg", "Student1zhzDNNz" },
                    { 40, "5533 Marietta Square, Wunschville, Poland", "New Clarkbury", new DateTime(2022, 10, 25, 15, 50, 39, 526, DateTimeKind.Local).AddTicks(7900), "Liza_Jacobs@gmail.com", "Liza", "Liza Jacobs", true, "Jacobs", "445.906.0161 x99210", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1061.jpg", "Student1Vx9TUb0" },
                    { 41, "478 Name Crossing, Lake Nicoton, Saint Martin", "Kihnborough", new DateTime(2023, 5, 30, 2, 5, 57, 426, DateTimeKind.Local).AddTicks(2843), "Carleton34@gmail.com", "Carleton", "Carleton Mitchell", false, "Mitchell", "674-592-8274", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/394.jpg", "StudentD5X2DmwU" },
                    { 42, "51614 Odie Valleys, Zackaryshire, Armenia", "West Kaydentown", new DateTime(2022, 11, 21, 17, 7, 49, 377, DateTimeKind.Local).AddTicks(2130), "Minnie.Blanda@gmail.com", "Minnie", "Minnie Blanda", false, "Blanda", "846-802-3651 x83241", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/452.jpg", "Student9R2ZzS1S" },
                    { 43, "9103 Jeanie Gateway, Hudsonmouth, Mauritania", "Lake Mina", new DateTime(2023, 4, 9, 11, 23, 57, 627, DateTimeKind.Local).AddTicks(9412), "Liliana_Hettinger@hotmail.com", "Liliana", "Liliana Hettinger", true, "Hettinger", "606-927-9309", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/446.jpg", "StudentaE4UwL6F" },
                    { 44, "03741 Isadore Freeway, Alexzanderberg, Niue", "Kreigerport", new DateTime(2023, 6, 25, 15, 18, 25, 818, DateTimeKind.Local).AddTicks(1359), "Icie.Hyatt4@hotmail.com", "Icie", "Icie Hyatt", false, "Hyatt", "267.544.4843", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/469.jpg", "Student5jTkiNfC" },
                    { 45, "53999 Antonia Turnpike, East Cornellchester, Uzbekistan", "Alvahstad", new DateTime(2023, 5, 26, 2, 14, 22, 582, DateTimeKind.Local).AddTicks(5946), "Laverne.West@yahoo.com", "Laverne", "Laverne West", false, "West", "(453) 608-4146", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/506.jpg", "Student6a50vW1b" },
                    { 46, "51811 Sienna Mews, Kihntown, Moldova", "Lake Enaberg", new DateTime(2022, 11, 11, 9, 9, 52, 662, DateTimeKind.Local).AddTicks(3298), "Jessica99@gmail.com", "Jessica", "Jessica Herman", false, "Herman", "859.940.8165 x020", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/472.jpg", "StudentvOCWu0Nm" },
                    { 47, "3581 Carole Burgs, Raeganfurt, Bouvet Island (Bouvetoya)", "Mariannebury", new DateTime(2023, 5, 3, 1, 3, 59, 834, DateTimeKind.Local).AddTicks(3887), "Zander.Lang77@hotmail.com", "Zander", "Zander Lang", false, "Lang", "1-833-441-8657 x6504", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/722.jpg", "Student7fVW29aV" },
                    { 48, "46331 Kihn Ford, Kingland, Egypt", "Lake Miltonburgh", new DateTime(2023, 1, 2, 18, 1, 9, 920, DateTimeKind.Local).AddTicks(9634), "Cleve15@hotmail.com", "Cleve", "Cleve Berge", false, "Berge", "764.683.7150 x202", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/342.jpg", "StudentfTkhktyz" },
                    { 49, "4504 Fisher Brooks, Allenefurt, Timor-Leste", "North Jevonport", new DateTime(2023, 9, 10, 15, 40, 31, 526, DateTimeKind.Local).AddTicks(9364), "Price.Howell39@gmail.com", "Price", "Price Howell", false, "Howell", "866.545.7221", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/437.jpg", "Student5akLmWSw" },
                    { 50, "104 Hills Tunnel, South Bessieland, Somalia", "Blairhaven", new DateTime(2023, 7, 11, 15, 0, 17, 25, DateTimeKind.Local).AddTicks(697), "Jevon.Tromp@gmail.com", "Jevon", "Jevon Tromp", false, "Tromp", "(787) 913-6102", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/276.jpg", "StudentZh58PDKB" }
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
