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
                name: "tbNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    readed = table.Column<bool>(type: "bit", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    userConnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNotification", x => x.Id);
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
                    readed = table.Column<bool>(type: "bit", nullable: true),
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
                name: "tbUserConn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Connected = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    NotiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserConn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbUserConn_tbNotification_NotiId",
                        column: x => x.NotiId,
                        principalTable: "tbNotification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbUserConn_tbUsers_UserId",
                        column: x => x.UserId,
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
                    { 1, "itj2DlfG", "superadmin@gmail.com", "$2a$11$nNkQJmN.K4JKxYZC/qY0xOMMUEH.TyZbaHLMiObtDZWvYzoPronTG", "Admin", true, "SuperAdmin" },
                    { 2, "RS4ofJIq", "supporter@gmail.com", "$2a$11$CUvx.JWNfz8UAOzyFQRH8eJLGXvOF39StEvSpxmM/e.FlRudzgDfq", "Supporter", true, "Supporter" },
                    { 3, "nsQTZCG7", "user@gmail.com", "$2a$11$3X9SIL1cP/pFvde6WRKRROPFKF9.97hVtmzOBc4tag6grM7SqOa2y", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "93210 Herman Park, North Dawsonborough, Democratic People's Republic of Korea", "Hollismouth", new DateTime(2023, 4, 13, 15, 10, 37, 997, DateTimeKind.Local).AddTicks(5441), "onhdexmapletest1991@gmail.com", "Allen", "Allen Bernier", false, "Bernier", "561.551.4426", "Student1Xu4S3zt" },
                    { 3, "10279 Cody Keys, South Emelieside, Svalbard & Jan Mayen Islands", "Port Ebonyshire", new DateTime(2022, 10, 27, 19, 36, 32, 365, DateTimeKind.Local).AddTicks(9672), "onhdexmapletest1993@gmail.com", "Angeline", "Angeline Wiza", true, "Wiza", "1-641-436-4586", "StudentsXYWPVqG" },
                    { 5, "473 Emmy Ways, Deronport, Macedonia", "West Gilesberg", new DateTime(2023, 4, 19, 13, 46, 51, 475, DateTimeKind.Local).AddTicks(6536), "onhdexmapletest1995@gmail.com", "Katelynn", "Katelynn Conroy", false, "Conroy", "943.322.1951 x4767", "Student9DyE3se5" },
                    { 7, "617 Macejkovic Ramp, Port Fionaberg, Luxembourg", "North Wallace", new DateTime(2023, 3, 12, 8, 5, 43, 154, DateTimeKind.Local).AddTicks(7946), "onhdexmapletest1997@gmail.com", "Judy", "Judy Kunde", true, "Kunde", "(973) 598-0191", "StudentwyHX6kTW" },
                    { 9, "670 Shyann Wells, Lake Delfina, Burkina Faso", "Lake Henrifurt", new DateTime(2022, 10, 4, 0, 11, 7, 77, DateTimeKind.Local).AddTicks(8137), "onhdexmapletest1999@gmail.com", "Vivianne", "Vivianne Marquardt", false, "Marquardt", "1-909-506-9100 x29339", "StudenttcI2B8lv" },
                    { 11, "80572 Fay Mews, East Willis, Bahamas", "North Leonora", new DateTime(2023, 7, 9, 11, 50, 24, 236, DateTimeKind.Local).AddTicks(8509), "onhdexmapletest19911@gmail.com", "Aaliyah", "Aaliyah Heller", true, "Heller", "328.576.7853", "StudentszgEjeCH" },
                    { 13, "383 Barbara Island, Charlenehaven, Canada", "North Trystan", new DateTime(2023, 1, 24, 1, 44, 34, 181, DateTimeKind.Local).AddTicks(787), "onhdexmapletest19913@gmail.com", "Louisa", "Louisa Larkin", false, "Larkin", "(551) 998-2745", "StudenteIxe37UN" },
                    { 15, "9795 Marks Station, Lake Reid, Suriname", "Randalmouth", new DateTime(2023, 3, 22, 4, 25, 8, 961, DateTimeKind.Local).AddTicks(7859), "onhdexmapletest19915@gmail.com", "Kenton", "Kenton Paucek", true, "Paucek", "520.335.6458 x55192", "Studentxnm2Pwue" },
                    { 17, "605 Lily Courts, Kennedymouth, Guinea", "Lake Ilianaport", new DateTime(2023, 6, 17, 1, 56, 42, 497, DateTimeKind.Local).AddTicks(7258), "onhdexmapletest19917@gmail.com", "Deborah", "Deborah Beatty", false, "Beatty", "226-523-6826 x25228", "StudentBsOammz8" },
                    { 19, "0317 Ernest Points, Mariabury, Burkina Faso", "South Holliechester", new DateTime(2023, 2, 13, 20, 40, 13, 92, DateTimeKind.Local).AddTicks(1040), "onhdexmapletest19919@gmail.com", "Damien", "Damien Luettgen", true, "Luettgen", "1-612-657-6087", "Studento6lmwB9t" },
                    { 21, "9535 Nader Wall, West Alfreda, Aruba", "South Amaya", new DateTime(2023, 8, 10, 22, 49, 49, 507, DateTimeKind.Local).AddTicks(3074), "onhdexmapletest19921@gmail.com", "Colin", "Colin Bartoletti", true, "Bartoletti", "1-915-479-1266 x2224", "StudentojbvCceO" },
                    { 23, "7939 Juliana Flat, Yostshire, Lesotho", "Lake Fredrick", new DateTime(2023, 9, 25, 13, 40, 27, 77, DateTimeKind.Local).AddTicks(3961), "onhdexmapletest19923@gmail.com", "Laurence", "Laurence Nitzsche", false, "Nitzsche", "646-961-6072 x0050", "Studentg5PfmSvZ" },
                    { 25, "2186 Crystel Loaf, Ellismouth, British Indian Ocean Territory (Chagos Archipelago)", "North Kiarrashire", new DateTime(2022, 12, 7, 17, 45, 4, 705, DateTimeKind.Local).AddTicks(7707), "onhdexmapletest19925@gmail.com", "Estrella", "Estrella Lehner", false, "Lehner", "(843) 936-0000 x9000", "Student8GzhXvXz" },
                    { 27, "1421 Patrick Motorway, Shieldsmouth, Cape Verde", "West Keenanville", new DateTime(2023, 9, 23, 1, 59, 16, 130, DateTimeKind.Local).AddTicks(3218), "onhdexmapletest19927@gmail.com", "Guy", "Guy Beatty", true, "Beatty", "1-237-669-0456 x06262", "StudentzhsxqWqO" },
                    { 29, "39483 Hermiston Stream, Lake Karen, Gibraltar", "Batztown", new DateTime(2023, 9, 28, 11, 10, 33, 306, DateTimeKind.Local).AddTicks(450), "onhdexmapletest19929@gmail.com", "Stacey", "Stacey Block", false, "Block", "495.270.0835", "StudentwXEAbFJg" },
                    { 31, "9232 Block Lodge, Mooreville, Guatemala", "Rolfsonton", new DateTime(2023, 1, 14, 23, 25, 53, 152, DateTimeKind.Local).AddTicks(428), "onhdexmapletest19931@gmail.com", "Lane", "Lane Gleason", true, "Gleason", "(728) 873-1296 x9480", "StudentXTjwdqal" },
                    { 33, "372 Marlen Villages, South Caleb, Ethiopia", "Hackettland", new DateTime(2023, 7, 31, 21, 13, 3, 329, DateTimeKind.Local).AddTicks(1382), "onhdexmapletest19933@gmail.com", "Retha", "Retha Considine", false, "Considine", "677.504.6643 x61060", "StudentN0vxEcCM" },
                    { 35, "2553 Ova Pines, West Cayla, Portugal", "Hickleside", new DateTime(2023, 8, 29, 13, 36, 17, 634, DateTimeKind.Local).AddTicks(5088), "onhdexmapletest19935@gmail.com", "Coty", "Coty King", false, "King", "(882) 583-5573 x374", "StudentBrT8qu5c" },
                    { 37, "260 Kenneth Mills, Kossborough, Germany", "Millerport", new DateTime(2023, 3, 31, 8, 48, 52, 160, DateTimeKind.Local).AddTicks(9513), "onhdexmapletest19937@gmail.com", "Kylie", "Kylie Dibbert", false, "Dibbert", "681.395.3199", "Student4RE1g0VY" },
                    { 39, "119 Marks Overpass, Ortizborough, Gambia", "Port Kobe", new DateTime(2023, 4, 19, 8, 54, 40, 38, DateTimeKind.Local).AddTicks(7816), "onhdexmapletest19939@gmail.com", "Darby", "Darby Luettgen", true, "Luettgen", "(679) 679-3805 x980", "Student9UJsJhBC" },
                    { 41, "94296 Lang Trail, South Jamey, Oman", "Gleasonmouth", new DateTime(2023, 2, 12, 15, 38, 5, 974, DateTimeKind.Local).AddTicks(9154), "onhdexmapletest19941@gmail.com", "Charlotte", "Charlotte Dooley", true, "Dooley", "(659) 423-4458 x16733", "StudentAMI73lZe" },
                    { 43, "559 Blanca Cliff, Colebury, Hungary", "Bednarbury", new DateTime(2023, 1, 23, 0, 37, 29, 514, DateTimeKind.Local).AddTicks(8430), "onhdexmapletest19943@gmail.com", "Jarrett", "Jarrett Goodwin", false, "Goodwin", "451.341.9606", "StudentisJV03to" },
                    { 45, "2675 Fahey Land, East Michealbury, Kuwait", "Lake Vena", new DateTime(2023, 3, 2, 21, 30, 29, 307, DateTimeKind.Local).AddTicks(5704), "onhdexmapletest19945@gmail.com", "Gillian", "Gillian Gutkowski", false, "Gutkowski", "474.538.1040 x9611", "StudentsqKDNNtL" },
                    { 47, "832 Gusikowski Stravenue, East Sarina, Syrian Arab Republic", "Lake Kaci", new DateTime(2023, 1, 29, 9, 17, 12, 34, DateTimeKind.Local).AddTicks(8584), "onhdexmapletest19947@gmail.com", "Clarabelle", "Clarabelle Hoeger", false, "Hoeger", "(535) 231-0572 x1808", "Studentif5xeF3p" },
                    { 49, "275 Torphy Lodge, Fayside, French Guiana", "Labadiehaven", new DateTime(2023, 5, 15, 4, 54, 5, 900, DateTimeKind.Local).AddTicks(180), "onhdexmapletest19949@gmail.com", "Waino", "Waino Corwin", true, "Corwin", "811-752-5964", "Student4ywbRaXC" },
                    { 51, "44060 Strosin Glens, Reymundohaven, Indonesia", "North Davon", new DateTime(2023, 4, 10, 16, 22, 19, 596, DateTimeKind.Local).AddTicks(4076), "onhdexmapletest19951@gmail.com", "Samanta", "Samanta Rohan", false, "Rohan", "(274) 416-7869 x4933", "StudentXKP7V6Zh" },
                    { 53, "23878 Barrows Pines, Denesikbury, Palestinian Territory", "Champlinland", new DateTime(2023, 5, 6, 3, 38, 3, 684, DateTimeKind.Local).AddTicks(6224), "onhdexmapletest19953@gmail.com", "Shanelle", "Shanelle Mueller", true, "Mueller", "1-660-825-6087 x578", "StudentiNcDdDG3" },
                    { 55, "334 Cyril Freeway, New Birdieport, Palau", "Kerlukeview", new DateTime(2023, 5, 2, 14, 37, 25, 714, DateTimeKind.Local).AddTicks(6909), "onhdexmapletest19955@gmail.com", "Terence", "Terence Adams", true, "Adams", "1-442-210-0873 x957", "StudentEGqtGkN4" },
                    { 57, "9134 Clotilde Way, Jazmintown, Latvia", "Nienowfurt", new DateTime(2023, 7, 20, 0, 37, 15, 825, DateTimeKind.Local).AddTicks(2956), "onhdexmapletest19957@gmail.com", "Lowell", "Lowell Marquardt", false, "Marquardt", "567.579.6159 x953", "StudentMtFmlZeZ" },
                    { 59, "24262 Ledner Route, Franciscomouth, Peru", "West Jeromyside", new DateTime(2023, 3, 6, 0, 8, 12, 795, DateTimeKind.Local).AddTicks(6640), "onhdexmapletest19959@gmail.com", "Diego", "Diego Greenholt", false, "Greenholt", "(929) 943-4361", "StudentirhoeArq" },
                    { 61, "755 Kiana Garden, South Haydenberg, Mali", "New Nadia", new DateTime(2023, 4, 21, 0, 41, 7, 984, DateTimeKind.Local).AddTicks(3594), "onhdexmapletest19961@gmail.com", "Chanel", "Chanel Abshire", true, "Abshire", "(370) 357-7926 x8311", "StudentPzgn2vpL" },
                    { 63, "70059 Bauch Plain, Monserratside, Ukraine", "Ludiehaven", new DateTime(2023, 7, 23, 23, 36, 38, 918, DateTimeKind.Local).AddTicks(2492), "onhdexmapletest19963@gmail.com", "Pierce", "Pierce Stracke", false, "Stracke", "466-316-7600 x3320", "StudentoPvFIV8y" },
                    { 65, "47981 Marks Plaza, Naderchester, Jordan", "East Waltonchester", new DateTime(2022, 11, 29, 3, 30, 26, 141, DateTimeKind.Local).AddTicks(3711), "onhdexmapletest19965@gmail.com", "Leila", "Leila Feeney", false, "Feeney", "1-731-409-5314 x82700", "Student9Q47k3a0" },
                    { 67, "1304 Gislason Union, West Roelfurt, Republic of Korea", "Torpview", new DateTime(2023, 1, 29, 12, 50, 44, 714, DateTimeKind.Local).AddTicks(5448), "onhdexmapletest19967@gmail.com", "Tiana", "Tiana Thompson", false, "Thompson", "1-552-537-8190 x087", "Studentzt8tKaWI" },
                    { 69, "3380 Jayme Falls, Chaunceystad, Moldova", "East Alaina", new DateTime(2023, 9, 24, 9, 38, 23, 682, DateTimeKind.Local).AddTicks(9610), "onhdexmapletest19969@gmail.com", "Libbie", "Libbie Schuppe", true, "Schuppe", "662-872-6543 x943", "Student1TQtXMEr" },
                    { 71, "18595 Keyon Center, Watsicaburgh, Netherlands", "East Twila", new DateTime(2023, 5, 13, 6, 26, 17, 884, DateTimeKind.Local).AddTicks(6184), "onhdexmapletest19971@gmail.com", "Robyn", "Robyn Goldner", false, "Goldner", "(403) 664-8254 x2131", "StudentZTJavVyS" },
                    { 73, "281 Izaiah Lodge, South Josephine, Sierra Leone", "Carterfort", new DateTime(2023, 1, 3, 0, 37, 2, 681, DateTimeKind.Local).AddTicks(5936), "onhdexmapletest19973@gmail.com", "Desiree", "Desiree Stokes", false, "Stokes", "586-315-7426 x6550", "StudentMdxxY4Ll" },
                    { 75, "09420 Eliza Forks, Georgianaport, Namibia", "Johathanstad", new DateTime(2023, 7, 28, 21, 54, 38, 100, DateTimeKind.Local).AddTicks(1380), "onhdexmapletest19975@gmail.com", "Melyssa", "Melyssa Kreiger", false, "Kreiger", "756.653.2242", "Studentu0nl1WNd" },
                    { 77, "7164 McLaughlin Row, Port Cleve, Jamaica", "Sengershire", new DateTime(2022, 10, 15, 17, 21, 52, 992, DateTimeKind.Local).AddTicks(8347), "onhdexmapletest19977@gmail.com", "Gracie", "Gracie Collier", false, "Collier", "(573) 273-7956 x54085", "Student2KkRaaHD" },
                    { 79, "7928 Deron Isle, Port Kayley, Gibraltar", "Reesetown", new DateTime(2023, 6, 30, 11, 49, 19, 460, DateTimeKind.Local).AddTicks(9468), "onhdexmapletest19979@gmail.com", "Nicholas", "Nicholas Mraz", true, "Mraz", "1-691-406-2383 x353", "Studentist0vAB5" },
                    { 81, "8217 Colleen Greens, Port Angela, Belarus", "East Jeanne", new DateTime(2023, 3, 13, 19, 39, 37, 303, DateTimeKind.Local).AddTicks(805), "onhdexmapletest19981@gmail.com", "Rashawn", "Rashawn Swift", true, "Swift", "(418) 538-3927", "StudentqeOK5tOa" },
                    { 83, "78556 Ivah Drives, East Eldred, Gibraltar", "Desireeville", new DateTime(2023, 2, 18, 6, 54, 9, 103, DateTimeKind.Local).AddTicks(68), "onhdexmapletest19983@gmail.com", "Madalyn", "Madalyn Koch", true, "Koch", "430-378-8216 x1647", "StudentBTN2ZjuH" },
                    { 85, "7183 Hertha Plaza, Florianside, Guadeloupe", "South Emmitt", new DateTime(2022, 11, 22, 6, 23, 7, 909, DateTimeKind.Local).AddTicks(5026), "onhdexmapletest19985@gmail.com", "Brennon", "Brennon Blick", false, "Blick", "766.487.5384 x936", "StudentY38yugcC" },
                    { 87, "29432 Littel Canyon, Giachester, Sierra Leone", "Nealside", new DateTime(2023, 2, 25, 19, 49, 32, 949, DateTimeKind.Local).AddTicks(4860), "onhdexmapletest19987@gmail.com", "Bulah", "Bulah Ondricka", true, "Ondricka", "(600) 412-0725 x7389", "StudentqBNAZdVt" },
                    { 89, "670 Lynch Village, Elysehaven, Mauritius", "Lake Claudiaberg", new DateTime(2023, 3, 7, 4, 30, 35, 340, DateTimeKind.Local).AddTicks(6165), "onhdexmapletest19989@gmail.com", "Arjun", "Arjun Goldner", false, "Goldner", "723.588.4340 x3151", "StudentNGb1k9lo" },
                    { 91, "3613 Abagail Underpass, South Lydiaview, Lithuania", "West Eusebiomouth", new DateTime(2023, 9, 13, 18, 8, 49, 670, DateTimeKind.Local).AddTicks(1787), "onhdexmapletest19991@gmail.com", "Elise", "Elise Lemke", true, "Lemke", "1-948-948-9400 x362", "StudentFBW98yXn" },
                    { 93, "392 Loraine Falls, Runtestad, Trinidad and Tobago", "Darehaven", new DateTime(2023, 9, 21, 20, 22, 17, 712, DateTimeKind.Local).AddTicks(5669), "onhdexmapletest19993@gmail.com", "Marisa", "Marisa Huel", false, "Huel", "(308) 696-3074 x88839", "Studentb2nShYm7" },
                    { 95, "79321 Pete Extension, South Brenda, Mauritania", "Kelsiton", new DateTime(2022, 12, 16, 18, 53, 27, 424, DateTimeKind.Local).AddTicks(9304), "onhdexmapletest19995@gmail.com", "Geo", "Geo Considine", true, "Considine", "806-974-1243", "StudentGAlfDodo" },
                    { 97, "3957 Jarrod Causeway, South Kennyhaven, Lebanon", "Gusikowskiland", new DateTime(2022, 11, 29, 21, 39, 22, 983, DateTimeKind.Local).AddTicks(5334), "onhdexmapletest19997@gmail.com", "Tate", "Tate Zieme", true, "Zieme", "635.452.2481 x40666", "StudentcLfWzpZu" },
                    { 99, "24325 Hartmann Locks, South Margie, Bangladesh", "North Cristobal", new DateTime(2023, 1, 30, 22, 36, 57, 309, DateTimeKind.Local).AddTicks(7955), "onhdexmapletest19999@gmail.com", "Dora", "Dora Becker", true, "Becker", "853.324.3521", "StudentCtEAd4qC" }
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
                name: "IX_tbUserConn_NotiId",
                table: "tbUserConn",
                column: "NotiId",
                unique: true,
                filter: "[NotiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserConn_UserId",
                table: "tbUserConn",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "tbUserConn");

            migrationBuilder.DropTable(
                name: "tbUserInfo");

            migrationBuilder.DropTable(
                name: "tbUsersInfo");

            migrationBuilder.DropTable(
                name: "tbNews");

            migrationBuilder.DropTable(
                name: "tbTicket");

            migrationBuilder.DropTable(
                name: "tbNotification");

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
