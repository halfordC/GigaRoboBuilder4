using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaRoboBuilder4.Data.Migrations
{
    public partial class addUserFieldToBuilds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Build",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Build");
        }
    }
}
