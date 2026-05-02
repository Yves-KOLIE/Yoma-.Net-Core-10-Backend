using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class uniqueMatriculeConstraintInTableUserAndStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_MATRICULE",
                table: "Users",
                column: "MATRICULE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_MATRICULE",
                table: "Students",
                column: "MATRICULE",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_MATRICULE",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Students_MATRICULE",
                table: "Students");
        }
    }
}
