using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inz.Migrations
{
    public partial class Init : Migration
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
                    ProduktId = table.Column<int>(type: "int", nullable: false),
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
                    LokalizacjaId = table.Column<int>(type: "int", nullable: false),
                    KodEan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkt_Lokalizacja_LokalizacjaId",
                        column: x => x.LokalizacjaId,
                        principalTable: "Lokalizacja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    TypDokumentuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazwaKonrahenta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    KodEan = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    TypDokumentuId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dokument_TypDokumentu_TypDokumentuId1",
                        column: x => x.TypDokumentuId1,
                        principalTable: "TypDokumentu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProduktPrzyjecie",
                columns: table => new
                {
                    ProduktyId = table.Column<int>(type: "int", nullable: false),
                    PrzyjeciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktPrzyjecie", x => new { x.ProduktyId, x.PrzyjeciaId });
                    table.ForeignKey(
                        name: "FK_ProduktPrzyjecie_Produkt_ProduktyId",
                        column: x => x.ProduktyId,
                        principalTable: "Produkt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktPrzyjecie_Przyjecie_PrzyjeciaId",
                        column: x => x.PrzyjeciaId,
                        principalTable: "Przyjecie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DokumentProdukt",
                columns: table => new
                {
                    DokumentyId = table.Column<int>(type: "int", nullable: false),
                    ProduktyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentProdukt", x => new { x.DokumentyId, x.ProduktyId });
                    table.ForeignKey(
                        name: "FK_DokumentProdukt_Dokument_DokumentyId",
                        column: x => x.DokumentyId,
                        principalTable: "Dokument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DokumentProdukt_Produkt_ProduktyId",
                        column: x => x.ProduktyId,
                        principalTable: "Produkt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_TypDokumentuId1",
                table: "Dokument",
                column: "TypDokumentuId1");

            migrationBuilder.CreateIndex(
                name: "IX_DokumentProdukt_ProduktyId",
                table: "DokumentProdukt",
                column: "ProduktyId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_LokalizacjaId",
                table: "Produkt",
                column: "LokalizacjaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktPrzyjecie_PrzyjeciaId",
                table: "ProduktPrzyjecie",
                column: "PrzyjeciaId");
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
