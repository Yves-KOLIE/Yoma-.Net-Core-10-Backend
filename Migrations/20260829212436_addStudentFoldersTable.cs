using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace backend.Migrations
{
    public partial class addStudentFoldersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FOLDER_INFORMATION",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "IS_SUPPORTED",
                table: "StudentRegistrations");

            migrationBuilder.CreateTable(
                name: "StudentFolders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFolders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentFolders_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFolders_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentFolders_SCHOOL_YEAR_ID",
                table: "StudentFolders",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFolders_STUDENT_ID",
                table: "StudentFolders",
                column: "STUDENT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentFolders");

            migrationBuilder.AddColumn<string>(
                name: "FOLDER_INFORMATION",
                table: "StudentRegistrations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IS_SUPPORTED",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
