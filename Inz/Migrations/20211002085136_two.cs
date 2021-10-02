using Microsoft.EntityFrameworkCore.Migrations;

namespace Inz.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dokument_TypDokumentu_TypDokumentuId1",
                table: "Dokument");

            migrationBuilder.DropIndex(
                name: "IX_Dokument_TypDokumentuId1",
                table: "Dokument");

            migrationBuilder.DropColumn(
                name: "TypDokumentuId1",
                table: "Dokument");

            migrationBuilder.AlterColumn<int>(
                name: "TypDokumentuId",
                table: "Dokument",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_TypDokumentuId",
                table: "Dokument",
                column: "TypDokumentuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dokument_TypDokumentu_TypDokumentuId",
                table: "Dokument",
                column: "TypDokumentuId",
                principalTable: "TypDokumentu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dokument_TypDokumentu_TypDokumentuId",
                table: "Dokument");

            migrationBuilder.DropIndex(
                name: "IX_Dokument_TypDokumentuId",
                table: "Dokument");

            migrationBuilder.AlterColumn<string>(
                name: "TypDokumentuId",
                table: "Dokument",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypDokumentuId1",
                table: "Dokument",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_TypDokumentuId1",
                table: "Dokument",
                column: "TypDokumentuId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dokument_TypDokumentu_TypDokumentuId1",
                table: "Dokument",
                column: "TypDokumentuId1",
                principalTable: "TypDokumentu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
