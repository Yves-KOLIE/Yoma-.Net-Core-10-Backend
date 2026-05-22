using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace backend.Migrations
{
    public partial class newTablesForStudentsStatusCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BUS_PRICE_IS_DISCOUNTED",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "BUS_PRICE_IS_SUPPORTED",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "SCHOOL_FESS_IS_DISCOUNTED",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "SCHOOL_FESS_IS_SUPPORTED",
                table: "StudentRegistrations");

            migrationBuilder.AddColumn<int>(
                name: "STUDENT_BUS_STATUS_OF_CARE_ID",
                table: "StudentRegistrations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "STUDENT_SCHOOL_STATUS_OF_CARE_ID",
                table: "StudentRegistrations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentBusStatusOfCares",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentBusStatusOfCares", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "StudentBusStatusOfCares",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Non inscrit au bus" },
                    { 2, "Aucun frais de bus n'est pris en charge" },
                    { 3, "Une partie des frais de bus est pris en charge" },
                    { 4, "Les frais de bus sont totalement pris en charge" },
                },
            schema: null);

            migrationBuilder.CreateTable(
                name: "StudentSchoolStatusOfCares",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSchoolStatusOfCares", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "StudentSchoolStatusOfCares",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Aucun frais de scolarité n'est pris en charge" },
                    { 2, "Une partie des frais de scolarité est pris en charge" },
                    { 3, "Les frais de scolarité sont totalement pris en charge" },
                },
            schema: null);

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_STUDENT_BUS_STATUS_OF_CARE_ID",
                table: "StudentRegistrations",
                column: "STUDENT_BUS_STATUS_OF_CARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_STUDENT_SCHOOL_STATUS_OF_CARE_ID",
                table: "StudentRegistrations",
                column: "STUDENT_SCHOOL_STATUS_OF_CARE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_StudentBusStatusOfCares_STUDENT_BUS_ST~",
                table: "StudentRegistrations",
                column: "STUDENT_BUS_STATUS_OF_CARE_ID",
                principalTable: "StudentBusStatusOfCares",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_StudentSchoolStatusOfCares_STUDENT_SCH~",
                table: "StudentRegistrations",
                column: "STUDENT_SCHOOL_STATUS_OF_CARE_ID",
                principalTable: "StudentSchoolStatusOfCares",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_StudentBusStatusOfCares_STUDENT_BUS_ST~",
                table: "StudentRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_StudentSchoolStatusOfCares_STUDENT_SCH~",
                table: "StudentRegistrations");

            migrationBuilder.DropTable(
                name: "StudentBusStatusOfCares");

            migrationBuilder.DropTable(
                name: "StudentSchoolStatusOfCares");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_STUDENT_BUS_STATUS_OF_CARE_ID",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_STUDENT_SCHOOL_STATUS_OF_CARE_ID",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "STUDENT_BUS_STATUS_OF_CARE_ID",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "STUDENT_SCHOOL_STATUS_OF_CARE_ID",
                table: "StudentRegistrations");

            migrationBuilder.AddColumn<bool>(
                name: "BUS_PRICE_IS_DISCOUNTED",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BUS_PRICE_IS_SUPPORTED",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SCHOOL_FESS_IS_DISCOUNTED",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SCHOOL_FESS_IS_SUPPORTED",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
