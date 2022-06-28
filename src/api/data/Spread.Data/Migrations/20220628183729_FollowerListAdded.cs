using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Data.Migrations
{
    public partial class FollowerListAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                schema: "Profile",
                table: "Followers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                schema: "Profile",
                table: "Followers");
        }
    }
}
