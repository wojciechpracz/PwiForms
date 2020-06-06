using Microsoft.EntityFrameworkCore.Migrations;

namespace PwiForms2.Migrations
{
    public partial class AddedEnglishNameToCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameEnglish",
                table: "Countries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEnglish",
                table: "Countries");
        }
    }
}
