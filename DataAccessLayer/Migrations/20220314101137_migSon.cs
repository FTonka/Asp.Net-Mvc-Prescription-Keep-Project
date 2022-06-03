using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migSon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANIES",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: true),
                    CompanyCity = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyDistrict = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyFoundationYear = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANIES", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeSurname = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeBirthdate = table.Column<string>(nullable: true),
                    EmployeeGender = table.Column<string>(maxLength: 1, nullable: true),
                    EmployeeMail = table.Column<string>(maxLength: 50, nullable: true),
                    EmployeePassword = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeAddress = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeTelNumber = table.Column<string>(maxLength: 20, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    EmployeesCompany = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeesDepartment = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "HOSPITALS",
                columns: table => new
                {
                    HospitalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(maxLength: 200, nullable: true),
                    HospitalCity = table.Column<string>(maxLength: 50, nullable: true),
                    HospitalDistrict = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOSPITALS", x => x.HospitalID);
                });

            migrationBuilder.CreateTable(
                name: "DOCTORS",
                columns: table => new
                {
                    DoctorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(maxLength: 100, nullable: true),
                    DoctorSurname = table.Column<string>(maxLength: 100, nullable: true),
                    DoctorBirthdate = table.Column<DateTime>(maxLength: 20, nullable: false),
                    DoctorGender = table.Column<string>(maxLength: 1, nullable: true),
                    DoctorAddress = table.Column<string>(maxLength: 200, nullable: true),
                    DoctorMail = table.Column<string>(maxLength: 50, nullable: true),
                    DoctorsPoliclinic = table.Column<string>(maxLength: 50, nullable: true),
                    HosiptalID = table.Column<int>(nullable: false),
                    HospitalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCTORS", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_DOCTORS_HOSPITALS_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "HOSPITALS",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTES",
                columns: table => new
                {
                    NoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteContent = table.Column<string>(maxLength: 1000, nullable: true),
                    NoteGeoLocation = table.Column<string>(maxLength: 100, nullable: true),
                    NoteCreateDate = table.Column<DateTime>(maxLength: 20, nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTES", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_NOTES_DOCTORS_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DOCTORS",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTES_EMPLOYEES_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOCTORS_HospitalID",
                table: "DOCTORS",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTES_DoctorID",
                table: "NOTES",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTES_EmployeeID",
                table: "NOTES",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPANIES");

            migrationBuilder.DropTable(
                name: "NOTES");

            migrationBuilder.DropTable(
                name: "DOCTORS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "HOSPITALS");
        }
    }
}
