using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migRemovePoliklinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorsPoliclinic",
                table: "DOCTORS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorsPoliclinic",
                table: "DOCTORS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
