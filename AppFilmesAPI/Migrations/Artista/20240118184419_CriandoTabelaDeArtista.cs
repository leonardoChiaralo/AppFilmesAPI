using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFilmesAPI.Migrations.Artista;

/// <inheritdoc />
public partial class CriandoTabelaDeArtista : Migration
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
                Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                Idade = table.Column<int>(type: "int", nullable: false, computedColumnSql: "DATEDIFF(YEAR, DataNascimento, GETDATE())")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Artistas", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Artistas");
    }
}
