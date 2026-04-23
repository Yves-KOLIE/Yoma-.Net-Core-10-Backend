using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addStudentParentInTableStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PARENT_1_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PARENT_2_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_PARENT_1_ID",
                table: "Students",
                column: "PARENT_1_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PARENT_2_ID",
                table: "Students",
                column: "PARENT_2_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentParents_PARENT_1_ID",
                table: "Students",
                column: "PARENT_1_ID",
                principalTable: "StudentParents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentParents_PARENT_2_ID",
                table: "Students",
                column: "PARENT_2_ID",
                principalTable: "StudentParents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentParents_PARENT_1_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentParents_PARENT_2_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PARENT_1_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PARENT_2_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PARENT_1_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PARENT_2_ID",
                table: "Students");
        }
    }
}
