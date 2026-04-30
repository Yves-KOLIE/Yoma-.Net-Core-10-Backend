using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class addTableUserTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Professeur" },
                    { 2, "Élève" },
                    { 3, "Parent d'élèves" },
                },
            schema: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}