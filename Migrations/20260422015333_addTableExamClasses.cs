using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace backend.Migrations
{
    public partial class addTableExamClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamClasses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IS_ADMITTED = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null),
                    STUDENT_REGISTRATION_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamClasses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExamClasses_StudentRegistrations_STUDENT_REGISTRATION_ID",
                        column: x => x.STUDENT_REGISTRATION_ID,
                        principalTable: "StudentRegistrations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamClasses_STUDENT_REGISTRATION_ID",
                table: "ExamClasses",
                column: "STUDENT_REGISTRATION_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamClasses");
        }
    }
}
