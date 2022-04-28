using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helniv_AccessControl.Migrations
{
    public partial class RoleKeyValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleConst",
                table: "Roles",
                column: "RoleConst",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleConst",
                table: "Roles");
        }
    }
}
