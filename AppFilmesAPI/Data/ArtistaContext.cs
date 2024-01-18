using AppFilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppFilmesAPI.Data;

public class ArtistaContext : DbContext
{
    public ArtistaContext(DbContextOptions<ArtistaContext> opts) : base(opts)
    {
    }

    public DbSet<Artista> Artistas { get; set; }
}
