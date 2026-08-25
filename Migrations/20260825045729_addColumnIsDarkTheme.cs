using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addColumnIsDarkTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_DARK_THEME",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IS_DARK_THEME",
                table: "Students",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IS_DARK_THEME",
                table: "Parents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_DARK_THEME",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IS_DARK_THEME",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IS_DARK_THEME",
                table: "Parents");
        }
    }
}
