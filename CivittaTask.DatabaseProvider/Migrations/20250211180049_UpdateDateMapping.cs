using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CivittaTask.DatabaseProvider.Migrations
{
    public partial class UpdateDateMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryDates_Countries_CountryId",
                table: "CountryDates");

            migrationBuilder.DropIndex(
                name: "IX_CountryDates_CountryId",
                table: "CountryDates");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CountryDates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CountryDates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CountryDates_CountryId",
                table: "CountryDates",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryDates_Countries_CountryId",
                table: "CountryDates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
