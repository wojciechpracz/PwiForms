using Microsoft.EntityFrameworkCore.Migrations;

namespace PwiForms2.Migrations
{
    public partial class SeededCountryEnglishNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Austria' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Belgium' WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Bulgaria' WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Croatia' WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Cyprus' WHERE Id = 5");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Czech Republic' WHERE Id = 6");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Denmark' WHERE Id = 7");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Estonia' WHERE Id = 8");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Finland' WHERE Id = 9");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'France' WHERE Id = 10");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Germany' WHERE Id = 11");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Greece' WHERE Id = 12");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Hungary' WHERE Id = 13");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Ireland' WHERE Id = 14");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Italy' WHERE Id = 15");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Latvia' WHERE Id = 16");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Lithuania' WHERE Id = 17");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Luxembourg' WHERE Id = 18");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Malta' WHERE Id = 19");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Netherlands' WHERE Id = 20");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Poland' WHERE Id = 21");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Portugal' WHERE Id = 22");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Romania' WHERE Id = 23");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Slovak Republic' WHERE Id = 24");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Slovenia' WHERE Id = 25");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Spain' WHERE Id = 26");
            migrationBuilder.Sql("UPDATE Countries SET NameEnglish = 'Sweden' WHERE Id = 27");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
