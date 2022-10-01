using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Project_WebAPI.Migrations
{
    public partial class fourthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Users_UsersUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UsersUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "AspNetUsers");
        }
    }
}
