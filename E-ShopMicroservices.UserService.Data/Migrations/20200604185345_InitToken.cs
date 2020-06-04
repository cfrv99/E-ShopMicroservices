using Microsoft.EntityFrameworkCore.Migrations;

namespace E_ShopMicroservices.UserService.Data.Migrations
{
    public partial class InitToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_AspNetUsers_AppUserId1",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_AppUserId1",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Tokens");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Tokens",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_AppUserId",
                table: "Tokens",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_AspNetUsers_AppUserId",
                table: "Tokens",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_AspNetUsers_AppUserId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_AppUserId",
                table: "Tokens");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Tokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Tokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_AppUserId1",
                table: "Tokens",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_AspNetUsers_AppUserId1",
                table: "Tokens",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
