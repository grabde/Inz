using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inz.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokalizacja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerRegalu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokalizacja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Przyjecie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjazdu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataWypakowania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoWystawil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KtoObsluguje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przyjecie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypDokumentu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IloscObecna = table.Column<int>(type: "int", nullable: false),
                    IloscZarezerwowana = table.Column<int>(type: "int", nullable: false),
                    IloscDostepna = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    KodEan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokalizacjaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.Id);
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
                    NazwaKonrahenta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    KodEan = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dokument_TypDokumentu_TypDokumentuId",
                        column: x => x.TypDokumentuId,
                        principalTable: "TypDokumentu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProduktPrzyjecie",
                columns: table => new
                {
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    PrzyjecieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktPrzyjecie", x => new { x.ProduktId, x.PrzyjecieId });
                    table.ForeignKey(
                        name: "FK_ProduktPrzyjecie_Produkt_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktPrzyjecie_Przyjecie_PrzyjecieId",
                        column: x => x.PrzyjecieId,
                        principalTable: "Przyjecie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DokumentProdukt",
                columns: table => new
                {
                    DokumentId = table.Column<int>(type: "int", nullable: false),
                    ProduktId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Dokument_TypDokumentuId",
                table: "Dokument",
                column: "TypDokumentuId");

            migrationBuilder.CreateIndex(
                name: "IX_DokumentProdukt_ProduktId",
                table: "DokumentProdukt",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_LokalizacjaId",
                table: "Produkt",
                column: "LokalizacjaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktPrzyjecie_PrzyjecieId",
                table: "ProduktPrzyjecie",
                column: "PrzyjecieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DokumentProdukt");

            migrationBuilder.DropTable(
                name: "ProduktPrzyjecie");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Przyjecie");

            migrationBuilder.DropTable(
                name: "TypDokumentu");

            migrationBuilder.DropTable(
                name: "Lokalizacja");
        }
    }
}
