using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class MarcaEModelos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Carros",
                newName: "ModeloNome");

            migrationBuilder.AlterColumn<int>(
                name: "CarroId",
                table: "Reservas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Carros",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Carros",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModeloId",
                table: "Carros",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FotoCarro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Conteudo = table.Column<byte[]>(type: "bytea", nullable: false),
                    Extensao = table.Column<string>(type: "text", nullable: false),
                    CarroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoCarro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoCarro_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeMarca = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeModelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MarcaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_MarcaId",
                table: "Carros",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ModeloId",
                table: "Carros",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_FotoCarro_CarroId",
                table: "FotoCarro",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_ModeloId",
                table: "Carros",
                column: "ModeloId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Marcas_MarcaId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_ModeloId",
                table: "Carros");

            migrationBuilder.DropTable(
                name: "FotoCarro");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropIndex(
                name: "IX_Carros_MarcaId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_ModeloId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ModeloId",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "ModeloNome",
                table: "Carros",
                newName: "Modelo");

            migrationBuilder.AlterColumn<long>(
                name: "CarroId",
                table: "Reservas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Carros",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Carros",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
