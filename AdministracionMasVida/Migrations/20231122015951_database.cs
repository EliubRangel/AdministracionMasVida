using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionMasVida.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId1",
                table: "GrupoPequeno");

            migrationBuilder.AlterColumn<int>(
                name: "MentorId1",
                table: "GrupoPequeno",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId1",
                table: "GrupoPequeno",
                column: "MentorId1",
                principalTable: "Servidor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId1",
                table: "GrupoPequeno");

            migrationBuilder.AlterColumn<int>(
                name: "MentorId1",
                table: "GrupoPequeno",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId1",
                table: "GrupoPequeno",
                column: "MentorId1",
                principalTable: "Servidor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
