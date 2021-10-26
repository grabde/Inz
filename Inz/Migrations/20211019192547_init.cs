using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inz.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kontrahent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrahent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokalizacja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumerRegalu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokalizacja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypDokumentu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypDokumentu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IloscObecna = table.Column<int>(type: "int", nullable: false),
                    IloscZarezerwowana = table.Column<int>(type: "int", nullable: false),
                    IloscDostepna = table.Column<int>(type: "int", nullable: false),
                    KodEan = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: true),
                    KategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkt_Kategoria_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produkt_Lokalizacja_LokalizacjaId",
                        column: x => x.LokalizacjaId,
                        principalTable: "Lokalizacja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypDokumentuId = table.Column<int>(type: "int", nullable: true),
                    KontrahentId = table.Column<int>(type: "int", nullable: true),
                    DataWystawienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZatwierdzeniaPrzyjecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoWystawilId = table.Column<int>(type: "int", nullable: true),
                    KtoZatwierdzilPrzyjalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dokument_Kontrahent_KontrahentId",
                        column: x => x.KontrahentId,
                        principalTable: "Kontrahent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dokument_Pracownik_KtoWystawilId",
                        column: x => x.KtoWystawilId,
                        principalTable: "Pracownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dokument_Pracownik_KtoZatwierdzilPrzyjalId",
                        column: x => x.KtoZatwierdzilPrzyjalId,
                        principalTable: "Pracownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dokument_TypDokumentu_TypDokumentuId",
                        column: x => x.TypDokumentuId,
                        principalTable: "TypDokumentu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DokumentProdukt",
                columns: table => new
                {
                    DokumentId = table.Column<int>(type: "int", nullable: false),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentProdukt", x => new { x.DokumentId, x.ProduktId });
                    table.ForeignKey(
                        name: "FK_DokumentProdukt_Dokument_DokumentId",
                        column: x => x.DokumentId,
                        principalTable: "Dokument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DokumentProdukt_Produkt_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_KontrahentId",
                table: "Dokument",
                column: "KontrahentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_KtoWystawilId",
                table: "Dokument",
                column: "KtoWystawilId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_KtoZatwierdzilPrzyjalId",
                table: "Dokument",
                column: "KtoZatwierdzilPrzyjalId");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_TypDokumentuId",
                table: "Dokument",
                column: "TypDokumentuId");

            migrationBuilder.CreateIndex(
                name: "IX_DokumentProdukt_ProduktId",
                table: "DokumentProdukt",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_KategoriaId",
                table: "Produkt",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_LokalizacjaId",
                table: "Produkt",
                column: "LokalizacjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DokumentProdukt");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Kontrahent");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "TypDokumentu");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Lokalizacja");
        }
    }
}
