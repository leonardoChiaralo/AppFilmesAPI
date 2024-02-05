using System.ComponentModel.DataAnnotations;

namespace AppFilmesAPI.Models;

public class Artista
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }
}
