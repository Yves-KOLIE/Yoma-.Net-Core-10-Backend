using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class nullableUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "USER_EMAIL_ID",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "USER_EMAIL_ID",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "USER_EMAIL_ID",
                table: "Parents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_UserEmails_USER_EMAIL_ID",
                table: "Parents",
                column: "USER_EMAIL_ID",
                principalTable: "UserEmails",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UserEmails_USER_EMAIL_ID",
                table: "Students",
                column: "USER_EMAIL_ID",
                principalTable: "UserEmails",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserEmails_USER_EMAIL_ID",
                table: "Users",
                column: "USER_EMAIL_ID",
                principalTable: "UserEmails",
                principalColumn: "ID");

            migrationBuilder.UpdateData(
                table: "StudentSchoolStatusOfCares",
                keyColumn: "ID",
                keyValue: 1,
                column: "DESCRIPTION",
                value: "Normal");

            migrationBuilder.UpdateData(
                table: "StudentSchoolStatusOfCares",
                keyColumn: "ID",
                keyValue: 2,
                column: "DESCRIPTION",
                value: "Reduit");

            migrationBuilder.UpdateData(
                table: "StudentSchoolStatusOfCares",
                keyColumn: "ID",
                keyValue: 3,
                column: "DESCRIPTION",
                value: "Pris en charge");

            migrationBuilder.UpdateData(
                table: "StudentBusStatusOfCares",
                keyColumn: "ID",
                keyValue: 1,
                column: "DESCRIPTION",
                value: "Non inscrit");


            migrationBuilder.UpdateData(
                table: "StudentBusStatusOfCares",
                keyColumn: "ID",
                keyValue: 2,
                column: "DESCRIPTION",
                value: "Normal");

            migrationBuilder.UpdateData(
                table: "StudentBusStatusOfCares",
                keyColumn: "ID",
                keyValue: 3,
                column: "DESCRIPTION",
                value: "Reduit");

            migrationBuilder.UpdateData(
                table: "StudentBusStatusOfCares",
                keyColumn: "ID",
                keyValue: 4,
                column: "DESCRIPTION",
                value: "Pris en charge");
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

            migrationBuilder.AlterColumn<int>(
                name: "USER_EMAIL_ID",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USER_EMAIL_ID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USER_EMAIL_ID",
                table: "Parents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}
