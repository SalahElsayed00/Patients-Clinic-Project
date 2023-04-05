using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientsClinicProject.Migrations
{
    public partial class addConstraintOnPhonDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Phone",
                table: "Doctors",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_Phone",
                table: "Doctors");
        }
    }
}
