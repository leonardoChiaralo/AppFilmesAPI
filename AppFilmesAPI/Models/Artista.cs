namespace AppFilmesAPI.Models;

public class Artista
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }
    public ICollection<Filme>? Filmografia { get; set; }
}
