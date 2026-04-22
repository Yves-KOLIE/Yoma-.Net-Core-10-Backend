using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addColumnIsExamClassInEducationLevelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_EXAM_CLASS",
                table: "EducationLevels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

                migrationBuilder.Sql(@"
                    UPDATE ""EducationLevels""
                    SET ""IS_EXAM_CLASS"" = TRUE
                    WHERE ""ID"" IN (9, 13, 20, 21, 22);
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_EXAM_CLASS",
                table: "EducationLevels");
        }
    }
}