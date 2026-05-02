using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace backend.Migrations
{
    public partial class setUsersNulableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IS_LOCK",
                table: "Users",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "Users",
                nullable: false,
                defaultValue: true
            );

            migrationBuilder.AlterColumn<bool>(
                name: "IS_PRINCIPAL_TEACHER",
                table: "Users",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AlterColumn<int[]>(
                name: "USER_POSITION_IDS",
                table: "Users",
                type: "integer[]",
                nullable: true,
                defaultValue: null,
                oldClrType: typeof(int[]),
                oldType: "integer[]"
            );

            migrationBuilder.AlterColumn<int[]>(
                name: "SCHOOL_EDUCATION_IDS",
                table: "Users",
                type: "integer[]",
                nullable: true,
                defaultValue: null,
                oldClrType: typeof(int[]),
                oldType: "integer[]"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IS_LOCK",
                table: "Users",
                nullable: false
            );

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "Users",
                nullable: false
            );

            migrationBuilder.AlterColumn<bool>(
                name: "IS_PRINCIPAL_TEACHER",
                table: "Users",
                nullable: false
            );

            migrationBuilder.AlterColumn<int[]>(
                name: "USER_POSITION_IDS",
                table: "Users",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0],
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<int[]>(
                name: "SCHOOL_EDUCATION_IDS",
                table: "Users",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0],
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);
        }
    }
}
