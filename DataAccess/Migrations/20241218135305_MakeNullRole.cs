using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MakeNullRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_roleclaim_roleclaim_id",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "roleclaim_id",
                table: "user",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_user_roleclaim_roleclaim_id",
                table: "user",
                column: "roleclaim_id",
                principalTable: "roleclaim",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_roleclaim_roleclaim_id",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "roleclaim_id",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roleclaim_roleclaim_id",
                table: "user",
                column: "roleclaim_id",
                principalTable: "roleclaim",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
