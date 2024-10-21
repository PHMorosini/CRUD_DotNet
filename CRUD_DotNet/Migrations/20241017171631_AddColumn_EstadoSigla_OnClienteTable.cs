using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_EstadoSigla_OnClienteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoSigla",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EstadoSigla",
                table: "Clientes");
        }
    }
}
