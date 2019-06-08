using Microsoft.EntityFrameworkCore.Migrations;

namespace SiyasMatrimony.API.Migrations
{
    public partial class CountryStateCityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    iso3 = table.Column<string>(nullable: true),
                    iso2 = table.Column<string>(nullable: true),
                    phone_code = table.Column<string>(nullable: true),
                    capital = table.Column<string>(nullable: true),
                    currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    country_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.id);
                    table.ForeignKey(
                        name: "FK_States_Countries_country_id",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    state_id = table.Column<int>(nullable: false),
                    country_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_country_id",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_States_state_id",
                        column: x => x.state_id,
                        principalTable: "States",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_country_id",
                table: "Cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_state_id",
                table: "Cities",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_States_country_id",
                table: "States",
                column: "country_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
