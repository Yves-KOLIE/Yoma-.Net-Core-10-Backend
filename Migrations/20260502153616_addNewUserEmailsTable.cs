using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class addNewUserEmailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_UserTypes_USER_TYPE_ID",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_UserTypes_USER_TYPE_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_USER_TYPE_ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "USER_TYPE_ID",
                table: "Users",
                newName: "USER_EMAIL_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_USER_TYPE_ID",
                table: "Users",
                newName: "IX_Users_USER_EMAIL_ID");

            migrationBuilder.RenameColumn(
                name: "USER_TYPE_ID",
                table: "Students",
                newName: "USER_EMAIL_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_USER_TYPE_ID",
                table: "Students",
                newName: "IX_Students_USER_EMAIL_ID");

            migrationBuilder.RenameColumn(
                name: "USER_TYPE_ID",
                table: "Parents",
                newName: "USER_EMAIL_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_USER_TYPE_ID",
                table: "Parents",
                newName: "IX_Parents_USER_EMAIL_ID");

            migrationBuilder.CreateTable(
                name: "UserEmails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EMAIL = table.Column<string>(type: "text", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_TYPE_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserEmails_UserTypes_USER_TYPE_ID",
                        column: x => x.USER_TYPE_ID,
                        principalTable: "UserTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEmails_USER_TYPE_ID",
                table: "UserEmails",
                column: "USER_TYPE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_UserEmails_USER_EMAIL_ID",
                table: "Parents",
                column: "USER_EMAIL_ID",
                principalTable: "UserEmails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UserEmails_USER_EMAIL_ID",
                table: "Students",
                column: "USER_EMAIL_ID",
                principalTable: "UserEmails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserEmails_USER_EMAIL_ID",
                table: "Users",
                column: "USER_EMAIL_ID",
                principalTable: "UserEmails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_UserEmails_USER_EMAIL_ID",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_UserEmails_USER_EMAIL_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserEmails_USER_EMAIL_ID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserEmails");

            migrationBuilder.RenameColumn(
                name: "USER_EMAIL_ID",
                table: "Users",
                newName: "USER_TYPE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_USER_EMAIL_ID",
                table: "Users",
                newName: "IX_Users_USER_TYPE_ID");

            migrationBuilder.RenameColumn(
                name: "USER_EMAIL_ID",
                table: "Students",
                newName: "USER_TYPE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_USER_EMAIL_ID",
                table: "Students",
                newName: "IX_Students_USER_TYPE_ID");

            migrationBuilder.RenameColumn(
                name: "USER_EMAIL_ID",
                table: "Parents",
                newName: "USER_TYPE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_USER_EMAIL_ID",
                table: "Parents",
                newName: "IX_Parents_USER_TYPE_ID");

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "Parents",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_UserTypes_USER_TYPE_ID",
                table: "Parents",
                column: "USER_TYPE_ID",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UserTypes_USER_TYPE_ID",
                table: "Students",
                column: "USER_TYPE_ID",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_USER_TYPE_ID",
                table: "Users",
                column: "USER_TYPE_ID",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
