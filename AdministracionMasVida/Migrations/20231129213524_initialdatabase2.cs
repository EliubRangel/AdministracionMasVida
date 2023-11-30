using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionMasVida.Migrations
{
    /// <inheritdoc />
    public partial class initialdatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPequeno_Mentor_MentorId",
                table: "GrupoPequeno");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId1",
                table: "GrupoPequeno");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropIndex(
                name: "IX_GrupoPequeno_MentorId1",
                table: "GrupoPequeno");

            migrationBuilder.DropColumn(
                name: "MentorId1",
                table: "GrupoPequeno");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId",
                table: "GrupoPequeno",
                column: "MentorId",
                principalTable: "Servidor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId",
                table: "GrupoPequeno");

            migrationBuilder.AddColumn<int>(
                name: "MentorId1",
                table: "GrupoPequeno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPequeno_MentorId1",
                table: "GrupoPequeno",
                column: "MentorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPequeno_Mentor_MentorId",
                table: "GrupoPequeno",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPequeno_Servidor_MentorId1",
                table: "GrupoPequeno",
                column: "MentorId1",
                principalTable: "Servidor",
                principalColumn: "Id");
        }
    }
}
