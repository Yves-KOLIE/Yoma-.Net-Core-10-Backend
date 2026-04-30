using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addUserTypeInUsersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "USER_TYPE_ID",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "USER_TYPE_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "USER_TYPE_ID",
                table: "Parents",
                type: "integer",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Users_USER_TYPE_ID",
                table: "Users",
                column: "USER_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_USER_TYPE_ID",
                table: "Students",
                column: "USER_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_USER_TYPE_ID",
                table: "Parents",
                column: "USER_TYPE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_UserTypes_USER_TYPE_ID",
                table: "Parents",
                column: "USER_TYPE_ID",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UserTypes_USER_TYPE_ID",
                table: "Students",
                column: "USER_TYPE_ID",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_USER_TYPE_ID",
                table: "Users",
                column: "USER_TYPE_ID",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_UserTypes_USER_TYPE_ID",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_UserTypes_USER_TYPE_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_USER_TYPE_ID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_USER_TYPE_ID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Students_USER_TYPE_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Parents_USER_TYPE_ID",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "USER_TYPE_ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "USER_TYPE_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "USER_TYPE_ID",
                table: "Parents");
        }
    }
}
