using System.ComponentModel.DataAnnotations;

namespace AppFilmesAPI.Data.DTOs;

public class ReadFilmeDTO
{
    public string Titulo { get; set; }

    public string Ano { get; set; }

    public string Genero { get; set; }

    public string Diretor { get; set; }

    public int Duracao { get; set; }

    public double Nota { get; set; }
}
