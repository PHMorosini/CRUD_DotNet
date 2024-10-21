using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_Cidade_OnClienteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Clientes");
        }
    }
}
