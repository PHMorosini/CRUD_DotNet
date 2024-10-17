using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabelaEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Estados_EstadoSigla",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_EstadoSigla",
                table: "Eventos");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Estados_Sigla",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Eventos");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoSigla",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EstadoId",
                table: "Eventos",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Estados_EstadoId",
                table: "Eventos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Estados_EstadoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_EstadoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Eventos");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoSigla",
                table: "Eventos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Estados",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Estados_Sigla",
                table: "Estados",
                column: "Sigla");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EstadoSigla",
                table: "Eventos",
                column: "EstadoSigla");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Estados_EstadoSigla",
                table: "Eventos",
                column: "EstadoSigla",
                principalTable: "Estados",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
