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
                    { 1, "s3mlbpSQ", "superadmin@gmail.com", "$2a$11$IhXCNdK4451wEoPEy4Byt.a6hfK6kChMYifwX.qA/Gs.sZZXPLgMe", "Admin", true, "SuperAdmin" },
                    { 2, "cVAxLY3n", "supporter@gmail.com", "$2a$11$3McJKSnp/oTpQjp2V5E6n.cDTKxbKCBULOeM2A9pa8BIllhjmPFnW", "Supporter", true, "Supporter" },
                    { 3, "DWMPBbMb", "user@gmail.com", "$2a$11$tBb/S.8hfd5z4wndT4UDv.sPO/xaO/CXcBzpCv74GDDZf0XV4Tzsq", "User", true, "User" }
                });

            migrationBuilder.InsertData(
                table: "tbUsersInfo",
                columns: new[] { "Id", "Address", "City", "DateOfBirth", "Email", "FirstName", "FullName", "Gender", "LastName", "Phone", "Student_code" },
                values: new object[,]
                {
                    { 1, "90911 Emard Camp, Levifort, Armenia", "East Steve", new DateTime(2023, 7, 27, 2, 52, 45, 814, DateTimeKind.Local).AddTicks(3365), "onhdexmapletest1991@gmail.com", "Glenda", "Glenda Rau", true, "Rau", "719.790.0634 x203", "Student8JEhqu1V" },
                    { 3, "37706 Angie Creek, Lake Emanuelview, Finland", "Dorafurt", new DateTime(2023, 5, 19, 22, 11, 19, 116, DateTimeKind.Local).AddTicks(9237), "onhdexmapletest1993@gmail.com", "Reid", "Reid Borer", true, "Borer", "583.845.3774 x222", "Studentl794cr9n" },
                    { 5, "91674 Karli Loaf, East Deangeloborough, Bangladesh", "Port Pamelaberg", new DateTime(2023, 2, 7, 1, 59, 59, 882, DateTimeKind.Local).AddTicks(3652), "onhdexmapletest1995@gmail.com", "Damian", "Damian Lowe", false, "Lowe", "456.292.3153", "Studentv61g4lCW" },
                    { 7, "94373 Pearline Pine, North Garryborough, Austria", "North Gracestad", new DateTime(2023, 8, 7, 6, 46, 47, 389, DateTimeKind.Local).AddTicks(3556), "onhdexmapletest1997@gmail.com", "Dariana", "Dariana Hayes", true, "Hayes", "830-754-0048", "StudentMdRuXePn" },
                    { 9, "463 Beer Union, Sydnifurt, Benin", "Schowalterview", new DateTime(2023, 4, 20, 2, 30, 22, 24, DateTimeKind.Local).AddTicks(786), "onhdexmapletest1999@gmail.com", "Maudie", "Maudie Nikolaus", true, "Nikolaus", "1-467-827-5811", "StudentHOFb7HSq" },
                    { 11, "85224 Mayer Meadows, Lebsackborough, Saint Pierre and Miquelon", "East Sallyberg", new DateTime(2022, 10, 9, 5, 10, 47, 922, DateTimeKind.Local).AddTicks(5886), "onhdexmapletest19911@gmail.com", "Evangeline", "Evangeline Cormier", false, "Cormier", "1-741-443-0315 x970", "Student29OVk4Dl" },
                    { 13, "19263 Marshall Land, East Freeda, Australia", "Arnoldton", new DateTime(2022, 10, 12, 10, 18, 33, 386, DateTimeKind.Local).AddTicks(1515), "onhdexmapletest19913@gmail.com", "Olaf", "Olaf Ferry", false, "Ferry", "398-426-9380 x1407", "StudentgGLwizpo" },
                    { 15, "7339 Antoinette Ridge, Jacinthemouth, Saint Helena", "North Johnathan", new DateTime(2023, 4, 11, 9, 55, 8, 913, DateTimeKind.Local).AddTicks(5152), "onhdexmapletest19915@gmail.com", "Arvel", "Arvel Runolfsdottir", true, "Runolfsdottir", "(468) 232-2658", "Studenti42XECCw" },
                    { 17, "294 Kub Causeway, Kemmertown, Estonia", "Morarchester", new DateTime(2022, 10, 29, 4, 14, 42, 644, DateTimeKind.Local).AddTicks(6306), "onhdexmapletest19917@gmail.com", "Arlo", "Arlo Reilly", true, "Reilly", "(246) 601-8820 x19640", "StudentSiy4yMNc" },
                    { 19, "6721 Alexander Underpass, Jessiemouth, United States of America", "Lake Carmela", new DateTime(2023, 2, 18, 23, 48, 19, 412, DateTimeKind.Local).AddTicks(2752), "onhdexmapletest19919@gmail.com", "Mathilde", "Mathilde Willms", true, "Willms", "847-769-1164 x969", "Studentkk6EwIzr" },
                    { 21, "96196 Laila Corners, West Allen, South Georgia and the South Sandwich Islands", "Keelingchester", new DateTime(2023, 3, 7, 19, 33, 26, 533, DateTimeKind.Local).AddTicks(1320), "onhdexmapletest19921@gmail.com", "Mariela", "Mariela Frami", true, "Frami", "734-634-6900 x767", "Student6LuZEUNx" },
                    { 23, "380 Robert Burgs, Myrtisbury, Denmark", "South Kenya", new DateTime(2023, 4, 4, 11, 12, 42, 271, DateTimeKind.Local).AddTicks(8910), "onhdexmapletest19923@gmail.com", "Mossie", "Mossie VonRueden", false, "VonRueden", "(926) 897-4867 x5464", "StudenteZEL32dX" },
                    { 25, "70704 Bayer Inlet, Lake Gabrielleview, Ethiopia", "Cristville", new DateTime(2023, 7, 8, 1, 45, 47, 260, DateTimeKind.Local).AddTicks(286), "onhdexmapletest19925@gmail.com", "Billy", "Billy Beatty", false, "Beatty", "1-671-203-5867 x0281", "StudentruZ4NVI6" },
                    { 27, "852 Bernard Squares, Electafurt, Lithuania", "Zboncakport", new DateTime(2022, 10, 27, 23, 24, 0, 553, DateTimeKind.Local).AddTicks(4114), "onhdexmapletest19927@gmail.com", "Christina", "Christina Hauck", true, "Hauck", "880-899-2033", "StudentS2bPjGne" },
                    { 29, "96362 Thompson Hills, East Danaland, Niue", "New Rosalynview", new DateTime(2023, 1, 1, 14, 24, 6, 57, DateTimeKind.Local).AddTicks(3150), "onhdexmapletest19929@gmail.com", "Waldo", "Waldo Sporer", false, "Sporer", "(875) 229-4565 x95019", "StudenttdfXgEi1" },
                    { 31, "483 Cyrus Terrace, Mitchellview, Oman", "Lake Sheldon", new DateTime(2023, 7, 7, 16, 22, 24, 191, DateTimeKind.Local).AddTicks(5728), "onhdexmapletest19931@gmail.com", "Dillon", "Dillon Rempel", false, "Rempel", "(994) 616-4449", "StudentFtTZCdO9" },
                    { 33, "028 Bernice Harbor, Port Barbara, Panama", "North Alyciaport", new DateTime(2023, 7, 19, 18, 28, 59, 152, DateTimeKind.Local).AddTicks(6370), "onhdexmapletest19933@gmail.com", "Gwen", "Gwen Emmerich", true, "Emmerich", "(303) 534-5493 x1358", "StudentGxTbOnim" },
                    { 35, "339 Dortha Green, Rupertview, Brunei Darussalam", "New Ruthe", new DateTime(2023, 3, 30, 22, 42, 0, 225, DateTimeKind.Local).AddTicks(2923), "onhdexmapletest19935@gmail.com", "Jena", "Jena Christiansen", true, "Christiansen", "449.923.5476", "Student3WhGr26K" },
                    { 37, "28867 Wilburn Road, North Joseph, Mauritania", "South Hortensechester", new DateTime(2023, 7, 22, 18, 49, 19, 289, DateTimeKind.Local).AddTicks(923), "onhdexmapletest19937@gmail.com", "Katelynn", "Katelynn Wehner", false, "Wehner", "964-575-0063 x62577", "Student55qGUrp2" },
                    { 39, "79016 McLaughlin Station, Friedaton, Christmas Island", "Martyport", new DateTime(2023, 9, 27, 12, 26, 46, 74, DateTimeKind.Local).AddTicks(8976), "onhdexmapletest19939@gmail.com", "Shaniya", "Shaniya Wilkinson", true, "Wilkinson", "(521) 988-5196 x3297", "StudentaqAuAJdK" },
                    { 41, "52174 Glover Estate, Port Karley, France", "Reyesland", new DateTime(2022, 11, 22, 16, 31, 46, 334, DateTimeKind.Local).AddTicks(6882), "onhdexmapletest19941@gmail.com", "Cleta", "Cleta Barrows", false, "Barrows", "786.731.9784", "StudentbzpO6v1t" },
                    { 43, "928 Edmund Tunnel, Connview, Haiti", "East Enolashire", new DateTime(2022, 11, 25, 18, 35, 38, 209, DateTimeKind.Local).AddTicks(6910), "onhdexmapletest19943@gmail.com", "Beverly", "Beverly Dickens", true, "Dickens", "250-260-5357 x3344", "Student0B4fC3pe" },
                    { 45, "187 Donnelly Shore, Port Trudiehaven, Poland", "Boylefort", new DateTime(2023, 1, 10, 4, 50, 23, 245, DateTimeKind.Local).AddTicks(7695), "onhdexmapletest19945@gmail.com", "Lorna", "Lorna Denesik", false, "Denesik", "1-861-949-2267 x4180", "Studentroce8zbj" },
                    { 47, "1696 Spencer Hills, East Arafurt, Western Sahara", "Aurorechester", new DateTime(2023, 4, 7, 20, 44, 58, 40, DateTimeKind.Local).AddTicks(7612), "onhdexmapletest19947@gmail.com", "Devin", "Devin Koepp", false, "Koepp", "747-817-8638 x96527", "StudentTTbiVKeD" },
                    { 49, "6303 Hodkiewicz Lakes, New Darrinville, Suriname", "Lake Emieburgh", new DateTime(2023, 1, 17, 20, 35, 40, 509, DateTimeKind.Local).AddTicks(2284), "onhdexmapletest19949@gmail.com", "River", "River Hirthe", true, "Hirthe", "(723) 683-2500 x320", "StudentnSn8Mk6V" },
                    { 51, "481 Abshire Pines, Handport, Jersey", "West Dennisburgh", new DateTime(2023, 4, 29, 4, 50, 35, 182, DateTimeKind.Local).AddTicks(6910), "onhdexmapletest19951@gmail.com", "Billy", "Billy Brekke", false, "Brekke", "(862) 515-5711 x3465", "Students0Q9b0Mc" },
                    { 53, "1707 Jedidiah Land, Port Heaven, Lithuania", "East Samson", new DateTime(2023, 1, 25, 18, 29, 3, 413, DateTimeKind.Local).AddTicks(9259), "onhdexmapletest19953@gmail.com", "Corine", "Corine Ortiz", true, "Ortiz", "(453) 611-7563", "StudentpRtyRzWL" },
                    { 55, "95143 Wilkinson Locks, Emmerichport, Monaco", "Lake Antwonville", new DateTime(2023, 8, 3, 16, 56, 52, 555, DateTimeKind.Local).AddTicks(8584), "onhdexmapletest19955@gmail.com", "Antwan", "Antwan Ratke", true, "Ratke", "830.201.0854 x2747", "Studentsdzk4mPo" },
                    { 57, "7293 McGlynn Junctions, Trompfurt, French Guiana", "Port Tre", new DateTime(2023, 6, 26, 4, 4, 37, 775, DateTimeKind.Local).AddTicks(1155), "onhdexmapletest19957@gmail.com", "Zander", "Zander Mante", true, "Mante", "343.852.0404", "StudentLUAPbior" },
                    { 59, "250 Immanuel Forks, Champlinmouth, Albania", "New Fredrick", new DateTime(2023, 4, 12, 13, 40, 17, 460, DateTimeKind.Local).AddTicks(232), "onhdexmapletest19959@gmail.com", "Lester", "Lester Marquardt", true, "Marquardt", "1-809-849-2778 x939", "Studentbis8W4kj" },
                    { 61, "708 Marcellus Place, East Arielle, Uzbekistan", "Hettingerchester", new DateTime(2023, 8, 9, 7, 50, 11, 388, DateTimeKind.Local).AddTicks(8750), "onhdexmapletest19961@gmail.com", "Jude", "Jude Rath", true, "Rath", "1-868-437-1065 x393", "StudentkpwHKoNc" },
                    { 63, "229 Jaime Junction, Clementinastad, Albania", "Katelyntown", new DateTime(2023, 9, 6, 21, 30, 54, 180, DateTimeKind.Local).AddTicks(4416), "onhdexmapletest19963@gmail.com", "Edwina", "Edwina Champlin", false, "Champlin", "(631) 271-0808 x420", "StudentepW9pUvi" },
                    { 65, "0075 Roberta Trail, Hansenchester, Burkina Faso", "Port Elizaland", new DateTime(2023, 8, 12, 22, 3, 17, 188, DateTimeKind.Local).AddTicks(4624), "onhdexmapletest19965@gmail.com", "Alba", "Alba Ferry", true, "Ferry", "596-876-5947", "StudentuLucAW9F" },
                    { 67, "1310 Newell Greens, East Micheal, Saint Lucia", "Cristside", new DateTime(2022, 11, 26, 9, 29, 55, 110, DateTimeKind.Local).AddTicks(4062), "onhdexmapletest19967@gmail.com", "Paige", "Paige Barton", false, "Barton", "1-612-941-4839", "StudentYCvUZ1wJ" },
                    { 69, "8906 Afton Mountains, West Jarrod, Lesotho", "North Lulu", new DateTime(2022, 10, 19, 20, 13, 24, 796, DateTimeKind.Local).AddTicks(4192), "onhdexmapletest19969@gmail.com", "Jazmyne", "Jazmyne Champlin", false, "Champlin", "643.311.2070 x552", "StudentPp3IkxWm" },
                    { 71, "58807 Schiller Highway, North Jesusberg, China", "Lake Chaddmouth", new DateTime(2022, 12, 2, 6, 58, 50, 71, DateTimeKind.Local).AddTicks(2366), "onhdexmapletest19971@gmail.com", "Dock", "Dock O'Hara", true, "O'Hara", "420-400-7441 x9324", "Studenth9JFc6pP" },
                    { 73, "62493 Schoen Trail, South Jesusshire, Hungary", "North Camille", new DateTime(2023, 1, 10, 5, 42, 56, 867, DateTimeKind.Local).AddTicks(3425), "onhdexmapletest19973@gmail.com", "Ike", "Ike Kuvalis", false, "Kuvalis", "811-656-5488 x01831", "StudentNQokBwx3" },
                    { 75, "52910 Runolfsson Hills, Port Rebeca, Bangladesh", "Isacchester", new DateTime(2023, 9, 6, 20, 17, 19, 431, DateTimeKind.Local).AddTicks(3928), "onhdexmapletest19975@gmail.com", "Zachary", "Zachary Vandervort", true, "Vandervort", "(342) 787-1051 x8554", "StudentBRktSsyl" },
                    { 77, "68729 Hardy Alley, South Moshe, Saint Lucia", "East Antonietta", new DateTime(2023, 8, 18, 18, 58, 50, 728, DateTimeKind.Local).AddTicks(5184), "onhdexmapletest19977@gmail.com", "Trent", "Trent Renner", false, "Renner", "1-980-851-8812 x0239", "StudentgYRwzR4P" },
                    { 79, "61500 Bergstrom Locks, South Dorothyland, Saint Pierre and Miquelon", "Howellshire", new DateTime(2022, 10, 1, 9, 14, 21, 407, DateTimeKind.Local).AddTicks(652), "onhdexmapletest19979@gmail.com", "Clare", "Clare Toy", true, "Toy", "(773) 585-4418", "StudentBOfHG9vN" },
                    { 81, "820 Crooks Crossing, Kingside, Belize", "Bryonfort", new DateTime(2023, 9, 3, 4, 9, 58, 760, DateTimeKind.Local).AddTicks(9082), "onhdexmapletest19981@gmail.com", "Dorcas", "Dorcas Champlin", false, "Champlin", "556.356.3198 x22585", "Studentc0qvjJP5" },
                    { 83, "073 Curtis Dale, Wilfridmouth, United Kingdom", "South Keeganville", new DateTime(2023, 8, 22, 20, 58, 16, 717, DateTimeKind.Local).AddTicks(5282), "onhdexmapletest19983@gmail.com", "Ora", "Ora Batz", false, "Batz", "875-871-5421 x280", "StudentIx0VHGCy" },
                    { 85, "4826 Trantow Canyon, Lake Theoshire, Azerbaijan", "Port Joana", new DateTime(2023, 7, 15, 19, 50, 11, 147, DateTimeKind.Local).AddTicks(2240), "onhdexmapletest19985@gmail.com", "Lorenzo", "Lorenzo Fritsch", true, "Fritsch", "(921) 758-4016", "StudentkdfELjwL" },
                    { 87, "8323 Adonis Track, Kilbackburgh, Mayotte", "New Pietro", new DateTime(2023, 1, 27, 11, 28, 43, 78, DateTimeKind.Local).AddTicks(622), "onhdexmapletest19987@gmail.com", "Anastacio", "Anastacio Will", false, "Will", "1-551-574-7471", "StudentSl0VB69M" },
                    { 89, "4512 Bayer Walk, North Lennytown, Finland", "Ernestinebury", new DateTime(2023, 2, 8, 16, 14, 6, 368, DateTimeKind.Local).AddTicks(2627), "onhdexmapletest19989@gmail.com", "Marcella", "Marcella McClure", false, "McClure", "1-569-615-2693 x643", "StudentGdkiC7ng" },
                    { 91, "22925 Kling Fork, New Samir, Estonia", "Ellsworthstad", new DateTime(2023, 7, 18, 1, 37, 14, 460, DateTimeKind.Local).AddTicks(3627), "onhdexmapletest19991@gmail.com", "Frederik", "Frederik Casper", true, "Casper", "(943) 693-1042 x343", "StudentnPoALDx2" },
                    { 93, "3764 Ardith Burgs, Port Katlynn, Sri Lanka", "Cassinton", new DateTime(2023, 6, 9, 1, 13, 16, 633, DateTimeKind.Local).AddTicks(8396), "onhdexmapletest19993@gmail.com", "Lenore", "Lenore Renner", false, "Renner", "882.664.9077 x631", "StudentPOWC1NHv" },
                    { 95, "1054 Bailey River, East Antonina, Peru", "New Saulstad", new DateTime(2022, 10, 20, 13, 24, 22, 29, DateTimeKind.Local).AddTicks(8511), "onhdexmapletest19995@gmail.com", "Julien", "Julien Kerluke", false, "Kerluke", "(286) 810-2317", "StudentYULiOKkd" },
                    { 97, "507 Walter Ferry, Corymouth, Montenegro", "Dickensport", new DateTime(2022, 12, 20, 1, 37, 34, 38, DateTimeKind.Local).AddTicks(7545), "onhdexmapletest19997@gmail.com", "Alexandra", "Alexandra Thiel", true, "Thiel", "490.232.1492 x2216", "StudentLbMAmkp8" },
                    { 99, "853 Estrella Terrace, Lake Derrick, Nicaragua", "New Elias", new DateTime(2023, 7, 8, 20, 51, 31, 481, DateTimeKind.Local).AddTicks(6415), "onhdexmapletest19999@gmail.com", "Linda", "Linda Kirlin", false, "Kirlin", "405.785.5679 x4188", "Student6uO80nvL" }
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
