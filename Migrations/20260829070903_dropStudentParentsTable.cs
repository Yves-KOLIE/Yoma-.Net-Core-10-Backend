using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace backend.Migrations
{
    public partial class dropStudentParentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentParents_PARENT_1_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentParents_PARENT_2_ID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentParents");

            migrationBuilder.AddColumn<int>(
                name: "PARENT_1_TYPE_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PARENT_2_TYPE_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_PARENT_1_TYPE_ID",
                table: "Students",
                column: "PARENT_1_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PARENT_2_TYPE_ID",
                table: "Students",
                column: "PARENT_2_TYPE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ParentTypes_PARENT_1_TYPE_ID",
                table: "Students",
                column: "PARENT_1_TYPE_ID",
                principalTable: "ParentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ParentTypes_PARENT_2_TYPE_ID",
                table: "Students",
                column: "PARENT_2_TYPE_ID",
                principalTable: "ParentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_PARENT_1_ID",
                table: "Students",
                column: "PARENT_1_ID",
                principalTable: "Parents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_PARENT_2_ID",
                table: "Students",
                column: "PARENT_2_ID",
                principalTable: "Parents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ParentTypes_PARENT_1_TYPE_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ParentTypes_PARENT_2_TYPE_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_PARENT_1_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_PARENT_2_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PARENT_1_TYPE_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PARENT_2_TYPE_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PARENT_1_TYPE_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PARENT_2_TYPE_ID",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentParents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PARENT_ID = table.Column<int>(type: "integer", nullable: false),
                    PARENT_TYPE_ID = table.Column<int>(type: "integer", nullable: false),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentParents_ParentTypes_PARENT_TYPE_ID",
                        column: x => x.PARENT_TYPE_ID,
                        principalTable: "ParentTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalTable: "Parents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_PARENT_ID",
                table: "StudentParents",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_PARENT_TYPE_ID",
                table: "StudentParents",
                column: "PARENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_STUDENT_ID",
                table: "StudentParents",
                column: "STUDENT_ID");

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
    }
}
