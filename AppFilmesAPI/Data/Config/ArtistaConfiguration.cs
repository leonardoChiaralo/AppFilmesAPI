using AppFilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFilmesAPI.Data.Config;

public class ArtistaConfiguration : IEntityTypeConfiguration<Artista>
{
    public void Configure(EntityTypeBuilder<Artista> builder)
    {
        builder
            .ToTable("Artistas");

        builder
            .Property(prop => prop.Id)
            .HasColumnName("Id")
            .HasColumnType("int");

        builder
            .Property(prop => prop.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(prop => prop.DataNascimento)
            .HasColumnName("DataNascimento")
            .HasColumnType("datetime")
            .IsRequired();

        builder
            .Property(a => a.Idade)
            .HasComputedColumnSql("DATEDIFF(YEAR, DataNascimento, GETDATE())")
            .IsRequired();
    }
}
