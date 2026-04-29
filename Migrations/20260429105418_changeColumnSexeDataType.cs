using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{    public partial class changeColumnSexeDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "SEXE",
                table: "Users",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<char>(
                name: "SEXE",
                table: "Students",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<char>(
                name: "SEXE",
                table: "Parents",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SEXE",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");

            migrationBuilder.AlterColumn<string>(
                name: "SEXE",
                table: "Students",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");

            migrationBuilder.AlterColumn<string>(
                name: "SEXE",
                table: "Parents",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");
        }
    }
}
