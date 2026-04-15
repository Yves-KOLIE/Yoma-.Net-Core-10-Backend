using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace backend.Migrations
{
    public partial class addTablesMonthlySalaryAssignmentsAndPayrollValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlySalaryAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USER_POSITION_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    MONTH_IDS = table.Column<int[]>(type: "integer[]", nullable: false),
                    MONTHLY_SALARY = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    USER_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlySalaryAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonthlySalaryAssignments_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlySalaryAssignments_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollValidations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SUM_SALARY_ADVANCE_COURS = table.Column<int>(type: "integer", nullable: false),
                    SUM_SALARY_ADVANCE_REVISION = table.Column<int>(type: "integer", nullable: false),
                    TOTAL_SALARY = table.Column<int>(type: "integer", nullable: false),
                    IS_PAYED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false),
                    MONTH_ID = table.Column<int>(type: "integer", nullable: false),
                    USER_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollValidations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PayrollValidations_Months_MONTH_ID",
                        column: x => x.MONTH_ID,
                        principalTable: "Months",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollValidations_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollValidations_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaryAssignments_SCHOOL_YEAR_ID",
                table: "MonthlySalaryAssignments",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaryAssignments_USER_ID",
                table: "MonthlySalaryAssignments",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollValidations_MONTH_ID",
                table: "PayrollValidations",
                column: "MONTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollValidations_SCHOOL_YEAR_ID",
                table: "PayrollValidations",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollValidations_USER_ID",
                table: "PayrollValidations",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlySalaryAssignments");

            migrationBuilder.DropTable(
                name: "PayrollValidations");
        }
    }
}