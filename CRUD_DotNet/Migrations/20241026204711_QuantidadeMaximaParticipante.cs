using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace CRUD_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class QuantidadeMaximaParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuantidadeMaxParticipantantes",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeMaxParticipantantes",
                table: "Eventos");
        }
    }
}
