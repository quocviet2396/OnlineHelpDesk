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
                name: "tbComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbComments_tbNews_NewId",
                        column: x => x.NewId,
                        principalTable: "tbNews",
                        principalColumn: "Id");
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
                    { 1, "WEew0r0T", "superadmin@gmail.com", "$2a$11$6E4upKWkfmKiubuw9SpFSuszHVOUBYfif7fip9GPgT8xZ3VHOhgWC", "Admin", true, "SuperAdmin" },
                    { 2, "kci5zn51", "supporter@gmail.com", "$2a$11$Tn0I8M09s8NO3p4jSzg86Ox/QHEJ7IWLZtEWkG71cWGngGJTtVPSm", "Supporter", true, "Supporter" },
                    { 3, "kgngFfdH", "user@gmail.com", "$2a$11$Xa1Cs5RawuXbjP4YFm7KheQeQrxZHB/Qo6twuoy9wVzlVFIcuSaH.", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Photo", "Student_code" },
                values: new object[,]
                {
                    { 1, "78322 Maybelle Mountain, Arnebury, Sudan", "Haileehaven", new DateTime(2023, 6, 15, 22, 22, 12, 236, DateTimeKind.Local).AddTicks(6335), "Khalid_Rosenbaum@yahoo.com", "Khalid", "Khalid Rosenbaum", false, "Rosenbaum", "(900) 525-0632", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/352.jpg", "Student5jfOSfsS" },
                    { 2, "63823 Gleichner Lodge, Schmidtville, Afghanistan", "Hartmannmouth", new DateTime(2023, 5, 11, 17, 52, 27, 827, DateTimeKind.Local).AddTicks(4879), "Bertram.Aufderhar79@gmail.com", "Bertram", "Bertram Aufderhar", false, "Aufderhar", "319-352-9756", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/732.jpg", "StudentxSy4UBtM" },
                    { 3, "20018 Carmella Motorway, West Ethelhaven, Fiji", "New Christaton", new DateTime(2023, 4, 4, 22, 24, 28, 83, DateTimeKind.Local).AddTicks(1601), "Josefina.Heller@yahoo.com", "Josefina", "Josefina Heller", false, "Heller", "461.975.9730 x28582", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/50.jpg", "StudenthcRArqMB" },
                    { 4, "58874 D'Amore Ville, North Willatown, Madagascar", "Port Thaliatown", new DateTime(2022, 12, 21, 11, 13, 36, 806, DateTimeKind.Local).AddTicks(2420), "Alejandra71@hotmail.com", "Alejandra", "Alejandra O'Conner", false, "O'Conner", "1-785-457-2400 x28575", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/396.jpg", "StudentecJ6SBVz" },
                    { 5, "48319 Delbert Fall, Dooleyberg, Ireland", "Port Christopfort", new DateTime(2022, 10, 14, 5, 58, 31, 700, DateTimeKind.Local).AddTicks(8024), "Lucie.Corwin9@yahoo.com", "Lucie", "Lucie Corwin", true, "Corwin", "1-799-676-2299", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/325.jpg", "Studentaxdqt4f0" },
                    { 6, "26075 Schaden Underpass, Nickolasfort, Mauritius", "East Makayla", new DateTime(2023, 5, 1, 17, 42, 58, 841, DateTimeKind.Local).AddTicks(272), "Evelyn61@gmail.com", "Evelyn", "Evelyn Schoen", true, "Schoen", "1-576-245-8079 x121", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/712.jpg", "Studentld8smzkS" },
                    { 7, "090 Jacobs Pine, West Andreane, Pitcairn Islands", "Watsonport", new DateTime(2023, 2, 19, 17, 26, 27, 387, DateTimeKind.Local).AddTicks(522), "Gabriel38@gmail.com", "Gabriel", "Gabriel Trantow", true, "Trantow", "(899) 688-6779 x74788", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/390.jpg", "Student7kphLlUZ" },
                    { 8, "377 Eino Roads, Melodytown, Jersey", "Port Enidburgh", new DateTime(2023, 4, 8, 1, 35, 42, 896, DateTimeKind.Local).AddTicks(3147), "Carolyn.Bauch28@hotmail.com", "Carolyn", "Carolyn Bauch", false, "Bauch", "706.800.0902", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/490.jpg", "Student4R5xIKJi" },
                    { 9, "82466 Janis Fork, East Ike, India", "Aminafurt", new DateTime(2023, 3, 11, 10, 53, 11, 629, DateTimeKind.Local).AddTicks(4780), "Ethelyn_Kerluke75@gmail.com", "Ethelyn", "Ethelyn Kerluke", false, "Kerluke", "1-651-759-6185 x971", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1198.jpg", "Studenticc64uaP" },
                    { 10, "79186 Terence Forks, Langworthville, Cameroon", "New Sandrine", new DateTime(2022, 11, 21, 23, 16, 30, 825, DateTimeKind.Local).AddTicks(3997), "Gabriella31@gmail.com", "Gabriella", "Gabriella Pfeffer", true, "Pfeffer", "1-378-759-7900", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/215.jpg", "Student0YE3AFSe" },
                    { 11, "876 Stark Forest, New Julius, Croatia", "East Tierra", new DateTime(2022, 12, 2, 7, 14, 36, 880, DateTimeKind.Local).AddTicks(6945), "Vallie_Ortiz2@hotmail.com", "Vallie", "Vallie Ortiz", false, "Ortiz", "387.380.8068", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/921.jpg", "Student3nvBgH0l" },
                    { 12, "943 Pacocha Fords, Delilahmouth, Lao People's Democratic Republic", "New Lilla", new DateTime(2023, 1, 12, 17, 39, 26, 653, DateTimeKind.Local).AddTicks(514), "Riley_Kassulke45@yahoo.com", "Riley", "Riley Kassulke", false, "Kassulke", "1-366-819-8993 x235", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/91.jpg", "StudentxrpgqnUB" },
                    { 13, "698 Selina Field, East Kylie, Yemen", "Hattieland", new DateTime(2023, 9, 24, 1, 45, 47, 759, DateTimeKind.Local).AddTicks(5714), "Ashtyn.Grant53@gmail.com", "Ashtyn", "Ashtyn Grant", true, "Grant", "217-203-1992", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/935.jpg", "StudentNr6C7Tt3" },
                    { 14, "01094 Amina Inlet, East Dorothea, Tanzania", "Mckennamouth", new DateTime(2023, 2, 16, 22, 55, 49, 876, DateTimeKind.Local).AddTicks(9791), "Riley18@gmail.com", "Riley", "Riley Kub", false, "Kub", "(281) 696-3981", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/363.jpg", "StudentHnfD2TQT" },
                    { 15, "030 Bauch Mount, Marinaton, Saint Martin", "Toyfort", new DateTime(2022, 10, 21, 3, 56, 55, 30, DateTimeKind.Local).AddTicks(900), "Roma53@gmail.com", "Roma", "Roma Roberts", true, "Roberts", "(266) 730-5494 x70209", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1071.jpg", "StudentMuwsGMR9" },
                    { 16, "0864 Saige Junction, Parisberg, Bangladesh", "Leuschkeport", new DateTime(2022, 12, 14, 8, 1, 56, 216, DateTimeKind.Local).AddTicks(7403), "Toby.Auer75@hotmail.com", "Toby", "Toby Auer", false, "Auer", "663.354.3592 x270", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/38.jpg", "StudentwA6LbphO" },
                    { 17, "077 Ratke Harbors, East Aimeeburgh, Panama", "East Jerrod", new DateTime(2023, 9, 22, 12, 22, 40, 68, DateTimeKind.Local).AddTicks(6562), "Lesley_Hickle@hotmail.com", "Lesley", "Lesley Hickle", true, "Hickle", "988.311.8171", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/334.jpg", "StudentSdjeWSzW" },
                    { 18, "169 Fermin Villages, Shanaland, Honduras", "West Asia", new DateTime(2022, 9, 29, 19, 40, 47, 485, DateTimeKind.Local).AddTicks(6146), "Kacey49@gmail.com", "Kacey", "Kacey Ankunding", false, "Ankunding", "1-608-576-3557", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/143.jpg", "StudentU7sH2a4Q" },
                    { 19, "42786 Salvatore Track, Lake Brandon, Djibouti", "New Missouri", new DateTime(2023, 1, 16, 11, 15, 56, 681, DateTimeKind.Local).AddTicks(9513), "Marquise.Stokes@hotmail.com", "Marquise", "Marquise Stokes", true, "Stokes", "376.542.3183", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/928.jpg", "StudentAp1AQa3a" },
                    { 20, "2796 Desiree Station, Corneliuston, South Georgia and the South Sandwich Islands", "North Josephland", new DateTime(2023, 5, 25, 1, 40, 54, 996, DateTimeKind.Local).AddTicks(7250), "Jerrell.Gerhold@yahoo.com", "Jerrell", "Jerrell Gerhold", false, "Gerhold", "442-705-0972 x8135", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1245.jpg", "StudentdnGEZnQG" },
                    { 21, "907 Little Locks, Madgeview, Chad", "North Marilie", new DateTime(2023, 7, 19, 18, 17, 42, 696, DateTimeKind.Local).AddTicks(1746), "Arlo_McGlynn7@yahoo.com", "Arlo", "Arlo McGlynn", true, "McGlynn", "(629) 365-2912 x124", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/973.jpg", "StudentFLL9nlE4" },
                    { 22, "71312 Tremblay Radial, Johnathonhaven, United Arab Emirates", "North Emmymouth", new DateTime(2023, 2, 9, 11, 8, 32, 370, DateTimeKind.Local).AddTicks(5615), "Ofelia82@hotmail.com", "Ofelia", "Ofelia Thompson", true, "Thompson", "829-952-8250", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1056.jpg", "Studentua1kqkWE" },
                    { 23, "6306 Christine Squares, Macejkovicfurt, Morocco", "Maggiohaven", new DateTime(2022, 12, 9, 22, 31, 40, 2, DateTimeKind.Local).AddTicks(8168), "Kylee_Wisozk64@yahoo.com", "Kylee", "Kylee Wisozk", false, "Wisozk", "1-683-237-6295", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/385.jpg", "StudentEuCdOe8f" },
                    { 24, "81233 Mack Mall, East Wadechester, Romania", "Anitaside", new DateTime(2023, 2, 16, 0, 4, 54, 851, DateTimeKind.Local).AddTicks(8227), "Lysanne.Gusikowski@yahoo.com", "Lysanne", "Lysanne Gusikowski", false, "Gusikowski", "700-885-4823 x81572", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/431.jpg", "StudentYF5kgj21" },
                    { 25, "11970 Myrtice Drive, Trentonshire, Austria", "Lake Juvenalbury", new DateTime(2023, 6, 11, 9, 9, 5, 47, DateTimeKind.Local).AddTicks(4203), "Chance.Hoeger@gmail.com", "Chance", "Chance Hoeger", true, "Hoeger", "949.903.1742", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/450.jpg", "StudentrJWf8aho" },
                    { 26, "1082 Walker Glen, Olatown, Slovakia (Slovak Republic)", "New Treychester", new DateTime(2022, 12, 16, 20, 54, 11, 470, DateTimeKind.Local).AddTicks(1378), "Nichole_Hansen@hotmail.com", "Nichole", "Nichole Hansen", false, "Hansen", "(979) 963-0622", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1153.jpg", "StudenttN9Pi768" },
                    { 27, "25409 Jaylon Roads, Port Londonton, Gibraltar", "South Shayna", new DateTime(2023, 9, 2, 12, 5, 11, 653, DateTimeKind.Local).AddTicks(4820), "Efrain_Heaney72@gmail.com", "Efrain", "Efrain Heaney", true, "Heaney", "(455) 804-1714", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/570.jpg", "StudentHAJ0L1EK" },
                    { 28, "98569 Carter Island, South Corneliusberg, Saudi Arabia", "Rolfsonberg", new DateTime(2023, 1, 7, 0, 8, 22, 773, DateTimeKind.Local).AddTicks(7590), "Winifred.Farrell@yahoo.com", "Winifred", "Winifred Farrell", true, "Farrell", "1-585-965-5947 x948", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/645.jpg", "StudentR52iP1jo" },
                    { 29, "31714 Emmie Rue, West Vanville, Belarus", "Gottliebville", new DateTime(2023, 7, 18, 1, 42, 29, 655, DateTimeKind.Local).AddTicks(7923), "Graciela.Kuphal@yahoo.com", "Graciela", "Graciela Kuphal", true, "Kuphal", "(359) 640-0782", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/742.jpg", "StudentfZFQtQop" },
                    { 30, "30105 Destinee Villages, Brakusland, Latvia", "Spencerton", new DateTime(2023, 6, 18, 3, 33, 47, 863, DateTimeKind.Local).AddTicks(5043), "Earl_Dickens@hotmail.com", "Earl", "Earl Dickens", true, "Dickens", "(947) 853-5980 x832", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/129.jpg", "StudentW8zDzEo7" },
                    { 31, "991 Konopelski Forge, Keyshawnbury, Palestinian Territory", "Darrellbury", new DateTime(2023, 3, 21, 13, 47, 7, 610, DateTimeKind.Local).AddTicks(6574), "Cordia.Wilderman99@gmail.com", "Cordia", "Cordia Wilderman", false, "Wilderman", "946.436.2197", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/22.jpg", "StudentdUlXGrmH" },
                    { 32, "0193 Veum Points, Vidaborough, Tuvalu", "Bauchmouth", new DateTime(2023, 2, 22, 2, 53, 11, 213, DateTimeKind.Local).AddTicks(1923), "Alysha_Blick@yahoo.com", "Alysha", "Alysha Blick", false, "Blick", "(569) 653-6671", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1080.jpg", "Student2P6mq8oY" },
                    { 33, "174 Brakus Valley, South Webstertown, Germany", "East Destiney", new DateTime(2023, 2, 11, 2, 20, 0, 259, DateTimeKind.Local).AddTicks(4829), "Talon22@gmail.com", "Talon", "Talon Schoen", true, "Schoen", "512.766.2908", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/887.jpg", "Student4ed4bGvg" },
                    { 34, "755 Jessy Lodge, Chynabury, Haiti", "Konopelskifort", new DateTime(2023, 7, 5, 4, 53, 3, 267, DateTimeKind.Local).AddTicks(2712), "Baylee_Bauch72@yahoo.com", "Baylee", "Baylee Bauch", true, "Bauch", "239.590.0753 x98736", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/478.jpg", "Studentf7XzCQMr" },
                    { 35, "1672 Reinger Inlet, Port Stephenbury, Kyrgyz Republic", "Ryanberg", new DateTime(2023, 9, 2, 0, 36, 39, 132, DateTimeKind.Local).AddTicks(4833), "Bettye_Graham@hotmail.com", "Bettye", "Bettye Graham", false, "Graham", "1-532-334-2614 x303", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/220.jpg", "StudentyEA3Msn1" },
                    { 36, "95131 Barton Pike, Amaramouth, Vanuatu", "New Maybelleview", new DateTime(2022, 12, 23, 14, 43, 32, 956, DateTimeKind.Local).AddTicks(8145), "Jade50@yahoo.com", "Jade", "Jade Ratke", true, "Ratke", "(289) 802-4627 x359", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1051.jpg", "Studentwh4fQk5d" },
                    { 37, "32402 London Ranch, Littleberg, Heard Island and McDonald Islands", "West Mackenzie", new DateTime(2022, 9, 27, 9, 26, 34, 342, DateTimeKind.Local).AddTicks(5862), "Nannie.Rath54@yahoo.com", "Nannie", "Nannie Rath", false, "Rath", "(302) 747-8511", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/731.jpg", "StudentiPd3GFG2" },
                    { 38, "30241 Mia Mission, Barrowsfort, Rwanda", "New Immanuel", new DateTime(2023, 7, 12, 11, 58, 50, 483, DateTimeKind.Local).AddTicks(7719), "Ines20@hotmail.com", "Ines", "Ines Mayert", true, "Mayert", "1-513-774-8454", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/112.jpg", "StudentINpgaYUo" },
                    { 39, "19031 McKenzie Circles, Lake Aracely, Timor-Leste", "Nakiamouth", new DateTime(2023, 1, 20, 7, 31, 52, 991, DateTimeKind.Local).AddTicks(3499), "Jeanie5@hotmail.com", "Jeanie", "Jeanie Klein", false, "Klein", "1-213-633-2689 x109", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/236.jpg", "StudentR0idQldE" },
                    { 40, "58477 Bashirian Curve, North Adeleborough, Luxembourg", "East Rhianna", new DateTime(2023, 8, 23, 12, 37, 27, 488, DateTimeKind.Local).AddTicks(110), "Mia.Willms54@gmail.com", "Mia", "Mia Willms", false, "Willms", "(679) 560-1649 x4094", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/721.jpg", "StudentE6AYZpv8" },
                    { 41, "11000 Tara Junctions, Halieland, Chad", "North Barbara", new DateTime(2023, 4, 18, 0, 58, 37, 688, DateTimeKind.Local).AddTicks(8283), "Cordia16@yahoo.com", "Cordia", "Cordia Hahn", false, "Hahn", "(455) 562-2967 x115", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/589.jpg", "StudentrfzGbjF5" },
                    { 42, "9353 Isom Well, Daughertyfort, Angola", "Lake Kody", new DateTime(2023, 9, 23, 9, 54, 0, 131, DateTimeKind.Local).AddTicks(8370), "Armando_Schmeler32@yahoo.com", "Armando", "Armando Schmeler", false, "Schmeler", "216.493.7584 x21070", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/195.jpg", "StudentNRcwiSzM" },
                    { 43, "8587 Ned View, North Scottie, Libyan Arab Jamahiriya", "Rempelbury", new DateTime(2023, 6, 13, 19, 13, 24, 415, DateTimeKind.Local).AddTicks(8449), "Nathaniel17@hotmail.com", "Nathaniel", "Nathaniel Upton", false, "Upton", "1-961-784-5560 x35465", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1142.jpg", "StudentAkDZMkqg" },
                    { 44, "409 Weber Spring, Satterfieldberg, Belgium", "East Pietro", new DateTime(2022, 10, 14, 5, 37, 16, 731, DateTimeKind.Local).AddTicks(2174), "Eveline56@gmail.com", "Eveline", "Eveline Mosciski", false, "Mosciski", "1-639-481-6432 x3639", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1015.jpg", "StudentM6yus3Rr" },
                    { 45, "6142 Emard Flat, Boyleborough, Burundi", "Adelatown", new DateTime(2023, 1, 6, 2, 32, 23, 499, DateTimeKind.Local).AddTicks(8588), "Ruthie66@hotmail.com", "Ruthie", "Ruthie Kassulke", false, "Kassulke", "1-667-357-7420", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/205.jpg", "StudentfWh4rYQc" },
                    { 46, "60767 Beer Springs, East Fern, Armenia", "West Anya", new DateTime(2023, 6, 10, 9, 25, 44, 983, DateTimeKind.Local).AddTicks(1691), "Melisa54@hotmail.com", "Melisa", "Melisa Oberbrunner", true, "Oberbrunner", "360.760.8911 x6676", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1149.jpg", "StudentFd3FgU9C" },
                    { 47, "8106 Schowalter Rue, West Colemanbury, Cuba", "Tatestad", new DateTime(2023, 5, 12, 3, 29, 50, 132, DateTimeKind.Local).AddTicks(1104), "Eriberto.Wisozk41@yahoo.com", "Eriberto", "Eriberto Wisozk", true, "Wisozk", "707-607-4601", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/285.jpg", "StudentIGhiOkL7" },
                    { 48, "1280 Ziemann Coves, East Betsy, Bahrain", "New Kiera", new DateTime(2023, 5, 24, 18, 33, 36, 32, DateTimeKind.Local).AddTicks(1844), "Alysa_King95@gmail.com", "Alysa", "Alysa King", false, "King", "(632) 749-5888 x963", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/202.jpg", "StudentgHiQ9rEx" },
                    { 49, "39937 Murray Road, Lewisport, Brazil", "New Mario", new DateTime(2022, 11, 2, 7, 6, 48, 467, DateTimeKind.Local).AddTicks(7691), "Andres85@gmail.com", "Andres", "Andres Towne", false, "Towne", "1-461-308-3662 x10119", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/546.jpg", "Studentdg1LCjUX" },
                    { 50, "141 Payton Plains, Lydiaport, Argentina", "Ubaldohaven", new DateTime(2022, 10, 21, 17, 43, 44, 849, DateTimeKind.Local).AddTicks(6823), "Freddie.OConner@yahoo.com", "Freddie", "Freddie O'Conner", true, "O'Conner", "644.524.2705 x770", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/587.jpg", "Student9s9Qt7We" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbComments_NewId",
                table: "tbComments",
                column: "NewId");

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
