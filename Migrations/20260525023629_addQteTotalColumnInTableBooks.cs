using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{

    public partial class addQteTotalColumnInTableBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QTE_TOTAL",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_QteRange",
                table: "Books",
                sql: "\"QTE_TOTAL\" > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_QteRange",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "QTE_TOTAL",
                table: "Books");
        }
    }
}
