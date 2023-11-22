using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionMasVida.Migrations
{
    /// <inheritdoc />
    public partial class ChangeHoraInicioName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoraInico",
                table: "GrupoPequeno",
                newName: "HoraInicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoraInicio",
                table: "GrupoPequeno",
                newName: "HoraInico");
        }
    }
}
