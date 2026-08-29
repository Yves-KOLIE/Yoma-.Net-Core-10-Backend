using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace backend.Migrations
{
    public partial class dropMonthOfSalaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthOfSalaries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthOfSalaries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true)
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
        }
    }
}