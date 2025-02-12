using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CivittaTask.DatabaseProvider.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDateId = table.Column<int>(type: "int", nullable: false),
                    ToDateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryDates_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolidayType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayType_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_FromDateId",
                table: "Countries",
                column: "FromDateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ToDateId",
                table: "Countries",
                column: "ToDateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryDates_CountryId",
                table: "CountryDates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayType_CountryId",
                table: "HolidayType",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CountryId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryDates_FromDateId",
                table: "Countries",
                column: "FromDateId",
                principalTable: "CountryDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryDates_ToDateId",
                table: "Countries",
                column: "ToDateId",
                principalTable: "CountryDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryDates_FromDateId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryDates_ToDateId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "HolidayType");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "CountryDates");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
