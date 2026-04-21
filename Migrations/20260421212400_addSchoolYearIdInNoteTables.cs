using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addSchoolYearIdInNoteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SCHOOL_YEAR_ID",
                table: "NotePrimarys",
                type: "integer",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "SCHOOL_YEAR_ID",
                table: "NoteMiddleSchools",
                type: "integer",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "SCHOOL_YEAR_ID",
                table: "NoteHightSchools",
                type: "integer",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_NotePrimarys_SCHOOL_YEAR_ID",
                table: "NotePrimarys",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteMiddleSchools_SCHOOL_YEAR_ID",
                table: "NoteMiddleSchools",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHightSchools_SCHOOL_YEAR_ID",
                table: "NoteHightSchools",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteHightSchools_SchoolYears_SCHOOL_YEAR_ID",
                table: "NoteHightSchools",
                column: "SCHOOL_YEAR_ID",
                principalTable: "SchoolYears",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteMiddleSchools_SchoolYears_SCHOOL_YEAR_ID",
                table: "NoteMiddleSchools",
                column: "SCHOOL_YEAR_ID",
                principalTable: "SchoolYears",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotePrimarys_SchoolYears_SCHOOL_YEAR_ID",
                table: "NotePrimarys",
                column: "SCHOOL_YEAR_ID",
                principalTable: "SchoolYears",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteHightSchools_SchoolYears_SCHOOL_YEAR_ID",
                table: "NoteHightSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteMiddleSchools_SchoolYears_SCHOOL_YEAR_ID",
                table: "NoteMiddleSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_NotePrimarys_SchoolYears_SCHOOL_YEAR_ID",
                table: "NotePrimarys");

            migrationBuilder.DropIndex(
                name: "IX_NotePrimarys_SCHOOL_YEAR_ID",
                table: "NotePrimarys");

            migrationBuilder.DropIndex(
                name: "IX_NoteMiddleSchools_SCHOOL_YEAR_ID",
                table: "NoteMiddleSchools");

            migrationBuilder.DropIndex(
                name: "IX_NoteHightSchools_SCHOOL_YEAR_ID",
                table: "NoteHightSchools");

            migrationBuilder.DropColumn(
                name: "SCHOOL_YEAR_ID",
                table: "NotePrimarys");

            migrationBuilder.DropColumn(
                name: "SCHOOL_YEAR_ID",
                table: "NoteMiddleSchools");

            migrationBuilder.DropColumn(
                name: "SCHOOL_YEAR_ID",
                table: "NoteHightSchools");
        }
    }
}
