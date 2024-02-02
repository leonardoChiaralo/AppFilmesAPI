using AppFilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFilmesAPI.Data.Config;

public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
{
    public void Configure(EntityTypeBuilder<Filme> builder)
    {
        builder
            .ToTable("Filmes");

        builder
            .Property(prop => prop.Id)
            .HasColumnName("Id")
            .HasColumnType("int");

        builder
            .Property(prop => prop.Titulo)
            .HasColumnName("Titulo")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder
            .Property(prop => prop.Ano)
            .HasColumnName("Ano")
            .HasColumnType("varchar(4)")
            .IsRequired();

        builder
            .Property(prop => prop.Genero)
            .HasColumnName("Genero")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(prop => prop.Diretor)
            .HasColumnName("Diretor")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(prop => prop.Duracao)
            .HasColumnName("Duracao(min.)")
            .HasColumnType("int")
            .IsRequired();

        builder
            .Property(prop => prop.Nota)
            .HasColumnName("Nota")
            .HasColumnType("float");
    }
}
