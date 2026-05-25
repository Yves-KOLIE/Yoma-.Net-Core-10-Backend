using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class newTablesBookRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategories",
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
                    table.PrimaryKey("PK_BookCategories", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Littérature"},
                    { 2, "Français"},
                    { 3, "Histoire"},
                    { 4, "Géographie"},
                    { 5, "Anglais"},
                    { 6, "Mathématiques"},
                    { 7, "Physique"},
                    { 8, "Chimie"},
                    { 9, "Biologie"},
                },
            schema: null);

            migrationBuilder.CreateTable(
                name: "Languages",
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
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[,]
                {
                    { 1, "Français"},
                    { 2, "Anglais"},
                },
            schema: null);

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TITLE = table.Column<string>(type: "text", nullable: false),
                    AUTHOR = table.Column<string>(type: "text", nullable: false),
                    EDITION = table.Column<string>(type: "text", nullable: true),
                    PUBLISHER = table.Column<string>(type: "text", nullable: true),
                    YEAR_OF_PUBLICATION = table.Column<string>(type: "text", nullable: true),
                    DAY_RENTAL_PRICE = table.Column<int>(type: "integer", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    BOOK_CATEGORY_ID = table.Column<int>(type: "integer", nullable: false),
                    LANGUAGE_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BOOK_CATEGORY_ID",
                        column: x => x.BOOK_CATEGORY_ID,
                        principalTable: "BookCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Languages_LANGUAGE_ID",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRentals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    INFORMATION = table.Column<string>(type: "text", nullable: true),
                    STUDENT_ID = table.Column<int>(type: "integer", nullable: false),
                    BOOK_ID = table.Column<int>(type: "integer", nullable: false),
                    DAY_RENTAL_PRICE = table.Column<int>(type: "integer", nullable: false),
                    RENTAL_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RETURN_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    UPDATED_USER_ID = table.Column<int>(type: "integer", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: DateTime.UtcNow),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRentals", x => x.ID);
                    table.CheckConstraint("CK_Order_DateRange", "\"RETURN_DATE\" > \"RENTAL_DATE\"");
                    table.ForeignKey(
                        name: "FK_BookRentals_Books_BOOK_ID",
                        column: x => x.BOOK_ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRentals_Students_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRentals_BOOK_ID",
                table: "BookRentals",
                column: "BOOK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BookRentals_STUDENT_ID",
                table: "BookRentals",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BOOK_CATEGORY_ID",
                table: "Books",
                column: "BOOK_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LANGUAGE_ID",
                table: "Books",
                column: "LANGUAGE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRentals");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}