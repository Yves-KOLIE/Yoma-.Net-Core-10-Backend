using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable

namespace backend.Migrations
{
    public partial class addForgotUserPasswordsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForgotUserPasswords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EMAIL = table.Column<string>(type: "text", nullable: false),
                    CODE_GENERETED = table.Column<string>(type: "text", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EXPIRE_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotUserPasswords", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgotUserPasswords");
        }
    }
}
