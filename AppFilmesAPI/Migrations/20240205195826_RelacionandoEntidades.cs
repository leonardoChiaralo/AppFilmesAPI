using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelacionandoEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistaFilme",
                columns: table => new
                {
                    ElencoId = table.Column<int>(type: "int", nullable: false),
                    FilmografiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistaFilme", x => new { x.ElencoId, x.FilmografiaId });
                    table.ForeignKey(
                        name: "FK_ArtistaFilme_Artistas_ElencoId",
                        column: x => x.ElencoId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistaFilme_Filmes_FilmografiaId",
                        column: x => x.FilmografiaId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistaFilme_FilmografiaId",
                table: "ArtistaFilme",
                column: "FilmografiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistaFilme");
        }
    }
}
