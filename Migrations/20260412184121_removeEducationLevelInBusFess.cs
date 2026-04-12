using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class removeEducationLevelInBusFess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusFess_EducationLevels_EDUCATION_LEVEL_ID",
                table: "BusFess");

            migrationBuilder.DropIndex(
                name: "IX_BusFess_EDUCATION_LEVEL_ID",
                table: "BusFess");

            migrationBuilder.DropColumn(
                name: "EDUCATION_LEVEL_ID",
                table: "BusFess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EDUCATION_LEVEL_ID",
                table: "BusFess",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BusFess_EDUCATION_LEVEL_ID",
                table: "BusFess",
                column: "EDUCATION_LEVEL_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BusFess_EducationLevels_EDUCATION_LEVEL_ID",
                table: "BusFess",
                column: "EDUCATION_LEVEL_ID",
                principalTable: "EducationLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
