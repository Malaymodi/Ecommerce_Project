using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Project_WebAPI.Migrations
{
    public partial class _5thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Users_UsersUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UsersUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users",
                column: "AspNetUsersId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUsersId",
                table: "Users",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUsersId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AspNetUsersId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UsersUserId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UsersUserId",
                table: "AspNetUsers",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Users_UsersUserId",
                table: "AspNetUsers",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
