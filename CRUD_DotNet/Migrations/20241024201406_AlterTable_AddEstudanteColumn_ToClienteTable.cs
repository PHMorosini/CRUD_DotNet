using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_AddEstudanteColumn_ToClienteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estudante",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
            migrationBuilder.Sql("UPDATE Clientes SET Estudante = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estudante",
                table: "Clientes");
        }
    }
}
