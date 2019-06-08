using Microsoft.EntityFrameworkCore.Migrations;

namespace SiyasMatrimony.API.Migrations
{
    public partial class timeofbirthAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "timeOfBirth",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timeOfBirth",
                table: "AspNetUsers");
        }
    }
}
