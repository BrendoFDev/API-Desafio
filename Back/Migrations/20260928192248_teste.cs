using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoCarros_Carros_CarroId1",
                table: "FotoCarros");

            migrationBuilder.DropIndex(
                name: "IX_FotoCarros_CarroId1",
                table: "FotoCarros");

            migrationBuilder.DropColumn(
                name: "CarroId1",
                table: "FotoCarros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarroId1",
                table: "FotoCarros",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FotoCarros_CarroId1",
                table: "FotoCarros",
                column: "CarroId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FotoCarros_Carros_CarroId1",
                table: "FotoCarros",
                column: "CarroId1",
                principalTable: "Carros",
                principalColumn: "Id");
        }
    }
}
