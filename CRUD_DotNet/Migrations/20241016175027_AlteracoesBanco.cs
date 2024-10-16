using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AlteracoesBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Eventos_EventoId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Estados_EstadoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_EstadoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Estados_EventoId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Estados");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Eventos",
                newName: "EventoId");

            migrationBuilder.AddColumn<string>(
                name: "EstadoSigla",
                table: "Eventos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EstadoSigla",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "Eventos",
                newName: "EstadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EstadoId",
                table: "Eventos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_EventoId",
                table: "Estados",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Eventos_EventoId",
                table: "Estados",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Estados_EstadoId",
                table: "Eventos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
