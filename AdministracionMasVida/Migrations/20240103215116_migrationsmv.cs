using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionMasVida.Migrations
{
    /// <inheritdoc />
    public partial class migrationsmv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoPequenoMiembro");

            migrationBuilder.AddColumn<int>(
                name: "grupoPequenosId",
                table: "Miembro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventosMv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Hora = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lugar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Grupo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosMv", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LugaresMv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugaresMv", x => x.Id);
                })
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
                name: "IX_Miembro_grupoPequenosId",
                table: "Miembro",
                column: "grupoPequenosId");

            migrationBuilder.CreateIndex(
                name: "IX_EventosMvLugaresMv_LugaresId",
                table: "EventosMvLugaresMv",
                column: "LugaresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_GrupoPequeno_grupoPequenosId",
                table: "Miembro",
                column: "grupoPequenosId",
                principalTable: "GrupoPequeno",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_GrupoPequeno_grupoPequenosId",
                table: "Miembro");

            migrationBuilder.DropTable(
                name: "EventosMvLugaresMv");

            migrationBuilder.DropTable(
                name: "EventosMv");

            migrationBuilder.DropTable(
                name: "LugaresMv");

            migrationBuilder.DropIndex(
                name: "IX_Miembro_grupoPequenosId",
                table: "Miembro");

            migrationBuilder.DropColumn(
                name: "grupoPequenosId",
                table: "Miembro");

            migrationBuilder.CreateTable(
                name: "GrupoPequenoMiembro",
                columns: table => new
                {
                    MiembroId = table.Column<int>(type: "int", nullable: false),
                    grupoPequenosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoPequenoMiembro", x => new { x.MiembroId, x.grupoPequenosId });
                    table.ForeignKey(
                        name: "FK_GrupoPequenoMiembro_GrupoPequeno_grupoPequenosId",
                        column: x => x.grupoPequenosId,
                        principalTable: "GrupoPequeno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoPequenoMiembro_Miembro_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPequenoMiembro_grupoPequenosId",
                table: "GrupoPequenoMiembro",
                column: "grupoPequenosId");
        }
    }
}
