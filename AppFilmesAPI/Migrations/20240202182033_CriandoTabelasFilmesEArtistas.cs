using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasFilmesEArtistas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false, computedColumnSql: "DATEDIFF(YEAR, DataNascimento, GETDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ano = table.Column<string>(type: "varchar(4)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Diretor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Duracaomin = table.Column<int>(name: "Duracao(min.)", type: "int", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
