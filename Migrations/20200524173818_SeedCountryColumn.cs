using Microsoft.EntityFrameworkCore.Migrations;

namespace PwiForms2.Migrations
{
    public partial class SeedCountryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Austria')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Belgia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Bułgaria')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Chorwacja')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Cypr')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Czechy')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Dania')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Estonia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Finlandia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Francja')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Niemcy')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Grecja')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Węgry')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Irlandia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Włochy')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Łotwa')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Litwa')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Luxemburg')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Malta')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Holandia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Polska')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Portugalia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Rumunia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Słowacja')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Słowenia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Hiszpania')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Szwecja')");
            
            
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table Countries");
        }
    }
}
