using System.ComponentModel.DataAnnotations;

namespace AppFilmesAPI.Data.DTOs;

public class ReadArtistaDTO
{
    public string? Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public int Idade { get; set; }
}
