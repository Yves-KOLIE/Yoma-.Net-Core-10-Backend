using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addProfessionalQualificationColumnInTableParents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PROFESSIONAL_QUALIFICATION_ID",
                table: "Parents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_PROFESSIONAL_QUALIFICATION_ID",
                table: "Parents",
                column: "PROFESSIONAL_QUALIFICATION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_ProfessionalQualifications_PROFESSIONAL_QUALIFICATI~",
                table: "Parents",
                column: "PROFESSIONAL_QUALIFICATION_ID",
                principalTable: "ProfessionalQualifications",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_ProfessionalQualifications_PROFESSIONAL_QUALIFICATI~",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_PROFESSIONAL_QUALIFICATION_ID",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "PROFESSIONAL_QUALIFICATION_ID",
                table: "Parents");
        }
    }
}
