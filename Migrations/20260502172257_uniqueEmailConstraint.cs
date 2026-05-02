using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class uniqueEmailConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserEmails_EMAIL",
                table: "UserEmails",
                column: "EMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserEmails_EMAIL",
                table: "UserEmails");
        }
    }
}
