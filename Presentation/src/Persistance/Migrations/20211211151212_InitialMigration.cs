using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModelType = table.Column<int>(type: "int", nullable: true),
                    CarGear = table.Column<int>(type: "int", nullable: true),
                    CarFabricationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsCurrentlyEmployed = table.Column<bool>(type: "bit", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructors_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingSessions_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingSessions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarFabricationTime", "CarGear", "CarModelType", "IsAvailable", "RegistrationNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, false, "TM 152" },
                    { 2, new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, false, "TM 824" },
                    { 3, new DateTime(2016, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, true, "TM 046" },
                    { 4, new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, false, "TM 055" },
                    { 5, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, false, "AR 552" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "mihai.ionascu23@gmail.com", "Mihai", "Ionascu", "+40 742 950 144" },
                    { 2, new DateTime(1992, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "cristian.ceb@gmail.com", "Cristian", "Ceboatari", "+40 715 675 614" },
                    { 3, new DateTime(1988, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "radu.mazur88@gmail.com", "Radu", "Mazur", "+40 722 101 021" },
                    { 4, new DateTime(1978, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dionis.agapii@gmail.com", "Dionis", "Agapii", "+40 751 551 100" },
                    { 5, new DateTime(1996, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "condur.denis515@gmail.com", "Denis", "Codur", "+40 712 229 545" },
                    { 6, new DateTime(2000, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "adrian.dragos28@gmail.com", "Adrian", "Dragos", "+40 060 066 144" },
                    { 7, new DateTime(2003, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "grosu.marin41@gmail.com", "Marin", "Grosu", "+40 614 411 421" },
                    { 8, new DateTime(1999, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ionut.remetea18@gmail.com", "Ionut", "Remetea", "+40 232 525 151" },
                    { 9, new DateTime(2002, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexandru.lungu2002@gmail.com", "Alexandru", "Lungu", "+40 513 153 531" },
                    { 10, new DateTime(2003, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "paul.rus2003@gmail.com", "Paul", "Rus", "+40 474 366 386" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CarId", "IsCurrentlyEmployed" },
                values: new object[,]
                {
                    { 1, 4, true },
                    { 2, null, false },
                    { 3, 5, true },
                    { 4, 1, true },
                    { 5, 3, true }
                });

            migrationBuilder.InsertData(
                table: "Students",
                column: "Id",
                values: new object[]
                {
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "BookingSessions",
                columns: new[] { "Id", "InstructorId", "IsAvailable", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2021, 12, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 1, true, new DateTime(2021, 12, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 1, true, new DateTime(2021, 12, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 1, true, new DateTime(2021, 12, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 1, true, new DateTime(2021, 12, 12, 1, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 1, true, new DateTime(2021, 12, 12, 3, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 1, true, new DateTime(2021, 12, 12, 4, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 3, true, new DateTime(2021, 12, 12, 1, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 4, true, new DateTime(2021, 12, 12, 3, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 5, true, new DateTime(2021, 12, 12, 4, 30, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingSessions_InstructorId",
                table: "BookingSessions",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSessions_StudentId",
                table: "BookingSessions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CarId",
                table: "Instructors",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSessions");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
