namespace AppFilmesAPI.Data.DTOs.Filme;

public class ReadFilmeDTO
{
    public string? Titulo { get; set; }

    public string? Ano { get; set; }

    public string? Genero { get; set; }

    public string? Diretor { get; set; }

    public int Duracao { get; set; }

    public double Nota { get; set; }
}
