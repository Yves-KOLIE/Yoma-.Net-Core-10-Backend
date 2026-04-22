using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class addTableMonthOfSalaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthOfSalaries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: null),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthOfSalaries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonthOfSalaries_Months_MONTH_ID",
                        column: x => x.MONTH_ID,
                        principalTable: "Months",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthOfSalaries_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthOfSalaries_MONTH_ID",
                table: "MonthOfSalaries",
                column: "MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MonthOfSalaries_SCHOOL_YEAR_ID",
                table: "MonthOfSalaries",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.InsertData(
                table: "MonthOfSalaries",
                columns: new[] { "ID", "SCHOOL_YEAR_ID", "MONTH_ID" },
                values: new object[,]
                {
                    { 1, 1, 1},
                    { 2, 1, 2},
                    { 3, 1, 3},
                    { 4, 1, 4},
                    { 5, 1, 5},
                    { 6, 1, 6},
                    { 7, 1, 7},
                    { 8, 1, 8},
                    { 9, 1, 9},
                    { 10, 1, 10},
                    { 11, 1, 11},
                    { 12, 1, 12},
                },
            schema: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthOfSalaries");
        }
    }
}