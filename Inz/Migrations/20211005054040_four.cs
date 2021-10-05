using Microsoft.EntityFrameworkCore.Migrations;

namespace Inz.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DokumentProdukt_Dokument_DokumentyId",
                table: "DokumentProdukt");

            migrationBuilder.DropForeignKey(
                name: "FK_DokumentProdukt_Produkt_ProduktyId",
                table: "DokumentProdukt");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktPrzyjecie_Produkt_ProduktyId",
                table: "ProduktPrzyjecie");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktPrzyjecie_Przyjecie_PrzyjeciaId",
                table: "ProduktPrzyjecie");

            migrationBuilder.RenameColumn(
                name: "PrzyjeciaId",
                table: "ProduktPrzyjecie",
                newName: "PrzyjecieId");

            migrationBuilder.RenameColumn(
                name: "ProduktyId",
                table: "ProduktPrzyjecie",
                newName: "ProduktId");

            migrationBuilder.RenameIndex(
                name: "IX_ProduktPrzyjecie_PrzyjeciaId",
                table: "ProduktPrzyjecie",
                newName: "IX_ProduktPrzyjecie_PrzyjecieId");

            migrationBuilder.RenameColumn(
                name: "ProduktyId",
                table: "DokumentProdukt",
                newName: "ProduktId");

            migrationBuilder.RenameColumn(
                name: "DokumentyId",
                table: "DokumentProdukt",
                newName: "DokumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DokumentProdukt_ProduktyId",
                table: "DokumentProdukt",
                newName: "IX_DokumentProdukt_ProduktId");

            migrationBuilder.AddForeignKey(
                name: "FK_DokumentProdukt_Dokument_DokumentId",
                table: "DokumentProdukt",
                column: "DokumentId",
                principalTable: "Dokument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DokumentProdukt_Produkt_ProduktId",
                table: "DokumentProdukt",
                column: "ProduktId",
                principalTable: "Produkt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktPrzyjecie_Produkt_ProduktId",
                table: "ProduktPrzyjecie",
                column: "ProduktId",
                principalTable: "Produkt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktPrzyjecie_Przyjecie_PrzyjecieId",
                table: "ProduktPrzyjecie",
                column: "PrzyjecieId",
                principalTable: "Przyjecie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DokumentProdukt_Dokument_DokumentId",
                table: "DokumentProdukt");

            migrationBuilder.DropForeignKey(
                name: "FK_DokumentProdukt_Produkt_ProduktId",
                table: "DokumentProdukt");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktPrzyjecie_Produkt_ProduktId",
                table: "ProduktPrzyjecie");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktPrzyjecie_Przyjecie_PrzyjecieId",
                table: "ProduktPrzyjecie");

            migrationBuilder.RenameColumn(
                name: "PrzyjecieId",
                table: "ProduktPrzyjecie",
                newName: "PrzyjeciaId");

            migrationBuilder.RenameColumn(
                name: "ProduktId",
                table: "ProduktPrzyjecie",
                newName: "ProduktyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProduktPrzyjecie_PrzyjecieId",
                table: "ProduktPrzyjecie",
                newName: "IX_ProduktPrzyjecie_PrzyjeciaId");

            migrationBuilder.RenameColumn(
                name: "ProduktId",
                table: "DokumentProdukt",
                newName: "ProduktyId");

            migrationBuilder.RenameColumn(
                name: "DokumentId",
                table: "DokumentProdukt",
                newName: "DokumentyId");

            migrationBuilder.RenameIndex(
                name: "IX_DokumentProdukt_ProduktId",
                table: "DokumentProdukt",
                newName: "IX_DokumentProdukt_ProduktyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DokumentProdukt_Dokument_DokumentyId",
                table: "DokumentProdukt",
                column: "DokumentyId",
                principalTable: "Dokument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DokumentProdukt_Produkt_ProduktyId",
                table: "DokumentProdukt",
                column: "ProduktyId",
                principalTable: "Produkt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktPrzyjecie_Produkt_ProduktyId",
                table: "ProduktPrzyjecie",
                column: "ProduktyId",
                principalTable: "Produkt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktPrzyjecie_Przyjecie_PrzyjeciaId",
                table: "ProduktPrzyjecie",
                column: "PrzyjeciaId",
                principalTable: "Przyjecie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
