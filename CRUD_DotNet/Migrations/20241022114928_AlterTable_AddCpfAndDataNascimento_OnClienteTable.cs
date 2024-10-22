using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_AddCpfAndDataNascimento_OnClienteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Clientes");
        }
    }
}
