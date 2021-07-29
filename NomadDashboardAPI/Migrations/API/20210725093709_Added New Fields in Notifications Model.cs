using Microsoft.EntityFrameworkCore.Migrations;

namespace NomadDashboardAPI.Migrations.API
{
    public partial class AddedNewFieldsinNotificationsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfile",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserProfile",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Notifications");
        }
    }
}
