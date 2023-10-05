using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbNews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNews", x => x.ID);
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
                name: "tbTicketDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSupporter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameSupporter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTicketDTO", x => x.Id);
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
                    EmailToConfirm = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NewsID = table.Column<int>(type: "int", nullable: false),
                    NewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbComments_tbNews_NewsID",
                        column: x => x.NewsID,
                        principalTable: "tbNews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupporterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbFacilities_tbUsers_SupporterId",
                        column: x => x.SupporterId,
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
                    Connected = table.Column<bool>(type: "bit", nullable: false),
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
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                columns: new[] { "Id", "Description", "Name", "SupporterId" },
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
                columns: new[] { "Id", "Code", "Email", "EmailToConfirm", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "erwWnHCe", "superadmin@gmail.com", null, "$2a$11$GplMA8ihdJPV9KdyoQN9GeA.iRYWSCuct8ebGvGJsMfmCtOWqun.O", "Admin", true, "SuperAdmin" },
                    { 2, "QAZO2Mhn", "supporter@gmail.com", null, "$2a$11$YzEwnSmYZmpXepwSAglXhOoj8E8Tn058jVhYE03pLqfw71QWkTuFu", "Supporter", true, "Supporter" },
                    { 3, "DgzcA1x8", "user@gmail.com", null, "$2a$11$MjBvuXErzMLoiHPtbVm/D.bgZtIevg6xfYVoSqJCSoeNwwsYo.YfW", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "3889 Gabriel Fork, Lake Martinaport, Macedonia", "West Albin", new DateTime(2023, 2, 21, 16, 6, 18, 157, DateTimeKind.Local).AddTicks(3814), "onhdexmapletest1991@gmail.com", "Melany", "Melany Gislason", true, "Gislason", "244.569.3925 x95106", "StudentGAbWR8Uz" },
                    { 3, "93611 Von Rue, Feliciafort, French Guiana", "Strosinshire", new DateTime(2023, 8, 18, 21, 24, 0, 59, DateTimeKind.Local).AddTicks(6067), "onhdexmapletest1993@gmail.com", "Demarco", "Demarco Heller", false, "Heller", "(505) 396-2868 x606", "StudentDIqjmNBx" },
                    { 5, "3784 Wintheiser Place, Quentinchester, Syrian Arab Republic", "New Madilyn", new DateTime(2023, 10, 3, 9, 22, 14, 34, DateTimeKind.Local).AddTicks(7495), "onhdexmapletest1995@gmail.com", "Alaina", "Alaina Klocko", true, "Klocko", "833.690.5958 x76935", "StudentYQzTVd72" },
                    { 7, "9732 Norbert Run, East Javonmouth, Bolivia", "Danielville", new DateTime(2022, 12, 29, 15, 34, 35, 830, DateTimeKind.Local).AddTicks(6286), "onhdexmapletest1997@gmail.com", "Rocky", "Rocky King", true, "King", "779.303.9828 x3801", "StudentNqqwS4pk" },
                    { 9, "55982 Ullrich Shores, Rippinland, Iraq", "East Rey", new DateTime(2023, 2, 9, 17, 49, 36, 823, DateTimeKind.Local).AddTicks(3356), "onhdexmapletest1999@gmail.com", "Candice", "Candice Torp", false, "Torp", "736-669-5721", "StudenthdGQo0Vt" },
                    { 11, "38915 Marty Plains, Schuppefort, Monaco", "Carterberg", new DateTime(2022, 11, 18, 22, 57, 44, 634, DateTimeKind.Local).AddTicks(1948), "onhdexmapletest19911@gmail.com", "Robert", "Robert King", false, "King", "946-376-6721", "Student2nrSC1Kd" },
                    { 13, "0003 Reynolds Plains, Valentinetown, Rwanda", "Lake Candacetown", new DateTime(2022, 10, 11, 11, 5, 49, 933, DateTimeKind.Local).AddTicks(7217), "onhdexmapletest19913@gmail.com", "Eliza", "Eliza Frami", false, "Frami", "(796) 458-4439 x5492", "Student6MKlsd2g" },
                    { 15, "35926 Gutmann Hollow, West Deonte, Maldives", "West Nadia", new DateTime(2023, 5, 26, 20, 27, 2, 765, DateTimeKind.Local).AddTicks(1249), "onhdexmapletest19915@gmail.com", "Leanna", "Leanna Quitzon", false, "Quitzon", "1-449-309-3662 x1998", "Student6dCown88" },
                    { 17, "8325 Mia Summit, Paulton, Tajikistan", "East Diegoton", new DateTime(2023, 4, 26, 13, 58, 11, 974, DateTimeKind.Local).AddTicks(3950), "onhdexmapletest19917@gmail.com", "Gaston", "Gaston Kling", false, "Kling", "427.464.3036 x4695", "Student3RnnrwMc" },
                    { 19, "405 Tillman Garden, East Rachelburgh, Trinidad and Tobago", "New Arvidchester", new DateTime(2023, 9, 22, 21, 36, 29, 504, DateTimeKind.Local).AddTicks(2808), "onhdexmapletest19919@gmail.com", "Marcelle", "Marcelle Lebsack", true, "Lebsack", "731.331.8682 x036", "StudentErW8vZL6" },
                    { 21, "63151 Cole Rapid, Port Jasmin, Sudan", "Fredericmouth", new DateTime(2023, 5, 26, 9, 16, 38, 468, DateTimeKind.Local).AddTicks(1760), "onhdexmapletest19921@gmail.com", "Dillan", "Dillan Herzog", true, "Herzog", "278-500-5506", "StudentJsaPp0b2" },
                    { 23, "4570 Rowe Creek, Gloverton, Botswana", "New Xavier", new DateTime(2022, 11, 7, 19, 56, 5, 429, DateTimeKind.Local).AddTicks(7198), "onhdexmapletest19923@gmail.com", "Winnifred", "Winnifred Conroy", true, "Conroy", "1-628-504-4681", "Student2JHAIqyh" },
                    { 25, "97685 Jessica Plain, Kulaschester, Cote d'Ivoire", "Jenaborough", new DateTime(2022, 10, 22, 3, 31, 48, 585, DateTimeKind.Local).AddTicks(4888), "onhdexmapletest19925@gmail.com", "Melvina", "Melvina O'Conner", false, "O'Conner", "1-455-665-0239", "Student2ZsJQMuh" },
                    { 27, "756 Wyman Plains, Marvinberg, Rwanda", "Katlynnborough", new DateTime(2022, 12, 28, 16, 59, 51, 116, DateTimeKind.Local).AddTicks(1974), "onhdexmapletest19927@gmail.com", "Jaqueline", "Jaqueline Jast", true, "Jast", "1-897-235-9433 x860", "StudentNLsGR2qF" },
                    { 29, "83631 Stamm Lane, Leilaland, Bahrain", "Runteport", new DateTime(2023, 7, 1, 17, 6, 35, 485, DateTimeKind.Local).AddTicks(823), "onhdexmapletest19929@gmail.com", "Rosina", "Rosina D'Amore", true, "D'Amore", "1-805-344-2635 x415", "Studentbylsdr5D" },
                    { 31, "04575 Daugherty Plain, Bentonmouth, Spain", "West Addie", new DateTime(2022, 10, 25, 22, 49, 6, 35, DateTimeKind.Local).AddTicks(2832), "onhdexmapletest19931@gmail.com", "Myrtice", "Myrtice Zulauf", false, "Zulauf", "513.257.2522", "StudentevOHzDgE" },
                    { 33, "33490 Runte Isle, Amaraside, Svalbard & Jan Mayen Islands", "West Maribel", new DateTime(2023, 1, 25, 23, 51, 21, 227, DateTimeKind.Local).AddTicks(4422), "onhdexmapletest19933@gmail.com", "Ronny", "Ronny Bradtke", true, "Bradtke", "(925) 911-7087", "Studentp5rHvV2p" },
                    { 35, "9342 Cordell Crossing, East Mattshire, Japan", "Abelardomouth", new DateTime(2023, 7, 5, 10, 31, 12, 542, DateTimeKind.Local).AddTicks(926), "onhdexmapletest19935@gmail.com", "Mavis", "Mavis Harvey", true, "Harvey", "943.794.7592 x893", "StudentKyliH2Kl" },
                    { 37, "86641 Andres Rapids, Sawaynton, Austria", "East Mireya", new DateTime(2023, 7, 28, 17, 36, 32, 215, DateTimeKind.Local).AddTicks(8748), "onhdexmapletest19937@gmail.com", "Lon", "Lon Wisozk", true, "Wisozk", "786.835.8403", "Student8uT57EaD" },
                    { 39, "38099 Carmen Loaf, Gracielashire, Georgia", "East Christianaton", new DateTime(2023, 3, 18, 4, 6, 7, 463, DateTimeKind.Local).AddTicks(5382), "onhdexmapletest19939@gmail.com", "Bryon", "Bryon Boyle", false, "Boyle", "(668) 962-4340 x718", "Student1beR2bw2" },
                    { 41, "47611 Schroeder Creek, Oberbrunnerbury, El Salvador", "East Una", new DateTime(2023, 10, 2, 4, 5, 50, 515, DateTimeKind.Local).AddTicks(4585), "onhdexmapletest19941@gmail.com", "Ludie", "Ludie Gleichner", false, "Gleichner", "908-217-9776", "StudentDve9ZIrb" },
                    { 43, "685 Alysson Crescent, East Melanyhaven, Malawi", "New Eusebiofurt", new DateTime(2022, 12, 18, 7, 58, 32, 400, DateTimeKind.Local).AddTicks(49), "onhdexmapletest19943@gmail.com", "Landen", "Landen Ullrich", false, "Ullrich", "647.911.4799 x2268", "StudentidYZeDZf" },
                    { 45, "1263 Pink Radial, South Zola, Cocos (Keeling) Islands", "Walkerland", new DateTime(2023, 1, 20, 4, 41, 0, 688, DateTimeKind.Local).AddTicks(1209), "onhdexmapletest19945@gmail.com", "Autumn", "Autumn Crona", true, "Crona", "953.254.6791", "Student6QBDbOmZ" },
                    { 47, "2921 Blanca Point, Halvorsonchester, Maldives", "Isaiahville", new DateTime(2022, 11, 2, 22, 47, 36, 455, DateTimeKind.Local).AddTicks(6878), "onhdexmapletest19947@gmail.com", "Rogelio", "Rogelio Sporer", true, "Sporer", "243.536.1457", "StudentumnTLTIY" },
                    { 49, "0684 Tamara Mission, West Catherine, Turkmenistan", "Feestport", new DateTime(2022, 10, 25, 16, 2, 46, 997, DateTimeKind.Local).AddTicks(4547), "onhdexmapletest19949@gmail.com", "Favian", "Favian Bernhard", true, "Bernhard", "1-572-963-2478 x905", "StudentlJ9IXlfQ" },
                    { 51, "680 Ankunding Greens, Peytonton, Turks and Caicos Islands", "Jeromeburgh", new DateTime(2023, 6, 20, 5, 52, 19, 248, DateTimeKind.Local).AddTicks(1923), "onhdexmapletest19951@gmail.com", "Shyann", "Shyann Predovic", false, "Predovic", "413.851.2481 x3114", "Student6cDMLnzl" },
                    { 53, "80891 Lockman Track, Lake Alanis, Guernsey", "West Jamal", new DateTime(2023, 3, 3, 15, 12, 29, 842, DateTimeKind.Local).AddTicks(8813), "onhdexmapletest19953@gmail.com", "Nyah", "Nyah Schoen", false, "Schoen", "503-964-1594 x89607", "StudentSA02t9az" },
                    { 55, "94010 Mabelle River, Robertsfort, Gambia", "South Vanessa", new DateTime(2023, 8, 10, 7, 4, 39, 163, DateTimeKind.Local).AddTicks(5410), "onhdexmapletest19955@gmail.com", "Consuelo", "Consuelo Fritsch", true, "Fritsch", "(500) 254-5144", "StudentwiVDJwuq" },
                    { 57, "55487 Martina Parks, Titoland, Singapore", "Groverchester", new DateTime(2023, 6, 28, 16, 52, 59, 642, DateTimeKind.Local).AddTicks(5669), "onhdexmapletest19957@gmail.com", "Geraldine", "Geraldine Schmidt", false, "Schmidt", "915.898.0448", "StudentuTaTpdKA" },
                    { 59, "806 Schaefer Rue, Mosciskiburgh, Comoros", "Marlenfort", new DateTime(2023, 7, 20, 18, 25, 44, 286, DateTimeKind.Local).AddTicks(525), "onhdexmapletest19959@gmail.com", "Brady", "Brady Runte", true, "Runte", "571-992-3430 x594", "StudenttjUvcD4r" },
                    { 61, "14365 Larson Cape, Brionnaside, Dominica", "New Jovanymouth", new DateTime(2023, 1, 29, 13, 40, 43, 624, DateTimeKind.Local).AddTicks(5574), "onhdexmapletest19961@gmail.com", "Stan", "Stan Maggio", true, "Maggio", "(417) 547-9422", "Studentiq13Y2GU" },
                    { 63, "5192 Renner Throughway, Lutherburgh, Hungary", "Heathcotechester", new DateTime(2023, 9, 17, 21, 29, 51, 410, DateTimeKind.Local).AddTicks(6026), "onhdexmapletest19963@gmail.com", "Emmy", "Emmy Kub", false, "Kub", "(556) 366-7881 x674", "StudentXn7mOgCn" },
                    { 65, "2850 Satterfield Mill, East Marjolaine, Guyana", "Schummton", new DateTime(2023, 9, 5, 4, 38, 25, 289, DateTimeKind.Local).AddTicks(9953), "onhdexmapletest19965@gmail.com", "Ryann", "Ryann Luettgen", true, "Luettgen", "(538) 781-6710 x63732", "StudentWHftCZse" },
                    { 67, "23243 Isobel Streets, Billyside, Cayman Islands", "Derekmouth", new DateTime(2023, 8, 29, 6, 5, 23, 699, DateTimeKind.Local).AddTicks(1570), "onhdexmapletest19967@gmail.com", "Agustin", "Agustin Schumm", false, "Schumm", "958-945-8849 x24045", "StudenthBHWPstS" },
                    { 69, "63138 Larson Plaza, South Sallie, Syrian Arab Republic", "Lake Coby", new DateTime(2023, 8, 21, 18, 45, 27, 217, DateTimeKind.Local).AddTicks(895), "onhdexmapletest19969@gmail.com", "Johanna", "Johanna Ondricka", false, "Ondricka", "1-764-957-8106 x710", "StudentbCRODBmJ" },
                    { 71, "103 Seth Groves, Franeckiville, Bahrain", "Lake Kitty", new DateTime(2023, 3, 17, 5, 28, 21, 646, DateTimeKind.Local).AddTicks(3751), "onhdexmapletest19971@gmail.com", "Lupe", "Lupe Jenkins", false, "Jenkins", "706-681-1229 x417", "StudentgPby1GoG" },
                    { 73, "8074 Hipolito Meadow, New Genesisfurt, Guadeloupe", "West Arthur", new DateTime(2023, 7, 3, 23, 38, 48, 4, DateTimeKind.Local).AddTicks(724), "onhdexmapletest19973@gmail.com", "Reta", "Reta Waters", false, "Waters", "375-585-5203 x1674", "StudentIR8Y3u0z" },
                    { 75, "330 Kaylee Run, East Godfreymouth, Namibia", "Littelborough", new DateTime(2023, 6, 5, 19, 13, 27, 717, DateTimeKind.Local).AddTicks(3864), "onhdexmapletest19975@gmail.com", "Daija", "Daija Klocko", false, "Klocko", "991.532.7137 x972", "StudentkbSMkG4O" },
                    { 77, "93776 Considine Junction, West Yeseniastad, Japan", "East Zander", new DateTime(2022, 11, 7, 13, 26, 28, 283, DateTimeKind.Local).AddTicks(1955), "onhdexmapletest19977@gmail.com", "Ruby", "Ruby Labadie", true, "Labadie", "(972) 705-5553 x4953", "StudentV5L4mOmw" },
                    { 79, "9287 Madyson Centers, West Deronhaven, Ecuador", "Runolfsdottirburgh", new DateTime(2022, 10, 23, 22, 36, 29, 275, DateTimeKind.Local).AddTicks(9915), "onhdexmapletest19979@gmail.com", "Joe", "Joe Rolfson", false, "Rolfson", "275.555.6718 x76364", "Student8pOeeUJB" },
                    { 81, "4204 Werner Light, Ocietown, Hungary", "West Montyhaven", new DateTime(2023, 5, 8, 5, 16, 3, 796, DateTimeKind.Local).AddTicks(8321), "onhdexmapletest19981@gmail.com", "Edmund", "Edmund Aufderhar", false, "Aufderhar", "500-563-6290", "StudentKcxDKcZu" },
                    { 83, "38479 Johnny Springs, Gustton, Bulgaria", "Walterville", new DateTime(2023, 6, 6, 13, 29, 3, 684, DateTimeKind.Local).AddTicks(1277), "onhdexmapletest19983@gmail.com", "Belle", "Belle Collins", true, "Collins", "891.585.7775 x14248", "StudentEYB2fTMi" },
                    { 85, "47127 Marjolaine Station, Lake Jessychester, Christmas Island", "Wisokyburgh", new DateTime(2023, 8, 11, 17, 31, 5, 412, DateTimeKind.Local).AddTicks(4955), "onhdexmapletest19985@gmail.com", "Ruth", "Ruth Kuhlman", true, "Kuhlman", "746.785.5862 x814", "StudentJB6AJfSE" },
                    { 87, "45666 Maya Meadows, East Brentchester, Slovenia", "East Jackson", new DateTime(2023, 6, 1, 11, 47, 3, 729, DateTimeKind.Local).AddTicks(2950), "onhdexmapletest19987@gmail.com", "Madilyn", "Madilyn Lowe", true, "Lowe", "356.292.6263", "StudentNRYQl7wg" },
                    { 89, "420 Jones View, Benedictbury, Ecuador", "Port Ransomburgh", new DateTime(2023, 3, 5, 19, 50, 12, 558, DateTimeKind.Local).AddTicks(9190), "onhdexmapletest19989@gmail.com", "Reba", "Reba Von", true, "Von", "440-893-9959 x919", "StudentovFCv3NH" },
                    { 91, "7722 Rutherford Highway, Reinholdville, Costa Rica", "Ferryview", new DateTime(2023, 3, 2, 15, 33, 21, 652, DateTimeKind.Local).AddTicks(690), "onhdexmapletest19991@gmail.com", "Lizeth", "Lizeth Bergnaum", true, "Bergnaum", "597.814.5975 x1071", "StudentmXto2WL7" },
                    { 93, "3127 Sauer Ports, West Sasha, Brunei Darussalam", "Douglasberg", new DateTime(2023, 2, 11, 0, 26, 34, 469, DateTimeKind.Local).AddTicks(3377), "onhdexmapletest19993@gmail.com", "Miles", "Miles Emard", false, "Emard", "985.432.5527 x03367", "StudentWvDWxBj0" },
                    { 95, "295 Alverta Passage, New Wilfordmouth, Zimbabwe", "Kuphalside", new DateTime(2023, 3, 29, 0, 6, 23, 263, DateTimeKind.Local).AddTicks(8146), "onhdexmapletest19995@gmail.com", "Donald", "Donald Botsford", true, "Botsford", "787-427-8551", "StudentvbrkSv8B" },
                    { 97, "3944 Velva Manors, Marcelleborough, Pakistan", "South Terence", new DateTime(2023, 4, 30, 20, 16, 57, 989, DateTimeKind.Local).AddTicks(889), "onhdexmapletest19997@gmail.com", "Olen", "Olen Kessler", true, "Kessler", "310-209-8987 x92956", "Student1sNB4s4T" },
                    { 99, "145 Jacobs Wall, Hobartton, Heard Island and McDonald Islands", "Mozelleshire", new DateTime(2023, 8, 26, 10, 22, 41, 920, DateTimeKind.Local).AddTicks(6774), "onhdexmapletest19999@gmail.com", "Ahmed", "Ahmed Wolf", true, "Wolf", "1-513-397-4285 x1905", "StudentkxK9AFdS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbComments_NewsID",
                table: "tbComments",
                column: "NewsID");

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
                name: "IX_tbFacilities_SupporterId",
                table: "tbFacilities",
                column: "SupporterId");

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
                name: "tbTicketDTO");

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
