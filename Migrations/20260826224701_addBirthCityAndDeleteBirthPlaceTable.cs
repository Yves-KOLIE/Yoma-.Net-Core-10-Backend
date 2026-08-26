using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class addBirthCityAndDeleteBirthPlaceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_BirthPlaces_BIRTH_PLACE_ID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "BirthPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Students_BIRTH_PLACE_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BIRTH_PLACE_ID",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "CITY_OF_BIRTH",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IS_SUPPORTED",
                table: "StudentRegistrations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CITY_OF_BIRTH",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IS_SUPPORTED",
                table: "StudentRegistrations");

            migrationBuilder.AddColumn<int>(
                name: "BIRTH_PLACE_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BirthPlaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PLACE = table.Column<string>(type: "text", nullable: false),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthPlaces", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_BIRTH_PLACE_ID",
                table: "Students",
                column: "BIRTH_PLACE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_BirthPlaces_BIRTH_PLACE_ID",
                table: "Students",
                column: "BIRTH_PLACE_ID",
                principalTable: "BirthPlaces",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
