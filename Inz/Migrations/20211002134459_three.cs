using Microsoft.EntityFrameworkCore.Migrations;

namespace Inz.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Przyjecie");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Dokument");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Przyjecie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Dokument",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
