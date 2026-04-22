using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addUserRoleInParentAndStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "USER_ROLE_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "USER_ROLE_ID",
                table: "Parents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_USER_ROLE_ID",
                table: "Students",
                column: "USER_ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_USER_ROLE_ID",
                table: "Parents",
                column: "USER_ROLE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_UserRoles_USER_ROLE_ID",
                table: "Parents",
                column: "USER_ROLE_ID",
                principalTable: "UserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UserRoles_USER_ROLE_ID",
                table: "Students",
                column: "USER_ROLE_ID",
                principalTable: "UserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_UserRoles_USER_ROLE_ID",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_UserRoles_USER_ROLE_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_USER_ROLE_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Parents_USER_ROLE_ID",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "USER_ROLE_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "USER_ROLE_ID",
                table: "Parents");
        }
    }
}