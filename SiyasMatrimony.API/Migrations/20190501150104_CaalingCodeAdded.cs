using Microsoft.EntityFrameworkCore.Migrations;

namespace SiyasMatrimony.API.Migrations
{
    public partial class CaalingCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallingCode",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallingCode",
                table: "AspNetUsers");
        }
    }
}
