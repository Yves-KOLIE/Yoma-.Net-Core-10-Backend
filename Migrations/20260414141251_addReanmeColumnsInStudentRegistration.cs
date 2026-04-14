using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class addReanmeColumnsInStudentRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IS_SUPPORTED",
                table: "StudentRegistrations",
                newName: "SCHOOL_FESS_IS_SUPPORTED");

            migrationBuilder.RenameColumn(
                name: "IS_DISCOUNTED",
                table: "StudentRegistrations",
                newName: "SCHOOL_FESS_IS_DISCOUNTED");

            migrationBuilder.AddColumn<int>(
                name: "BUS_PRICE_1",
                table: "StudentRegistrations",
                type: "integer",
                nullable: true,
                defaultValue: null
            );

            migrationBuilder.AddColumn<int>(
                name: "BUS_PRICE_2",
                table: "StudentRegistrations",
                type: "integer",
                nullable: true,
                defaultValue: null
            );

            migrationBuilder.AddColumn<int>(
                name: "BUS_PRICE_3",
                table: "StudentRegistrations",
                type: "integer",
                nullable: true,
                defaultValue: null
            );

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "BUS_PRICE_IS_DISCOUNTED",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "BUS_PRICE_IS_SUPPORTED",
                table: "StudentRegistrations");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_FESS_IS_SUPPORTED",
                table: "StudentRegistrations",
                newName: "IS_SUPPORTED");

            migrationBuilder.RenameColumn(
                name: "SCHOOL_FESS_IS_DISCOUNTED",
                table: "StudentRegistrations",
                newName: "IS_DISCOUNTED");
        }
    }
}