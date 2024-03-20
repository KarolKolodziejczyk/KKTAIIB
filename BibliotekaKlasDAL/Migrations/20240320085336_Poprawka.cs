using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaKlasDAL.Migrations
{
    /// <inheritdoc />
    public partial class Poprawka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "PozycjeZamowieni",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZamowieni_ProductID",
                table: "PozycjeZamowieni",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_PozycjeZamowieni_Produkty_ProductID",
                table: "PozycjeZamowieni",
                column: "ProductID",
                principalTable: "Produkty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PozycjeZamowieni_Produkty_ProductID",
                table: "PozycjeZamowieni");

            migrationBuilder.DropIndex(
                name: "IX_PozycjeZamowieni_ProductID",
                table: "PozycjeZamowieni");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "PozycjeZamowieni");
        }
    }
}
