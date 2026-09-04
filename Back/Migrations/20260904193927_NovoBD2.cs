using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class NovoBD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ModeloNome",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros");

            migrationBuilder.AddColumn<string>(
                name: "ModeloNome",
                table: "Carros",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
