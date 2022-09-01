using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Project_WebAPI.Migrations.Registration
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registrations_UserRoleId",
                table: "registrations",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_UserRole_UserRoleId",
                table: "registrations",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrations_UserRole_UserRoleId",
                table: "registrations");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_registrations_UserRoleId",
                table: "registrations");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "registrations");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "registrations");
        }
    }
}
