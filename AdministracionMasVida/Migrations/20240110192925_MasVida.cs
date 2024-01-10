using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionMasVida.Migrations
{
    /// <inheritdoc />
    public partial class MasVida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventosMvLugaresMv");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "EventosMv");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "EventosMv");

            migrationBuilder.DropColumn(
                name: "Lugar",
                table: "EventosMv");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "EventosMv",
                newName: "Fecha");

            migrationBuilder.AddColumn<int>(
                name: "GpId",
                table: "EventosMv",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LugarId",
                table: "EventosMv",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventosMv_GpId",
                table: "EventosMv",
                column: "GpId");

            migrationBuilder.CreateIndex(
                name: "IX_EventosMv_LugarId",
                table: "EventosMv",
                column: "LugarId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosMv_GrupoPequeno_GpId",
                table: "EventosMv",
                column: "GpId",
                principalTable: "GrupoPequeno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventosMv_LugaresMv_LugarId",
                table: "EventosMv",
                column: "LugarId",
                principalTable: "LugaresMv",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosMv_GrupoPequeno_GpId",
                table: "EventosMv");

            migrationBuilder.DropForeignKey(
                name: "FK_EventosMv_LugaresMv_LugarId",
                table: "EventosMv");

            migrationBuilder.DropIndex(
                name: "IX_EventosMv_GpId",
                table: "EventosMv");

            migrationBuilder.DropIndex(
                name: "IX_EventosMv_LugarId",
                table: "EventosMv");

            migrationBuilder.DropColumn(
                name: "GpId",
                table: "EventosMv");

            migrationBuilder.DropColumn(
                name: "LugarId",
                table: "EventosMv");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "EventosMv",
                newName: "fecha");

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "EventosMv",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Hora",
                table: "EventosMv",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Lugar",
                table: "EventosMv",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventosMvLugaresMv",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    LugaresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosMvLugaresMv", x => new { x.EventoId, x.LugaresId });
                    table.ForeignKey(
                        name: "FK_EventosMvLugaresMv_EventosMv_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventosMv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventosMvLugaresMv_LugaresMv_LugaresId",
                        column: x => x.LugaresId,
                        principalTable: "LugaresMv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EventosMvLugaresMv_LugaresId",
                table: "EventosMvLugaresMv",
                column: "LugaresId");
        }
    }
}
