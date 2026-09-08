using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class FotoCarro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoCarro_Carros_CarroId",
                table: "FotoCarro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FotoCarro",
                table: "FotoCarro");

            migrationBuilder.DropColumn(
                name: "Extensao",
                table: "FotoCarro");

            migrationBuilder.RenameTable(
                name: "FotoCarro",
                newName: "FotoCarros");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "FotoCarros",
                newName: "FotoBytes");

            migrationBuilder.RenameIndex(
                name: "IX_FotoCarro_CarroId",
                table: "FotoCarros",
                newName: "IX_FotoCarros_CarroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotoCarros",
                table: "FotoCarros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FotoCarros_Carros_CarroId",
                table: "FotoCarros",
                column: "CarroId",
                principalTable: "Carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoCarros_Carros_CarroId",
                table: "FotoCarros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FotoCarros",
                table: "FotoCarros");

            migrationBuilder.RenameTable(
                name: "FotoCarros",
                newName: "FotoCarro");

            migrationBuilder.RenameColumn(
                name: "FotoBytes",
                table: "FotoCarro",
                newName: "Conteudo");

            migrationBuilder.RenameIndex(
                name: "IX_FotoCarros_CarroId",
                table: "FotoCarro",
                newName: "IX_FotoCarro_CarroId");

            migrationBuilder.AddColumn<string>(
                name: "Extensao",
                table: "FotoCarro",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotoCarro",
                table: "FotoCarro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FotoCarro_Carros_CarroId",
                table: "FotoCarro",
                column: "CarroId",
                principalTable: "Carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
