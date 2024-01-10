using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionMasVida.Migrations
{
    /// <inheritdoc />
    public partial class masvida2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosMv_GrupoPequeno_GpId",
                table: "EventosMv");

            migrationBuilder.AlterColumn<int>(
                name: "GpId",
                table: "EventosMv",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosMv_GrupoPequeno_GpId",
                table: "EventosMv",
                column: "GpId",
                principalTable: "GrupoPequeno",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosMv_GrupoPequeno_GpId",
                table: "EventosMv");

            migrationBuilder.AlterColumn<int>(
                name: "GpId",
                table: "EventosMv",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventosMv_GrupoPequeno_GpId",
                table: "EventosMv",
                column: "GpId",
                principalTable: "GrupoPequeno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
