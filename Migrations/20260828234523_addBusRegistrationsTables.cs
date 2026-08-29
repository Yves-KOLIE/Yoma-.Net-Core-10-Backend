using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class addBusRegistrationsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BUS_PRICE_1",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "BUS_PRICE_2",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "BUS_PRICE_3",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "IS_SUBSCRIBE_TO_THE_BUS_FESS_1",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "IS_SUBSCRIBE_TO_THE_BUS_FESS_2",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "IS_SUBSCRIBE_TO_THE_BUS_FESS_3",
                table: "StudentRegistrations");

            migrationBuilder.CreateTable(
                name: "BusRegistrations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BUS_PRICE_1 = table.Column<int>(type: "integer", nullable: false),
                    BUS_PRICE_2 = table.Column<int>(type: "integer", nullable: false),
                    BUS_PRICE_3 = table.Column<int>(type: "integer", nullable: false),
                    IS_SUBSCRIBE_TO_THE_BUS_FESS_1 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_SUBSCRIBE_TO_THE_BUS_FESS_2 = table.Column<bool>(type: "boolean", nullable: false),
                    IS_SUBSCRIBE_TO_THE_BUS_FESS_3 = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    SCHOOL_YEAR_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRegistrations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusRegistrations_SchoolYears_SCHOOL_YEAR_ID",
                        column: x => x.SCHOOL_YEAR_ID,
                        principalTable: "SchoolYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusRegistrations_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusRegistrations_SCHOOL_YEAR_ID",
                table: "BusRegistrations",
                column: "SCHOOL_YEAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BusRegistrations_STUDENT_ID",
                table: "BusRegistrations",
                column: "STUDENT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusRegistrations");

            migrationBuilder.AddColumn<int>(
                name: "BUS_PRICE_1",
                table: "StudentRegistrations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BUS_PRICE_2",
                table: "StudentRegistrations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BUS_PRICE_3",
                table: "StudentRegistrations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IS_SUBSCRIBE_TO_THE_BUS_FESS_1",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IS_SUBSCRIBE_TO_THE_BUS_FESS_2",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IS_SUBSCRIBE_TO_THE_BUS_FESS_3",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
