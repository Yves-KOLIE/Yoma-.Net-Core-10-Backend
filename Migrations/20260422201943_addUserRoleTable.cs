using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class addUserRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "USER_ROLE_ID",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true, defaultValue: null),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: null)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_USER_ROLE_ID",
                table: "Users",
                column: "USER_ROLE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_USER_ROLE_ID",
                table: "Users",
                column: "USER_ROLE_ID",
                principalTable: "UserRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Professeur" },
                    { 2, "Enseignant" },
                    { 3, "Comptable" },
                    { 4, "Proviseur" },
                    { 5, "Censeur" },
                    { 6, "Surveillant" },
                    { 7, "Directeur des études" },
                    { 8, "Fondateur" },
                    { 9, "Adminiatrateur" },
                    { 10, "Super-adminiatrateur" },
                },
            schema: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_USER_ROLE_ID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Users_USER_ROLE_ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "USER_ROLE_ID",
                table: "Users");
        }
    }
}