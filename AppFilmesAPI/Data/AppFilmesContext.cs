using AppFilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppFilmesAPI.Data;

public class AppFilmesContext : DbContext
{
    public AppFilmesContext(DbContextOptions<AppFilmesContext> opts) : base(opts)
    {
    }

    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Artista> Artistas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artista>().Property(a => a.Idade).HasComputedColumnSql("DATEDIFF(YEAR, DataNascimento, GETDATE())").IsRequired();
    }
}
