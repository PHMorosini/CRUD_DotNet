using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AddEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EstadoId",
                table: "Eventos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_EventoId",
                table: "Estados",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Estados_EstadoId",
                table: "Eventos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Sigla", "Nome", "Ativo" },
                values: new object[,]
                {
                    { "RO", "RONDONIA", true },
                    { "AC", "ACRE", true },
                    { "AM", "AMAZONAS", true },
                    { "RR", "RORAIMA", true },
                    { "PA", "PARA", true },
                    { "AP", "AMAPA", true },
                    { "TO", "TOCANTINS", true },
                    { "MA", "MARANHAO", true },
                    { "PI", "PIAUI", true },
                    { "CE", "CEARA", true },
                    { "RN", "RIO GRANDE DO NORTE", true },
                    { "PB", "PARAIBA", true },
                    { "PE", "PERNAMBUCO", true },
                    { "AL", "ALAGOAS", true },
                    { "SE", "SERGIPE", true },
                    { "BA", "BAHIA", true },
                    { "MG", "MINAS GERAIS", true },
                    { "ES", "ESPIRITO SANTO", true },
                    { "RJ", "RIO DE JANEIRO", true },
                    { "SP", "SAO PAULO", true },
                    { "PR", "PARANA", true },
                    { "SC", "SANTA CATARINA", true },
                    { "RS", "RIO GRANDE DO SUL", true },
                    { "MS", "MATO GROSSO DO SUL", true },
                    { "MT", "MATO GROSSO", true },
                    { "GO", "GOIAS", true },
                    { "DF", "DISTRITO FEDERAL", true },
                    { "EX", "EXTERIOR", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Estados_EstadoId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_EstadoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Eventos");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("DELETE FROM estados WHERE sigla IN ('RO', 'AC', 'AM', 'RR', 'PA', 'AP', 'TO', 'MA', 'PI', 'CE', 'RN', 'PB', 'PE', 'AL', 'SE', 'BA', 'MG', 'ES', 'RJ', 'SP', 'PR', 'SC', 'RS', 'MS', 'MT', 'GO', 'DF', 'EX')");
        }
    }
}
