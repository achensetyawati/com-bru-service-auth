using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Bateeq.Service.Auth.Lib.Migrations
{
    public partial class roleUIDInAccountRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleUId",
                table: "AccountRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleUId",
                table: "AccountRoles");
        }
    }
}
