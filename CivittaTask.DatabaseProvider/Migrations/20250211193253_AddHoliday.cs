using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CivittaTask.DatabaseProvider.Migrations
{
    public partial class AddHoliday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryDates_FromDateId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryDates_ToDateId",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryDates",
                table: "CountryDates");

            migrationBuilder.RenameTable(
                name: "CountryDates",
                newName: "CountryDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryDate",
                table: "CountryDate",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HolidayDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false),
                    HolidayType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_HolidayDate_DateId",
                        column: x => x.DateId,
                        principalTable: "HolidayDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolidayName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayName_Holidays_HolidayId",
                        column: x => x.HolidayId,
                        principalTable: "Holidays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayName_HolidayId",
                table: "HolidayName",
                column: "HolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_DateId",
                table: "Holidays",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryDate_FromDateId",
                table: "Countries",
                column: "FromDateId",
                principalTable: "CountryDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryDate_ToDateId",
                table: "Countries",
                column: "ToDateId",
                principalTable: "CountryDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryDate_FromDateId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryDate_ToDateId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "HolidayName");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "HolidayDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryDate",
                table: "CountryDate");

            migrationBuilder.RenameTable(
                name: "CountryDate",
                newName: "CountryDates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryDates",
                table: "CountryDates",
                column: "Id");

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
    }
}
