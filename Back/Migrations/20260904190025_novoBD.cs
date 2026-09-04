using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class novoBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
